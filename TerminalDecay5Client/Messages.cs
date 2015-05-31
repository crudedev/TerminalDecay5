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
            string request = MessageConstants.nextMessageToken + playerToken.ToString() + MessageConstants.nextMessageToken;

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

        private void renderMessages(List<List<string>> transmition)
        {
            lstMessages.Items.Clear();

            foreach (var item in transmition[1])
            {
                lstMessages.Items.Add(item);
            }

            ListContacts.Items.Clear();

            foreach (var item in transmition[2])
            {
                ListContacts.Items.Add(item);
            }
        }
    }
}
