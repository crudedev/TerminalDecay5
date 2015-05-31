using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace TerminalDecay5Server
{ 
    [Serializable()]
    public class Position : ISerializable
    {
        public int X;
        public int Y;

        public Position()
        {

        }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }


        public Position(SerializationInfo info, StreamingContext ctxt)
        {
            this.X = (int)info.GetValue("px", typeof(int));
            this.Y = (int)info.GetValue("py", typeof(int));              
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("px", this.X);
            info.AddValue("py", this.Y);
        }
    }
}
