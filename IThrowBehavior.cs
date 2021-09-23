using System;

namespace mis321_pa2_dcmeisenheimer
{
    public interface IThrowBehavior
    {
        public string ThrowType(); //Method for showing throw type
        public int ThrowDamage(); //Method for generating damage
        public string AttackType{get; set;} //property that stores the attack name
        public int Damage{get; set;} //property that stores the damage amount
    }
}
