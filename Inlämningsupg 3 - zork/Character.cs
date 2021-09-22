using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlämningsupg_3___zork
{
    class Character : ICharacter
    {
        private readonly Room _currentRoom;
        private readonly string _name;

        public Character(Room currentRoom, string name)
        {
            _currentRoom = currentRoom;
            _name = name;
        }
        public List<Item> ItemList { get; set; }
        public string LastDirection { get; set; }
        public int ScoreCount { get; set; }
        public int MovesCount { get; set; }
        public void Move(string direction)
        {
            throw new NotImplementedException();
        }

        public void PickUpItem(Item item)
        {
            throw new NotImplementedException();
        }

        public void DropItem(Item item)
        {
            throw new NotImplementedException();
        }

        public bool TryOpenDoor(Item door)
        {
            throw new NotImplementedException();
        }
    }
}
