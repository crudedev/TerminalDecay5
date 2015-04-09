﻿using System;
using System.Collections.Generic;

namespace TerminalDecay5Server
{
    public class Outpost
    {
        public Int64 ID;
        public int OwnerID;
        public int Upgrade;
        public int Capacity;
        public int Production;

        public List<Position> Tiles;

        public List<int> Buildings;

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
            Buildings = new List<int>();
            foreach (var b in Cmn.BuildType)
            {
                Buildings.Add(0);
            }
        }
    }


}
