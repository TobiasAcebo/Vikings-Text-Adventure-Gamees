using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inlämningsupg_3___zork.GameClasses;
using Inlämningsupg_3___zork.Interfaces;

namespace Inlämningsupg_3___zork
{
    public class Game 
    {
        private readonly Character _character;
        private readonly GameContent _gameContent;

        public Game(Character character, GameContent gameContent)
        {
            this._character = character;
            _gameContent = gameContent;
        }

        public virtual void ExecuteInput(string input)
        {
            var currentScenario = _character.CurrentScenario;

            if(currentScenario.Id == 1)
            {
                var gameTheDocks = new GameTheDocks(_character, _gameContent);
                gameTheDocks.ExecuteInput(input);
            }
            else if (currentScenario.Id == 2)
            {
                var gameMuddyRoad = new GameMuddyRoad(_character, _gameContent);
                gameMuddyRoad.ExecuteInput(input);
            }

            else if (currentScenario.Id == 3)
            {
                var gameTown = new GameTown(_character, _gameContent);
                gameTown.ExecuteInput(input);
            }


            _character.MovesCount++;
        }
        public void DisplayItemsAvailable()
        {
            _character.CurrentLocation.Description += "\r\nItems available: ";
            foreach (var location in _character.CurrentScenario.LocationList)
            {
                foreach (var item in location.ItemList)
                {
                    _character.CurrentLocation.Description += "\r\n" + item.Title;
                }

            }

            _character.CurrentLocation.Description += "\r\n";
        }
        public bool InventoryFull()
        {
            if (_character.ItemList.Count() == 2)
            {
                return true;
            }
            return false;
        }
        public void OpenGate()
        {
            _character.CurrentLocation.Door.IsOpen = true;
            Item key = _character.ItemList.Find(x => x.IsKey == true);
            _character.ItemList.Remove(key);
        }
        public bool CharacterHasKey()
        {
            return _character.ItemList.Any(i => i.IsKey == true);
        }
        public void CannotExecuteInputFrom(string currentLocationTitle)
        {
            _character.CurrentLocation.Description = "The command may work somewhere in this game but not in: " + currentLocationTitle;
        }
        public bool CharacterHasCoin()
        {
            return _character.ItemList.Any(i => i.isCoin == true);
        }




    }
}
