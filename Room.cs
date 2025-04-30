using System;

namespace DungeonExplorer
{
    public class Room
    { 
        private string description; 
        private Monster monster;

        public Room(string description, Monster monster = null) //Give a room a description and monster is null unless a monster is in the room
        {
            this.description = description;
            this.monster = monster;
        }
        public string GetDescription()
        {
            return description; //Return current room description
        }

        public Monster GetMonster()
        {
            return monster; //Return current room monster if one is present
        }
    }
}