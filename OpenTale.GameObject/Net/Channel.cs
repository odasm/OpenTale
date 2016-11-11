using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTale.GameObject.Net
{
    public class Channel
    {
        public int ID;
        public string IP;
        public int Port;
        public int Load;

        public Channel(int id, string ip, int port, int load)
        {
            ID = id;
            IP = ip;
            Port = port;
            Load = load;
        }
        public override string ToString()
        {
            return string.Format("Channel {0}", ID);

        }
    }
}
