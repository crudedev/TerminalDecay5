using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace TerminalDecay5Server
{
    [Serializable()]
    public class Universe : ISerializable
    {
        public List<Cluster> clusters;
        public List<Outpost> outposts;
        public List<BuildQueueItem> BuildingBuildQueue;
        public List<BuildQueueItem> DefenceBuildQueue;
        public List<BuildQueueItem> OffenceBuildQueue;
        public List<Player> players;
        public Random r;
        public List<Message> Messages;

        public void InitUniverse()
        {
            clusters = new List<Cluster>();
            clusters.Add(new Cluster());
            clusters[0].solarSystems = new List<SolarSystem>();
            clusters[0].solarSystems.Add(new SolarSystem());
            clusters[0].solarSystems[0].planets = new List<Planet>();
            clusters[0].solarSystems[0].planets.Add(new Planet());
            clusters[0].solarSystems[0].planets[0].mapTiles = new List<MapTile>();
            
            BuildingBuildQueue = new List<BuildQueueItem>();
            DefenceBuildQueue = new List<BuildQueueItem>();
            OffenceBuildQueue = new List<BuildQueueItem>();
            outposts = new List<Outpost>();
            players = new List<Player>();
            Messages = new List<Message>();

            if (true)
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

                    clusters[0].solarSystems[0].planets[0].mapTiles.Add(t);
                    t.position = new Position(x, y);

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

            this.clusters = (List<Cluster>)info.GetValue("Cluster", typeof(List<Cluster>));
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

            info.AddValue("Cluster", this.clusters);
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
