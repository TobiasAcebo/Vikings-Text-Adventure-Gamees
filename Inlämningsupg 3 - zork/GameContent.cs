using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlämningsupg_3___zork
{
    public class GameContent
    {
        private readonly List<Scenario> _allScenariosList;
        public GameContent()
        {
            _allScenariosList = new List<Scenario>
            {
                new Scenario
                {
                    Id = 1,
                    Title = "The Docks",
                    Description = "Years of traveling in the Mediterranean sea.\r\nYou have finally arrived in Kattegatt with your ship.\r\nHere at the docks, you must find your way into the great halls.\r\n\r\nAt the end of the docks, there's a fisherman talking about his travels with his men. \r\nPerhaps he knows how to get into the great halls. ",
                    LocationList = new List<Location>
                    {
                        new Location {Title = "starting point", Description = "Years of traveling in the Mediterranean sea. \r\nYou have finally arrived in Kattegatt with your ship.  \r\nHere at the docks, you must find your way into the great halls. \r\n\r\nAt the end of the docks, there's a fisherman talking about his travels with his men. \r\nPerhaps he knows how to get into the great halls. "},
                        new Location {Title = "water", Description = "Oh no! You fell into the water. Try and climb back up the docks."},
                        new Location {Title = "boat", Description = "You have boarded the ship."},
                        new Location {Title = "end of docks", ItemList = new List<Item>{new Item {Title = "knife"}, new Item{Title = "fishing line" } }},
                        new Location {Title = "west side", Description = "West side of the docks. \r\nIt’s so noisy here, what is that sound? Very well, nothing to see I guess. "},
                        new Location {Title = "guidance", Description = "Hey there traveler! You seem lost. Maybe the fisherman knows the way around this place."},
                        new Location {Title = "gate", Door = new Door {IsOpen = false}, Description =  "A locked gate. Wondering where this leads. Do you have a key perhaps? We could find out. \r\nIf not, ask around the docks. Maybe someone knows. "}
                    },
                    ImagePath = @"../../docks.jpg",

                    IsEndPoint = false
                },
                new Scenario
                {
                    Id = 2,
                    Title = "Muddy Road",
                    Description = "You have entered Muddy road.\r\nA mist settels over the abandoned houses.\r\nThe sign of life seems to have left this place.\r\nif you are lucky, perhaps someone is still around.",
                    LocationList = new List<Location>
                    {
                        new Location {Title = "starting point", Description = "You have entered Muddy road... \r\nA mist settels over the abandoned houses. \r\nThe sign of life seems to have left this place. \r\nif you are lucky, perhaps someone is still around."},
                        new Location {Title = "middle of the road", Description = "Oh look, there is someone here. It seems to be a Viking. Maybe he knows how to get out of this place."},
                        new Location {Title = "house with stack full of logs", Description = "You have entered a house with a stack of logs"},
                        new Location {Title = "house with a shield on the wall", Description = "You have entered a house with a shield on the wall.", ItemList = new List<Item>{ new Item { Title = "spear"}, new Item {Title = "helmet"}, new Item {Title = "book"}, new Item {Title = "candle" }}},
                        new Location {Title = "house with carpet a made of fur", Description = "You have entered a house with a carpet made of fur."},
                        new Location {Title = "house next to a water well", Description = "You have entered a house next to a water well."},
                        new Location {Title = "gate", Door = new Door{IsOpen = false }, Description = "Another locked gate. Do you have the key perhaps? If not, try find someone to ask."}
                    },
                    ImagePath = @"../../muddy road.jpg",

                    IsEndPoint = false
                },
            
            };
        }

        public Scenario GetStartingScenario()
        {
            return _allScenariosList.First(s => s.Id == 1);
        }

        public Scenario GetMuddyRoadScenario()
        {
            return _allScenariosList.First(s => s.Id == 2);
        }
    }
}
