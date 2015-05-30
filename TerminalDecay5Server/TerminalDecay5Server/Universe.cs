using System;
using System.Collections.Generic;

namespace TerminalDecay5Server
{
    public class Universe
    {
        public List<MapTile> Maptiles;
        public List<Outpost> outposts;
        public List<BuildQueueItem> BuildingBuildQueue;
        public List<BuildQueueItem> DefenceBuildQueue;
        public List<BuildQueueItem> OffenceBuildQueue;
        public List<Player> players;
        public Random r;
        public List<Message> Messages;

        public void InitUniverse()
        {
            Maptiles = new List<MapTile>();
            BuildingBuildQueue = new List<BuildQueueItem>();
            DefenceBuildQueue = new List<BuildQueueItem>();
            OffenceBuildQueue = new List<BuildQueueItem>();
            outposts = new List<Outpost>();
            players = new List<Player>();

            MapTile t;

            int x = 0;
            int y = 0;

            r = new Random();
            
            for (int i = 0; i < 625; i++)
            {
                t = new MapTile();
                t.Resources[Cmn.Resource[Cmn.Renum.Metal]] = r.Next(20000);
                t.Resources[Cmn.Resource[Cmn.Renum.Food]] = r.Next(500);
                t.Resources[Cmn.Resource[Cmn.Renum.Water]]= r.Next(10000);

                t.MaxResources[Cmn.Resource[Cmn.Renum.Metal]] = t.Resources[Cmn.Resource[Cmn.Renum.Metal]];
                t.MaxResources[Cmn.Resource[Cmn.Renum.Food]] = t.Resources[Cmn.Resource[Cmn.Renum.Food]];
                t.MaxResources[Cmn.Resource[Cmn.Renum.Water]]= t.Resources[Cmn.Resource[Cmn.Renum.Water]];

                Maptiles.Add(t);
                t.X = x;
                t.Y = y;

                x++;
                if (x==25)
                {
                    x = 0;
                    y++;
                }
            }
        }
    }
}
