using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inlämningsupg_3___zork.GameClasses;
using Inlämningsupg_3___zork.Interfaces;

namespace Inlämningsupg_3___zork
{
    public class Game : IGame
    {
        private readonly Character _character;
        private readonly GameContent _gameContent;

        public Game(Character character, GameContent gameContent)
        {
            this._character = character;
            _gameContent = gameContent;
        }

        public void ExecuteInput(string input)
        {
            var lowerCaseInput = input.ToLower();
            var currentScenario = _character.CurrentScenario;

            if(currentScenario.Id == 1)
            {
                var gameTheDocks = new GameTheDocks(_character, _gameContent);
                gameTheDocks.ExecuteInput(lowerCaseInput);
            }


            _character.MovesCount++;
        }
    }
}
