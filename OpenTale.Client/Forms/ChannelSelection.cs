using OpenTale.GameObject.Net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenTale.Client.Forms
{
    public partial class ChannelSelection : Form
    {
        private List<Server> _servers;
        public ChannelSelection(List<Server> servers)
        {
            InitializeComponent();
            _servers = servers;
            foreach(Server s in servers)
            {
                serverListBox.Items.Add(s);
            }
        }

        private void serverListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (serverListBox.SelectedIndex != -1)
            {
                channelListBox.Items.Clear();
                foreach (Channel c in _servers[serverListBox.SelectedIndex].Channels)
                {
                    channelListBox.Items.Add(c);
                }
            }
            else
            {
                
            }
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            //TODO: Connect to:
            //_servers[serverListBox.SelectedIndex]
            //        .Channels[channelListBox.SelectedIndex]

        }
    }
}
