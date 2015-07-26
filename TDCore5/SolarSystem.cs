using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TDCore5
{
    [Serializable()]
    public class SolarSystem : ISerializable
    {
        public List<Planet> planets;
        public Position position;

        public int SolarSystemType;

        public int SolarSystemID;

        public SolarSystem()
        {

        }

        public SolarSystem(SerializationInfo info, StreamingContext ctxt)
        {
            planets = (List<Planet>)info.GetValue("Planet", typeof(List<Planet>));
            position = (Position)info.GetValue("planetposition", typeof(Position));
            SolarSystemType = (int)info.GetValue("solarsystemtype", typeof(int));
            SolarSystemID = (int)info.GetValue("solarsystemid", typeof(int));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("Planet", typeof(List<Planet>));
            info.AddValue("planetposition", typeof(Position));
            info.AddValue("solarsystemtype", typeof(int));
            info.AddValue("solarsystemid", typeof(int));
        }
    }
}
