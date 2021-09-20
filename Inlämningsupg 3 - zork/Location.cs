using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlämningsupg_3___zork
{
    class Location
    {
        public bool IsEndPoint { get; set; }
        public List<Exit> ExitList { get; set; }
        public List<Item> ItemList { get; set; }
    }
}
