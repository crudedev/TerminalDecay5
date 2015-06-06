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

        public BuildQueueItem()
        {

        }

        public BuildQueueItem(SerializationInfo info, StreamingContext ctxt)
        {
            
            this.resourcesRemaining = (List<long>)info.GetValue("resourcesRemaining",typeof(List<long>));
            this.PlayerId = (int)info.GetValue("playerid",typeof(int));
            this.OutpostId = (int)info.GetValue("outpostId", typeof(int));
            this.ItemType = (int)info.GetValue("itemtype",typeof(int));
            this.ItemTotal = (int)info.GetValue("itemtotal",typeof(int));
            this.Complete = (int)info.GetValue("complete",typeof(int));

        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("resourcesRemaining", this.resourcesRemaining);
            info.AddValue("playerid", this.PlayerId);
            info.AddValue("outpostId", this.OutpostId);
            info.AddValue("itemtype", this.ItemType);
            info.AddValue("itemtotal", this.ItemTotal);
            info.AddValue("complete", this.Complete);
        }

    }
}
