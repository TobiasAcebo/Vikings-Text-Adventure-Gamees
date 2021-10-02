using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlämningsupg_3___zork.GameClasses
{
    class GameTheDocks : Game
    {
        private Character _character;
        public GameTheDocks(Character character) : base(character)
        {
            _character = character;
        }

        public override void ExecuteInput(string input)
        {
            var currentLocation = _character.CurrentLocation;

            if (currentLocation.Title == "starting point")
                StartingPointExecuteInput(input);
            
            else if (currentLocation.Title == "end of docks")
                EndOfDocksExecuteInput(input);
            
            else if (currentLocation.Title == "water")
                WaterExecuteInput(input);
            
        }

        private void StartingPointExecuteInput(string input)
        {

            if (input == "go east" || input == "go west" || input == "jump in water" || input == "jump into the water")
                GoToWater();
            
            else if (input == "go south" || input == "go on the boat" || input == "go on boat")
                GoToBoat();
            
            else if (input == "go north" || input == "go to fisherman" || input == "go to end of docks")
                GoToEndOfDocks();
            
            else if (input == "go back")
            {
                if (_character.PreviousLocation != null && _character.PreviousLocation != "starting point")
                    GoBack();
                else
                    _character.CurrentLocation.Description = "You are still at the starting point";
            }
            else if (input == "go to gate")
                GoToGate();

            _character.PreviousLocation = "starting point";

            //DESSA KOMMANDON ÄR KVAR:
            //"open gate",
            //"look",
            //"hi",
            //"hi there",
            //"hello",
            //"hello there", 
            //"talk to fisherman",
            //"talk",
            //"buy fishing line",
            //"buy knife",
            //"buy fishing line and knife"

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
        private void WaterExecuteInput(string input)
        {
            if (input == "go back")
            {
                if (_character.PreviousLocation != null)
                {
                    if (_character.PreviousLocation == "starting point")
                    {
                        _character.CurrentLocation = _character.CurrentScenario.LocationList.Find(x => x.Title == "starting point");
                        _character.CurrentLocation.Description =
                            "Ah here we are, back were we started. At the end of the docks I can see a fisherman talking about his travels with his men. ";
                    }
                    else if (_character.PreviousLocation == "boat")
                    {
                        _character.CurrentLocation = _character.CurrentScenario.LocationList.Find(x => x.Title == "boat");
                        _character.CurrentLocation.Description = "You are back on the ship.";
                    }
                    //fortsättning följer....
                }
            }
            //fortsättning följer.....

            _character.PreviousLocation = "water";
        }
        private void GoBack()
        {
            if (_character.PreviousLocation == "water")
                GoBackToWater();

            else if (_character.PreviousLocation == "boat")
                GoBackToBoat();

            else if (_character.PreviousLocation == "end of docks")
                GoBackToEndOfDocks();

            else if (_character.PreviousLocation == "end of docks")
                GoBackToGate();

            else if (_character.PreviousLocation == "west side")
                GoBackToWestSide();

            else if (_character.PreviousLocation == "guidance")
                GoBackToGuidance();

            //fortsättning följer....
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

    }
}
