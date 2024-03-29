﻿using System;
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
        public List<Outpost> deadOutposts;
        public List<BuildQueueItem> BuildingBuildQueue;
        public List<BuildQueueItem> DefenceBuildQueue;
        public List<BuildQueueItem> OffenceBuildQueue;
        public List<Player> players;
        public Random r;
        public List<Message> Messages;
        public List<TroopMovement> TroopMovements;
        public List<SpecialStructure> SpecialStructures;
        public List<BaseMovement> BaseMovements;
        public List<AIController> Ai;
                
        public int CurrentTick = 0;

        public void InitUniverse()
        {
        
            //create the universe

            CurrentTick = 0;

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
                        
                    for (int iii = 0; iii < 5; iii++)
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
            deadOutposts = new List<Outpost>();
            players = new List<Player>();
            Messages = new List<Message>();
            TroopMovements = new List<TroopMovement>();
            SpecialStructures = new List<SpecialStructure>();
            BaseMovements = new List<BaseMovement>();

        }
        
        public Universe()
        {

        }

        public Universe(SerializationInfo info, StreamingContext ctxt)
        {

            clusters = (List<Cluster>)info.GetValue("Cluster", typeof(List<Cluster>));
            outposts = (List<Outpost>)info.GetValue("outposts", typeof(List<Outpost>));
            BuildingBuildQueue = (List<BuildQueueItem>)info.GetValue("buildingqueue", typeof(List<BuildQueueItem>));
            DefenceBuildQueue = (List<BuildQueueItem>)info.GetValue("defencequeue", typeof(List<BuildQueueItem>));
            OffenceBuildQueue = (List<BuildQueueItem>)info.GetValue("offencequeue", typeof(List<BuildQueueItem>));
            players = (List<Player>)info.GetValue("players", typeof(List<Player>));
            r = (Random)info.GetValue("random", typeof(Random));
            Messages = (List<Message>)info.GetValue("messages", typeof(List<Message>));
            TroopMovements = (List<TroopMovement>)info.GetValue("TroopMovement", typeof(List<TroopMovement>));
            SpecialStructures = (List<SpecialStructure>)info.GetValue("SpecialStructure", typeof(List<SpecialStructure>));
            BaseMovements = (List<BaseMovement>)info.GetValue("BaseMovement", typeof(List<BaseMovement>));

        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {

            info.AddValue("Cluster", clusters);
            info.AddValue("outposts", outposts);
            info.AddValue("buildingqueue", BuildingBuildQueue);
            info.AddValue("defencequeue", DefenceBuildQueue);
            info.AddValue("offencequeue", OffenceBuildQueue);
            info.AddValue("players", players);
            info.AddValue("random", r);
            info.AddValue("messages", Messages);
            info.AddValue("TroopMovement", TroopMovements);
            info.AddValue("SpecialStructure", SpecialStructures);
            info.AddValue("BaseMovement", BaseMovements);
        }


    }
}
