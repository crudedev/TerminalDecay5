using System;
using System.Collections.Generic;

namespace TerminalDecay5Server
{
    public class Outpost
    {
        public int ID;
        public int OwnerID;
        public int Upgrade;
        public int Capacity;
        public int Production;

        public List<Position> Tiles;

        public List<long> Buildings;

        public List<long> Defence;

        public List<long> Offence;

        //public int mine;
        //public int well;
        //public int habitat;
        //public int farm;
        //public int solarPlant;
        //public int fabracator;

        public int watertank;
        public int storeHouse;
        public int capacitors;
        public int freezer;

        public Outpost()
        {
            Buildings = new List<long>();
            foreach (var b in Cmn.BuildType)
            {
                Buildings.Add(0);
            }

            Defence = new List<long>();
            foreach (var d in Cmn.DefenceType)
            {
                Defence.Add(0);
            }

            Offence = new List<long>();
            foreach (var o in Cmn.OffenceType)
            {
                Offence.Add(0);
            }
        }
    }


}
