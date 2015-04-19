using System.Collections.Generic;

namespace TerminalDecay5Server
{
    public class BuildQueueItem
    {
        public List<long> resourcesRemaining;
        public int PlayerId;
        public int OutpostId;
        public int ItemType;
        public long ItemTotal;
        public long Complete;

        public BuildQueueItem(int playerid, int outpostId, long total, int type,List<long> cost)
        {
            Complete = 0;
            PlayerId = playerid;
            OutpostId = outpostId;
            ItemTotal = total;
            ItemType = type;
            

            resourcesRemaining = new List<long>();

            foreach (var r in Cmn.Resource)
            {
                resourcesRemaining.Add(0);
            }

            resourcesRemaining[Cmn.Resource[Cmn.Renum.Food]] = cost[Cmn.Resource[Cmn.Renum.Food]] * ItemTotal;
            resourcesRemaining[Cmn.Resource[Cmn.Renum.Metal]] = cost[Cmn.Resource[Cmn.Renum.Metal]] * ItemTotal;
            resourcesRemaining[Cmn.Resource[Cmn.Renum.Population]] = cost[Cmn.Resource[Cmn.Renum.Population]] * ItemTotal;
            resourcesRemaining[Cmn.Resource[Cmn.Renum.Power]] = cost[Cmn.Resource[Cmn.Renum.Power]] * ItemTotal;
            resourcesRemaining[Cmn.Resource[Cmn.Renum.Water]] = cost[Cmn.Resource[Cmn.Renum.Water]] * ItemTotal;
            
        }
    }
}
