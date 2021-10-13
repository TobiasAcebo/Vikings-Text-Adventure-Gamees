using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inlämningsupg_3___zork.GameClasses;

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
            if (input == "look")
            {
                Look();
                return;
            }

            if (TryingToPickUpMultipleItems(input))
                return;

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

        public void Look()
        {
            if (_character.CurrentScenario.Id == 1)
            {
                var frmInfoTheDocks = new FrmInfoTheDocks(_character);
                frmInfoTheDocks.Show();
            }
            else if (_character.CurrentScenario.Id == 2)
            {
                var frmInfoMuddyRoad = new FrmInfoMuddyRoad(_character);
                frmInfoMuddyRoad.Show();
            }
            else if (_character.CurrentScenario.Id == 3)
            {
                var frmInfoTown = new FrmInfoTown(_character);
                frmInfoTown.Show();
            }


        }

        public bool PickUpItemInputWorks(string input)
        {
            var itemsInLocation = _character.CurrentLocation.ItemList;
            foreach (var item in itemsInLocation)
            {
                if (input == "pick up " + item.Title)
                {
                    if (!InventoryFull())
                    {
                        _character.PickUpItem(item);
                        _character.CurrentLocation.Description = "You have picked up " + item.Title;
                        return true;
                    }
                }
            }
            return false;
        }
        public bool DropItemInputWorks(string input)
        {
            var inventory = _character.ItemList;
            foreach (var item in inventory)
            {
                if (input == "drop " + item.Title)
                {
                    _character.DropItem(item);
                    _character.CurrentLocation.Description = "You have dropped " + item.Title + " in " + "\"" + _character.CurrentLocation.Title + "\"";
                    return true;
                }
            }
            return false;
        }
        private bool TryingToPickUpMultipleItems(string input)
        {
            if (input.Contains("pick up") && input.Contains(" and "))
            {
                _character.CurrentLocation.Description = "Try pick up one item at the time.";
                return true;
            }
            return false;
        }
    }
}
