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
    public partial class FrmScenario : Form
    {
        private Character _character;
        public FrmScenario(Character character)
        {
            _character = character;
            
            InitializeComponent();
            playerNameLabel.Text = _character.Name;
        }

        private void FrmScenario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            string inputExceptionMessage = InputHandler.GetInputExceptionMessage(_character, userInputTxt.Text);

            if (!string.IsNullOrEmpty(inputExceptionMessage)) 
                PrintExceptionMessage(inputExceptionMessage);
            else
            {
                //_game.ExecuteCommand(_character, userInputTxt.Text);

                UpdateScenario();
            }
        }

        private void UpdateScenario()
        {
            throw new NotImplementedException();
        }

        private void PrintExceptionMessage(string inputExceptionMessage)
        {
            throw new NotImplementedException();
        }
    }
}
