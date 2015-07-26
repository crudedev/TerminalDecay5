using System;
using System.Runtime.Serialization;

namespace TDCore5
{
    [Serializable()]
    public class BaseMovement : ISerializable
    {

        public Outpost OriginOutpost;
        public Position DestinationBase;
        public int StartTick;
        public int Duration;
        
        public BaseMovement()
        {

        }

        public BaseMovement(SerializationInfo info, StreamingContext ctxt)
        {
            OriginOutpost = (Outpost)info.GetValue("originOutpost", typeof(Outpost));
            DestinationBase = (Position)info.GetValue("destination", typeof(Position));
            StartTick = (int)info.GetValue("starttick", typeof(int));
            Duration = (int)info.GetValue("duration", typeof(int));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("originOutpost", OriginOutpost);
            info.AddValue("destination", DestinationBase);
            info.AddValue("starttick", StartTick);
            info.AddValue("duration", Duration);
        }
    }
}
