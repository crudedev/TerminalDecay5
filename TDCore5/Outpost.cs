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

        public UniversalAddress Address;

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
            ID = (int)info.GetValue("id", typeof(int));
            OwnerID = (int)info.GetValue("ownerid", typeof(int));
            Capacity = (int)info.GetValue("capacity", typeof(int));
            Tile = (Position)info.GetValue("tile", typeof(Position));
            Buildings = (List<long>)info.GetValue("building", typeof(List<long>));
            Defence = (List<long>)info.GetValue("defence", typeof(List<long>));
            Offence = (List<long>)info.GetValue("offence", typeof(List<long>));
            Address = (UniversalAddress)info.GetValue("address", typeof(UniversalAddress));
            CoreShards = (int)info.GetValue("coreshards", typeof(int));                 
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("id", ID);
            info.AddValue("ownerid", OwnerID);
            info.AddValue("capacity", Capacity);
            info.AddValue("tile", Tile);
            info.AddValue("building", Buildings);
            info.AddValue("defence", Defence);
            info.AddValue("offence", Offence);
            info.AddValue("address", Address);
            info.AddValue("coreshards", CoreShards);
        }
    }

}
