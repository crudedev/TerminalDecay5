using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace TDCore5
{
    [Serializable()] 
    public class BuildQueueItem : ISerializable
    {
        public List<long> resourcesRemaining;
        public int PlayerId;
        public Outpost Outpost;
        public int ItemType;
        public long ItemTotal;
        public long Complete;
        public Guid BuildQueueID;

        public BuildQueueItem(int playerid, Outpost outpost, long total, int type,List<long> cost)
        {
            Complete = 0;
            PlayerId = playerid;
            Outpost = outpost;
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

            BuildQueueID = Guid.NewGuid();
            
        }

        public BuildQueueItem()
        {
            BuildQueueID = Guid.NewGuid();
        }

        public BuildQueueItem(SerializationInfo info, StreamingContext ctxt)
        {
            
            resourcesRemaining = (List<long>)info.GetValue("resourcesRemaining",typeof(List<long>));
            PlayerId = (int)info.GetValue("playerid",typeof(int));
            Outpost = (Outpost)info.GetValue("outpost", typeof(Outpost));
            ItemType = (int)info.GetValue("itemtype",typeof(int));
            ItemTotal = (int)info.GetValue("itemtotal",typeof(int));
            Complete = (int)info.GetValue("complete",typeof(int));
            BuildQueueID = (Guid)info.GetValue("BuildQueue", typeof(Guid));

    }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("resourcesRemaining", resourcesRemaining);
            info.AddValue("playerid", PlayerId);
            info.AddValue("outpost", Outpost);
            info.AddValue("itemtype", ItemType);
            info.AddValue("itemtotal", ItemTotal);
            info.AddValue("complete", Complete);
            info.AddValue("BuildQueue", BuildQueueID);
        }

    }
}
