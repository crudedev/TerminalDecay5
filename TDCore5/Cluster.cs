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


        public Cluster()
        {

        }

        public Cluster(SerializationInfo info, StreamingContext ctxt)
        {
            this.solarSystems = (List<SolarSystem>)info.GetValue("solarsystem", typeof(List<SolarSystem>));
            this.position = (Position)info.GetValue("solarposition", typeof(Position));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("solarsystem", typeof(List<SolarSystem>));
            info.AddValue("solarposition", typeof(Position));
        }

    }
}
