﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inlämningsupg_3___zork.Interfaces;

namespace Inlämningsupg_3___zork.GameClasses
{
    class GameTheDocks : IGame
    {
        private readonly Character _character;
        private readonly GameContent _gameContent;
        public GameTheDocks(Character character, GameContent gameContent)
        {
            _character = character;
            _gameContent = gameContent;
        }

        public void ExecuteInput(string input)
        {
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
                WestSideExecuteInput();

            else if (currentLocation.Title == "guidance")
                GuidanceExecuteInput(input);

            else if (currentLocation.Title == "gate")
                GateExecuteInput(input);
        }

       

        private void StartingPointExecuteInput(string input)
        {

            if (input == "go east" || input == "go west" || IsTryingToJumpInWater(input))
                GoToWater();
            
            else if (input == "go south" || IsTryingToEnterBoat(input))
                GoToBoat();
            
            else if (input == "go north" || IsTryingToEnterEndOfDocks(input))
                GoToEndOfDocks();
            
            else if (input == "go to gate")
                GoToGate();

            else if (input == "open gate")
                TryOpenGate();

            else if (IsTryingToEnterMuddyRoad(input))
                TryEnterMuddyRoad();

            else if (input == "go back")
                StartingPointGoBack();
            
            else if (IsTryingToGreet(input) || input.Contains("excuse me"))
                _character.CurrentLocation.Description = "There is no one here to talk to at the starting point";
            
            else if (input == "talk to fisherman")
                _character.CurrentLocation.Description = "The fisherman is not here at starting point";

            else if (IsTryingToBuy(input))
                _character.CurrentLocation.Description = "There is no one here at the starting point who is selling anything. Perhaps the fisherman can help you.";
            
            else if (IsTryingToClimb(input))
                _character.CurrentLocation.Description = "It's not possible to climb here";

            else if (input == "look")
                _character.CurrentLocation.Description = _character.CurrentLocation.Description; //hur gör vi här? Vilken text ska visas vid "Look"?
            

            _character.PreviousLocation = "starting point";
        }

        


        private void WaterExecuteInput(string input)
        {
            if (input == "go back" || IsTryingToClimb(input))
                WaterGoBack();
            

            //ÅTERSTÅENDE KOMMANDON....
            //"go east",
            //"go west",
            //"go north",
            //"go south",
            //"go to fisherman",
            //"open gate",
            //"jump in water",
            //"jump into the water",
            //"go back",
            //"go to end of docks",
            //"go to gate",
            //"look",
            //"go on the boat",
            //"go on boat",
            //"hi",
            //"hi there",
            //"hello",
            //"hello there", 
            //"talk to fisherman",
            //"talk",
            //"buy fishing line",
            //"buy knife",
            //"buy fishing line and knife",
            //"buy knife and fishing line",
            //"go to starting point",
            //"enter muddy road",
            //"go to muddy road"

            _character.PreviousLocation = "water";
        }


        private void EndOfDocksExecuteInput(string input)
        {
            if (input == "Go east")
            {
                _character.CurrentLocation = _character.CurrentScenario.LocationList.Find(x => x.Title == "gate");
            }

            else if (input == "Go west")
            {
                _character.CurrentLocation = _character.CurrentScenario.LocationList.Find(x => x.Title == "west side");
            }

            else if (input == "Go back")
            {
                _character.CurrentLocation = _character.CurrentScenario.LocationList.Find(x => x.Title == "starting point");
            }

            else if (input == "Go forward")
            {
                _character.CurrentLocation = _character.CurrentScenario.LocationList.Find(x => x.Title == "guidance");

            }

            _character.PreviousLocation = "end of docks";

        }
        private void GateExecuteInput(string input)
        {
            throw new NotImplementedException();
        }

        private void GuidanceExecuteInput(string input)
        {
            throw new NotImplementedException();
        }

        private void WestSideExecuteInput()
        {
            throw new NotImplementedException();
        }

        private void BoatExecuteInput(string input)
        {
            throw new NotImplementedException();
        }


        private void GoBack()
        {
            if (_character.PreviousLocation == "starting point")
                GoBackToStartingPoint();

            else if (_character.PreviousLocation == "water")
                GoBackToWater();

            else if (_character.PreviousLocation == "boat")
                GoBackToBoat();

            else if (_character.PreviousLocation == "end of docks")
                GoBackToEndOfDocks();

            else if (_character.PreviousLocation == "gate")
                GoBackToGate();

            else if (_character.PreviousLocation == "west side")
                GoBackToWestSide();

            else if (_character.PreviousLocation == "guidance")
                GoBackToGuidance();
        }
        private void TryOpenGate()
        {
            if (_character.CurrentLocation.Title != "gate")
                _character.CurrentLocation.Description = "You can't open the gate from here";
            else
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
                    _character.CurrentLocation.Door.IsOpen = true;
                    _character.CurrentLocation.Description =
                        "You opened the gate. You can now enter Muddy Road";
                }
                else
                {
                    _character.CurrentLocation.Description =
                        "The gate is already open";
                }
            }
        }
        private void TryEnterMuddyRoad()
        {
            if (_character.CurrentLocation.Title != "gate")
                _character.CurrentLocation.Description = "You can only enter Muddy Road from the gate";
            else
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
        }
        
        private void StartingPointGoBack()
        {
            if (_character.PreviousLocation != null && _character.PreviousLocation != "starting point")
                GoBack();
            else
                _character.CurrentLocation.Description = "You are still at the starting point";
        }
        private void WaterGoBack()
        {
            if (_character.PreviousLocation != null && _character.PreviousLocation != "water")
                GoBack();
            else
                _character.CurrentLocation.Description = "You are still in the water";
        }

        private void GoBackToStartingPoint()
        {
            _character.CurrentLocation = _character.CurrentScenario.LocationList.Find(x => x.Title == "starting point");
            _character.CurrentLocation.Description =
                "Ah here we are, back were we started. At the end of the docks I can see a fisherman talking about his travels with his men. ";
        }
        private void GoBackToGuidance()
        {
            _character.CurrentLocation = _character.CurrentScenario.LocationList.Find(x => x.Title == "guidance");
            _character.CurrentLocation.Description =
                "Hi there, traveler. We meet again. You seem lost. Maybe the fisherman knows the way around this place. Remember to be polite.";
        }
        private void GoBackToWestSide()
        {
            _character.CurrentLocation = _character.CurrentScenario.LocationList.Find(x => x.Title == "west side");
            _character.CurrentLocation.Description = "West side of the docks. \r\nIt’s still noisy here. Very well, nothing to see I guess.";
        }
        private void GoBackToGate()
        {
            GoToGate();
        }
        private void GoBackToEndOfDocks()
        {
            _character.CurrentLocation = _character.CurrentScenario.LocationList.Find(x => x.Title == "end of docks");
            _character.CurrentLocation.Description =
                "Once again, you are at the end of the docks, there's a fisherman here talking about his travels with his men.";
        }
        private void GoBackToWater()
        {
            _character.CurrentLocation = _character.CurrentScenario.LocationList.Find(x => x.Title == "water");
            _character.CurrentLocation.Description =
                "Oh no! You fell into the water AGAIN. Try and climb back up the docks.";
        }
        private void GoBackToBoat()
        {
            _character.CurrentLocation = _character.CurrentScenario.LocationList.Find(x => x.Title == "boat");
            _character.CurrentLocation.Description = "You are back on the ship.";
        }

        private void GoToGate()
        {
            _character.CurrentLocation = _character.CurrentScenario.LocationList.Find(x => x.Title == "gate");
            var characterHasKey = _character.ItemList.Any(i => i.Title == "key");
            var gateIsOpen = _character.CurrentLocation.Door.IsOpen;
            if (!characterHasKey && !gateIsOpen)
            {
                _character.CurrentLocation.Description =
                    "A locked gate.Wondering where this leads. Do you have a key perhaps? We could find out. \r\nIf not, ask around the docks. Maybe someone knows.";
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
        private void GoToEndOfDocks()
        {
            _character.CurrentLocation = _character.CurrentScenario.LocationList.Find(x => x.Title == "end of docks");
            _character.CurrentLocation.Description =
                "You are at the end of the docks, there's a fisherman here talking about his travels with his men.";
        }
        private void GoToBoat()
        {
            _character.CurrentLocation = _character.CurrentScenario.LocationList.Find(x => x.Title == "boat");
            _character.CurrentLocation.Description = "You have boarded the ship.";
        }
        private void GoToWater()
        {
            _character.CurrentLocation = _character.CurrentScenario.LocationList.Find(x => x.Title == "water");
            _character.CurrentLocation.Description =
                "Oh no! You fell into the water. Try and climb back up the docks.";
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
        private bool IsTryingToBuy(string input)
        {
            var buyingPhrasesList = new List<string>
            {
                "buy fishing line",
                "buy knife",
                "buy fishing line and knife",
                "buy knife and fishing line"
            };

            return buyingPhrasesList.Contains(input);
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

        private bool CharacterHasKey()
        {
            return _character.ItemList.Any(i => i.Title == "key");
        }
    }
}
