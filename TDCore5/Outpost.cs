using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace TDCore5
{
    [Serializable()]
    public class Outpost : ISerializable
    {
        public int ID;
        public int OwnerID;
        public int Capacity;

        public Position Tile;
        public List<long> Buildings;
        public List<long> Defence;
        public List<long> Offence;

        public UniversalAddress Home;

        public int CoreShards;

        public Outpost()
        {
            Buildings = new List<long>();
            foreach (var b in Cmn.BuildType)
            {
                Buildings.Add(0);
            }

            Defence = new List<long>();
            foreach (var d in Cmn.DefenceType)
            {
                Defence.Add(0);
            }

            Offence = new List<long>();
            foreach (var o in Cmn.OffenceType)
            {
                Offence.Add(0);
            }
        }

        public Outpost(SerializationInfo info, StreamingContext ctxt)
        {
            this.ID = (int)info.GetValue("id", typeof(int));
            this.OwnerID = (int)info.GetValue("ownerid", typeof(int));
            this.Capacity = (int)info.GetValue("capacity", typeof(int));
            this.Tile = (Position)info.GetValue("tile", typeof(Position));
            this.Buildings = (List<long>)info.GetValue("building", typeof(List<long>));
            this.Defence = (List<long>)info.GetValue("defence", typeof(List<long>));
            this.Offence = (List<long>)info.GetValue("offence", typeof(List<long>));                 
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("id", this.ID);
            info.AddValue("ownerid", this.OwnerID);
            info.AddValue("capacity", this.Capacity);
            info.AddValue("tile", this.Tile);
            info.AddValue("building", this.Buildings);
            info.AddValue("defence", this.Defence);
            info.AddValue("offence", this.Offence);
        }
    }

}
