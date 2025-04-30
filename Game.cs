using System;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;
        private GameMap map;

        public Game() 
        {
            Console.WriteLine("Welcome to the Dungeon Explorer Game!");
            Console.Write("\nEnter your preferred character name: ");
            string name = Console.ReadLine();   //Get the users input for the character name they want
            player = new Player(name, 100); //Give the player a name and health
            map = new GameMap();    //Calling a new map
            currentRoom = map.CurrentRoom();    //The currentRoom user is in is returned
        }
        
        public void Start() 
        {
            bool playing = true;
            Console.WriteLine($"\nWelcome, Tarnished {player.Name}. You are about to embark on your new journey in these dungeons but be careful on your discovery as who knows what you may find, remember you only have {player.Health} health.");
            Console.WriteLine("\nYou have a Sword and an Estus Flask to start with, any other items you find can be added to your inventory but beware there is a limit.");
            Console.WriteLine("Keep your eyes peeled as you may discover a key which may be needed to get out of the dungeon.");
            Console.WriteLine($"\nYou are currently in a {currentRoom.GetDescription()}.");   //Give the user a description of the room 
            Console.WriteLine("\nTo begin your journey you will have to decide what you want to do.");
            while (playing) //While playing true
            {
                Console.WriteLine("\nPlease choose what you want to do from the following..."); //Tell the user that they will now have to choose from the following options, shown on a new line each time for better readability
                Console.WriteLine("1) Room description");
                Console.WriteLine("2) Explore room");
                Console.WriteLine("3) Check inventory");
                Console.WriteLine("4) Check health");
                Console.WriteLine("5) Enter the next room");    //Option to go to new room after comment from a reviewer  
                Console.WriteLine("6) Enter previous room");
                Console.WriteLine("7) Use Estus Flask to heal");    //Option to regain health 
                Console.WriteLine("8) Exit the game");
                Console.Write("Please enter your choice with a number from 1 to 8: ");
                
                string userChoice = Console.ReadLine(); //Get the userChoice input as an integer

                switch (userChoice)
                {
                    case "1":
                        Console.WriteLine($"\nYou are in {currentRoom.GetDescription()}.");   //Room description shown again 
                        break;
                    case "2":
                        Console.Write("\nDuring your search around the room");    //Tells user what they found during room search
                        player.Inventory.PickUpItem();  //Call pickUpItem from the inventory to run its code to show the user what item they picked up 
                        player.Inventory.ReplaceContents(); //Call ReplaceContents from inventory, runs that code and user can change items in inventory
                        break;
                    case "3":
                        Console.Write("\nYou chose to check your inventory, ");    //Shows the user what is in their inventory
                        player.Inventory.InventoryContents();   //Call InventoryContents from inventory to run code to show user their inventory items
                        break;
                    case "4":
                        Console.WriteLine($"\nYou are currently at {player.Health} health out of 100.");  //Shows the user their health
                        break;
                    case "5":
                        if (map.NextRoom()) //Run NextRoom code as this has been selected
                        {
                            currentRoom = map.CurrentRoom();
                            Console.WriteLine($"\nYou walk through a tunnel and enter a new room: {currentRoom.GetDescription()}.");    //Return the current room description 
                            Monster currentMonster = currentRoom.GetMonster();  //Used to check if current room has a monster so corresponding code can be run
                            
                            if (currentMonster != null && currentMonster.Health <= 0) //Check if monster is in the room and if the monsters health is below or equal to 0 display following
                            { 
                                Console.WriteLine($"\nThe {currentMonster.Name} you just defeated is lay on the floor dead."); 
                            }
                            else if (currentMonster != null) //If room does contain a monster return following code, else it will just return the description from two lines above
                            {
                                Console.WriteLine($"\nWhen entering the room a {currentMonster.Name} appeared, it has {currentMonster.Health} health and deals {currentMonster.Damage} damage when it attacks, be careful.");   //Display monsters name, health and damage
                                Console.WriteLine($"\n{currentMonster.Name} has spotted you and says '{currentMonster.CatchPhrase}'."); //Display monsters catchphrase
                                Console.WriteLine("\nYou need to equip a weapon to use to fight.");
                                player.Inventory.DisplayStats();    //Display the current items in the users inventory and their stats 
                                Console.Write("\nPlease enter the name of the weapon you would like to equip: ");
                                string WeaponOfChoice = Console.ReadLine(); //Get users input fot weapon of choice
                                int WeaponDamage = 0;   //Weapon Damage for weapon is currently 0 
                                
                                if (WeaponOfChoice != null) //If user input isn't null check if the input matches any of the following and change weaponDamage value depending on weapon
                                {
                                    if (WeaponOfChoice == "Sword")
                                    {
                                        WeaponDamage = 20;
                                    }
                                    else if (WeaponOfChoice == "Estus Flask")   //If user selects a potion deal the user damage as they should have picked an item with a weapon type
                                    {
                                        Console.WriteLine("\nA potion can't be used to deal damage, as consequence you will lose damage");
                                        player.DamageRecieved(25);  //Deal player 25 damage as consequence
                                        WeaponDamage = 5;   //Make weapon damage low
                                    }
                                    else if (WeaponOfChoice == "Upgraded Sword")
                                    {
                                        WeaponDamage = 35;
                                    }
                                    else if (WeaponOfChoice == "Spear")
                                    {
                                        WeaponDamage = 18;
                                    }
                                    else if (WeaponOfChoice == "Halberd")
                                    {
                                        WeaponDamage = 22;
                                    }
                                    else if (WeaponOfChoice == "Dagger")
                                    {
                                        WeaponDamage = 15;
                                    }
                                    else if (WeaponOfChoice == "Trevelock")
                                    {
                                        WeaponDamage = 23;
                                    }
                                    else    //No match so let user know their input was unknown, as a consequence they will deal less damage
                                    {
                                        Console.WriteLine($"\n{WeaponOfChoice} is an unknown weapon choice.");  //Let user know their input was unknown
                                        Console.WriteLine($"\nAs you had an unknown choice {player.Name} uses their hands.");
                                        WeaponDamage = 5;   //User deals 5 damage with hands
                                    }
                                }
                                

                                Console.WriteLine("\n---------------------------------------------------------------------");   //Separate the users weapon choice and the start of the fight as it was hard to see when the fight started
                                
                                while (currentMonster.Health > 0 && player.Health > 0)  //While both monster and player health are above 0 make them fight until someone dies
                                {
                                    currentMonster.AttackStyle();
                                    int monsterDamage = currentMonster.DealtDamage(currentMonster.Damage);  //Using current monster run Dealtdamage using current monsters damage vlaue
                                    player.DamageRecieved(monsterDamage);   //Using damageRecieved deal the player the monstersdamage value, changing player health
                                    if (player.Health <= 0)
                                    {
                                        Console.WriteLine($"\n{currentMonster.Name} has {currentMonster.Health} health remaining.");    //Return monsters health when the player is dead
                                        break;
                                    }
                                    
                                    player.AttackStyle();   //Return the wasy the user attacks
                                    player.DealtDamage(WeaponDamage);
                                    currentMonster.DamageRecieved(WeaponDamage);    //Deal monster damage from the weapon of choices corresponding weapon damage
                                    if (currentMonster.Health <= 0)
                                    {
                                        Console.WriteLine($"\n{player.Name} has {player.Health} out of 100 health remaining."); //Return players health when current monster is dead
                                        break;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (player.Inventory.FinsihingKey())    //Only let user to the last room if they have a key in their inventory
                            {
                                map.LastRoom(); //Once all the rooms have been navigated through, use the last room to finish the game 
                            }
                            else    //If user doesn't have key run this code
                            {
                                Console.WriteLine("\nYou have entered a new room, a room with a flame on the wall next to a door.");
                                Console.WriteLine("You dont seem to have a key in your inventory to open the door.");
                                Console.WriteLine("You turn around to try and search for the key and a Imp was hidden among the ivy blending in.");
                                Console.WriteLine("The Imp jumps down onto you and it bites you in the neck and runs away.");
                                Console.WriteLine("You have been injured too much for an Estus Flask to even help you, you lay there helpless with the blood puddle around you getting bigger....");
                                Console.WriteLine("\nThank you for playing my game, better luck next time. On your next journey you may want to keep your eyes peeled for a key.");
                                playing = false;
                                Environment.Exit(0);    //Exit program as user has bled out 
                            }
                        }
                        break;
                    case "6":
                        map.PreviousRoom(); //User will enter previous room and monster won't reappear as it has 0 health
                        Console.WriteLine("\nYou have entered the previous room");
                        break;
                    case "7":
                        Console.WriteLine($"\nYou currently have {player.Health} health out of 100.");  //Tell user their health
                        if (player.Health >= 100)   //Don't drink flask if health is full
                        {
                            Console.WriteLine("\nYou have 100 health out of 100.");
                        }
                        if (player.Health < 100)   
                        {
                            player.Inventory.RemoveEstus(); //Check if inventory has an estus flask and restore health if it does 
                            player.Health += 25;
                            if (player.Health > 100)
                            {
                                player.Health = 100;
                            }
                            Console.WriteLine($"\n{player.Name} has {player.Health} health out of 100.");   //If health does go over 100 reset back to 100
                        }
                        break;
                    case "8":
                        Console.WriteLine("\nYou chose to exit the game.");   //Lets user exit game
                        playing = false;
                        break;
                    default:    //If none of the cases are met the following is shown
                        Console.WriteLine($"Please try again '{userChoice}' is an invalid choice, please enter a valid choice.");    //Tells user their choice was invalid and to enter a new valid choice
                        continue;
                }
            }
        }
    }
}