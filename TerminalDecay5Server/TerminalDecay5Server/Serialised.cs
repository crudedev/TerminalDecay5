using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace TerminalDecay5Server
{
    [Serializable()]
    public class Serialised : ISerializable
    {
        private Universe u;

        public Universe tu
        {
            get { return this.u; }
            set { u = value; }
        }

        public Serialised(SerializationInfo info, StreamingContext ctxt)
        {
            this.tu = (Universe)info.GetValue("u", typeof(Universe));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("u", this.tu);
        }

        public Serialised()
        {
            
        }

        public Serialised(Universe inu)
        {
            tu = inu;
        }


    }
}
