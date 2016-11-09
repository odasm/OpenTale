using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTale.GameObject.Net
{
    public class Server
    {
        public int ID;
        public string Name;
        public List<Channel> Channels;

        public Server(int id, string name)
        {
            ID = id;
            Name = name;
            Channels = new List<Channel>();
        }

        public void AddChannel(int id, string ip, int port, int load)
        {
            Channels.Add(new Channel(id, ip, port, load));
        }
    }
}
