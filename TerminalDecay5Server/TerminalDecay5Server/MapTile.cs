using System;
using System.Collections.Generic;

namespace TerminalDecay5Server
{
    public class MapTile
    {
        public Int64 X;
        public Int64 Y;

        public List<long> Resources;
        public List<long> MaxResources;
        
        //public Int64 Metal;
        //public Int64 Organics;
        //public Int64 Water;

        public MapTile()
        {
            Resources = new List<long>();
            MaxResources = new List<long>();
            foreach (var r in Cmn.Resource)
            {
                Resources.Add(0);
                MaxResources.Add(0);
            }
        }
        
    }
}
