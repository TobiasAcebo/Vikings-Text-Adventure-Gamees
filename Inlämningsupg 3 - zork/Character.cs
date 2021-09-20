using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlämningsupg_3___zork
{
    class Character
    {
        public string Name { get; set; }
        public List<Item> ItemList { get; set; }
        public string LastDirection { get; set; }
        public int Score { get; set; }
        public int Moves { get; set; }
    }
}
