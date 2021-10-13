using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlämningsupg_3___zork
{
    interface ICharacter
    {
        void PickUpItem(Item item);
        void DropItem(Item item);
    }
}
