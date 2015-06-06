using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TDCore5;

namespace TerminalDecay5Client
{
    public partial class Login : Form
    {
        Guid logintoken;
       
        public Login()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            ServerConnection sc = new ServerConnection();
            sc.ServerRequest(login,2, MessageConstants.splitMessageToken + TxtEmail.Text + MessageConstants.splitMessageToken + TxtPassWord.Text + MessageConstants.messageCompleteToken);
        }

        private void login(List<List<string>> response)
        {
            if(response[1][0] == "Yeppers")
            {
                Map m = new Map();
               
                logintoken = new Guid(response[2][0]);
                m.SetPlayerToken(logintoken);
                m.Show();
            }
        }

        private void BtnCreateAccount_Click(object sender, EventArgs e)
        {
            CreateAccount ca = new CreateAccount();
            ca.Show();
        }
                
    }
}
