using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            

            if (input == "use helmet on long sword" || input == "use long sword on helmet")
            {
                TryCreateKey();
                return;
            }

            if (_character.CurrentLocation.Title != "sword smith")
            {
                if (DropItemInputWorks(input))
                    return;

                if (PickUpItemInputWorks(input))
                {
                    InventoryStatusPrint();
                    return;
                }
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

            else if (currentLocation.Title == "stairs")
                StairsExecuteInput(input);

            else if (currentLocation.Title == "great halls gate")
                GreatHallsGateExecuteInput(input);
            else if (currentLocation.Title == "sailing")
                SailingExecuteInput(input);
        }

        

        private void TryCreateKey()
        {
            if (CharacterHasHelmetAndLongSword())
            {
                Item key = new Item();
                key.IsKey = true;
                key.Title = "key";
                _character.ItemList.Clear();
                _character.ItemList.Add(key);
                _character.CurrentLocation.Description = "\"You have made a key!\"";
            }
        }

        

        private void StairsExecuteInput(string input)
        {
            if (input == "go north" || input == "go to great halls")
                GoToGreatHalls(_character.CurrentLocation.Title);
            else
                CannotExecuteInputFrom(_character.CurrentLocation.Title);
        }

        private void GoToGreatHalls(string previousLocation)
        {
            _character.CurrentLocation = _character.CurrentScenario.LocationList.Find(x => x.Title == "great halls gate");
            _character.PreviousLocation = previousLocation;
        }

        private void GreatHallsGateExecuteInput(string input)
        {
            if (input == "open great halls" || input == "open gate" || input == "use key on gate") 
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
            else if (input == "enter great halls" || input == "go to great halls")
                TryEnterGreatHalls();

            else
                CannotExecuteInputFrom(_character.CurrentLocation.Title);
        }

        private void TryEnterGreatHalls()
        {
            if (_character.CurrentLocation.Door.IsOpen)
            {
                _character.IsAtEndPoint = true;
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

            if (input.Contains("excuse me") || input.Contains("hello") || input.Contains("hi") || input == "erhild")
                OpenDialog();

            else if (input.Contains("great halls"))
            {
                if (_character.InDialog)
                    _character.CurrentLocation.Description = "Erhild: \"Ah yes, the Great halls is where King Ragnar lives.\r\nYou have to go through the gate to get there.\"";
                else
                    DialogNotOpen();
            }

            else if (input.Contains("gate"))
            {
                if (_character.InDialog)
                    _character.CurrentLocation.Description = "Erhild: \"Yes, I know about this gate. It's located north of the fountain\"";
                else
                    DialogNotOpen();
            }

            else if (input.Contains("key"))
            {
                if (_character.InDialog)
                    _character.CurrentLocation.Description = "Erhild: \"I don't know anything about a key..\r\nBut!.. Excuse me, I'm bit drunk\r\nOkey yes! The key. You will need to go back to the docks and find the spirit of thor\r\nHe is located in the west side. Remember, use the word\" thor\"when you get there.\r\nOh, I almost forgot...There is a boat that you can take you back there.\r\nJust go east of the entrance and you fill fint it.\"";
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
            _character.CurrentLocation.Description = "Erhild: \"Well hello there, I'm Erhild. Who are you?\r\nNevermind.What can I do for you?\"";
            _character.InDialog = true;
        }

        private void SwordSmithExecuteInput(string input)
        {
            if (input == "go east" || input == "go back")
                GoBackToFounatain(_character.CurrentLocation.Title);
            else
                CannotExecuteInputFrom(_character.CurrentLocation.Title);

            if (input == "good work")
                GetLongSword();
        }

        private void GetLongSword()
        {
            if (LongSwordAvailable())
            {
                if (!InventoryFull())
                {
                    LongSwordGiven();
                    _character.CurrentLocation.Description = "Swordsmith: \"Well thank you kind sir.\r\nHere, take this long sword as a sign of my appreciation.\"";
                    InventoryStatusPrint();
                }
                else
                    _character.CurrentLocation.Description = "You have a full inventory, drop an item";


            }
            else
                _character.CurrentLocation.Description = "Swordsmith: \"That item has already been taken.\"";
          
        }


        private void InventoryStatusPrint()
        {
            if (CharacterHasHelmetAndLongSword())
            {
                _character.CurrentLocation.Description += "You have helmet and long sword in your inventory \r\n";
                _character.CurrentLocation.Description += "\"Try use them on each other.\"";
            }
        }

        private bool CharacterHasHelmetAndLongSword()
        {
            if (_character.ItemList.Count(item => item.Title == "helmet" || item.Title == "long sword") == 2)
            {
                return true;
            }
            return false;
        }

        private void LongSwordGiven()
        {
            Item longSword = _character.CurrentLocation.ItemList.Find(x => x.Title == "long sword");
            _character.ItemList.Add(longSword);
            _character.CurrentLocation.ItemList.Remove(longSword);
        }

        private bool LongSwordAvailable()
        {
            return _character.CurrentLocation.ItemList.Any(x => x.Title == "long sword");
        }

        private void GoBackToFounatain(string previousLocation)
        {
            _character.CurrentLocation = _character.CurrentScenario.LocationList.Find(x => x.Title == "fountain");
            _character.CurrentLocation.Description =
                "Back at the fountain. Hopefully Erhild is still around. He should be able to help you. He usually stays in the pub. Find the pub and get your answers.";
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

            else if (input == "go south" || input == "go to starting point" || input == "go back")
            {
                GoBackToStartingPoint(_character.CurrentLocation.Title);
                _character.CurrentLocation.Description = "You are back at the entrance in Town";
                _character.InDialog = false;
            }
             
            
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

            else if (input == "yes")
                Sailing();
            

            else if (input == "no")
                _character.CurrentLocation.Description = "Very well then, come back anytime.";

            else
                CannotExecuteInputFrom(_character.CurrentLocation.Title);
        }

        private void Sailing()
        {
            _character.PreviousLocation = null;
            _character.CurrentLocation = _character.CurrentScenario.LocationList.Find(location => location.Title == "sailing");
        }
        private void SailingExecuteInput(string input)
        {
            if (input == "sail back to the docks")
            {
                GoBackToTheDocks();
            }
        }

        private void GoBackToTheDocks()
        {
            _character.PreviousLocation = null;
            _character.CurrentScenario = _gameContent.GetStartingScenario();
            _character.CurrentLocation = _character.CurrentScenario.LocationList.Find(location => location.Title == "starting point");
            _character.CurrentLocation.Description = "You are back at The Docks";
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
                "We are back at the entrance of Town.";
            _character.PreviousLocation = previousLocation;
        }

        private void StartingPointExecuteInput(string input)
        {
            if (input == "go east" || input == "go to boat house" || input == "go to the boat house")
                GoToBoatHouse(_character.CurrentLocation.Title);

            else if (input == "go west" || input == "go to armorsmith" || input == "go to the armorsmith")
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
                _character.CurrentLocation.Description = "You are still at the starting point \r\nIf you want to go back to the Muddy road, type: enter muddy road";
        }

        private void EnterMuddyRoad()
        {
            _character.CurrentScenario = _gameContent.GetMuddyRoadScenario();
            _character.CurrentLocation = _character.CurrentScenario.LocationList.First(l => l.Title == "gate");
            _character.PreviousLocation = null;
            _character.CurrentLocation.Description = "You have entered Muddy roads.\r\nYou are still at the gate.\r\nIf you want to go back to Town, type: enter town.\r\nElse you can move as you please within Muddy roads";
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

       
    }
}
