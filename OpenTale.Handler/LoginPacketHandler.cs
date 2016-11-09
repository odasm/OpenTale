using OpenTale.GameObject.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTale.Handler
{
    public class LoginPacketHandler
    {
        public void HandlePacket(string packet)
        {
            if (packet.StartsWith("NsTeST"))
            {
                HandleNsTeST(packet);
            }
            else if (packet.StartsWith("fail"))
            {
                throw new Exception(packet.Replace("fail ", ""));
            }

        }

        //NsTeST [SESSION] [IP]:[PORT]:[LOAD]:[SERVER].[CHANNEL].[NAME]
        public virtual List<Server> HandleNsTeST(string packet)
        {
            List<Server> servers = new List<Server>();
            int i = 0;
            int sessionID = 0;
            foreach (string s in packet.Split(' '))
            {
                if (i == 0)
                {
                    i++;
                }
                else if (i == 1)
                {
                    sessionID = int.Parse(s);
                    i++;
                }
                else if (string.IsNullOrEmpty(s))
                {
                    break;
                }
                else
                {
                    bool exists = false;
                    string ip = s.Split(':')[0];
                    int port = int.Parse(s.Split(':')[1]);
                    int load = int.Parse(s.Split(':')[2]);
                    int sid = int.Parse(s.Split(':')[3].Split('.')[0]);
                    int cid = int.Parse(s.Split(':')[3].Split('.')[1]);
                    string name = s.Split(':')[3].Split('.')[2];

                    foreach(Server serv in servers)
                    {
                        if (serv.ID == sid)
                        {
                            exists = true;
                            serv.AddChannel(cid, ip, port, load);
                        }
                    }
                    if (exists == false)
                    {
                        Server server = new Server(sid, name);
                        servers.Add(server);
                        server.AddChannel(cid, ip, port, load);
                    }
                                            
                }
            }
            return servers;
        }
    }
}
