using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using TDCore5;

namespace TerminalDecay5Client
{
    class ServerConnection
    {

        private List<List<string>> Decodetransmission(string Message)
        {
            Message = Message.Replace(MessageConstants.messageCompleteToken, "");
            string[] messages;
            messages = Message.Split(new string[] { MessageConstants.nextMessageToken }, StringSplitOptions.None);

            List<List<string>> transmissions = new List<List<string>>();


            foreach (string m in messages)
            {
                List<string> messageList = new List<string>();
                messageList.AddRange(m.Split(new string[] { MessageConstants.splitMessageToken }, StringSplitOptions.None));

                transmissions.Add(messageList);

            }

            return transmissions;
        }

        public delegate void ClientCallback(List<List<string>> transfer);

        public void ServerRequest(ClientCallback callback, int mtype, string req)
        {
            IPAddress ad =  Dns.GetHostAddresses("dankdankdank.ddns.net")[0];
            
            MessageConstants.InitValues();

            TcpClient client = new TcpClient();

            IPEndPoint serverEndPoint = new IPEndPoint(ad, 42666);

            client.Connect(serverEndPoint);

            NetworkStream clientStream = client.GetStream();

            ASCIIEncoding encoder = new ASCIIEncoding();
            byte[] buffer = encoder.GetBytes(MessageConstants.MessageTypes[mtype] + req + MessageConstants.messageCompleteToken);

            clientStream.Write(buffer, 0, buffer.Length);

            clientStream.Flush();

            TcpClient tcpClient = (TcpClient)client;
            clientStream = tcpClient.GetStream();

            byte[] message = new byte[4096];
            int bytesRead;

            string reply = "";


            bytesRead = 0;


            try
            {
                //blocks until a client sends a message
                bytesRead = clientStream.Read(message, 0, 4096);


                //keep reading until the message is done;
                while (bytesRead != 0)
                {
                    //message has successfully been received
                    encoder = new ASCIIEncoding();

                    reply += encoder.GetString(message, 0, bytesRead);

                    if (reply.Substring(reply.Length - MessageConstants.messageCompleteToken.Length,MessageConstants.messageCompleteToken.Length) == MessageConstants.messageCompleteToken)
                    {
                        break;
                    }

                    if (bytesRead < 4096)
                    {
                      //  break;
                    }

                    bytesRead = clientStream.Read(message, 0, 4096);
                }
            }

            catch
            {
                //a socket error has occured
                return;
            }

            if (bytesRead == 0)
            {
                //the client has disconnected from the server
                return;
            }
            

            List<List<string>> transmission = Decodetransmission(reply);

            if (transmission[0][0] == MessageConstants.MessageTypes[mtype])
            {
                callback(transmission);
            }


        }
    }
}
