using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inlämningsupg_3___zork
{
    public partial class StartScreen : Form
    {
        public StartScreen()
        {
            InitializeComponent();
        }

        private void playBtn_Click(object sender, EventArgs e)
        {
            GameContent gameContent = new GameContent();

            Scenario currentScenario = gameContent.GetStartingScenario();

            Character character = new Character(currentScenario, userNameTxt.Text);
            character.CurrentLocation = currentScenario.LocationList.First(l => l.Title == "starting point");

            FrmScenario frmScenario = new FrmScenario(character, gameContent);
            StartScreen.ActiveForm.Hide();
            frmScenario.Show();
            
        }
    }
}
