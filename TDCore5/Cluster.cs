using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TDCore5
{
    [Serializable()]
    public class Cluster : ISerializable
    {
        public List<SolarSystem> solarSystems;
        public Position position;

        public int ClusterType;

        public int ClusterID;


        public Cluster()
        {

        }

        public Cluster(SerializationInfo info, StreamingContext ctxt)
        {
            solarSystems = (List<SolarSystem>)info.GetValue("solarsystem", typeof(List<SolarSystem>));
            position = (Position)info.GetValue("solarposition", typeof(Position));
            ClusterType = (int)info.GetValue("clusterType", typeof(int));
            ClusterID = (int)info.GetValue("clusterid", typeof(int));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("solarsystem", typeof(List<SolarSystem>));
            info.AddValue("solarposition", typeof(Position));
            info.AddValue("clusterType", typeof(int));
            info.AddValue("clusterid", typeof(int));
        }

    }
}
