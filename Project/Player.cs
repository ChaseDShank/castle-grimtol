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
      Health = 10;
      Score = 0;
      Ammo = 2;
      Inventory = new List<Item>();
    }
    public string NameCharacter()
    {
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
      The florescent lights are so bright, and the constant 'bzzzz' is only worsening your headache. 
      A raunchy scent triggers a fleeting memory into last night's terrible scene.

      You open your eyes and see that you've been sleeping in - what seems to be, rather -
      what you hope to be, your own vommit.

      You feel like death.
      
      You hear a groan coming from the next room", CharacterName);
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