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

            var currentLocation = _character.CurrentLocation;

            if (currentLocation.Title == "starting point")
                StartingPointExecuteInput(input);

            else if (currentLocation.Title == "house with stack of logs")
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
                _character.CurrentLocation.Description = "You are still at the starting point";
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
            _character.CurrentScenario = _gameContent.GetStartingScenario();
            _character.CurrentLocation = _character.CurrentScenario.LocationList.First(l => l.Title == "middle of the road");
            _character.PreviousLocation = previousLocation;
        }

        private void EnterTheDocks()
        {
            _character.CurrentScenario = _gameContent.GetStartingScenario();
            _character.CurrentLocation = _character.CurrentScenario.LocationList.First(l => l.Title == "gate");
            _character.PreviousLocation = null;
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
            throw new NotImplementedException();
        }

        private void HouseWithACarpetMadeOfFurExecuteInput(string input)
        {
            throw new NotImplementedException();
        }

        private void MiddleOfTheRoadExecuteInput(string input)
        {
            if (input == "go north" || input == "go to gate")
            {
                GoToGate(_character.CurrentLocation.Title);
                _character.InDialog = false;
            }

            else if (input == "go west")
            {
                GoToHouseWithACarpetMadeOfFur(_character.CurrentLocation.Title);
                _character.InDialog = false;
            }

            else if (input == "go back")
            {
                MiddleOfTheRoadGoBack(_character.CurrentLocation.Title);
                _character.InDialog = false;
            }

            else if (input == "go north")
            {
                EndOfDocksGoForward(_character.CurrentLocation.Title);
                _character.InDialog = false;
            }
            else if (input == "go south" || input == "go to starting point")
            {
                GoBackToStartingPoint(_character.CurrentLocation.Title);
                _character.InDialog = false;
            }
        }

        private void MiddleOfTheRoadGoBack(string previousLocation)
        {
            if (_character.PreviousLocation == "starting point")
                GoBackToStartingPoint(previousLocation);

            else if (_character.PreviousLocation == "house with a carpet made of fur")
                GoBackToWestSide(previousLocation);

            else if (_character.PreviousLocation == "gate")
                GoBackToGate(previousLocation);

            else if (_character.PreviousLocation == "house next to a water well")
                GoBackToGuidance(previousLocation);
        }

        private void GoBackToStartingPoint(string previousLocation)
        {
            _character.CurrentLocation = _character.CurrentScenario.LocationList.Find(x => x.Title == "starting point");
            _character.CurrentLocation.Description =
                "Once again ";
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
            throw new NotImplementedException();
        }

        private void HouseWithStackOfLogsExecuteInput(string input)
        {
            throw new NotImplementedException();
        }

        public void Look()
        {
            _character.CurrentLocation.Description = _character.CurrentScenario.Description + "\r\n"; 
            _character.CurrentLocation.Description += "\r\nThere is a gate located north of the road";
            DisplayItemsAvailable();
        }
    }
}
