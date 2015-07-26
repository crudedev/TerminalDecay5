using System;
using System.Runtime.Serialization;

namespace TDCore5
{
    [Serializable()]
    public class SpecialStructure : ISerializable
    {
        public int resourceType;
        public Cmn.SpecialType specialType;
        public int ProductionSize;
        public float BuffSize;
        public UniversalAddress Address;
        public Position Tile;
        public UniversalAddress DestinationAddress;
        public Position DestinationTile;

        public SpecialStructure()
        {

        }

        public SpecialStructure(SerializationInfo info, StreamingContext ctxt)
        {
            resourceType = (int)info.GetValue("resourceType", typeof(int));
            specialType = (Cmn.SpecialType)info.GetValue("specialType", typeof(Cmn.SpecialType));
            ProductionSize = (int)info.GetValue("productionsize", typeof(int));
            BuffSize = (float)info.GetValue("buffsize", typeof(float));
            Address = (UniversalAddress)info.GetValue("address", typeof(UniversalAddress));
            Tile = (Position)info.GetValue("tile", typeof(Position));
            DestinationAddress = (UniversalAddress)info.GetValue("destinationaddress", typeof(UniversalAddress));
            DestinationTile = (Position)info.GetValue("destinationtile", typeof(Position));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("resourceType", resourceType);
            info.AddValue("specialType", specialType);
            info.AddValue("productionsize", ProductionSize);
            info.AddValue("buffsize", BuffSize);
            info.AddValue("address", Address);
            info.AddValue("tile", Tile);
            info.AddValue("destinationaddress", DestinationAddress);
            info.AddValue("destinationtile", DestinationTile);
        }

    }
}
