using System;
using System.Collections.Generic;using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace TDCore5
{
    [Serializable()]
    public class Player : ISerializable
    {
        public int PlayerID;
        public string Name;
        public string Password;
        public string EmpireName;
        public string Email;

        public UniversalAddress home;

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
            PlayerID = (int)info.GetValue("playerid", typeof(int));
            Name = (string)info.GetValue("name", typeof(string));
            Password = (string)info.GetValue("password", typeof(string));
            EmpireName = (string)info.GetValue("empirename", typeof(string));
            Email = (string)info.GetValue("email", typeof(string));
            Resources = (List<long>)info.GetValue("resources", typeof(List<long>));
            token = (Guid)info.GetValue("token", typeof(Guid));                 
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("playerid", PlayerID);
            info.AddValue("name", Name);
            info.AddValue("password", Password);
            info.AddValue("empirename", EmpireName);
            info.AddValue("email", Email);
            info.AddValue("resources", Resources);
            info.AddValue("token", token);
        }

    }
}
