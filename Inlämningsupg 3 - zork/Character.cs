using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlämningsupg_3___zork
{
    public class Character : ICharacter
    {
        public Character(Scenario currentScenario, string name)
        {
            CurrentScenario = currentScenario;
            CurrentLocation = currentScenario.LocationList.FirstOrDefault(l => l.Title == "starting point");
            Name = name;
        }

        public string Name { get; set; }
        public Scenario CurrentScenario { get; set; }
        public Location CurrentLocation { get; set; }
        public List<Item> ItemList { get; set; } = new List<Item>();
        public string PreviousLocation { get; set; }
        public int MovesCount { get; set; } = 0;
        public bool InDialog { get; set; } 
        public void Move(string direction)
        {
            throw new NotImplementedException();
        }

        public void PickUpItem(Item item)
        {
            ItemList.Add(item);
            CurrentLocation.ItemList.Remove(item);
        }

        public void DropItem(Item item)
        {
            ItemList.Remove(item);
            CurrentLocation.ItemList.Add(item);
        }

        public bool TryOpenDoor(Item door)
        {
            throw new NotImplementedException();
        }
    }
}
