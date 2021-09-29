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

            var currentScenario = _character.CurrentScenario;

            if(currentScenario.Id == 1)
            {
                ExecuteInputTheDocks(input);
            }
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
        }

        private void StartingPointTheDocks(string input)
        {
            if(input == "Go east" || input == "Go west")
            {
                _character.CurrentLocation = _character.CurrentScenario.LocationList.Find(x => x.Title == "water");
            }

            else if (input == "Go back")
            {
                _character.CurrentLocation = _character.CurrentScenario.LocationList.Find(x => x.Title == "boat");
            }

            else if (input == "Go forward")
            {
                _character.CurrentLocation = _character.CurrentScenario.LocationList.Find(x => x.Title == "end of docks");
            }

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

        }

    }
}
