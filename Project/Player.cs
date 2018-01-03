using System;
using System.Collections.Generic;

namespace CastleGrimtol.Game
{
  public class Player : IPlayer
  {
    public string CharacterName;
    public int Health { get; set; }
    public int Score {get; set;}
    public List<Item> Inventory { get; set; }
    public int Ammo{get; set;}
    public Player()
    {
      CharacterName = NameCharacter();
      Health = 11;
      Score = 0;
      Ammo = 2;
      Inventory = new List<Item>();
    }
    public string NameCharacter()
    {
      Console.ForegroundColor = ConsoleColor.Black;
      Console.WriteLine(@"
      What do you want to be called?");
      Console.Write(@"
      Your name: ");
      Console.ForegroundColor = ConsoleColor.Blue;
      string input = Console.ReadLine();
      if(input != ""){
          CharacterName = input;
      }
      else{
          CharacterName = "Dillweed";
      }
      Console.Clear();
      Console.ForegroundColor = ConsoleColor.Black;
      Console.WriteLine(@"
      Okay, {0}, you just woke up in a basement, and you can't remember how you got here...
      
      You hear a groan coming from the next room

      Your mission is to kill everything.", CharacterName);
      return CharacterName;
    }
    public void ShowInventory(Player player)
    {
      Console.ForegroundColor = ConsoleColor.DarkCyan;
      Console.WriteLine(@"
      __________________Inventory_______________");
      for (int i = 0; i < player.Inventory.Count; i++)
      {
        Console.Write($@"
      {player.Inventory[i].Name}  :  {player.Inventory[i].Description}");
      }
      if(player.Inventory != null){
      Console.WriteLine($@"
      Ammo  :  {player.Ammo}
      __________________________________________
      
      ");
      }
    }
  }
}