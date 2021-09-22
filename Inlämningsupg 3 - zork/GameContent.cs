using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlämningsupg_3___zork
{
    class GameContent
    {
        private readonly List<Room> _allRoomsList;
        public GameContent()
        {
            _allRoomsList = new List<Room>
            {
                new Room
                {
                    Title = "Living room",
                    DoorList = new List<Door>{new Door{IsOpen = false}, new Door{IsOpen = true}},
                    ItemList = new List<Item>{new Item {Title = "book", IsKey = false}, new Item {Title = "key", IsKey = true}},
                    IsEndPoint = false

                },
                new Room
                {
                    Title = "Bedroom",
                    DoorList = new List<Door>{new Door{IsOpen = false}},
                    ItemList = new List<Item>{new Item {Title = "book", IsKey = false}, new Item {Title = "key", IsKey = true}},
                    IsEndPoint = true

                }
            };
        }

        
    }
}
