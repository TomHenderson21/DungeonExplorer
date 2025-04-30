using System;

namespace DungeonExplorer
{
    public class Monster : Creature, IDamageable //Implements IDamageable class and creature abstract class
    {
        public string Name { get; private set; }    //Public so user can see monster name, health, damage, catchphrase                       
        public int Health { get; set; }
        public int Damage { get; private set; }
        public string CatchPhrase { get; private set; }

        public Monster(string name, int health, int damage, string catchPhrase) //Give monster a name, health, damage and catchphrase. Used in game map class to create new monsters
        {
            Name = name;
            Health = health;
            Damage = damage;
            CatchPhrase = catchPhrase;
        }

        public void DamageRecieved(int damage) //Body for DamageRecieved
        {
            Health -= damage; //Monsters health decreased by damage
            Console.WriteLine($"\n{Name} has {Health} health remaining."); //Tell the user how much damage the monster has taken and how much health they have left
            if (Health <= 0)
            {
                Console.WriteLine($"\n{Name} has been slain!"); //If monster health is below or equal to 0 tell user that they have killed it
            }
        }

        public int DealtDamage(int damage) //Body for DealtDamaged
        {
            Console.WriteLine($"\n{Name} attacks you dealing {damage} damage."); //Tell user the name of monster and how much damage it does to the user
            return damage;
        }

        public override void AttackStyle()  //Override class to customise attack style to Monster
        {
            Console.WriteLine($"\n{Name} attacks the player by charging and hitting you.");
        }
    }
}