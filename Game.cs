using System;
using System.Linq.Expressions;
using System.Media;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;

        public Game() 
        {
            Console.WriteLine("Welcome to the Dungeon Explorer Game!");
            Console.Write("Enter your preferred character name: ");
            string name = Console.ReadLine();   //Get the users input for the character name they want
            player = new Player(name, 100); //Give the player a name and health
            currentRoom = new Room("small dark room with a flickering flame in the middle that ever so slightly lightens up the room, and the sound of water pattering against the floor echos throughout.");
        }
        public void Start() 
        {
            bool playing = true;
            Console.WriteLine($"Welcome, Tarnished {player.Name}. You are about to embark on your new journey in these dungeons but be careful on your discovery as who knows what you may find, remember you only have {player.Health} health.");
            Console.WriteLine($"You are currently in a {currentRoom.GetDescription()}.");   //Give the user a description of the room 
            Console.WriteLine("To begin your journey you will have to decide what you want to do.");
            while (playing)
            {
                Console.WriteLine("\nPlease choose what you want to do from the following..."); //Tell the user that they will now have to choose from the following options, shown on a new line each time for better readability
                Console.WriteLine("1) Room description");
                Console.WriteLine("2) Explore room ");
                Console.WriteLine("3) Check inventory");
                Console.WriteLine("4) Check health");
                Console.WriteLine("5) Enter the next room");
                Console.WriteLine("6) Exit the game");
                Console.Write("Please enter your choice with the corresponding number: ");
                
                int userChoice = Convert.ToInt32(Console.ReadLine()); //Get the userChoice input as an integer
                
                if (userChoice == 1)
                {
                    Console.WriteLine($"Your are in {currentRoom.GetDescription()}.");  //Room description shown again 
                }
                else if (userChoice == 2)
                {
                    Console.WriteLine("During your search around the room");    //Tells user what they found during room search
                    player.PickUpItem();
                }
                else if (userChoice == 3)
                {
                    Console.WriteLine("You chose to check your inventory, ");   //Shows the user what is in their inventory
                    player.InventoryContents();
                }
                else if (userChoice == 4)
                {
                    Console.WriteLine($"You are currently at {player.Health} health out of 100.");  //Shows the user their health
                }
                else if (userChoice == 5)
                {
                    Console.WriteLine("You chose to enter the next room, this is currently unavailable.");  //Tell the user that this action is unavailable
                }
                else if (userChoice == 6)
                {
                    Console.WriteLine("You chose to exit the game.");   //Lets user exit game
                    playing = false;
                }
                else
                {
                    Console.WriteLine($"Please try again '{userChoice}' is an invalid choice, please enter a valid choice. ");  //If none of the userChoices ran tell the user to enter a valid choice
                }
            }
        }
    }
}