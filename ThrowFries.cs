using System;

namespace mis321_pa2_dcmeisenheimer
{
    public class ThrowFries : IThrowBehavior
    {
        public string AttackType{get; set;} //property that stores the attack name
        public int Damage{get; set;} //Method for generating damage
        public string ThrowType() //Method to assign Attack type and return value
        {
            AttackType = "Throws French Fries";
            return AttackType;
        }
        public int ThrowDamage() //method to generate random throw power
        {
            Random rnd = new Random();
            Damage = rnd.Next(1, 100);

            return Damage;
        }
    }
}
