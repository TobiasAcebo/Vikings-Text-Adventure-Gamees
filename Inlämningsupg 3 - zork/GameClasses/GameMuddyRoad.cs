using Inlämningsupg_3___zork.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlämningsupg_3___zork.GameClasses
{
    class GameMuddyRoad : Game, IGame
    {
        private readonly Character _character;
        private readonly GameContent _gameContent;
        public GameMuddyRoad(Character character, GameContent gameContent) : base(character, gameContent)
        {
            _character = character;
            _gameContent = gameContent;
        }
        public override void ExecuteInput(string input)
        {
            if (input == "look")
            {
                Look();
                return;
            }

            if (input == "use spear on book" || input == "use book on spear")
            {
                TryCreateKey();
                return;
            }
            if (DropItemInputWorks(input))
                return;

            if (PickUpItemInputWorks(input))
                return;

            if (TryingToPickUpMultipleItems(input))
                return;
            

            var currentLocation = _character.CurrentLocation;

            if (currentLocation.Title == "starting point")
                StartingPointExecuteInput(input);

            else if (currentLocation.Title == "house with stack full of logs")
                HouseWithStackOfLogsExecuteInput(input);

            else if (currentLocation.Title == "house with a shield on the wall")
                HouseWithAShieldOnTheWallExecuteInput(input);

            else if (currentLocation.Title == "middle of the road")
                MiddleOfTheRoadExecuteInput(input);

            else if (currentLocation.Title == "house with a carpet made of fur")
                HouseWithACarpetMadeOfFurExecuteInput(input);

            else if (currentLocation.Title == "house next to a water well")
                HouseNextToAWaterWellExecuteInput(input);

            else if (currentLocation.Title == "gate")
                GateExecuteInput(input);
        }
        private bool PickUpItemInputWorks(string input)
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
                        InventoryStatusPrint();
                        return true;
                    }
                }
            }
            return false;
        }
        private bool DropItemInputWorks(string input)
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
        private void TryCreateKey()
        {
            if (CharacterHasSpearAndBook())
            {
                Item key = new Item();
                key.IsKey = true;
                key.Title = "key";
                _character.ItemList.Clear();
                _character.ItemList.Add(key);
                _character.CurrentLocation.Description = "\"You have made a key!\"";
            }
        } // skapar en ny key?

        private void InventoryStatusPrint()
        {
            if (CharacterHasSpearAndBook())
            {
                _character.CurrentLocation.Description = "You have spear and book in your inventory \r\n";
                _character.CurrentLocation.Description += "\"Hold up..! Hold up..! You are on to something here.\r\nTry use them on each other.\"";
            }
        }

        private bool CharacterHasSpearAndBook()
        {
            if (_character.ItemList.Count(item => item.Title == "spear" || item.Title == "book") == 2)
            {
                return true;
            }
            return false;
        }

        private void StartingPointExecuteInput(string input)
        {
            if (input == "go east" || input == "go to house with a shield on the wall" || input == "go to the house with a shield on the wall")
                GoToHouseWithAShieldOnTheWall(_character.CurrentLocation.Title);

            else if (input == "go west" || input == "go to house with stack full of logs" || input == "go to the house with stack full of logs")
                GoToHouseWithStackFullOfLogs(_character.CurrentLocation.Title);

            else if (input == "go north" || input == "go to middle of the road")
                GoToMiddleOfTheRoad(_character.CurrentLocation.Title);

            else if (input == "go back to the docks" || input == "enter the docks" || input == "go to the docks")
                EnterTheDocks();
            else if (input == "go back")
                StartingPointGoBack(_character.CurrentLocation.Title);

            else
                CannotExecuteInputFrom(_character.CurrentLocation.Title);
        }

        private void StartingPointGoBack(string previousLocation)
        {
            if (_character.PreviousLocation == null)
                _character.CurrentLocation.Description = "You are still at the starting point \r\nIf you want to go back to the docks, type: enter the docks";
            else
            {
                if (_character.PreviousLocation == "middle of the road")
                    GoBackToMiddleOfTheRoad(previousLocation);

                else if (_character.PreviousLocation == "house with a shield on the wall")
                    GoBackToHouseWithAShieldOnTheWall(previousLocation);

                else if (_character.PreviousLocation == "house with a stack full of logs")
                    GoBackToHouseWithAStackFullOfLogs(previousLocation);
            }
        }

        private void GoBackToHouseWithAStackFullOfLogs(string previousLocation)
        {
            _character.CurrentLocation = _character.CurrentScenario.LocationList.Find(x => x.Title == "house with a stack full of logs");
            _character.CurrentLocation.Description =
                "This house seems familiar. It's the house with a stack full of logs";
            _character.PreviousLocation = previousLocation;
        }

        private void GoBackToHouseWithAShieldOnTheWall(string previousLocation)
        {
            _character.CurrentLocation = _character.CurrentScenario.LocationList.Find(x => x.Title == "house with a shield on the wall");
            _character.CurrentLocation.Description =
                "This house seems familiar. It's the house with a shiled on the wall";
            _character.PreviousLocation = previousLocation;
        }

        private void GoBackToMiddleOfTheRoad(string previousLocation)
        {
            _character.CurrentLocation = _character.CurrentScenario.LocationList.Find(x => x.Title == "middle of the road");
            _character.CurrentLocation.Description =
                "Back at the middle of the road. Is the Viking still around? Maybe he knows how to get out of this place.";
            _character.PreviousLocation = previousLocation;
        }

        private void GoToMiddleOfTheRoad(string previousLocation)
        {
            _character.CurrentLocation = _character.CurrentScenario.LocationList.Find(x => x.Title == "middle of the road");
            _character.CurrentLocation.Description =
                "You are at the middle of the road.\r\nOh look, there is someone here. It seems to be a viking.\r\nMaybe he knows how to get out of this place.";
            _character.PreviousLocation = previousLocation;
        }

        private void EnterTheDocks()
        {
            _character.CurrentScenario = _gameContent.GetStartingScenario();
            _character.CurrentLocation = _character.CurrentScenario.LocationList.First(l => l.Title == "gate");
            _character.PreviousLocation = null;
            _character.CurrentLocation.Description = "You have entered The docks.\r\nYou are still at the gate.\r\nIf you want to go back to Muddy road, type: enter muddy road.\r\nElse you can move as you please within The docks";
        }

        private void GoToHouseWithStackFullOfLogs(string previousLocation)
        {
            _character.CurrentLocation = _character.CurrentScenario.LocationList.Find(x => x.Title == "house with stack full of logs");
            _character.PreviousLocation = previousLocation;
        }

        private void GoToHouseWithAShieldOnTheWall(string previousLocation)
        {
            _character.CurrentLocation = _character.CurrentScenario.LocationList.Find(x => x.Title == "house with a shield on the wall");
            _character.PreviousLocation = previousLocation;
        }

        private void GateExecuteInput(string input)
        {
            if (input == "open gate") // lägg till flera alternativ
                TryOpenGate();

            else if (input == "go south")
                GoBackToMiddleOfTheRoad(_character.CurrentLocation.Title);
            else if (input == "go back")
            {
                if (_character.PreviousLocation != null)
                {
                    GoBackToMiddleOfTheRoad(_character.CurrentLocation.Title);
                }
                else
                    _character.CurrentLocation.Description = "You need to enter town again";
            }
            else if (input == "enter town" || input == "go to town")
                TryEnterTown();

            else
                CannotExecuteInputFrom(_character.CurrentLocation.Title);
        }

        private void TryEnterTown()
        {
            if (_character.CurrentLocation.Door.IsOpen)
            {
                //_character.CurrentScenario = _gameContent.GetMuddyRoadScenario(); // skapa scenario
                _character.CurrentLocation = _character.CurrentScenario.LocationList.First(l => l.Title == "starting point");
                _character.PreviousLocation = null;
            }
            else if (CharacterHasKey())
            {
                _character.CurrentLocation.Description =
                    "You must open the gate to enter Town. I believe you have the key.";
            }
            else
            {
                _character.CurrentLocation.Description =
                    "You must open the gate to enter Town. I don't believe you have the key, do you. Ask the Viking, he should know";
            }
        }

        private void TryOpenGate()
        {
            bool characterHasKey = CharacterHasKey();
            bool gateIsOpen = _character.CurrentLocation.Door.IsOpen;

            if (!characterHasKey && !gateIsOpen)
            {
                _character.CurrentLocation.Description =
                    "The gate is locked and you don't have a key. Ask the Viking, he should know how to get one.";
            }
            else if (characterHasKey && !gateIsOpen)
            {
                OpenGate();
                _character.CurrentLocation.Description = "You opened the gate. You can now enter Town.";
            }
            else
                _character.CurrentLocation.Description = "The gate is already open. You can now enter Town.";
        }

        private void HouseNextToAWaterWellExecuteInput(string input)
        {
            if(input == "go west" || input == "go back")
                GoBackToMiddleOfTheRoad(_character.CurrentLocation.Title);
            else
                CannotExecuteInputFrom(_character.CurrentLocation.Title);
        }

        private void HouseWithACarpetMadeOfFurExecuteInput(string input)
        {
            if (input == "go east" || input == "go back")
                GoBackToMiddleOfTheRoad(_character.CurrentLocation.Title);
            else
                CannotExecuteInputFrom(_character.CurrentLocation.Title);
        }

        private void MiddleOfTheRoadExecuteInput(string input)
        {
            if (input == "go north" || input == "go to gate")
            {
                GoToGate(_character.CurrentLocation.Title);
                _character.InDialog = false;
            }

            else if (input == "go west" || input == "go to house with a carpet made of fur" || input == "go to the house with a carpet made of fur")
            {
                GoToHouseWithACarpetMadeOfFur(_character.CurrentLocation.Title);
                _character.InDialog = false;
            }

            else if (input == "go back")
            {
                MiddleOfTheRoadGoBack(_character.CurrentLocation.Title);
                _character.InDialog = false;
            }

            else if (input == "go east" || input == "go to house next to a water well" || input == "go to the house next to a water well")
            {
                GoToHouseNextToAWaterWell(_character.CurrentLocation.Title);
                _character.InDialog = false;
            }
            else if (input == "go south" || input == "go to starting point")
            {
                GoBackToStartingPoint(_character.CurrentLocation.Title);
                _character.InDialog = false;
            }
            else if (input.Contains("excuse me") || input.Contains("hello") || input.Contains("hi") || input == "talk to viking")
                OpenDialog();

            else if (input.Contains("great halls"))
            {
                if (_character.InDialog)
                    _character.CurrentLocation.Description = "Viking: \"Ah yes, the Great halls is where King Ragnar lives.\r\nYou have to go through the gate to get there.\"";
                else
                    DialogNotOpen();
            }

            else if (input.Contains("gate"))
            {
                if (_character.InDialog)
                    _character.CurrentLocation.Description = "Viking: \"Yes, I know about this gate. It's located north from here\"";
                else
                    DialogNotOpen();
            }

            else if (input.Contains("key"))
            {
                if (_character.InDialog)
                    _character.CurrentLocation.Description = "Viking: \"I don't know anything about a key..\r\nI do know, there are still some items left in this place that could help you.\r\nTry the house with a shield on the wall.\r\nRemember to use the word " + "\"Valhalla\"" + " when you enter.\"";
                else
                    DialogNotOpen();
            }

        }

        private void DialogNotOpen()
        {
            _character.CurrentLocation.Description = "Try get his attention";
        }

        private void OpenDialog()
        {
            _character.CurrentLocation.Description = "Viking: \"What are you doing here? This place is dangerous.\r\nHow can I help you?\"";
            _character.InDialog = true;
        }

        private void GoToHouseNextToAWaterWell(string previousLocation)
        {
            _character.CurrentLocation = _character.CurrentScenario.LocationList.Find(x => x.Title == "house next to a water well");
            _character.PreviousLocation = previousLocation;
        }

        private void MiddleOfTheRoadGoBack(string previousLocation)
        {
            if (_character.PreviousLocation == "starting point")
                GoBackToStartingPoint(previousLocation);

            else if (_character.PreviousLocation == "house with a carpet made of fur")
                GoBackToHouseWithACarpetMadeOfFur(previousLocation);

            else if (_character.PreviousLocation == "gate")
                GoBackToGate(previousLocation);

            else if (_character.PreviousLocation == "house next to a water well")
                GoBackToHouseNextToAWaterWell(previousLocation);
        }

        private void GoBackToHouseNextToAWaterWell(string previousLocation)
        {
            _character.CurrentLocation = _character.CurrentScenario.LocationList.Find(x => x.Title == "house next to a water well");
            _character.CurrentLocation.Description = "This house seems familiar. It's the house next to a water well";
            _character.PreviousLocation = previousLocation;
        }

        private void GoBackToGate(string previousLocation)
        {
            GoToGate(previousLocation);
        }

        private void GoBackToHouseWithACarpetMadeOfFur(string previousLocation)
        {
            _character.CurrentLocation = _character.CurrentScenario.LocationList.Find(x => x.Title == "house with a carpet made of fur");
            _character.CurrentLocation.Description = "This house seems familiar. It's the house with a carpet made of fur";
            _character.PreviousLocation = previousLocation;
        }

        private void GoBackToStartingPoint(string previousLocation)
        {
            _character.CurrentLocation = _character.CurrentScenario.LocationList.Find(x => x.Title == "starting point");
            _character.CurrentLocation.Description =
                "We are back at the entrance of Muddy road. Wondering if there's still someone around in this place.";
            _character.PreviousLocation = previousLocation;
        }

        private void GoToHouseWithACarpetMadeOfFur(string previousLocation)
        {
            _character.CurrentLocation = _character.CurrentScenario.LocationList.Find(x => x.Title == "house with a carpet made of fur");
            _character.PreviousLocation = previousLocation;
        }

        private void GoToGate(string previousLocation)
        {
            _character.CurrentLocation = _character.CurrentScenario.LocationList.Find(x => x.Title == "gate");
            var characterHasKey = _character.ItemList.Any(i => i.Title == "key");
            var gateIsOpen = _character.CurrentLocation.Door.IsOpen;
            if (!characterHasKey && !gateIsOpen)
            {
                _character.CurrentLocation.Description =
                    "Another locked gate. Wondering where this one leads. Do you have the key? \r\nIf not, ask the Viking, he should know";
            }
            else if (characterHasKey && !gateIsOpen)
            {
                _character.CurrentLocation.Description =
                    "A locked gate. Wondering where this leads. Do you have a key perhaps?";
            }
            else
            {
                _character.CurrentLocation.Description =
                    "An open gate.";
            }
            _character.PreviousLocation = previousLocation;
        }

        private void HouseWithAShieldOnTheWallExecuteInput(string input)
        {
            if (input == "go west" || input == "go back")
                GoBackToStartingPoint(_character.CurrentLocation.Title);
            else if (input == "valhalla")
                DisplayMuddyRoadItems();
            else
                CannotExecuteInputFrom(_character.CurrentLocation.Title);
        }

        private bool TryingToPickUpMultipleItems(string input) 
        {
            if (input.Contains("pick up") && input.Contains("and"))
            {
                _character.CurrentLocation.Description = "Try pick up one item at the time.";
                return true;
            }
            return false;
        }

        private void TryPickUpHelmet()
        {
            Item helmet = _character.CurrentLocation.ItemList.Find(x => x.Title == "helmet");
            _character.ItemList.Add(helmet);
            _character.CurrentLocation.ItemList.Remove(helmet);
        }

        private void TryPickUpCandle()
        {
            Item candle = _character.CurrentLocation.ItemList.Find(x => x.Title == "candle");
            _character.ItemList.Add(candle);
            _character.CurrentLocation.ItemList.Remove(candle);
        }

        private void TryPickUpBook()
        {
            Item book = _character.CurrentLocation.ItemList.Find(x => x.Title == "book");
            _character.ItemList.Add(book);
            _character.CurrentLocation.ItemList.Remove(book);
        }

        private void TryPickUpSpear()
        {
            Item spear = _character.CurrentLocation.ItemList.Find(x => x.Title == "spear");
            _character.ItemList.Add(spear);
            _character.CurrentLocation.ItemList.Remove(spear);
        }

        private void DisplayMuddyRoadItems()
        {
            _character.CurrentLocation.Description = "You unlocked the hidden items.\r\nHelmet\r\nBook\r\nCandle\r\nSpear";
        }

        private void HouseWithStackOfLogsExecuteInput(string input)
        {
            if (input == "go east" || input == "go back")
                GoBackToStartingPoint(_character.CurrentLocation.Title);
            else
                CannotExecuteInputFrom(_character.CurrentLocation.Title);
        }

        public void Look()
        {
            FrmInfoMuddyRoad frmInfoMuddyRoad = new FrmInfoMuddyRoad(_character);
            frmInfoMuddyRoad.Show();
        }
    }
}
