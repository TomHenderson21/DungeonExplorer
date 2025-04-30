using System;

namespace DungeonExplorer
{
    public class Item : ICollectible //Implements ICollectible
    {
        public string ItemName { get; private set; } //Get and set item name
        public int ItemDamage { get; private set; } //Get and set item damage
        public int ItemHealing { get; private set; } //Get and set item healing
        public string ItemType { get; private set; } //Get and set item type

        public Item(string itemName, int itemDamage, int itemHealing, string itemType) //Give item a name, damage, healing, type. Used in Inventory class to assign weapons names and stats
        {
            ItemName = itemName;
            ItemDamage = itemDamage;
            ItemType = itemType;
            ItemHealing = itemHealing;
        }
        

        public void WeaponCollected() //Body for Weapon collected
        {
            Console.WriteLine($"\n{ItemName}, Type: {ItemType}, Damage: {ItemDamage}"); //Tell the user the items name, item is a weapon and that the weapon deals however much damage
        }

        public void PotionCollected() //Body for potion collected
        {
            Console.WriteLine($"\n{ItemName}, Type: {ItemType}, Heal: {ItemHealing}"); //Tell user the item name, item is a potion and the amount of health the user will regain 
        }
    }
}