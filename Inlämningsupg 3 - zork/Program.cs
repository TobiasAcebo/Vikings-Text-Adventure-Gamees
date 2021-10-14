using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inlämningsupg_3___zork
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var gameContent = new GameContent();
            var character = new Character(gameContent.GetTownScenario(), "Tobias");
            character.CurrentLocation = character.CurrentScenario.LocationList.First(l => l.Title == "starting point");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmScenario(character, gameContent));
        }
    }
}
