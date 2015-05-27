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

        public enum OffTenum
        {
            Scout = 0,
            Gunship = 1,
            Bomber = 2,
            Frigate = 3,
            Destroyer = 4,
            Carrier = 5,
            Battleship = 6
        }

        public static Dictionary<OffTenum, int> OffenceType;

        public static List<List<long>> OffenceCost;

        public enum DefTenum
        {
            Patrol = 0,
            Gunner = 1,
            Turret = 2,
            Artillery = 3,
            DroneBase = 4
        }

        public static Dictionary<DefTenum, int> DefenceType;

        public static List<List<long>> DefenceCost;

        public static List<long> DefenceAttack;

        public static List<long> OffenceAttack;

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

            DefenceType = new Dictionary<DefTenum, int>
            {
                {DefTenum.Patrol,0},
                {DefTenum.Gunner,1},
                {DefTenum.Turret,2},
                {DefTenum.Artillery,3},
                {DefTenum.DroneBase,4}
            };

            OffenceType = new Dictionary<OffTenum, int>
            {
                {OffTenum.Scout,0},
                {OffTenum.Gunship,1},
                {OffTenum.Bomber,2},
                {OffTenum.Frigate,3},
                {OffTenum.Destroyer,4},
                {OffTenum.Carrier,5},    
                {OffTenum.Battleship,6},
            };

            BuildCost = new List<List<long>>();
            BuildingProduction = new List<List<long>>();
            DefenceCost = new List<List<long>>();
            DefenceAttack = new List<long>();
            OffenceCost = new List<List<long>>();
            OffenceAttack = new List<long>();

            foreach (KeyValuePair<BldTenum, int> build in BuildType)
            {
                List<long> tbuild = new List<long>();
                foreach (KeyValuePair<Renum, int> res in Resource)
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

            foreach (KeyValuePair<DefTenum, int> item in DefenceType)
            {
                List<long> dcost = new List<long>();
                foreach (KeyValuePair<Renum, int> res in Resource)
                {
                    dcost.Add(0);
                }
                DefenceCost.Add(dcost);

                DefenceAttack.Add(0);
            }

            foreach (KeyValuePair<OffTenum, int> item in OffenceType)
            {
                List<long> ocost = new List<long>();
                foreach (KeyValuePair<Renum, int> res in Resource)
                {
                    ocost.Add(0);
                }
                OffenceCost.Add(ocost);

                OffenceAttack.Add(0);
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

            DefenceCost[DefenceType[DefTenum.Patrol]][Resource[Renum.Food]] = 1;
            DefenceCost[DefenceType[DefTenum.Patrol]][Resource[Renum.Metal]] = 1;
            DefenceCost[DefenceType[DefTenum.Patrol]][Resource[Renum.Population]] = 1;
            DefenceCost[DefenceType[DefTenum.Patrol]][Resource[Renum.Power]] = 1;
            DefenceCost[DefenceType[DefTenum.Patrol]][Resource[Renum.Water]] = 1;

            DefenceCost[DefenceType[DefTenum.Gunner]][Resource[Renum.Food]] = 2;
            DefenceCost[DefenceType[DefTenum.Gunner]][Resource[Renum.Metal]] = 2;
            DefenceCost[DefenceType[DefTenum.Gunner]][Resource[Renum.Population]] = 2;
            DefenceCost[DefenceType[DefTenum.Gunner]][Resource[Renum.Power]] = 2;
            DefenceCost[DefenceType[DefTenum.Gunner]][Resource[Renum.Water]] = 2;

            DefenceCost[DefenceType[DefTenum.Turret]][Resource[Renum.Food]] = 3;
            DefenceCost[DefenceType[DefTenum.Turret]][Resource[Renum.Metal]] = 3;
            DefenceCost[DefenceType[DefTenum.Turret]][Resource[Renum.Population]] = 3;
            DefenceCost[DefenceType[DefTenum.Turret]][Resource[Renum.Power]] = 3;
            DefenceCost[DefenceType[DefTenum.Turret]][Resource[Renum.Water]] = 3;

            DefenceCost[DefenceType[DefTenum.Artillery]][Resource[Renum.Food]] = 4;
            DefenceCost[DefenceType[DefTenum.Artillery]][Resource[Renum.Metal]] = 4;
            DefenceCost[DefenceType[DefTenum.Artillery]][Resource[Renum.Population]] = 4;
            DefenceCost[DefenceType[DefTenum.Artillery]][Resource[Renum.Power]] = 4;
            DefenceCost[DefenceType[DefTenum.Artillery]][Resource[Renum.Water]] = 4;

            DefenceCost[DefenceType[DefTenum.DroneBase]][Resource[Renum.Food]] = 5;
            DefenceCost[DefenceType[DefTenum.DroneBase]][Resource[Renum.Metal]] = 5;
            DefenceCost[DefenceType[DefTenum.DroneBase]][Resource[Renum.Population]] = 5;
            DefenceCost[DefenceType[DefTenum.DroneBase]][Resource[Renum.Power]] = 5;
            DefenceCost[DefenceType[DefTenum.DroneBase]][Resource[Renum.Water]] = 5;

            DefenceAttack[DefenceType[DefTenum.Patrol]] = 2;
            DefenceAttack[DefenceType[DefTenum.Gunner]] = 5;
            DefenceAttack[DefenceType[DefTenum.Turret]] = 10;
            DefenceAttack[DefenceType[DefTenum.Artillery]] = 15;
            DefenceAttack[DefenceType[DefTenum.DroneBase]] = 40;
            
            OffenceCost[OffenceType[OffTenum.Scout]][Resource[Renum.Food]] = 1;
            OffenceCost[OffenceType[OffTenum.Scout]][Resource[Renum.Metal]] = 1;
            OffenceCost[OffenceType[OffTenum.Scout]][Resource[Renum.Population]] = 1;
            OffenceCost[OffenceType[OffTenum.Scout]][Resource[Renum.Power]] = 1;
            OffenceCost[OffenceType[OffTenum.Scout]][Resource[Renum.Water]] = 1;

            OffenceCost[OffenceType[OffTenum.Gunship]][Resource[Renum.Food]] = 2;
            OffenceCost[OffenceType[OffTenum.Gunship]][Resource[Renum.Metal]] = 2;
            OffenceCost[OffenceType[OffTenum.Gunship]][Resource[Renum.Population]] = 2;
            OffenceCost[OffenceType[OffTenum.Gunship]][Resource[Renum.Power]] = 2;
            OffenceCost[OffenceType[OffTenum.Gunship]][Resource[Renum.Water]] = 2;

            OffenceCost[OffenceType[OffTenum.Bomber]][Resource[Renum.Food]] = 3;
            OffenceCost[OffenceType[OffTenum.Bomber]][Resource[Renum.Metal]] = 3;
            OffenceCost[OffenceType[OffTenum.Bomber]][Resource[Renum.Population]] = 3;
            OffenceCost[OffenceType[OffTenum.Bomber]][Resource[Renum.Power]] = 3;
            OffenceCost[OffenceType[OffTenum.Bomber]][Resource[Renum.Water]] = 3;

            OffenceCost[OffenceType[OffTenum.Frigate]][Resource[Renum.Food]] = 4;
            OffenceCost[OffenceType[OffTenum.Frigate]][Resource[Renum.Metal]] = 4;
            OffenceCost[OffenceType[OffTenum.Frigate]][Resource[Renum.Population]] = 4;
            OffenceCost[OffenceType[OffTenum.Frigate]][Resource[Renum.Power]] = 4;
            OffenceCost[OffenceType[OffTenum.Frigate]][Resource[Renum.Water]] = 4;

            OffenceCost[OffenceType[OffTenum.Destroyer]][Resource[Renum.Food]] = 5;
            OffenceCost[OffenceType[OffTenum.Destroyer]][Resource[Renum.Metal]] = 5;
            OffenceCost[OffenceType[OffTenum.Destroyer]][Resource[Renum.Population]] = 5;
            OffenceCost[OffenceType[OffTenum.Destroyer]][Resource[Renum.Power]] = 5;
            OffenceCost[OffenceType[OffTenum.Destroyer]][Resource[Renum.Water]] = 5;

            OffenceCost[OffenceType[OffTenum.Carrier]][Resource[Renum.Food]] = 6;
            OffenceCost[OffenceType[OffTenum.Carrier]][Resource[Renum.Metal]] = 6;
            OffenceCost[OffenceType[OffTenum.Carrier]][Resource[Renum.Population]] = 6;
            OffenceCost[OffenceType[OffTenum.Carrier]][Resource[Renum.Power]] = 6;
            OffenceCost[OffenceType[OffTenum.Carrier]][Resource[Renum.Water]] = 6;

            OffenceCost[OffenceType[OffTenum.Battleship]][Resource[Renum.Food]] = 7;
            OffenceCost[OffenceType[OffTenum.Battleship]][Resource[Renum.Metal]] = 7;
            OffenceCost[OffenceType[OffTenum.Battleship]][Resource[Renum.Population]] = 7;
            OffenceCost[OffenceType[OffTenum.Battleship]][Resource[Renum.Power]] = 7;
            OffenceCost[OffenceType[OffTenum.Battleship]][Resource[Renum.Water]] = 7;

            OffenceAttack[OffenceType[OffTenum.Scout]] = 1;
            OffenceAttack[OffenceType[OffTenum.Gunship]] = 2;
            OffenceAttack[OffenceType[OffTenum.Bomber]] = 3;
            OffenceAttack[OffenceType[OffTenum.Frigate]] = 4;
            OffenceAttack[OffenceType[OffTenum.Destroyer]] = 5;
            OffenceAttack[OffenceType[OffTenum.Carrier]] = 6;
            OffenceAttack[OffenceType[OffTenum.Battleship]] = 7;
        }
    }
}
