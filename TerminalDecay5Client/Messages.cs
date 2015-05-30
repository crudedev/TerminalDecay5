using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TerminalDecay5Server;

namespace TerminalDecay5Client
{
    public partial class Messages : Form
    {
        Universe u;

        public Messages()
        {
            InitializeComponent();
        }

        private void Messages_Load(object sender, EventArgs e)
        {

        }

        public void Init(Universe uni)
        {
            u = uni;



        }
    }
}
