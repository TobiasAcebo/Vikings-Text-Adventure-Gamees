using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlämningsupg_3___zork.GameClasses
{
    class GameTheDocks : Game
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
            
            if (input == "use knife on fishing line" || input == "use fishing line on knife")
            {
                TryCreateKey();
                return;
            }

            if (_character.CurrentLocation.Title != "end of docks")
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

        
        private void StartingPointExecuteInput(string input)
        {

            if (input.IsDirectionEast() || input.IsDirectionWest() || input.IsJumpInWater())
                GoTo("water");
            
            else if (input.IsDirectionSouth() || input.IsEnterBoat())
                GoTo("boat");
            
            else if (input.IsDirectionNorth() || input.IsMoveToEndOfDocks())
                GoTo("end of docks");
            
            else if (input.IsGoBack())
                StartingPointGoBack();

            else
                CannotExecuteInputFrom(_character.CurrentLocation.Title);
        }
        private void WaterExecuteInput(string input)
        {
            if (input.IsClimbUp())
                GoBackTo("starting point");
                
            else
                CannotExecuteInputFrom(_character.CurrentLocation.Title);
        }
        private void BoatExecuteInput(string input)
        {
            if (input.IsDirectionNorth() || input.IsMoveToStartingPoint() || input.IsGoBack())
                GoBackTo("starting point");

            else if (input.IsDirectionSouth() || input.IsDirectionEast() || input.IsDirectionWest() || input.IsJumpInWater())
                GoTo("water");
            else
                CannotExecuteInputFrom(_character.CurrentLocation.Title);
        }
        private void WestSideExecuteInput(string input)
        {
            if (input.IsDirectionEast() || input.IsGoBack() || input.IsMoveToEndOfDocks())
            {
                GoBackTo("end of docks");
                _character.InDialog = false;
            }
                
            
            else if (input.IsAGreeting())
            {
                if(_character.InDialog)
                    _character.CurrentLocation.Description = "Spirit of Thor: \"Hello there.\"";
                else
                {
                    //nåt svar om att det inte finns någon att säga hej till
                }
            }
            
            else if (input.Contains("thor"))
                OpenDialogForThor();

            else if (input.Contains("key"))
            {
                if(_character.InDialog) 
                    _character.CurrentLocation.Description = "Spirit of Thor: \"Yes the key to the Great halls.\r\nYou will need to collect 2 items to make one.\r\nFind the helmet in muddy road.\r\nThen go to the swordsmith in Town and remember to say: " + "\"good work\"" + " when you enter.\"";
                else
                {
                    //nåt svar om att det inte finns någon att fråga det om
                }
            }

            else
                CannotExecuteInputFrom(_character.CurrentLocation.Title);
        }
        private void GateExecuteInput(string input)
        {
            if (input.IsOpenGate())
                TryOpenGate();

            else if (input.IsDirectionWest())
                GoBackTo("end of docks");

            else if (input.IsGoBack())
            {
                if (_character.PreviousLocation != null)
                    GoBackTo("end of docks");
                
                else
                    _character.CurrentLocation.Description = "You need to enter muddy road again";
            }

            else if (input == "yes")
                _character.CurrentLocation.Description = "Try open the gate";

            else if (input.IsEnterMuddyRoad())
                TryEnterMuddyRoad();

            else
                CannotExecuteInputFrom(_character.CurrentLocation.Title);
        }
        private void GuidanceExecuteInput(string input)
        {
            if(input.IsGoBack() || input.IsMoveToEndOfDocks())
                GoBackTo("end of docks");
            else
                CannotExecuteInputFrom(_character.CurrentLocation.Title);
        }
        private void EndOfDocksExecuteInput(string input)
        {
            if (input.IsDirectionEast() || input.IsMoveToGate())
            {
                GoToGate();
                _character.InDialog = false;
            }
                
            else if (input.IsDirectionWest())
            {
                GoTo("west side");
                _character.InDialog = false;
            }
                
            else if (input.IsGoBack())
            {
                EndOfDocksGoBack();
                _character.InDialog = false;
            }
                
            else if (input.IsDirectionNorth())
            {
                GoTo("guidance");
                _character.InDialog = false;
            }
            else if (input.IsDirectionSouth() || input.IsMoveToStartingPoint())
            {
                GoBackTo("starting point");
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
            else if (input.Contains("coin"))
            {
                if (_character.InDialog)
                    _character.CurrentLocation.Description = "Fisherman: \"You will need a coin to shop here.\r\nYou should be able to find one around here.\"" + "\r\n\r\nRemember, you can move anywhere you want by typing for example:\r\ngo north\r\ngo west\r\ngo south\r\ngo east ";
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

            else if (input.IsAGreeting() || input == "talk to fisherman")
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
            else
                CannotExecuteInputFrom(_character.CurrentLocation.Title);
        }

        
        private void InventoryStatusPrint()
        {
            if (CharacterHasKnifeAndFihsingLine())
            {
                _character.CurrentLocation.Description += "You have knife and fishing line in your inventory \r\n";
                _character.CurrentLocation.Description += "\"Try use them on each other.\"";
            }
        }

        private void StartingPointGoBack()
        {
            if (_character.PreviousLocation == null)
                _character.CurrentLocation.Description = "You are still at the starting point";
            else
            {
                if (_character.PreviousLocation == "end of docks")
                    GoBackTo("end of docks");

                else if (_character.PreviousLocation == "water")
                    GoBackTo("water");

                else if (_character.PreviousLocation == "boat")
                    GoBackTo("boat");
            }
        }
        private void EndOfDocksGoBack()
        {
            if (_character.PreviousLocation == "starting point")
                GoBackTo("starting point");

            else if (_character.PreviousLocation == "west side")
                GoBackTo("west side");

            else if (_character.PreviousLocation == "gate")
                GoToGate();

            else if (_character.PreviousLocation == "guidance")
                GoBackTo("guidance");
        }

        private void GoBackTo(string locationTitle)
        {
            _character.PreviousLocation = _character.CurrentLocation.Title;
            _character.CurrentLocation = _character.CurrentScenario.LocationList.Find(x => x.Title == locationTitle);

            if(_character.CurrentLocation.Title == "starting point")
                _character.CurrentLocation.Description = "Ah here we are, back were we started. At the end of the docks I can see a fisherman talking about his travels with his men. ";

            else if(_character.CurrentLocation.Title == "end of docks")
                _character.CurrentLocation.Description = "Once again, you are at the end of the docks, there's a fisherman here talking about his travels with his men.";

            else if(_character.CurrentLocation.Title == "water")
                _character.CurrentLocation.Description = "Oh no! You fell into the water AGAIN. Try and climb back up the docks.";

            else if(_character.CurrentLocation.Title == "west side")
                _character.CurrentLocation.Description = "West side of the docks. \r\nIt’s still noisy here. Very well, nothing to see I guess.";

            else if (_character.CurrentLocation.Title == "guidance")
                _character.CurrentLocation.Description = "Hi there, traveler. We meet again. You seem lost. Maybe the fisherman knows the way around this place. Remember to excuse yourself to get his attention.";

            else if (_character.CurrentLocation.Title == "boat")
                _character.CurrentLocation.Description = "You are back on the ship.";
        }
        private void GoTo(string locationTitle)
        {
            _character.PreviousLocation = _character.CurrentLocation.Title;
            _character.CurrentLocation = _character.CurrentScenario.LocationList.Find(x => x.Title == locationTitle);
        }
        private void GoToGate()
        {
            _character.PreviousLocation = _character.CurrentLocation.Title;
            _character.CurrentLocation = _character.CurrentScenario.LocationList.Find(x => x.Title == "gate");
            var characterHasKey = _character.ItemList.Any(i => i.Title == "key");
            var gateIsOpen = _character.CurrentLocation.Door.IsOpen;
            if (!characterHasKey && !gateIsOpen)
            {
                _character.CurrentLocation.Description =
                    "A locked gate. Wondering where this leads. Do you have a key perhaps?. \r\nIf not, ask around the docks. Maybe someone knows.";
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
        }
        
        private bool KnifeAvailable()
        {
            return _character.CurrentLocation.ItemList.Any(x => x.Title == "knife");
        }
        private bool FishingLineAvailable()
        {
            return _character.CurrentLocation.ItemList.Any(x => x.Title == "fishing line");
        }
        private bool CharacterHasKnifeAndFihsingLine()
        {
            if (_character.ItemList.Count(item => item.Title == "knife" || item.Title == "fishing line") == 2)
            {
                return true;
            }
            return false;
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

        private void CoinSpent()
        {
            if (CharacterHasKnifeAndFihsingLine())
            {
                var coin = _character.ItemList.First(i => i.isCoin);
                _character.ItemList.Remove(coin);
                
            }
        }

        private void OpenDialogForThor()
        {
            _character.CurrentLocation.Description = "You have unlocked the Spirit of Thor. Ask him about the key.";
            _character.InDialog = true;
        }
        private void OpenDialog()
        {
            _character.CurrentLocation.Description = "Fisherman: \"Oh hello there traveler. Didn't quite see you.\r\nHow can I help you?\"";
            _character.InDialog = true;
        }
        private void DialogNotOpen()
        {
            _character.CurrentLocation.Description = "They seem to be in a middle of a conversation.\r\nTry and get their attention by being polite.";
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
                _character.PreviousLocation = null;
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
        private void TryBuyKnife()
        {
            if (KnifeAvailable())
            {
                if (CharacterHasCoin())
                {
                    BuyKnife();
                    _character.CurrentLocation.Description = "Fisherman:  \"Here you go.\"";
                    CoinSpent();
                    InventoryStatusPrint();
                }
                else
                    _character.CurrentLocation.Description = "Fisherman: \"You can't buy that without a coin.\"";

            }
            else
                _character.CurrentLocation.Description = "Fisherman: \"That item has already been bought.\"";
        }
        private void TryBuyFishingLine()
        {
            if (FishingLineAvailable())
            {
                if (CharacterHasCoin())
                {
                    BuyFishingLine();
                    _character.CurrentLocation.Description = "Fisherman: \"Here you go.\"";
                    CoinSpent();
                    InventoryStatusPrint();
                }
                else
                    _character.CurrentLocation.Description = "Fisherman: \"You can't buy that without a coin.\"";

            }
            else
                _character.CurrentLocation.Description = "Fisherman: \"That item has already been bought.\"";
        }
        private void TryBuyFishingLineAndKnife()
        {
            if (FishingLineAvailable() && KnifeAvailable())
            {
                if (CharacterHasCoin())
                {
                    BuyFishingLine();
                    BuyKnife();
                    _character.CurrentLocation.Description = "Fisherman: \"Here you go.\"";
                    CoinSpent();
                    InventoryStatusPrint();
                }
                else
                    _character.CurrentLocation.Description = "Fisherman: \"You can't buy that without a coin.\"";

            }
            else
                _character.CurrentLocation.Description = "You can't do that.";
        }

    }
}
