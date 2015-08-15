using System;
using System.Runtime.Serialization;

namespace TDCore5
{
    [Serializable()]
    public class UniversalAddress : ISerializable
    {
        public int ClusterID;
        public int SolarSytemID;
        public int PlanetID;
        public UniversalAddress()
        {

        }

        public UniversalAddress(int clust, int solar, int planet)
        {
            ClusterID = clust;
            SolarSytemID = solar;
            PlanetID = planet;
        }

        public UniversalAddress(SerializationInfo info, StreamingContext ctxt)
        {
            ClusterID = (int)info.GetValue("ClusterID", typeof(int));
            SolarSytemID = (int)info.GetValue("SolarSytemID", typeof(int));
            PlanetID = (int)info.GetValue("PlanetID", typeof(int));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("ClusterID", ClusterID);
            info.AddValue("SolarSytemID", SolarSytemID);
            info.AddValue("PlanetID", PlanetID);

        }

        public bool Compare(UniversalAddress a)
        {
            if (a.ClusterID == ClusterID && a.SolarSytemID == SolarSytemID && a.PlanetID == PlanetID)
            { return true; }
            else
            { return false; }
        }

    }
}
