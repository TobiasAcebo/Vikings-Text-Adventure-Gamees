using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlämningsupg_3___zork
{
    interface IGameEvent
    {
        void Move(Character character, string direction);
        void PickUpItem(Character character, Item item, Location location);
        void DropItem(Character character, Item item, Location location);

    }
}
