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
        private int _seconds = 0;
        private int _minutes = 0;
        private Character _character;
        private Game _game;
        private readonly GameContent _gameContent;
        public FrmScenario(Character character, GameContent gameContent)
        {
            _character = character;
            _gameContent = gameContent;
            _game = new Game(_character, _gameContent);
            InitializeComponent();
            playerNameLabel.Text = _character.Name;
            GameTimer();
            Scene();
            ActiveControl = userInputTxt;
        }
       
        private void FrmScenario_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void UpdateScenario()
        {
            Moves();
            Scene();
            Inventory();
        }

        private void Inventory() 
        {
            ItemsTheDocks();
        }
        private void ItemsTheDocks()
        {
            var currentInventory = _character.ItemList;
            item1Label.Text = "";
            item2Label.Text = "";
            foreach (var item in currentInventory)
            {
               
                if (item1Label.Text == "" && item2Label.Text == "")
                {
                    item1Label.Text = item.Title;
                }
                else if (item1Label.Text != "" && item2Label.Text == "")
                    item2Label.Text = item.Title;
            }
            
        }
       
        private void Scene()
        {
            string howToPlay = "\"How to play\"";
            string lineBreak = "---------------------------------------------------------";
            var currentScenario = _character.CurrentScenario;
            if (_character.MovesCount == 0)
             roomDescriptionTxt.Text = lineBreak + "\r\n" + "Welcome to Vikings.\r\nThis is a text-based fantasy adventure game.\r\nYou can find all rules in " + howToPlay + "\r\n" + lineBreak + "\r\n\r\n" + _character.CurrentLocation.Description + "\r\n\r\n";
            else
             roomDescriptionTxt.AppendText(_character.CurrentLocation.Description + "\r\n\r\n");
            
            roomNameLabel.Text = currentScenario.Title;
            roomPicturebox.ImageLocation = currentScenario.ImagePath;
            roomPicturebox.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        private void Moves()
        {
           
            movesLabel.Text = "Moves: " + _character.MovesCount;
        }
        public void GameTimer()
        {
            this._seconds++;

            if (this._seconds == 60)
            {
                this._seconds = 0;
                this._minutes++;
            }

            TimerMinNSeconds.Text = this._minutes.ToString() + ":" + this._seconds.ToString();
            
        }
        private void PrintExceptionMessage(string inputExceptionMessage)
        {
            roomDescriptionTxt.AppendText(inputExceptionMessage + "\r\n\r\n");
    }

        private void pickUpItemBtn_Click(object sender, EventArgs e)
        {
            
        }

        private void userInputTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            string userInput = userInputTxt.Text.ToLower();
            string inputExceptionMessage = InputHandler.GetInputExceptionMessage(_character, userInput);
            

            if (!string.IsNullOrEmpty(inputExceptionMessage))
                PrintExceptionMessage(inputExceptionMessage);
            else
            {
                _game.ExecuteInput(userInput);

                UpdateScenario();
            }
            userInputTxt.Clear();
            roomDescriptionTxt.ScrollToCaret();
        }

        private void TimeCounter_Tick(object sender, EventArgs e)
        {
            GameTimer();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HowToPlayForm howToPlayForm = new HowToPlayForm();
            howToPlayForm.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            


            if (_character.CurrentScenario.Id == 1)
            {
                var frmInfoTheDocks = new FrmInfoTheDocks(_character);
                frmInfoTheDocks.Show();
            }
            else if (_character.CurrentScenario.Id == 2)
            {
                FrmInfoMuddyRoad frmInfoMuddyRoad = new FrmInfoMuddyRoad(_character);
                frmInfoMuddyRoad.Show();
            }
            _character.MovesCount++;
            Moves();
        }
    }
}
