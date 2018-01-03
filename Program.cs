using System;
using System.Collections.Generic;
using CastleGrimtol.Game;

namespace CastleGrimtol {
    public class Program {
        public static void Main (string[] args) {
            Game.Game game = new Game.Game ();
            game.Playing = true;

            game.Setup ();
            game.BuildRooms ();
            game.Look (game.CurrentRoom);

            while (game.Playing) {
                game.CheckScore();
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                string userChoice = game.GetUserInput ().ToLower ();
                string[] userAction = userChoice.Split (' ');
                if(userChoice == "clear"){
                    Console.Clear();
                }
                Room nextRoom;
                game.CurrentRoom.Exits.TryGetValue (userAction[0], out nextRoom);
                if(game.CurrentRoom.Zombies > 0){
                    Console.WriteLine("Zombie attacks, deals 1 damage");
                    game.CurrentPlayer.Health --;
                }
                if (userAction[0] == "look" || userAction[0] == "l") {
                    game.Look (game.CurrentRoom);
                } else if (userAction[0] == "quit" || userAction[0] == "q") {
                    game.Playing = game.Quit (game.Playing);
                } else if (userAction[0] == "help" || userAction[0] == "h") {
                    game.Help ();
                } else if(userAction[0] == "restart" || userAction[0] == "r"){
                    game.PromptReset();
                }else if (userAction[0] == "take" && userAction[1] != null) {
                    game.TakeItem (userAction[1]);
                } else if (userAction[0] == "inventory" || userAction[0] == "inv" || userAction[0] == "i") {
                    game.CurrentPlayer.ShowInventory (game.CurrentPlayer);
                } else if (userAction[0] == "use" || userAction[0] == "u") {
                    game.UseItem (userAction[1]);
                    game.Look (game.CurrentRoom);
                } else if (nextRoom != null) {
                    game.CurrentRoom = nextRoom;
                    Console.WriteLine ("\n\n\n");
                    game.Look (game.CurrentRoom);
                } else {
                    Console.WriteLine ("Not sure what you are trying to do...");
                }
            }
        }
    }
}