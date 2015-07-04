using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TDCore5;

namespace TerminalDecay5Client
{
    public partial class Messages : Form
    {
        Guid playerToken;

        public Messages()
        {
            InitializeComponent();
        }

        private void Messages_Load(object sender, EventArgs e)
        {
            refreshMessages();
        }

        private void refreshMessages()
        {
            string request = MessageConstants.splitToken + playerToken.ToString() + MessageConstants.nextToken;

            ServerConnection sc = new ServerConnection();
            sc.ServerRequest(renderMessages, 15, request);
        }

        public void Init(Guid playertoken)
        {
            playerToken = playertoken;

        }

        private void btnRefreshMessages_Click(object sender, EventArgs e)
        {
            refreshMessages();
        }

        private void renderMessages(List<List<string>> transmission)
        {
            lstMessages.Items.Clear();

            foreach (var item in transmission[1])
            {
                lstMessages.Items.Add(item);
            }

            ListContacts.Items.Clear();

            foreach (var item in transmission[2])
            {
                ListContacts.Items.Add(item);
            }
        }
        
        void lstMessages_Click(object sender, System.EventArgs e)
        {
            ListBox l = (ListBox)sender;
            string request = MessageConstants.nextToken + playerToken.ToString() + MessageConstants.nextToken + l.SelectedIndex;

            ServerConnection sc = new ServerConnection();
            sc.ServerRequest(renderSpecificMessage, 16, request);
        }

        private void renderSpecificMessage(List<List<string>> transmission)
        {
            if(transmission[1][0] != "")
            { 
            txtTitle.Text = transmission[1][0] + " sent by: " + transmission[1][1] + " at:" + transmission[1][3];
            txtMessage.Text = transmission[1][2];
            }
        }
        
    }
}
