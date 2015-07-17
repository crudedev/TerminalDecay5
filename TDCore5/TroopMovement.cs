using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDCore5
{
    public class TroopMovement
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
    }
}
