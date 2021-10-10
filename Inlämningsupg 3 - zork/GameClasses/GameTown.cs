using Inlämningsupg_3___zork.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlämningsupg_3___zork.GameClasses
{
    class GameTown : Game
    {
        private readonly Character _character;
        private readonly GameContent _gameContent;

        public GameTown(Character character, GameContent gameContent) : base(character, gameContent)
        {
            _character = character;
            _gameContent = gameContent;
        }

        public override void ExecuteInput(string input)
        {
            if (input == "Look")
            {
                Look();
                return;
            }

            var currentLocation = _character.CurrentLocation;

            if (currentLocation.Title == "starting point")
                StartingPointExecuteInput(input);

            else if (currentLocation.Title == "armorsmith")
                ArmmorSmithExecute(input);

            else if (currentLocation.Title == "boat house")
                BoatHouseExecuteInput(input);

            else if (currentLocation.Title == "fountain")
                FountainExecuteInput(input);

            else if (currentLocation.Title == "swordsmith")
                SwordSmithExecuteInput(input);

            else if (currentLocation.Title == "pub")
                PubExecuteInput(input);

            else if (currentLocation.Title == "great halls gate")
                GreatHallsGateExecuteInput(input);
        }

        private void GreatHallsGateExecuteInput(string input)
        {
            if (input == "open gate") // lägg till flera alternativ
                TryOpenGate();

            else if (input == "go south")
                GoBackToFounatain(_character.CurrentLocation.Title);
            else if (input == "go back")
            {
                if (_character.PreviousLocation != null)
                {
                    GoBackToFounatain(_character.CurrentLocation.Title);
                }
                else
                    _character.CurrentLocation.Description = "You need to enter town again";
            }
            else if (input == "enter the great halls" || input == "go to the great halls")
                TryEnterGreatHalls();

            else
                CannotExecuteInputFrom(_character.CurrentLocation.Title);
        }

        private void TryEnterGreatHalls()
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
                    "You must open the gate to enter the Great halls. I believe you have the key.";
            }
            else
            {
                _character.CurrentLocation.Description =
                    "You must open the gate to enter the Great Halls. I don't believe you have the key, do you. Ask Erhild, he should know";
            }
        }

        private void TryOpenGate()
        {
            bool characterHasKey = CharacterHasKey();
            bool gateIsOpen = _character.CurrentLocation.Door.IsOpen;

            if (!characterHasKey && !gateIsOpen)
            {
                _character.CurrentLocation.Description =
                    "The gate is locked and you don't have a key. Ask Erhild, he should know how to get one.";
            }
            else if (characterHasKey && !gateIsOpen)
            {
                OpenGate();
                _character.CurrentLocation.Description = "You opened the gate. You can now enter the Great halls.";
            }
            else
                _character.CurrentLocation.Description = "The gate is already open. You can now enter the Great halls.";
        }

        private void PubExecuteInput(string input)
        {
            if (input == "go west" || input == "go back")
                GoBackToFounatain(_character.CurrentLocation.Title);
            else
                CannotExecuteInputFrom(_character.CurrentLocation.Title);
        }

        private void SwordSmithExecuteInput(string input)
        {
            if (input == "go east" || input == "go back")
                GoBackToFounatain(_character.CurrentLocation.Title);
            else
                CannotExecuteInputFrom(_character.CurrentLocation.Title);
        }

        private void GoBackToFounatain(string previousLocation)
        {
            _character.CurrentLocation = _character.CurrentScenario.LocationList.Find(x => x.Title == "fountain");
            _character.CurrentLocation.Description =
                "Back at the fountain hope the guy Erhild is still around. He should be able to help you. He usually is in the pub. Find the pub and get your answers.";
            _character.PreviousLocation = previousLocation;
        }

        private void FountainExecuteInput(string input)
        {
            if (input == "go north" || input == "go to stairs")
            {
                GoToStairs(_character.CurrentLocation.Title);
                _character.InDialog = false;
            }

            else if (input == "go west" || input == "go to swordsmith" || input == "go to the swordsmith")
            {
                GoToSwordSmith(_character.CurrentLocation.Title);
                _character.InDialog = false;
            }

            else if (input == "go east" || input == "go to pub" || input == " go to the pub")
            {
                GoToPub(_character.CurrentLocation.Title);
                _character.InDialog = false;
            }

            else if (input == "go south" || input == "go to starting point")
            {
                GoBackToStartingPoint(_character.CurrentLocation.Title);
                _character.InDialog = false;
            }
             
            // else if (input.Contains("excuse me") || input.Contains("hello") || input.Contains("hi") || input == "talk to viking")
            //    OpenDialog();

            //else if (input.Contains("great halls"))
            //{
            //    if (_character.InDialog)
            //        _character.CurrentLocation.Description = "Viking: \"Ah yes, the Great halls is where King Ragnar lives.\r\nYou have to go through the gate to get there.\"";
            //    else
            //        DialogNotOpen();
            //}

            //else if (input.Contains("gate"))
            //{
            //    if (_character.InDialog)
            //        _character.CurrentLocation.Description = "Viking: \"Yes, I know about this gate. It's located north from here\"";
            //    else
            //        DialogNotOpen();
            //}

            //else if (input.Contains("key"))
            //{
            //    if (_character.InDialog)
            //        _character.CurrentLocation.Description = "Viking: \"I don't know anything about a key..\r\nI do know, there are still some items left in this place that could help you.\r\nTry the house with a shield on the wall.\r\nRemember to use the word " + "\"Valhalla\"" + " when you enter.\"";
            //    else
            //        DialogNotOpen();
            //}
        }

        private void GoToPub(string previousLocation)
        {
            _character.CurrentLocation = _character.CurrentScenario.LocationList.Find(x => x.Title == "pub");
            _character.PreviousLocation = previousLocation;


        }

        private void GoToSwordSmith(string previousLocation)
        {
            _character.CurrentLocation = _character.CurrentScenario.LocationList.Find(x => x.Title == "swordsmith");
            _character.PreviousLocation = previousLocation;
        }

        private void GoToStairs(string previousLocation)
        {
            _character.CurrentLocation = _character.CurrentScenario.LocationList.Find(x => x.Title == "stairs");
            _character.PreviousLocation = previousLocation;
        }

        private void BoatHouseExecuteInput(string input)
        {
            if (input == "go west" || input == "go back")
                GoBackToStartingPoint(_character.CurrentLocation.Title);
            else
                CannotExecuteInputFrom(_character.CurrentLocation.Title);
        }

        private void ArmmorSmithExecute(string input)
        {
            if (input == "go east" || input == "go back")
                GoBackToStartingPoint(_character.CurrentLocation.Title);
            else
                CannotExecuteInputFrom(_character.CurrentLocation.Title);
        }

        private void GoBackToStartingPoint(string previousLocation)
        {
            _character.CurrentLocation = _character.CurrentScenario.LocationList.Find(x => x.Title == "starting point");
            _character.CurrentLocation.Description =
                "We are back at the entrance of Town. Wondering if there's someone around here.";
            _character.PreviousLocation = previousLocation;
        }

        private void StartingPointExecuteInput(string input)
        {
            if (input == "go east" || input == "go to boat house" || input == "go to the boat house")
                GoToBoatHouse(_character.CurrentLocation.Title);

            else if (input == "go west " || input == "go to armorsmith" || input == "go to the armorsmith")
                GoToArmorSmith(_character.CurrentLocation.Title);

            else if (input == "go north" || input == "go to fountain" || input == "go to the fountain")
                GoToFountain(_character.CurrentLocation.Title);

            else if (input == "go back to muddy road" || input == "go to muddy roads" || input == "enter muddy road")
                EnterMuddyRoad();

            else if (input == "go back")
                StartingPointGoBack(_character.CurrentLocation.Title);
        }

        private void StartingPointGoBack(string previousLocation)
        {
            if (_character.PreviousLocation == null)
                _character.CurrentLocation.Description = "You are still at the starting point \r\nIf you want to go back to the muddy road, type: enter muddy road";
        }

        private void EnterMuddyRoad()
        {
            _character.CurrentScenario = _gameContent.GetMuddyRoadScenario();
            _character.CurrentLocation = _character.CurrentScenario.LocationList.First(l => l.Title == "gate");
            _character.PreviousLocation = null;
            _character.CurrentLocation.Description = "You have entered muddy roads.\r\nYou are still at the gate.\r\nIf you want to go back to town, type: enter town.\r\nElse you can move as you please within muddy roads";
        }

        private void GoToFountain(string previousLocation)
        {
            _character.CurrentLocation = _character.CurrentScenario.LocationList.Find(x => x.Title == "fountain");
            _character.PreviousLocation = previousLocation;
        }

        private void GoToArmorSmith(string previousLocation)
        {
            _character.CurrentLocation = _character.CurrentScenario.LocationList.Find(x => x.Title == "armorsmith");
            _character.PreviousLocation = previousLocation;
        }

        private void GoToBoatHouse(string previousLocation)
        {
            _character.CurrentLocation = _character.CurrentScenario.LocationList.Find(x => x.Title == "boat house");
            _character.PreviousLocation = previousLocation;
        }

        private void Look()
        {
            FrmInfoMuddyRoad frmInfoMuddy = new FrmInfoMuddyRoad(_character);
            frmInfoMuddy.Show();
        }
    }
}
