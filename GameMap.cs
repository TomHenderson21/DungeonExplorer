using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class GameMap
    {
        private List<Room> rooms = new List<Room>(); //Create a new list to add my new rooms to
        private int currentRoom = 0;   //Current room is the 1st room in the list

        public GameMap()
        {
            rooms.Add(new Room("large room with a flight of stairs in the middle with tree roots leading up the stair case"));
            rooms.Add(new Room("small room full of tree roots leading to a tree trunk in the middle", new Monster("Goblin", 20, 10, "Show me what you've got")));   //Goblin room
            rooms.Add(new Room("small dark room with a flickering flame in the middle that ever so slightly lightens up the room, and the sound of water pattering against the floor echos throughout"));
            rooms.Add(new Room("a large room lit up with flames and a boxing ring in the middle and minecraft villagers surrounding the ring", new Monster("Chicken Jockey", 60, 15, "Chicken Jockey")));   //Chicken Jockey room
            rooms.Add(new Room("a large room filled with ivy and moss hiding the walls"));
            rooms.Add(new Room("a cold dark room with gym equipment everywhere and the sound of weights clashing echoes throughout", new Monster("Purple Aki", 90, 20, "Gis a squeeze"))); //  Purple Aki room
        }

        public Room CurrentRoom()
        {
            return rooms[currentRoom];  //Return the current room the user is in 
        }

        public bool NextRoom()
        {
            if (currentRoom < rooms.Count - 1)  //Move to new rooms while user isn't in the last room
            {
                currentRoom++;  //Increment current room by 1
                return true;
            }
            return false;
        }

        public void PreviousRoom()
        {
            if (currentRoom > 0)    //Move to previous room as long as the user isn't in the first room 
            {
                currentRoom--;  //Increment back a room by 1
                return;
            }
            Console.WriteLine("\nYou are in the first room, you cant go to a previous room.");    //Let the user know they cant move back as they are in the first room 
        }

        public void LastRoom()  //Code for when the user enters the last room
        {
            Console.WriteLine("\nYou have entered a new room, a room with a flame on the wall next to a door.");
            Console.WriteLine("You approach the door and grab into you bag and retrieve the key, you insert the key into the door lock and the door opens.");
            Console.WriteLine("You are hit with blinding sun distorting your vision for a second, it quickly disappears and you step out of the door and are welcomed into Limgrave");
            Console.WriteLine("Who knows what you may find exploring Limgrave....");
            Console.WriteLine("\nCongratulations, you made it out and completed my game.");
            Console.WriteLine("\nThank you for playing my game and embarking on this journey.");
            Environment.Exit(0);    //Finish the Program as the user has completed escaping the dungeon explorer
        }
    }
}