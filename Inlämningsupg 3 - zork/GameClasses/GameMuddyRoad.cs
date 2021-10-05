using Inlämningsupg_3___zork.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlämningsupg_3___zork.GameClasses
{
    class GameMuddyRoad : Game, IGame
    {
        private readonly Character _character;
        private readonly GameContent _gameContent;
        public GameMuddyRoad(Character character, GameContent gameContent) : base(character, gameContent)
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
        }

        public void Look()
        {
            _character.CurrentLocation.Description = _character.CurrentScenario.Description + "\r\n"; 
            _character.CurrentLocation.Description += "\r\nThere is a gate located north of the road";
            DisplayItemsAvailable();
        }
    }
}
