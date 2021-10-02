using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inlämningsupg_3___zork.GameClasses;

namespace Inlämningsupg_3___zork
{
    public class Game
    {
        private Character _character;
      
        public Game(Character character)
        {
            this._character = character;
        }

        public virtual void ExecuteInput(string input)
        {
            var lowerCaseInput = input.ToLower();
            var currentScenario = _character.CurrentScenario;

            if(currentScenario.Id == 1)
            {
                var gameTheDocks = new GameTheDocks(_character);
                gameTheDocks.ExecuteInput(lowerCaseInput);
            }

            _character.MovesCount++;
        }
    }
}
