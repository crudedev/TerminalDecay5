using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace TerminalDecay5Server
{    
    [Serializable()] 
    public class MapTile : ISerializable
    {
        public Int64 X;
        public Int64 Y;

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

            this.X = (long)info.GetValue("x", typeof(long));
            this.Y = (long)info.GetValue("y", typeof(long));
            this.Resources = (List<long>)info.GetValue("resources", typeof(List<long>));
            this.MaxResources = (List<long>)info.GetValue("maxresources", typeof(List<long>));
            
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("x", this.X);
            info.AddValue("y", this.Y);
            info.AddValue("resources", this.Resources);
            info.AddValue("maxresources", this.MaxResources);
        }
        
    }
}
