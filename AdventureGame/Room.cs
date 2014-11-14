using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame
{
    class Room
    {
        // Properties to hold room details
        public string Title;
        public string Description;

        // Properties for possible exits
        public Room North;
        public Room East;
        public Room South;
        public Room West;

        // The Constructor
        public Room (string title, string description)
        {
            Title = title;
            Description = description;
        }
    }
}
