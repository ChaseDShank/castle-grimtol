using System;
using System.Collections.Generic;

namespace CastleGrimtol.Game {
    public class Game : IGame {
        public Boolean Playing { get; set; }
        public Room CurrentRoom { get; set; }
        public List<Room> Rooms { get; set; }
        public Player CurrentPlayer { get; set; }
        public void Setup () {
            Console.Clear ();
            CurrentPlayer = new Player ();
            if (CurrentPlayer.CharacterName == "D$") {
                Win ();
            }
            Rooms = new List<Room> ();
            Console.WriteLine ("\n\n\nPress 'ENTER' to continue");
            string input = Console.ReadLine ();
            Help ();
            
        }
        public string GetUserInput () {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine ("\nWhat is your next move {0}?\n", CurrentPlayer.CharacterName);
            Console.ForegroundColor = ConsoleColor.Blue;
            string input = Console.ReadLine ();
            return input;
        }

        public void PromptReset(){
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(@"
            Are you sure you want to restart game? ");
            Console.ForegroundColor = ConsoleColor.Green;
            string pick = Console.ReadLine();
            if(pick == "yes" || pick == "y"){
                Reset();
            }
            else{
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("ok");
            }
        }
        public void Reset () {
            Playing = true;

            Setup ();
            BuildRooms ();
        }
        public void UseItem (string itemName) {

            Item item = CurrentPlayer.Inventory.Find (Item => Item.Name.ToLower () == itemName);

            if (item != null && item.Name.ToLower () == "gun" && CurrentPlayer.Ammo != 0) {
                Console.Clear ();
                Fire ();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine ("Bang!");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine ("Ammunition remaining: {0}", CurrentPlayer.Ammo);

            }
            if (item != null && item.Name.ToLower () == "gun" && CurrentPlayer.Ammo == 0) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine ("\n\n\nYou're out of ammo {0}!!\n\n", CurrentPlayer.CharacterName.ToUpper ());
                Console.ForegroundColor = ConsoleColor.Black;
            }
            if (item != null && item.Name.ToLower () == "ammo") {
                Reload ();
                Console.WriteLine ("Reloaded 1 round");
                Console.WriteLine ("You have {0} remaining rounds", CurrentPlayer.Ammo);
            }
            if (item == null) {
                Console.WriteLine ("That's not an option bucko");
            }
        }
        public void TakeItem (string itemName) {
            Item item = CurrentRoom.Items.Find (Item => Item.Name.ToLower () == itemName);
            if (item != null) {
                CurrentRoom.Items.Remove (item);
                CurrentPlayer.Inventory.Add (item);
                CurrentPlayer.ShowInventory (CurrentPlayer);
            }
            if (itemName.ToLower () == "ammunition" || itemName.ToLower () == "ammo") {
                CurrentPlayer.Ammo++;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine (@"
                1 round added
                Ammo: {0}", CurrentPlayer.Ammo);
                Console.ForegroundColor = ConsoleColor.Black;

            }
            if (itemName.ToLower () == "gun" && CurrentPlayer.Inventory.Contains (item)) {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine ("\"This might come in handy\"");

            }
        }
        public Boolean Quit (Boolean playing) {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine ("\nAre you sure you want to quit? Y/N\n\n\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            string input = Console.ReadLine ().ToLower ();
            Console.ForegroundColor = ConsoleColor.Black;

            if (input == "y" || input == "yes") {
                Console.Clear ();
                Console.WriteLine (@"
            Goodbye {0}.", CurrentPlayer.CharacterName);
                Console.WriteLine (@"
            
            Final Health: {0}
            Final Score: {1}",
                CurrentPlayer.Health, CurrentPlayer.Score);
                return playing = false;
            } else {
                Console.WriteLine ("Good choice!");
                Look(CurrentRoom);
                return playing = true;
            }
        }

        public void Win () {
            Console.Clear ();
            if (CurrentPlayer.CharacterName == "D$") {
                Console.WriteLine (@"
                You are too powerfull D$ !!, 
                You automatically win");
            }
            else{
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine (@"
            You have beat the game {0}
            Final Health: {1}
            Final Score: {2}",
                CurrentPlayer.CharacterName, CurrentPlayer.Health, CurrentPlayer.Score);
            }
            Playing = false;
        }
        public void Lose () {
            Console.Clear ();
            Console.WriteLine (@"
            {0}, you DIED!
            Final Health: {1}
            Final Score: {2}",
                CurrentPlayer.CharacterName, CurrentPlayer.Health, CurrentPlayer.Score);
            Playing = false;
        }
        public void CheckScore () {
            if (CurrentPlayer.Score == 10) {
                Win ();
            }
            if (CurrentPlayer.Health == 0) {
                Lose ();
            }
        }

        public void Reload () {
            CurrentPlayer.Ammo++;
        }
        public void Fire () {
            CurrentPlayer.Ammo--;
            if (CurrentRoom.Zombies != 0) {
                CurrentRoom.Zombies--;
                CurrentPlayer.Score++;
                Console.WriteLine (@"
            Zombie down!
            {0} remaining", CurrentRoom.Zombies);
            } else {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine (@"
            You shoot randomly and the bullet ricochettes and hits you");
                CurrentPlayer.Health--;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            Console.WriteLine (@"
            Health: {0}
            Score:  {1}", CurrentPlayer.Health, CurrentPlayer.Score);
            Console.Beep (400, 50);

        }
        public void Look (Room room) {

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(@"
Health: {0}
Score {1}", CurrentPlayer.Health, CurrentPlayer.Score);
            Console.WriteLine (@"
______________________________________________________________________________________________________________________");
            Console.Write ("Current Location: ");
            Console.WriteLine ($"\n\n{room.Name} :  {room.Description}\n");

            if (CurrentRoom.Zombies > 1) {
                Console.WriteLine ("\n\n\nthere are {0} zombies in this room\n\n\n", CurrentRoom.Zombies);
            }
            if (CurrentRoom.Zombies == 1) {
                Console.WriteLine ("\n\n\nthere is {0} zombie in this room\n\n\n", CurrentRoom.Zombies);
            }

            Console.WriteLine ("Items:\n");
            for (int i = 0; i < room.Items.Count; i++) {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine ($"{room.Items[i].Name}");
                Console.WriteLine ($"{room.Items[i].Description}");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine (@"
______________________________________________________________________________________________________________________");

            }
        }
        public void Help () {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine (@"
_________________________________________________
                   Help Menu                     
                                                 
Commands:                                        
    Use          + (item name)                   
    Take (t)     + (item name)                   
    Direction (w): move in the desired direction 
    Inv (i)      : display current inventory          
    Look (l)     : look around current room            
    Help (h)     : opens this menu               
    Restart (r)  : restart game                            
    Quit (q)     : quit game                     
                                                 
                                                 
_________________________________________________");
            Console.BackgroundColor = ConsoleColor.White;

        }
        public void BuildRooms () {
            Room room1 = new Room (@"Room 1",
                @"It's pretty filthy down here, not much to look at besides your pool of vomit.
            Exits: EAST & WEST",
                0);
            Room room2 = new Room (@"Room 2",
                @"A dimly lit room, with blood on the walls. 
            Exits: South, West",
                2);
            Room room3 = new Room (@"Room 3",
                @"Another dimly lit room with even more blood on the walls. 
            Exits: North, East",
                5);
            Room room4 = new Room (@"Room 4",
                @"Room 4 description There appears to be a Chest in the corner.
            Exits: West
                                    *hint: 'openchest'  
            ",
                2);
            Room room5 = new Room (@"Room 5",
                @"Where did this room come from?
                
            Exits: East",
                1);
            Room chest = new Room (@"Old Cedar Chest",
                @"There is a golden key in here, nice.
            *hint: 'closechest'",
                0);

            AddRooms ();

            void AddRooms () {
                Rooms.Add (room1);
                Rooms.Add (room2);
                Rooms.Add (room3);
                Rooms.Add (room4);
                Rooms.Add (room5);
                Rooms.Add (chest);

                AddExits ();
            }
            CurrentRoom = room1;

            void AddExits () {
                room1.AddDoor ("w", room5);
                room1.AddDoor ("e", room2);
                room2.AddDoor ("w", room1);
                room2.AddDoor ("s", room3);
                room3.AddDoor ("n", room2);
                room3.AddDoor ("e", room4);
                room4.AddDoor ("w", room3);
                room4.AddDoor ("openchest", chest);
                chest.AddDoor ("closechest", room4);
                room5.AddDoor ("e", room1);

                SpawnItems ();
            }

            void SpawnItems () {
                Item gun = new Item ("Gun", ".45 caliber revolver.");
                room1.Items.Add (gun);
                Item ammo = new Item ("Ammunition", "An bottomless box of .45 ammo.");
                room2.Items.Add (ammo);
                Item key = new Item ("Key", "Key to that locked door, probably");
                chest.Items.Add (key);
            }
        }
    }
}