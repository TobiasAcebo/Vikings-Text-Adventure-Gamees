using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlämningsupg_3___zork
{
    class Location
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Item> ItemList { get; set; }
        public Door Door { get; set; }
    }
}
