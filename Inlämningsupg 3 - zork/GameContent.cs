using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlämningsupg_3___zork
{
    class GameContent
    {
        private readonly List<Scenario> _allScenariosList;
        public GameContent()
        {
            _allScenariosList = new List<Scenario>
            {
                new Scenario
                {
                    Id = 1,
                    Title = "the docks",
                    Description = "Years of traveling in the Mediterranean sea. \r\nYou have finally arrived in Kattegatt with your ship.  \r\nHere at the docks, you must find your way into the great halls. \r\nAt the end of the docks, there's a fisherman talking about his travels with his men. \r\nPerhaps he knows how to get into the great halls. ",
                    LocationList = new List<Location>
                    {
                        new Location {Title = "starting point", Description = "Ah here we are, back were we started. At the end of the docks I can see a fisherman talking about his travels with his men. "}, 
                        new Location {Title = "water", Description = "Oh no! You fell into the water. Try and climb back up the docks."},
                        new Location {Title = "boat", Description = "You have boarded the ship."},
                        new Location {Title = "end of docks", ItemList = new List<Item>{new Item {Title = "knife"}, new Item{Title = "fishing line" } }},
                        new Location {Title = "west side", Description = "West side of the docks. \r\nIt’s so noisy here, what is that sound? Very well, nothing to see I guess. "},
                        new Location {Title = "guidance", Description = "Hey there traveler! You seem lost. Maybe the fisherman knows the way around this place."},
                        new Location {Title = "gate", Door = new Door {IsOpen = false}, Description =  "A locked gate. Wondering where this leads. Do you have a key perhaps? We could find out. \r\nIf not, ask around the docks. Maybe someone knows. "}
                    },

                    IsEndPoint = false
                },
            
            };
        }

        public Scenario GetStartingScenario()
        {
            return _allScenariosList.First(s => s.Id == 1);
        }
    }
}
