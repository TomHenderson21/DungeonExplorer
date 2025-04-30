using System;

namespace DungeonExplorer
{
    public class Player : Creature, IDamageable   //Implements IDamageable interface and creature abstract class

    {
        public string Name { get; private set; }    //Public so the user can see their name and health
        public int Health { get; set; }
        public Inventory Inventory { get; private set; }    

        public Player(string name, int health)  //Give a player a name and health
        {
            Name = name;
            Health = health;
            Inventory = new Inventory();
        }
        
        public void DamageRecieved(int damage)  //Body for DamageRecieved
        {
            Health -= damage;   //Players health reduced by damage value
            Console.WriteLine($"\n{Name} has taken {damage} damage. {Health} health remaining");    //Tell user how much damage they took and how much health remains
            if (Health <= 0)
            {
                Console.WriteLine("\nYOU DIED!");   //If health is below or equal to 0 let user know they died
                Console.WriteLine("\nThank you for playing this game, but better luck on your next journey.");
                Environment.Exit(0);    //End program as user has died and they can't continue
            }
        }

        public int DealtDamage(int damage)  //Body for DealtDamage
        {
            Console.WriteLine($"\n{Name} has attacked the monster and dealt {damage} damage.");  //Tell user how much damage they have done to monster
            return damage;
        }

        public override void AttackStyle()  //Override class to customise attack style to Player
        {
            Console.WriteLine($"\n{Name} attacks the monster by running and hitting it with there weapon.");
        }
    }
}