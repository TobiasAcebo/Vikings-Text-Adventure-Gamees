using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlämningsupg_3___zork
{
    class Room
    {
        public string Title { get; set; }
        public bool IsEndPoint { get; set; }
        public List<Door> DoorList { get; set; }
        public List<Item> ItemList { get; set; }
    }
}
