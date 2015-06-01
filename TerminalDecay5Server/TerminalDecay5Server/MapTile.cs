using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace TerminalDecay5Server
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

            this.position = (Position)info.GetValue("maptileposition", typeof(Position));
            this.Resources = (List<long>)info.GetValue("resources", typeof(List<long>));
            this.MaxResources = (List<long>)info.GetValue("maxresources", typeof(List<long>));
            
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("maptileposition", this.position);
            info.AddValue("resources", this.Resources);
            info.AddValue("maxresources", this.MaxResources);
        }
        
    }
}
