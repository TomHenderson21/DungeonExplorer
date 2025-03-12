using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player
    {
        public string Name { get; private set; } 
        public int Health { get; private set; }

        private List<string> inventory = new List<string> {};   //Create an empty inventory list for items to be added to
        private List<string> ItemsForUse = new List<string> {"Sword", "Shield", "Spear"};   //Create a list of items that can be found
        Random random = new Random();   //Initialise random function
        
        public Player(string name, int health) 
        {
            Name = name;
            Health = health;   
        }
        public void PickUpItem()
        {
            if (inventory.Count < 3)    //If user inventory count is below 3 allow for items to found
            {
                string chosenItem = ItemsForUse[random.Next(ItemsForUse.Count)];    //Select a random item from ItemsForUse each time
                Console.WriteLine($" you picked up a {chosenItem}.");
                inventory.Add(chosenItem);  //Add the item found to the inventory list
                ItemsForUse.Remove(chosenItem); //Removed the item found from the item list once found to stop duplicates after a comment from reviewer
            }
            else if (inventory.Count == 3)  //If user inventory is at 3 don't allow anymore items to be found as all possible items found
            {
                Console.WriteLine(" you didnt find anything, this room has been fully searched.");
            }
        }
        public void InventoryContents()
        {
            if (inventory.Count == 0)   //If the user checks inventory when no items in there show the following
            {
                Console.WriteLine("you currently have no items in your inventory.");
            }
            else     //As long as the inventory has items show the following
            {
                Console.WriteLine("your inventory contains: " + string.Join(", ", inventory));
            }
        }
    }
}