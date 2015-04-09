using System.Collections.Generic;

namespace TerminalDecay5Server
{
    public static class Cmn
    {
        public enum Renum
        {
            Population = 0,
            Metal = 1,
            Water = 2,
            Power = 3,
            Food = 4
        }

        public static Dictionary<Renum, int> Resource;

        public enum BldTenum
        {
            Mine = 0,
            Well = 1,
            Habitat = 2,
            Farm = 3,
            SolarPLant = 4,
            Fabricator = 5

        }

        public static Dictionary<BldTenum, int> BuildType;

        public static List<List<long>> BuildCost;

        public static List<List<long>> BuildingProduction;

        public enum UntTenum
        {
            Scout = 0,
            Intercepter = 1,
            Gunship = 2,
            Bomber = 3,
            Frigate = 4,
            Destroyer = 5,
            Carrier = 6

        }

        public static Dictionary<UntTenum, int> UnitType;

        public static List<List<int>> UnitCost;

        public static void Init()
        {
            Resource = new Dictionary<Renum, int>
            {
                {Renum.Population, 0},
                {Renum.Metal, 1},
                {Renum.Water, 2},
                {Renum.Power, 3},
                {Renum.Food, 4}
            };

            BuildType = new Dictionary<BldTenum, int>            
            {
                {BldTenum.Mine, 0},
                {BldTenum.Well, 1},
                {BldTenum.Habitat, 2},
                {BldTenum.Farm, 3},
                {BldTenum.SolarPLant, 4},
                {BldTenum.Fabricator, 5}
            };

            BuildCost = new List<List<long>>();
            BuildingProduction = new List<List<long>>();

            foreach (KeyValuePair<BldTenum, int> build in BuildType)
            {
                List<long> tbuild = new List<long>();
                foreach (KeyValuePair<Renum,int> res in Resource)
                {
                   tbuild.Add(0);
                }
                BuildCost.Add(tbuild);
               
            }

            foreach (KeyValuePair<BldTenum, int> build in BuildType)
            {
                List<long> tbuild = new List<long>();
                foreach (KeyValuePair<Renum, int> res in Resource)
                {
                    tbuild.Add(0);
                }
                BuildingProduction.Add(tbuild);
            } 
           

            BuildCost[BuildType[BldTenum.Mine]][Resource[Renum.Population]] = 1;
            BuildCost[BuildType[BldTenum.Mine]][Resource[Renum.Metal]] = 2;
            BuildCost[BuildType[BldTenum.Mine]][Resource[Renum.Water]] = 3;
            BuildCost[BuildType[BldTenum.Mine]][Resource[Renum.Power]] = 4;
            BuildCost[BuildType[BldTenum.Mine]][Resource[Renum.Food]] = 5;

            BuildCost[BuildType[BldTenum.Well]][Resource[Renum.Population]] = 6;
            BuildCost[BuildType[BldTenum.Well]][Resource[Renum.Metal]] = 7;
            BuildCost[BuildType[BldTenum.Well]][Resource[Renum.Water]] = 8;
            BuildCost[BuildType[BldTenum.Well]][Resource[Renum.Power]] = 9;
            BuildCost[BuildType[BldTenum.Well]][Resource[Renum.Food]] = 10;

            BuildCost[BuildType[BldTenum.Habitat]][Resource[Renum.Population]] = 11;
            BuildCost[BuildType[BldTenum.Habitat]][Resource[Renum.Metal]] = 12;
            BuildCost[BuildType[BldTenum.Habitat]][Resource[Renum.Water]] = 13;
            BuildCost[BuildType[BldTenum.Habitat]][Resource[Renum.Power]] = 14;
            BuildCost[BuildType[BldTenum.Habitat]][Resource[Renum.Food]] = 15;

            BuildCost[BuildType[BldTenum.Farm]][Resource[Renum.Population]] = 16;
            BuildCost[BuildType[BldTenum.Farm]][Resource[Renum.Metal]] = 17;
            BuildCost[BuildType[BldTenum.Farm]][Resource[Renum.Water]] = 18;
            BuildCost[BuildType[BldTenum.Farm]][Resource[Renum.Power]] = 19;
            BuildCost[BuildType[BldTenum.Farm]][Resource[Renum.Food]] = 20;

            BuildCost[BuildType[BldTenum.SolarPLant]][Resource[Renum.Population]] = 21;
            BuildCost[BuildType[BldTenum.SolarPLant]][Resource[Renum.Metal]] = 22;
            BuildCost[BuildType[BldTenum.SolarPLant]][Resource[Renum.Water]] = 23;
            BuildCost[BuildType[BldTenum.SolarPLant]][Resource[Renum.Power]] = 24;
            BuildCost[BuildType[BldTenum.SolarPLant]][Resource[Renum.Food]] = 25;

            BuildCost[BuildType[BldTenum.Fabricator]][Resource[Renum.Population]] = 26;
            BuildCost[BuildType[BldTenum.Fabricator]][Resource[Renum.Metal]] = 27;
            BuildCost[BuildType[BldTenum.Fabricator]][Resource[Renum.Water]] = 28;
            BuildCost[BuildType[BldTenum.Fabricator]][Resource[Renum.Power]] = 29;
            BuildCost[BuildType[BldTenum.Fabricator]][Resource[Renum.Food]] = 30;



            BuildingProduction[BuildType[BldTenum.Mine]][Resource[Renum.Metal]] = 20;

            BuildingProduction[BuildType[BldTenum.Well]][Resource[Renum.Water]] = 20;

            BuildingProduction[BuildType[BldTenum.Habitat]][Resource[Renum.Population]] = 1;

            BuildingProduction[BuildType[BldTenum.Farm]][Resource[Renum.Food]] = 10;

            BuildingProduction[BuildType[BldTenum.SolarPLant]][Resource[Renum.Power]] = 10;
            
        }

    }
}
