using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerminalDecay5Server
{
    public class Message
    {
        int senderID;
        int recipientID;

        string messageTitle;
        string messageBody;

        DateTime sentDate;
        bool read;

        public Message(int sender, int recipient, string title, string message)
        {

            senderID = sender;
            recipientID = recipient;
            messageTitle = title;
            messageBody = message;

            read = false;
            sentDate = DateTime.Now;
        }
        
    }
}
