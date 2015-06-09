using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace TDCore5
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

            r = new Random();
            clusters = new List<Cluster>();
            for (int i = 0; i < 1; i++)
            {
                Cluster c = new Cluster();
                c.solarSystems = new List<SolarSystem>();
                c.position = new Position(r.Next(25), r.Next(25));
                c.ClusterType = r.Next(10);
                c.ClusterID = i;

                for (int ii = 0; ii < 1; ii++)
                {
                    SolarSystem s = new SolarSystem();
                    s.planets = new List<Planet>();
                    s.position = new Position(r.Next(25), r.Next(25));
                    s.SolarSystemType = r.Next(10);
                    s.SolarSystemID = ii;
                        
                    for (int iii = 0; iii < 1; iii++)
                    {
                        Planet p = new Planet();

                        p.planetType = r.Next(10);
                        p.position = new Position(r.Next(25), r.Next(25));
                        p.mapTiles = new List<MapTile>();

                        p.PlanetID = iii;

                        MapTile t;

                        int x = 0;
                        int y = 0;

                        for (int iv = 0; iv < 625; iv++)
                        {
                            t = new MapTile();
                            t.Resources[Cmn.Resource[Cmn.Renum.Metal]] = r.Next(20000);
                            t.Resources[Cmn.Resource[Cmn.Renum.Food]] = r.Next(500);
                            t.Resources[Cmn.Resource[Cmn.Renum.Water]] = r.Next(10000);

                            t.MaxResources[Cmn.Resource[Cmn.Renum.Metal]] = t.Resources[Cmn.Resource[Cmn.Renum.Metal]];
                            t.MaxResources[Cmn.Resource[Cmn.Renum.Food]] = t.Resources[Cmn.Resource[Cmn.Renum.Food]];
                            t.MaxResources[Cmn.Resource[Cmn.Renum.Water]] = t.Resources[Cmn.Resource[Cmn.Renum.Water]];

                            p.mapTiles.Add(t);
                            t.position = new Position(x, y);

                            x++;
                            if (x == 25)
                            {
                                x = 0;
                                y++;
                            }
                        }

                        s.planets.Add(p);
                    }


                    c.solarSystems.Add(s);
                }

                clusters.Add(c); 

            }

            
            BuildingBuildQueue = new List<BuildQueueItem>();
            DefenceBuildQueue = new List<BuildQueueItem>();
            OffenceBuildQueue = new List<BuildQueueItem>();
            outposts = new List<Outpost>();
            players = new List<Player>();
            Messages = new List<Message>();

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
