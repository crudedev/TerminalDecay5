using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace TerminalDecay5Server
{   
    [Serializable()] 
    public class Message : ISerializable
    {
        public int senderID;
        public int recipientID;

        public string messageTitle;
        public string messageBody;

        public DateTime sentDate;
        public bool read;

        public Message(int sender, int recipient, string title, string message)
        {

            senderID = sender;
            recipientID = recipient;
            messageTitle = title;
            messageBody = message;

            read = false;
            sentDate = DateTime.Now;
        }

        public Message(SerializationInfo info, StreamingContext ctxt)
        {
            this.senderID = (int)info.GetValue("senderid", typeof(int));
            this.recipientID = (int)info.GetValue("recipientid", typeof(int));
            this.messageTitle = (string)info.GetValue("messagetitle", typeof(string));
            this.messageBody = (string)info.GetValue("messagebody", typeof(string));
            this.sentDate = (DateTime)info.GetValue("sentDate", typeof(DateTime));
            this.read = (bool)info.GetValue("read", typeof(bool));                        
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("senderid", this.senderID);
            info.AddValue("recipientid", this.recipientID);
            info.AddValue("messagetitle", this.messageTitle);
            info.AddValue("messagebody", this.messageBody);
            info.AddValue("sentDate", this.sentDate);
            info.AddValue("read", this.read);
        }
        
    }
}
