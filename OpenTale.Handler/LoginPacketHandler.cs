using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTale.Handler
{
    public static class LoginPacketHandler
    {
        public static void HandlePacket(string packet)
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
        private static void HandleNsTeST(string packet)
        {
#warning TODO: Implement proper handling
        }
    }
}
