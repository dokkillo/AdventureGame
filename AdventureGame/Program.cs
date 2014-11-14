using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declares Room currentRoom and assigns it to the result of SetUpMap
            Room currentRoom = SetUpMap();
            string userChoice = "";

            // Game runs until players quits (enters "q")
            while (userChoice != "q")
            {
                // Displays current room information, sets "> " as input prefix,
                // and takes user input and sends it to lowercase...
                DescribeRoom(currentRoom);
                Console.Write("> ");
                userChoice = Console.ReadLine().ToLower();

                // ...So that it can be easily understood by our switch statement
                switch (userChoice)
                {
                    // If the player enters "n"...
                    case "n":
                        if (currentRoom.North != null)
                            currentRoom = currentRoom.North;
                        break;
                    // If the player enters "e"...
                    case "e":
                        if (currentRoom.East != null)
                            currentRoom = currentRoom.East;
                        break;
                    // If the player enters "s"...
                    case "s":
                        if (currentRoom.South != null)
                            currentRoom = currentRoom.South;
                        break;
                    // If the player enters "w"
                    case "w":
                        if (currentRoom.West != null)
                            currentRoom = currentRoom.West;
                        break;
                    // If the player enters "q"...
                    case "q":
                        Console.WriteLine("\nThanks for playing. Goodbye.");
                        break;
                    // Otherwise...
                    default:
                        Console.WriteLine("Please enter a valid option: (n, e, s, w, q)");
                        break;
                }
            }
        }

        static Room SetUpMap()
        {
            // Create Rooms
            Room library = new Room(
                "The Old Library",
                "You are in a large library. The walls are lined with old, dusty books.");

            Room northHall = new Room(
                "The North Hallway",
                "You are in the northern hallway. Portraits of the royal family watch you.");

            Room eastHall = new Room(
                "The East Hallway",
                "You are in the eastern hallway. A grandfather clock ticks loudly.");

            Room southHall = new Room(
                "The South Hallway",
                "You are in the southern hallway. Shelves crammed with scrolls line the walls.");

            Room westHall = new Room(
                "The West Hallway",
                "You are in the western hallway. Tall windows line the walls. There is a slight chilling wind.");

            // library exits
            library.North = northHall;
            library.East = eastHall;
            library.South = southHall;
            library.West = westHall;

            // northHall exits
            northHall.South = library;

            // eastHall exits
            eastHall.West = library;

            // southHall exits
            southHall.North = library;

            // westHall exits
            westHall.East = library;

            // Return the starting room
            return library;
        }

        static void DescribeRoom(Room room)
        {
            // Clears console
            Console.Clear();

            // Displays room title
            Console.WriteLine();
            Console.WriteLine(room.Title);

            // Create border above and below room description
            Console.WriteLine("".PadLeft(room.Title.Length, '-'));
            Console.WriteLine(room.Description);
            Console.WriteLine("".PadLeft(room.Title.Length, '-'));

            // Displays possible exits from room
            Console.WriteLine("Exits: {0}{1}{2}{3}\n",
                room.North == null ? "" : "North ",
                room.East == null ? "" : "East ",
                room.South == null ? "" : "South ",
                room.West == null ? "" : "West ");
        }
    }
}
