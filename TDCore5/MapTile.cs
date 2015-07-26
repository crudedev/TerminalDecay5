using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TDCore5
{    
    [Serializable()] 
    public class MapTile : ISerializable
    {
        public Position position;

        public List<long> Resources;
        public List<long> MaxResources;


        public MapTile()
        {
            Resources = new List<long>();
            MaxResources = new List<long>();
            foreach (var r in Cmn.Resource)
            {
                Resources.Add(0);
                MaxResources.Add(0);
            }
        }


        public MapTile(SerializationInfo info, StreamingContext ctxt)
        {

            position = (Position)info.GetValue("maptileposition", typeof(Position));
            Resources = (List<long>)info.GetValue("resources", typeof(List<long>));
            MaxResources = (List<long>)info.GetValue("maxresources", typeof(List<long>));
            
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("maptileposition", position);
            info.AddValue("resources", Resources);
            info.AddValue("maxresources", MaxResources);
        }
        
    }
}
