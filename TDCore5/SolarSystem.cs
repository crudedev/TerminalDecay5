using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TDCore5
{
    [Serializable()]
    public class SolarSystem : ISerializable
    {
        public List<Planet> planets;
        public Position position;

        public int SolarSystemType;

        public SolarSystem()
        {

        }

        public SolarSystem(SerializationInfo info, StreamingContext ctxt)
        {
            this.planets = (List<Planet>)info.GetValue("Planet", typeof(List<Planet>));
            this.position = (Position)info.GetValue("planetposition", typeof(Position));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("Planet", typeof(List<Planet>));
            info.AddValue("planetposition", typeof(Position));
        }
    }
}
