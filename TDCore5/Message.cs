using System;
using System.Runtime.Serialization;

namespace TDCore5
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
            senderID = (int)info.GetValue("senderid", typeof(int));
            recipientID = (int)info.GetValue("recipientid", typeof(int));
            messageTitle = (string)info.GetValue("messagetitle", typeof(string));
            messageBody = (string)info.GetValue("messagebody", typeof(string));
            sentDate = (DateTime)info.GetValue("sentDate", typeof(DateTime));
            read = (bool)info.GetValue("read", typeof(bool));                        
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("senderid", senderID);
            info.AddValue("recipientid", recipientID);
            info.AddValue("messagetitle", messageTitle);
            info.AddValue("messagebody", messageBody);
            info.AddValue("sentDate", sentDate);
            info.AddValue("read", read);
        }
        
    }
}
