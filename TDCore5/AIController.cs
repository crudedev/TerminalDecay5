using System;
using System.Runtime.Serialization;


namespace TDCore5
{
    [Serializable()]
    public class AIController: ISerializable
    {
        public float TurtleAttacking;
        public float ActionDelayMultiplier;
        public float HelpSelfish;
        public Outpost Outpost;
        public int ActionDelay;
        public int AttackDealy;
        
        public AIController()
        {

        }

        public AIController(SerializationInfo info, StreamingContext ctxt)
        {

            TurtleAttacking = (float)info.GetValue("TurtleAttacking", typeof(float));
            ActionDelayMultiplier = (float)info.GetValue("ActionDelayMultiplier", typeof(float));
            HelpSelfish = (float)info.GetValue("HelpSelfish", typeof(float));
            Outpost = (Outpost)info.GetValue("AIOutpost", typeof(Outpost));
            ActionDelay = (int)info.GetValue("ActionDelay", typeof(int));
            AttackDealy = (int)info.GetValue("AttackDealy", typeof(int));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("TurtleAttacking", TurtleAttacking);
            info.AddValue("ActionDelayMultiplier", ActionDelayMultiplier);
            info.AddValue("HelpSelfish", HelpSelfish);
            info.AddValue("AIOutpost", Outpost);
            info.AddValue("ActionDelay", ActionDelay);
            info.AddValue("AttackDelay", AttackDealy);

        }
    }
}
