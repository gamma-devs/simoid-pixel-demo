using System.Collections;
using System.Collections.Generic;

namespace CombatClasses{
    public struct CombatAction
    {
        public string name;
        public int damage;
        public int healing;
        public int effectID;
        public int sourceID;
        public int targetID;
        public string[] statusEffects;
    }
}
