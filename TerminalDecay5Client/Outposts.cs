using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TDCore5;

namespace TerminalDecay5Client
{
    public partial class Outposts : Form
    {
        Guid PlayerToken;

        public Outposts(Guid PToken)
        {
            PlayerToken = new Guid();
            PlayerToken = PToken;
            InitializeComponent();
        }

        private void Outposts_Load(object sender, EventArgs e)
        {
            ServerConnection sc = new ServerConnection();
            sc.ServerRequest(UpdateOutposts, 29, MessageConstants.splitToken + Convert.ToString(PlayerToken) + MessageConstants.completeToken);
        }

        private void UpdateOutposts(List<List<string>> transmission)
        {

        }
    }
}
