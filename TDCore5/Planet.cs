using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TDCore5
{
    [Serializable()]
    public class Planet : ISerializable
    {

        public List<MapTile> mapTiles;
        public Position position;

        public int planetType;

        public Planet()
        {

        }

        public Planet(SerializationInfo info, StreamingContext ctxt)
        {
            this.mapTiles = (List<MapTile>)info.GetValue("mapTiles", typeof(List<MapTile>));
            this.position = (Position)info.GetValue("planetposition", typeof(Position));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("mapTiles", typeof(List<MapTile>));
            info.AddValue("planetposition", typeof(Position));
        }

    }
}
