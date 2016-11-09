using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenTale.Client
{
    public partial class Entry : Form
    {
        public Entry()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Forms.Login loginForm = new Forms.Login();
            loginForm.ShowDialog();
        }
    }
}
