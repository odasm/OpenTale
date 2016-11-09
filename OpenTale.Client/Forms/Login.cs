using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using OpenTale.Handler;
using OpenTale.Net;
using OpenTale.GameObject.Net;

namespace OpenTale.Client.Forms
{
    public partial class Login : Form
    {
        public bool loggedIn = false;
        public Login()
        {
            InitializeComponent();
        }
        
        private void loginButton_Click(object sender, EventArgs e)
        {
            LoginFormPacketHandler handler = new LoginFormPacketHandler();
            LoginClient lc = new LoginClient(ipBox.Text, Convert.ToInt32(portNUpDown.Value), handler);

            lc.Connect();
            lc.Login(userBox.Text, passBox.Text);

            while(handler.Servers == null)
            {
                if (!string.IsNullOrWhiteSpace(handler.FailMessage))
                {
                    MessageBox.Show(handler.FailMessage, "Login Failed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            loggedIn = true;
            //Do Stuff here
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!loggedIn)
            {
                Application.Exit();
            }
        }
    }
    public class LoginFormPacketHandler : LoginPacketHandler
    {
        public int SessionID = 0;
        public string FailMessage;
        public List<Server> Servers;
        public override List<Server> HandleNsTeST(string packet)
        {
            Servers = base.HandleNsTeST(packet);

            return Servers;
        }
    }
}
