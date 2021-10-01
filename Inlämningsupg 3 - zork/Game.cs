using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlämningsupg_3___zork
{
    class Game
    {
        private Character _character;

        public Game(Character character)
        {
            this._character = character;
        }

        public void ExecuteInput(string input)
        {
            var lowerCaseInput = input.ToLower();
            var currentScenario = _character.CurrentScenario;

            if(currentScenario.Id == 1)
            {
                ExecuteInputTheDocks(lowerCaseInput);
            }

            
            _character.MovesCount++;
        }

        private void ExecuteInputTheDocks(string input)
        {
            var currentLocation = _character.CurrentLocation;

            if(currentLocation.Title == "starting point")
            {
                StartingPointTheDocks(input);
            }

            else if (currentLocation.Title == "end of docks")
            {
                EndOfDocks(input);
            }
            else if (currentLocation.Title == "water")
            {
                WaterTheDocks(input);
            }
        }

        private void WaterTheDocks(string input)
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
        }

        private void StartingPointTheDocks(string input)
        {
            

            if(input == "go east" || input == "go west" || input == "jump in water" || input == "jump into the water")
            {
                _character.CurrentLocation = _character.CurrentScenario.LocationList.Find(x => x.Title == "water");
                _character.CurrentLocation.Description =
                    "Oh no! You fell into the water. Try and climb back up the docks.";
                
            }

            else if (input == "go south" || input == "go on the boat" || input == "go on boat")
            {
                _character.CurrentLocation = _character.CurrentScenario.LocationList.Find(x => x.Title == "boat");
                _character.CurrentLocation.Description = "You have boarded the ship.";
            }

            else if (input == "go north" || input == "go to fisherman" || input == "go to end of docks")
            {
                _character.CurrentLocation = _character.CurrentScenario.LocationList.Find(x => x.Title == "end of docks");
                _character.CurrentLocation.Description =
                    "You are at the end of the docks, there's a fisherman here talking about his travels with his men.";
            }
            else if (input == "go back")
            {
                if (_character.PreviousLocation != null)
                {
                    if (_character.PreviousLocation == "water")
                    {
                        _character.CurrentLocation = _character.CurrentScenario.LocationList.Find(x => x.Title == "water");
                        _character.CurrentLocation.Description =
                            "Oh no! You fell into the water AGAIN. Try and climb back up the docks.";
                    }
                    else if (_character.PreviousLocation == "boat")
                    {
                        _character.CurrentLocation = _character.CurrentScenario.LocationList.Find(x => x.Title == "boat");
                        _character.CurrentLocation.Description = "You are back on the ship.";
                    }
                    //fortsättning följer....
                }
            }
            _character.PreviousLocation = "starting point";

            //DESSA KOMMANDON ÄR KVAR:
            //"open gate",
            //"go to gate",
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

        private void EndOfDocks(string input)
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

    }
}
