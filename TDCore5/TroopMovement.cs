using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TDCore5
{
    [Serializable()]
    public class TroopMovement : ISerializable
    {
        public Cmn.MovType MovementType;

        public List<long> Defence;
        public List<long> Offence;

        public Outpost OriginOutpost;
        public Outpost DestinationOutpost;

        UniversalAddress Address;

        public int StartTick;
        public int Duration;

        public TroopMovement()
        {

            Defence = new List<long>();
            foreach (var d in Cmn.DefenceType)
            {
                Defence.Add(0);
            }

            Offence = new List<long>();
            foreach (var o in Cmn.OffenceType)
            {
                Offence.Add(0);
            }
                    }

        public TroopMovement(SerializationInfo info, StreamingContext ctxt)
        {
            MovementType = (Cmn.MovType)info.GetValue("movetype", typeof(Cmn.MovType));
            Defence = (List<long>)info.GetValue("Defence", typeof(List<long>));
            Offence = (List<long>)info.GetValue("Offence", typeof(List<long>));
            OriginOutpost = (Outpost)info.GetValue("OriginOutpost", typeof(Outpost));
            DestinationOutpost = (Outpost)info.GetValue("DestinationOutpost", typeof(Outpost));
            Address = (UniversalAddress)info.GetValue("Address", typeof(UniversalAddress));
            StartTick = (int)info.GetValue("StartTick", typeof(int));
            Duration = (int)info.GetValue("Duration", typeof(int));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("movetype", MovementType);
            info.AddValue("Defence", Defence);
            info.AddValue("Offence", Offence);
            info.AddValue("OriginOutpost", OriginOutpost);
            info.AddValue("DestinationOutpost", DestinationOutpost);
            info.AddValue("Address", Address);
            info.AddValue("StartTick", StartTick);
            info.AddValue("Duration", Duration);

        }
    }
}

