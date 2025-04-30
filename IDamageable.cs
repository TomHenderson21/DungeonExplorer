using System;

namespace DungeonExplorer
{
    public interface IDamageable    //Create interface
    {
        void DamageRecieved(int damage);    //Interface method without body, int damage as numbers will be needed to show damage a player or monster receives or gives
        int DealtDamage(int damage);    //Interface method without body, int damage as numbers will be needed to show the damage the player and monster are dealing to one another
    }
}