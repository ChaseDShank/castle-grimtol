using System;
using CastleGrimtol.Project;

namespace CastleGrimtol {
    public class Program {
        public static void Main (string[] args) {

            Game game = new Game ();
            game.playing = true;
            game.Setup ();
            game.Help ();

            while (game.playing) {
                Console.WriteLine ("this is the first room");
                string command = game.GetCommand ();
                if (command == "q" || command == "quit") {
                    Console.WriteLine ("Are you sure you want to quit? (Y/N)");
                    string affirmation = Console.ReadLine ().ToLower ();
                    if (affirmation == "y" || affirmation == "yes") {
                        Console.WriteLine ("\nAight, peace homes");
                        game.playing = false;
                    } else if (affirmation == "n" || affirmation == "no") {
                        continue;
                    }
                   

                } else if (command == "") {
                    Console.WriteLine ("wat?");
                } else if (command == "help" || command == "h") {
                    game.Help ();
                }

            }
        }
    }
}