using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inlämningsupg_3___zork.Interfaces;

namespace Inlämningsupg_3___zork.GameClasses
{
    class GameTheDocks : Game, IGame
    {
        private readonly Character _character;
        private readonly GameContent _gameContent;
        public GameTheDocks(Character character, GameContent gameContent) :base(character, gameContent)
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

            if (input == "use knife on fishing line" || input == "use fishing line on knife")
            {
                TryCreateKey();
                return;
            }
            if (DropItemInputWorks(input))
                return;
            
            if (PickUpItemInputWorks(input))
                return;

            var currentLocation = _character.CurrentLocation;

            if (currentLocation.Title == "starting point")
                StartingPointExecuteInput(input);

            else if (currentLocation.Title == "water")
                WaterExecuteInput(input);

            else if (currentLocation.Title == "boat")
                BoatExecuteInput(input);

            else if (currentLocation.Title == "end of docks")
                EndOfDocksExecuteInput(input);

            else if (currentLocation.Title == "west side")
                WestSideExecuteInput(input);

            else if (currentLocation.Title == "guidance")
                GuidanceExecuteInput(input);

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
            if (CharacterHasKnifeAndFihsingLine())
            {
                Item key = new Item();
                key.IsKey = true;
                key.Title = "key";
                _character.ItemList.Clear();
                _character.ItemList.Add(key);
                _character.CurrentLocation.Description = "\"You have made a key!\"";
            }
        }

        private void StartingPointExecuteInput(string input)
        {

            if (input == "go east" || input == "go west" || IsTryingToJumpInWater(input))
                GoToWater(_character.CurrentLocation.Title);
            
            else if (input == "go south" || IsTryingToEnterBoat(input))
                GoToBoat(_character.CurrentLocation.Title);
            
            else if (input == "go north"|| IsTryingToEnterEndOfDocks(input))
                GoToEndOfDocks(_character.CurrentLocation.Title);
            
            else if (input == "go back")
                StartingPointGoBack(_character.CurrentLocation.Title);

            else
                CannotExecuteInputFrom(_character.CurrentLocation.Title);
        }
        private void WaterExecuteInput(string input)
        {
            if (IsTryingToClimb(input))
                GoBackToStartingPoint(_character.CurrentLocation.Title);
                
            else
                CannotExecuteInputFrom(_character.CurrentLocation.Title);
        }
        private void BoatExecuteInput(string input)
        {
            if (input == "go north" || input == "go to starting point" || input == "go back")
                GoBackToStartingPoint(_character.CurrentLocation.Title);

            else if (input == "go south" || input == "go east" || input == "go west" || IsTryingToJumpInWater(input))
                GoToWater(_character.CurrentLocation.Title);

            else
                CannotExecuteInputFrom(_character.CurrentLocation.Title);
        }
        private void WestSideExecuteInput(string input)
        {
            if(input == "go east" || input == "go back" || IsTryingToEnterEndOfDocks(input))
                GoBackToEndOfDocks(_character.CurrentLocation.Title);
            else
                CannotExecuteInputFrom(_character.CurrentLocation.Title);
        }
        private void GateExecuteInput(string input)
        {
            if(input == "open gate") // lägg till flera alternativ
                TryOpenGate();

            else if(input == "go west" || input == "go back")
                GoBackToEndOfDocks(_character.CurrentLocation.Title);

            else if(IsTryingToEnterMuddyRoad(input))
                TryEnterMuddyRoad();

            else
                CannotExecuteInputFrom(_character.CurrentLocation.Title);
        }
        private void GuidanceExecuteInput(string input)
        {
            if(input == "go back" || IsTryingToEnterEndOfDocks(input))
                GoBackToEndOfDocks(_character.CurrentLocation.Title);
            else
                CannotExecuteInputFrom(_character.CurrentLocation.Title);
        }
        private void EndOfDocksExecuteInput(string input)
        {
            if (input == "go east" || input == "go to gate")
            {
                GoToGate(_character.CurrentLocation.Title);
                _character.InDialog = false;
            }
                
            else if (input == "go west")
            {
                GoToWestSide(_character.CurrentLocation.Title);
                _character.InDialog = false;
            }
                
            else if (input == "go back")
            {
                EndOfDocksGoBack(_character.CurrentLocation.Title);
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

            else if (input.Contains("excuse me"))
                OpenDialog();

            else if (input.Contains("great halls"))
            {
                if (_character.InDialog)
                    _character.CurrentLocation.Description = "Fisherman: \"Ah yes, the Great halls is where King Ragnar lives.\r\nYou have to go through the gate to get there.\"";
                else
                     DialogNotOpen();
            }

            else if (input.Contains("gate"))
            {
                if (_character.InDialog)
                    _character.CurrentLocation.Description = "Fisherman: \"Yes, I know about this gate. It's located east of the docks\"";
                else
                    DialogNotOpen();
            }

            else if (input.Contains("key"))
            {
                if (_character.InDialog)
                    _character.CurrentLocation.Description = "Fisherman: \"I don't know anything about a key..\r\nI do sell a knife and a fishing line though.\r\nmaybe they can come in handy for your misson.\"";
                else
                    DialogNotOpen();
            }

            else if (IsTryingToGreet(input))
            {
                if (_character.InDialog)
                    _character.CurrentLocation.Description = "Fisherman: \"Hello there, traveler. How can I help you?\"";
                else
                    DialogNotOpen();
            }

            else if (input == "buy knife")
            {
                if (_character.InDialog)
                    TryBuyKnife();
                else
                    DialogNotOpen();
            }

            else if (input == "buy fishing line")
            {
                if (_character.InDialog)
                    TryBuyFishingLine();
                else
                    DialogNotOpen();
            }

            else if (input == "buy fishing line and knife" || input == "buy knife and fishing line")
            {
                if (_character.InDialog)
                    TryBuyFishingLineAndKnife();
                else
                    DialogNotOpen();
            }
        }

        
        private void OpenDialog()
        {
            _character.CurrentLocation.Description = "Fisherman: \"Oh hello there traveler. Didn't quite see you.\r\nHow can I help you?\"";
            _character.InDialog = true;
        }

        private void TryOpenGate()
        {

            bool characterHasKey = CharacterHasKey();
            bool gateIsOpen = _character.CurrentLocation.Door.IsOpen;

            if (!characterHasKey && !gateIsOpen)
            {
                _character.CurrentLocation.Description =
                    "The gate is locked and you don't have a key. Ask around the docks. Maybe someone knows how to get one.";
            }
            else if (characterHasKey && !gateIsOpen)
            {
                OpenGate();
                _character.CurrentLocation.Description = "You opened the gate. You can now enter Muddy Road.";
            }
            else
                _character.CurrentLocation.Description = "The gate is already open. You can now enter Muddy Road.";
            
        }

        private void TryEnterMuddyRoad()
        {
            if (_character.CurrentLocation.Door.IsOpen)
            {
                _character.CurrentScenario = _gameContent.GetMuddyRoadScenario();
                _character.CurrentLocation = _character.CurrentScenario.LocationList.First(l => l.Title == "starting point");
            }
            else if (CharacterHasKey())
            {
                _character.CurrentLocation.Description =
                    "You must open the gate to enter Muddy Road. I believe you have the key.";
            }
            else
            {
                _character.CurrentLocation.Description =
                    "You must open the gate to enter Muddy Road. I don't believe you have the key, do you. Ask around the docks. Maybe someone knows how to get one.";
            }
        }
        private void TryBuyFishingLine()
        {
            if (FishingLineAvailable())
            {
                BuyFishingLine();
                _character.CurrentLocation.Description = "Fisherman: \"Here you go.\"";
                 InventoryStatusPrint();
            }
            else
                _character.CurrentLocation.Description = "\"That item has already been bought.\"";
        }

        private void InventoryStatusPrint()
        {
            if (CharacterHasKnifeAndFihsingLine())
            {
                _character.CurrentLocation.Description = "You have knife and fishing line in your inventory \r\n";
                _character.CurrentLocation.Description += "\"Try use them on each other.\"";
            }
        }

        private bool CharacterHasKnifeAndFihsingLine()
        {
            if (_character.ItemList.Count(item => item.Title == "knife" || item.Title == "fishing line") == 2)
            {
                return true;
            }
            return false;
        }

        private void TryBuyFishingLineAndKnife()
        {
            if (FishingLineAvailable() && KnifeAvailable())
            {
                BuyFishingLine();
                BuyKnife();
                _character.CurrentLocation.Description = "Fisherman: \"Here you go.\"";
                InventoryStatusPrint();
            }
            else
                _character.CurrentLocation.Description = "You can't do that.";
        }
        private void TryBuyKnife()
        {
            if (KnifeAvailable())
            {
                BuyKnife();
                _character.CurrentLocation.Description = "Fisherman:  \"Here you go.\"";
                InventoryStatusPrint();
            }
            else
                _character.CurrentLocation.Description = "\"That item has already been bought.\"";
        }

        private void StartingPointGoBack(string previousLocation)
        {
            if (_character.PreviousLocation == null)
                _character.CurrentLocation.Description = "You are still at the starting point";
            else
            {
                if (_character.PreviousLocation == "end of docks")
                    GoBackToEndOfDocks(previousLocation);

                else if (_character.PreviousLocation == "water")
                    GoBackToWater(previousLocation);

                else if (_character.PreviousLocation == "boat")
                    GoBackToBoat(previousLocation);
            }
        }
        private void EndOfDocksGoBack(string previousLocation)
        {
            if (_character.PreviousLocation == "starting point")
                GoBackToStartingPoint(previousLocation);

            else if (_character.PreviousLocation == "west side")
                GoBackToWestSide(previousLocation);

            else if (_character.PreviousLocation == "gate")
                GoBackToGate(previousLocation);

            else if (_character.PreviousLocation == "guidance")
                GoBackToGuidance(previousLocation);
        }

        private void GoBackToStartingPoint(string previousLocation)
        {
            _character.CurrentLocation = _character.CurrentScenario.LocationList.Find(x => x.Title == "starting point");
            _character.CurrentLocation.Description =
                "Ah here we are, back were we started. At the end of the docks I can see a fisherman talking about his travels with his men. ";
            _character.PreviousLocation = previousLocation;
        }
        private void GoBackToGuidance(string previousLocation)
        {
            _character.CurrentLocation = _character.CurrentScenario.LocationList.Find(x => x.Title == "guidance");
            _character.CurrentLocation.Description =
                "Hi there, traveler. We meet again. You seem lost. Maybe the fisherman knows the way around this place. Remember to be polite.";
            _character.PreviousLocation = previousLocation;
        }
        private void GoBackToWestSide(string previousLocation)
        {
            _character.CurrentLocation = _character.CurrentScenario.LocationList.Find(x => x.Title == "west side");
            _character.CurrentLocation.Description = "West side of the docks. \r\nIt’s still noisy here. Very well, nothing to see I guess.";
            _character.PreviousLocation = previousLocation;
        }
        private void GoBackToGate(string previousLocation)
        {
            GoToGate(previousLocation);
        }
        private void GoBackToEndOfDocks(string previousLocation)
        {
            _character.CurrentLocation = _character.CurrentScenario.LocationList.Find(x => x.Title == "end of docks");
            _character.CurrentLocation.Description =
                "Once again, you are at the end of the docks, there's a fisherman here talking about his travels with his men.";
            _character.PreviousLocation = previousLocation;
        }
        private void GoBackToWater(string previousLocation)
        {
            _character.CurrentLocation = _character.CurrentScenario.LocationList.Find(x => x.Title == "water");
            _character.CurrentLocation.Description =
                "Oh no! You fell into the water AGAIN. Try and climb back up the docks.";
            _character.PreviousLocation = previousLocation;
        }
        private void GoBackToBoat(string previousLocation)
        {
            _character.CurrentLocation = _character.CurrentScenario.LocationList.Find(x => x.Title == "boat");
            _character.CurrentLocation.Description = "You are back on the ship.";
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
                    "A locked gate. Wondering where this leads. Do you have a key perhaps? We could find out. \r\nIf not, ask around the docks. Maybe someone knows.";
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
        private void GoToEndOfDocks(string previousLocation)
        {
            _character.CurrentLocation = _character.CurrentScenario.LocationList.Find(x => x.Title == "end of docks");
            _character.CurrentLocation.Description =
                "You are at the end of the docks, there's a fisherman here talking about his travels with his men.";
            _character.PreviousLocation = previousLocation;
        }
        private void GoToBoat(string previousLocation)
        {
            _character.CurrentLocation = _character.CurrentScenario.LocationList.Find(x => x.Title == "boat");
            _character.CurrentLocation.Description = "You have boarded the ship.";
            _character.PreviousLocation = previousLocation;
        }
        private void GoToWater(string previousLocation)
        {
            _character.CurrentLocation = _character.CurrentScenario.LocationList.Find(x => x.Title == "water");
            _character.CurrentLocation.Description =
                "Oh no! You fell into the water. Try and climb back up the docks.";
            _character.PreviousLocation = previousLocation;
        }
        private void GoToWestSide(string previousLocation)
        {
            _character.CurrentLocation = _character.CurrentScenario.LocationList.Find(x => x.Title == "west side");
            _character.PreviousLocation = previousLocation;
        }
        private void EndOfDocksGoForward(string previousLocation)
        {
            _character.CurrentLocation = _character.CurrentScenario.LocationList.Find(x => x.Title == "guidance");
            _character.CurrentLocation.Description = "Lady: \"Hey there traveler! You seem lost. Maybe the fisherman knows the way around this place.\"";
            _character.PreviousLocation = previousLocation;
        }

        public void Look()
        {
            _character.CurrentLocation.Description = _character.CurrentScenario.Description + "\r\n"; 
            _character.CurrentLocation.Description += "\r\nThere is a gate located east of the docks";
            DisplayItemsAvailable();
        }

        private bool IsTryingToGreet(string input)
        {
            var greetingPhrasesList = new List<string>
            {
                "hi",
                "hi there",
                "hello",
                "hello there"
            };

            return greetingPhrasesList.Contains(input);
        }
        private bool IsTryingToClimb(string input)
        {
            var climbingPhrasesList = new List<string>
            {
                "climb up",
                "climb back up"
            };

            return climbingPhrasesList.Contains(input);
        }
        private bool IsTryingToEnterBoat(string input)
        {
            var boatPhrasesList = new List<string>
            {
                "go on the boat",
                "go on boat"
            };

            return boatPhrasesList.Contains(input);
        }
        private bool IsTryingToEnterEndOfDocks(string input)
        {
            var endOfDocksPhrasesList = new List<string>
            {
                "go to fisherman",
                "go to end of docks"
            };

            return endOfDocksPhrasesList.Contains(input);
        }
        private bool IsTryingToJumpInWater(string input)
        {
            var jumpInWaterPhrasesList = new List<string>
            {
                "jump in water",
                "jump into the water"
            };

            return jumpInWaterPhrasesList.Contains(input);
        }
        private bool IsTryingToEnterMuddyRoad(string input)
        {
            var enterMuddyRoadPhrasesList = new List<string>
            {
                "enter muddy road",
                "go to muddy road"
            };

            return enterMuddyRoadPhrasesList.Contains(input);
        }
 
        private void DialogNotOpen()
        {
            _character.CurrentLocation.Description = "They seem to be in a middle of a conversation.\r\nTry and get their attention by being polite.";
        }
        private bool KnifeAvailable()
        {
            return _character.CurrentLocation.ItemList.Any(x => x.Title == "knife");
        }

        private void BuyFishingLine()
        {
            Item fishingLine = _character.CurrentLocation.ItemList.Find(x => x.Title == "fishing line");
            _character.ItemList.Add(fishingLine);
            _character.CurrentLocation.ItemList.Remove(fishingLine);
        }
        private void BuyKnife()
        {
            Item knife = _character.CurrentLocation.ItemList.Find(x => x.Title == "knife");
            _character.ItemList.Add(knife);
            _character.CurrentLocation.ItemList.Remove(knife);
        }
        private bool FishingLineAvailable()
        {
            return _character.CurrentLocation.ItemList.Any(x => x.Title == "fishing line");
        }
        private void CannotExecuteInputFrom(string currentLocationTitle)
        {
            _character.CurrentLocation.Description = "The command may work somewhere in this game but not in: " + currentLocationTitle;
        }
    }
}
