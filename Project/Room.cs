using System;
using System.Collections.Generic;

namespace CastleGrimtol.Game
{
  public class Room : IRoom
{
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Item> Items { get; set; }
    public int Zombies {get; set;}
    public Dictionary<string, Room> Exits = new Dictionary<string, Room>();
    public Room(string name, string description, int zombies)
    {
      Name = name;
      Description = description;
      Items = new List<Item>();
      Zombies = zombies;
      
    }
    public void AddDoor(string direction, Room room)
    {
      Exits.Add(direction, room);
    }

        public void UseItem(Item item)
        {
            throw new NotImplementedException();
        }
    }
}