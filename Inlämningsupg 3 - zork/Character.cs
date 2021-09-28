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
