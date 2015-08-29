using System;
using System.Runtime.Serialization;


namespace TDCore5
{
    [Serializable()]
    public class AIController: ISerializable
    {
        public float ViolentExpansive;
        public float TurtleAttacking;
        public float ActiveInactive;
        public float HelpSelfish;
        public float CommittedChange;
        public Outpost Outpost;
        public int ActionDelay;


        public AIController()
        {

        }

        public AIController(SerializationInfo info, StreamingContext ctxt)
        {

            ViolentExpansive = (float)info.GetValue("ViolentExpansive", typeof(float));
            TurtleAttacking = (float)info.GetValue("TurtleAttacking", typeof(float));
            ActiveInactive = (float)info.GetValue("ActiveInactive", typeof(float));
            HelpSelfish = (float)info.GetValue("HelpSelfish", typeof(float));
            CommittedChange= (float)info.GetValue("CommittedChange", typeof(float));
            Outpost = (Outpost)info.GetValue("AIOutpost", typeof(Outpost));
            ActionDelay = (int)info.GetValue("ActionDelay", typeof(int));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("ViolentExpansive", ViolentExpansive);
            info.AddValue("TurtleAttacking", TurtleAttacking);
            info.AddValue("ActiveInactive", ActiveInactive);
            info.AddValue("HelpSelfish", HelpSelfish);
            info.AddValue("CommittedChange", CommittedChange);
            info.AddValue("AIOutpost", Outpost);
            info.AddValue("ActionDelay", ActionDelay);

        }
    }
}
