using System;

namespace mis321_pa2_dcmeisenheimer
{
    public class Characters
    {
        public string Name {get; set;}
        public int Health {get; set;}
        public int ThrowPower{get; set;}
        public int DefensePower{get; set;}
        public string PlayerAction{get; set;}
        public double MaxPower {get; set;}

        public IThrowBehavior myThrow {get; set;}

        public void SetThrowBehavior(IThrowBehavior myThrow) //Allows user set their own interface behavior
        {
            this.myThrow = myThrow;
        }
        public void SetHealth(int Health) //Sets figher healt
        {
            this.Health = Health;
        }
        public void SetThrowPower(int ThrowPower) //Sets Throw Power for Interface Class
        {
            this.ThrowPower = ThrowPower;
        }
        public int GetDefensePower() //Random Defense Generator
        {
            Random rnd = new Random();
            DefensePower = rnd.Next(1,100); //Between 1 - 100 
            return DefensePower; //returns defense 
        }
        public void BonusPower(Characters otherPlayer) //Bonus attack method
        {
            MaxPower = 1.2; //User is facing someone with a damage multiplier of 1.2
            double damage =(double)(otherPlayer.ThrowPower - DefensePower) * MaxPower; //Formula to solve damage
            if (damage < 0) //If user health and defense is greater than attack user is unaffected
            {
                System.Console.WriteLine($"{otherPlayer.Name} {otherPlayer.myThrow.ThrowType()} \nThe enemy deals {otherPlayer.ThrowPower} damage with a power multiplier of {MaxPower} \nLuckily your defense was {DefensePower} and the attack was inaffective");
            }
            else //User will take damage and lose health
            {
                System.Console.WriteLine($"{otherPlayer.Name} {otherPlayer.myThrow.ThrowType()} \nThe enemy deals {otherPlayer.ThrowPower} damage\nYour defense of {DefensePower} was not enough \nEnemy hit a bonus multiplier of {MaxPower} and dealt {damage} damage to your health \nThe attack was super effective");
                Health = Health - (int)damage;
            }
            System.Console.WriteLine();
            PlayerStats(); //Displays current player stats
            Console.ReadLine();
            
        }
        public void DamageDealt(Characters otherPlayer) //Regular Attack Method
        {
            MaxPower = 1; ////User is facing someone with a damage multiplier of 1
            double damage = (double)(otherPlayer.ThrowPower - DefensePower) * MaxPower; //Formula to solve damage
            if (damage < 0) //If user health and defense is greater than attack user is unaffected
            {
                System.Console.WriteLine($"{otherPlayer.Name} {otherPlayer.myThrow.ThrowType()} \nThe enemy deals {otherPlayer.ThrowPower} damage with a power multiplier of {MaxPower} \nLuckily your defense was {DefensePower} and the attack was inaffective");
            }
            else //User will take damage and lose health
            {
                System.Console.WriteLine($"{otherPlayer.Name} {otherPlayer.myThrow.ThrowType()} \nThe enemy deals {otherPlayer.ThrowPower} damage\nYour defense of {DefensePower} was not enough \nEnemy hit a bonus multiplier of {MaxPower} and dealt {damage} damage to your health \nThe attack was super effective");
                Health = Health - (int)damage;
            }
            System.Console.WriteLine();
            PlayerStats(); //Displays current player stats
            Console.ReadLine();
            
        }
        public void PlayerStats() //Displays current players stats
        {
            System.Console.WriteLine($"Player Stats: \nName: {Name} \nHealth: {Health} \nFighting Style: {PlayerAction}"); 
        }
    }
}
