using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace TerminalDecay5Server
{
    [Serializable()]
    public class Universe : ISerializable
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
            Messages = new List<Message>();

            if (false)
            {
                MapTile t;

                int x = 0;
                int y = 0;

                r = new Random();

                for (int i = 0; i < 625; i++)
                {
                    t = new MapTile();
                    t.Resources[Cmn.Resource[Cmn.Renum.Metal]] = r.Next(20000);
                    t.Resources[Cmn.Resource[Cmn.Renum.Food]] = r.Next(500);
                    t.Resources[Cmn.Resource[Cmn.Renum.Water]] = r.Next(10000);

                    t.MaxResources[Cmn.Resource[Cmn.Renum.Metal]] = t.Resources[Cmn.Resource[Cmn.Renum.Metal]];
                    t.MaxResources[Cmn.Resource[Cmn.Renum.Food]] = t.Resources[Cmn.Resource[Cmn.Renum.Food]];
                    t.MaxResources[Cmn.Resource[Cmn.Renum.Water]] = t.Resources[Cmn.Resource[Cmn.Renum.Water]];

                    Maptiles.Add(t);
                    t.X = x;
                    t.Y = y;

                    x++;
                    if (x == 25)
                    {
                        x = 0;
                        y++;
                    }
                }
            }
        }

        public Universe()
        {

        }

        public Universe(SerializationInfo info, StreamingContext ctxt)
        {

            this.Maptiles = (List<MapTile>)info.GetValue("maptiles", typeof(List<MapTile>));
            this.outposts = (List<Outpost>)info.GetValue("outposts", typeof(List<Outpost>));
            this.BuildingBuildQueue = (List<BuildQueueItem>)info.GetValue("buildingqueue", typeof(List<BuildQueueItem>));
            this.DefenceBuildQueue = (List<BuildQueueItem>)info.GetValue("defencequeue", typeof(List<BuildQueueItem>));
            this.OffenceBuildQueue = (List<BuildQueueItem>)info.GetValue("offencequeue", typeof(List<BuildQueueItem>));
            this.players = (List<Player>)info.GetValue("players", typeof(List<Player>));
            this.r = (Random)info.GetValue("random", typeof(Random));
            this.Messages = (List<Message>)info.GetValue("messages", typeof(List<Message>));

        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {

            info.AddValue("maptiles", this.Maptiles);
            info.AddValue("outposts", this.outposts);
            info.AddValue("buildingqueue", this.BuildingBuildQueue);
            info.AddValue("defencequeue", this.DefenceBuildQueue);
            info.AddValue("offencequeue", this.OffenceBuildQueue);
            info.AddValue("players", this.players);
            info.AddValue("random", this.r);
            info.AddValue("messages", this.Messages);
        }


    }
}
