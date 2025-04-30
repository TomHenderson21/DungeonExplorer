using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonExplorer
{
    public class Inventory
    {
        private List<string> inventory = new List<string> {"Sword", "Estus Flask"}; //Updated the user invenotry so they start with items
        private List<string> ItemsForUse = new List<string> {"Upgraded Sword", "Spear", "Halberd", "Dagger", "Trevelock", "Key"}; //Items that can be found on the way
        private List<Item> Allitems = new List<Item>(); //Item list so I can add the stats to items
        private Random random = new Random();

        public Inventory()
        {
            Allitems.Add(new Item("Sword", 20, 0, "Weapon"));   //Add new items to the allitems list with relevant stats identified in the item class
            Allitems.Add(new Item("Estus Flask", 5, 25, "Potion")); //Make damage low as a consequence for not picking a weapon, same damage as fists
            Allitems.Add(new Item("Upgraded Sword", 35, 0, "Weapon"));
            Allitems.Add(new Item("Spear", 18, 0, "Weapon"));
            Allitems.Add(new Item("Halberd", 22, 0, "Weapon"));
            Allitems.Add(new Item("Dagger", 15, 0, "Weapon"));
            Allitems.Add(new Item("Trevelock", 23, 0, "Weapon"));
        }

        public void PickUpItem()
        {
            if (ItemsForUse.Count > 0 && inventory.Count < 5) //If user inventory count is below 5 allow for items to found
            {
                string chosenItem = ItemsForUse[random.Next(ItemsForUse.Count)]; //Select a random item from ItemsForUse each time
                Console.WriteLine($" you picked up a {chosenItem}.");
                inventory.Add(chosenItem); //Add the item found to the inventory list
                ItemsForUse.Remove(chosenItem); //Removed the item found from the item list once found to stop duplicates after a comment from reviewer
            }
            else    //If all items found no more can be found
            {
                Console.WriteLine(" you didnt pick up anything, all items must have been found.");
            }
        }

        public void InventoryContents()
        {
            Console.WriteLine("your inventory contains: " + string.Join(", ", inventory));  //Show the user their items in their inventory 
        }

        public void ReplaceContents()
        {
            if (inventory.Count >= 5)   //If the user has 5 items make them replace another item in inventory as 4 max items
            {
                Console.WriteLine("\nYour inventory is currently full: " + string.Join(", ", inventory));   //Show Invenotry
                Console.WriteLine("\nThe last item in the inventory is the item you just picked up, you need to decide what to replace. ");
                Console.Write("\nPlease enter the item in which you would like to replace or enter 'None' if you dont want to replace any: ");  //Tell user they will need to replace an item to add new item
                string WeaponPos = Console.ReadLine();  //Get the users input

                if (WeaponPos == "None")    //Don't replace any items
                {
                    inventory.RemoveAt(inventory.Count - 1);    //Remove the 5th item from the list
                    Console.WriteLine("\nYou chose to not replace anything.");
                    Console.WriteLine("\nYour current inventory contains: " + string.Join(", ", inventory));    //Show user their inventory 
                }
                else if (inventory.Contains(WeaponPos)) //Check if the inventory has the users input
                {
                    string chosenItem = inventory[random.Next(inventory.Count)];    
                    inventory.Remove(WeaponPos);    //Remove the user input item from the inventory
                    inventory.Add(chosenItem);  //Add new item to inventory
                    inventory.RemoveAt(inventory.Count - 1);    //Use this to delete duplicate item
                    Console.WriteLine($"\nYou replaced {WeaponPos} with {inventory[3]}.");  //Tell the user what weapon was replaced and what with
                    Console.WriteLine("\nYour new inventory: " + string.Join(", ", inventory));

                }
                else
                {
                    Console.WriteLine("\nYour input was invalid, you have lost the opportunity for this item.");    //If input is invalid remove it from being able to be found again
                    inventory.RemoveAt(inventory.Count - 1);    //Remove the newly picked up item from the list so the list is the same as before with only 4 items
                }
            }
        }
        
        public void RemoveEstus()
        { 
            if (inventory.Contains("Estus Flask"))  //Check if inventory has an estus flask
            { 
                Console.WriteLine("\nYou drank the Estus Flask and you have regained health.");
                inventory.Remove("Estus Flask");    //Remove from inventory once it's been used
            }
            else if (!inventory.Contains("Estus Flask"))
            { 
                inventory.Remove("Estus Flask");
                Console.WriteLine("\nYou dont have an Estus Flask to heal.");
            }
        }

        public void DisplayStats()
        {
            foreach (string i in inventory)  
            {
                Item ItemStats = Allitems.Find(x => x.ItemName == i);    //Foreach item in the inventory check if it's in allitems and return the items name, type, damage or healing
                if (ItemStats != null)
                {
                    if (ItemStats.ItemType == "Weapon") //If the item type is weapon run weapon collected
                    {
                        ItemStats.WeaponCollected();
                    }
                    if (ItemStats.ItemType == "Potion") //If the item type is potion run potion collected
                    {
                        ItemStats.PotionCollected();
                    }
                }
            }
        }

        public bool FinsihingKey()  
        {
            if (inventory.Contains("Key"))  //Check if the users inventory contains a key
            {
                Console.WriteLine("\nYou have collected the key, this is your means of escape.");
                return true;
            }
            return false;
        }
    }
}