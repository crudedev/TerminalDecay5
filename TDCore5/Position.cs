using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace TDCore5
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
            X = (int)info.GetValue("px", typeof(int));
            Y = (int)info.GetValue("py", typeof(int));              
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("px", X);
            info.AddValue("py", Y);
        }
    }
}
