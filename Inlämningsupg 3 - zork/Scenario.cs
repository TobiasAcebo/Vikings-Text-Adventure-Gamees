using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlämningsupg_3___zork
{
    class Scenario
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsEndPoint { get; set; }
        public List<Location> LocationList { get; set; }
    }
}
