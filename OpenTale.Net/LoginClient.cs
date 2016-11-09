using System;
using System.Net;
using System.Net.Sockets;
using OpenTale.Crypto;
using OpenTale.Handler;
using System.Text;

namespace OpenTale.Net
{
    /// <summary>
    /// Description of SocketClient.	
    /// </summary>
    public class LoginClient
    {
        byte[] m_dataBuffer = new byte[10];
        IAsyncResult m_result;
        IPAddress _loginIP;
        int _loginPort = 0;
        LoginPacketHandler _handler;
        public AsyncCallback m_pfnCallBack;
        public Socket m_clientSocket;

        public LoginClient(string loginIP, int loginPort, LoginPacketHandler handler)
        {
            if ((String.IsNullOrWhiteSpace(loginIP)))
            {
                throw new ArgumentNullException("loginIP", "Parameter not set");
            }
            _loginIP = IPAddress.Parse(loginIP);
            if (loginPort == 0)
            {
                throw new ArgumentNullException("loginPort", "Parameter not set");
            }
            _loginPort = loginPort;
            if (handler == null)
            {
                throw new ArgumentNullException("handler", "Parameter not set");
            }
            _handler = handler;
        }


        public void Connect()
        {
            // Create the socket instance
            m_clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // Create the end point 
            IPEndPoint ipEnd = new IPEndPoint(_loginIP, _loginPort);

            // Connect to the remote host
            m_clientSocket.Connect(ipEnd);
            if (m_clientSocket.Connected)
            {
                //Wait for data asynchronously 
                WaitForData();
            }
        }

        public void Login(string userName, string password)
        {
            Random r = new Random();

            string msg = "NoS0575 {0} {1} {2} {3} 0 {4}";

            msg = String.Format(
                msg,
                r.Next(1000000, 50000000),
                userName,
                LoginCrypto.CreatePasswordHash(password),
                LoginCrypto.CreateLoginVersion("VERSIONSTRING HERE"),
                LoginCrypto.CreateLoginHash("DXHASH HERE", "GLHASH HERE", userName));

            byte[] byData = LoginCrypto.Encrypt(msg);
            if (m_clientSocket != null)
            {
                m_clientSocket.Send(byData);
            }
        }
        public void WaitForData()
        {

            if (m_pfnCallBack == null)
            {
                m_pfnCallBack = new AsyncCallback(OnDataReceived);
            }
            SocketPacket theSocPkt = new SocketPacket();
            theSocPkt.thisSocket = m_clientSocket;

            // Start listening to the data asynchronously
            m_result = m_clientSocket.BeginReceive(theSocPkt.dataBuffer,
                                                    0, theSocPkt.dataBuffer.Length,
                                                    SocketFlags.None,
                                                    m_pfnCallBack,
                                                    theSocPkt);

        }
        public class SocketPacket
        {
            public System.Net.Sockets.Socket thisSocket;
            public byte[] dataBuffer = new byte[1024];
        }

        public void OnDataReceived(IAsyncResult asyn)
        {
            SocketPacket theSockId = (SocketPacket)asyn.AsyncState;
            int iRx = theSockId.thisSocket.EndReceive(asyn);

            string szData = LoginCrypto.LoginDecrypt(theSockId.dataBuffer, iRx);

            _handler.HandlePacket(szData);

            Disconnect();
        }

        public void Disconnect()
        {
            if (m_clientSocket != null)
            {
                m_clientSocket.Close();
                m_clientSocket = null;
            }
        }
    }
}
