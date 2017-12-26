using System;
using System.Collections.Generic;

namespace CastleGrimtol.Project {
    public class Game : IGame {

        public Room CurrentRoom { get; set; }
        public Player CurrentPlayer { get; set; }

        public bool playing { get; set; }
        
        public void Reset () {
            Setup ();
        }

        public void Setup () {
            Console.Clear();
            CurrentPlayer = new Player ();
            Console.Clear ();
            Console.WriteLine ("Hello {0}\n", CurrentPlayer.Name);
            Console.WriteLine ("Welcome to the matrix, this is going to be a journey\n");

        }

        public void Help () {
            Console.Clear();
            Console.WriteLine (@"
{0}, here are your Commands:
                            'Help' - pulls up this menu
                            'Quit' - quit game
                            'Look' - look around room to discover clues / items
                            'Use'  - use items
                            'Go'   - move player from room to room (must be used with directional command)
                                     i.e. : Go North
        
        Type 'ok' to exit help menu        ", CurrentPlayer.Name);
            string command = GetCommand();
            if(command == "ok"){
                Console.Clear();
            }
            else{
                Console.Clear();
                Help();
            }

        }

        public string GetCommand () {
            string command = Console.ReadLine ();
            return command;
        }

        public void UseItem (string itemName) {
            throw new System.NotImplementedException ();
        }
        //---------------------------------------------------------------------------------//

    }
}