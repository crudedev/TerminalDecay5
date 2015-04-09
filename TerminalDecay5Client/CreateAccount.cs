using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TerminalDecay5Server;

namespace TerminalDecay5Client
{
    public partial class CreateAccount : Form
    {
        public CreateAccount()
        {
            InitializeComponent();//dropbox test
        }

        private void BtnCreateAccount_Click(object sender, EventArgs e)
        {
            ServerConnection sc = new ServerConnection();
            sc.ServerRequest(CreateAccountResponse, 1, MessageConstants.splitMessageToken + TxtAccountName.Text + MessageConstants.splitMessageToken + TxtEmail.Text + MessageConstants.splitMessageToken + TxtPassWord.Text + MessageConstants.messageCompleteToken);
        }

        private void CreateAccountResponse(List<List<string>> transfer)
        {
            if (transfer[1][0] == "AccountCreated")
            {
                MessageBox.Show("Account Created");
                this.Close();
            }
            else
            {
                MessageBox.Show("Account Details Already Exist");
            }
        }

    }
}
