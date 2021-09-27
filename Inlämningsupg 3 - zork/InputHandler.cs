using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlämningsupg_3___zork
{
    class InputHandler
    {
        //private readonly standardCommands = new string[]{""}
        public List<string> GetInputExceptionsList(Scenario currentScenario, Character character, string command)
        {
            
            if (currentScenario.Id == 1)
                return GetTheDocksInputExceptionsList(currentScenario, character, command);

            return null;
        }

        private List<string> GetTheDocksInputExceptionsList(Scenario currentScenario, Character character, string command)
        {
            var currentLocation = character.CurrentLocation;
            return null;
        }
    }
}
