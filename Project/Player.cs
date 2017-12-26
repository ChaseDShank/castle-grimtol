using System;
using System.Collections.Generic;


namespace CastleGrimtol.Project
{
    public class Player : IPlayer
    {
        public string  Name {get; set;}
        public int Score { get; set; }
        public List<Item> Inventory { get; set; }
        
        public Player()
        {
            Name = userName();
            Score = 0;
            Inventory = new List<Item>();
        }

         public string userName(){
            Console.Write("Hello, please enter your name: ");
            string userName = Console.ReadLine();
            return userName;
        }





    }
}