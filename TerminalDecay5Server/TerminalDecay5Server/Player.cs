using System;
using System.Collections.Generic;using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace TerminalDecay5Server
{
    [Serializable()]
    public class Player : ISerializable
    {
        public int PlayerID;
        public string Name;
        public string Password;
        public string EmpireName;
        public string Email;

        public List<long> Resources;

        public Guid token;

        public Player()
        {
            Resources = new List<long>();

                foreach (var r in Cmn.Resource)
                {
                    Resources.Add(0);
                }
       
        }

        public Player(SerializationInfo info, StreamingContext ctxt)
        {
            this.PlayerID = (int)info.GetValue("playerid", typeof(int));
            this.Name = (string)info.GetValue("name", typeof(string));
            this.Password = (string)info.GetValue("password", typeof(string));
            this.EmpireName = (string)info.GetValue("empirename", typeof(string));
            this.Email = (string)info.GetValue("email", typeof(string));
            this.Resources = (List<long>)info.GetValue("resources", typeof(List<long>));
            this.token = (Guid)info.GetValue("token", typeof(Guid));                 
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("playerid", this.PlayerID);
            info.AddValue("name", this.Name);
            info.AddValue("password", this.Password);
            info.AddValue("empirename", this.EmpireName);
            info.AddValue("email", this.Email);
            info.AddValue("resources", this.Resources);
            info.AddValue("token", this.token);
        }

    }
}
