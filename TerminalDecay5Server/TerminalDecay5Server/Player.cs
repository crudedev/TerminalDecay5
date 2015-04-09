using System;
using System.Collections.Generic;

namespace TerminalDecay5Server
{
    public class Player
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

    }
}
