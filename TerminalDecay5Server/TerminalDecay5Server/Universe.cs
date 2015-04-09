using System;
using System.Collections.Generic;

namespace TerminalDecay5Server
{
    public class Universe
    {
        public List<MapTile> Maptiles;
        public List<Outpost> outposts;
        public List<BuildQueueItem> BuildQueue;
        public List<Player> players;
        Random r;

        public void InitUniverse()
        {
            Maptiles = new List<MapTile>();
            BuildQueue = new List<BuildQueueItem>();
            outposts = new List<Outpost>();
            players = new List<Player>();

            MapTile t;

            int x = 0;
            int y = 0;

            r = new Random();
            
            for (int i = 0; i < 625; i++)
            {
                t = new MapTile();
                t.Metal = r.Next(20000);
                t.Organics = r.Next(500);
                t.Water = r.Next(10000);
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
