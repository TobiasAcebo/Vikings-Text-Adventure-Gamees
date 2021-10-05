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
        int counter = 0;
        

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
            KeyTheDocks();
        }
        private void ItemsTheDocks()
        {
            var currentInventory = _character.ItemList;
            item1Label.Text = "";
            item2Label.Text = "";
            foreach (var item in currentInventory)
            {
                //switch (item.Title)
                //{
                //    case "knife":
                //        if (item1Label.Text == "" && item2Label.Text == "")
                //            item1Label.Text = "Knife";

                //        else if (item1Label.Text != "" && item2Label.Text == "")
                //            item2Label.Text = "knife";

                //        else if (item1Label.Text == "" && item2Label.Text != "")
                //            item1Label.Text = "knife";

                //        break;

                //    case "fishing line":
                //        if (item1Label.Text == "" && item2Label.Text == "")
                //            item1Label.Text = "Fishing line";

                //        else if (item1Label.Text != "" && item2Label.Text == "")
                //            item2Label.Text = "Fishing line";

                //        else if (item1Label.Text == "" && item2Label.Text != "")
                //            item1Label.Text = "Fishing line";

                //        break;
                //}
                if (item1Label.Text == "" && item2Label.Text == "")
                {
                    item1Label.Text = item.Title;
                }
                else if (item1Label.Text != "" && item2Label.Text == "")
                    item2Label.Text = item.Title;
              

            }
            
        }
        private void KeyTheDocks()
        {
            //string inventory1 = item1Label.Text;
            //string inventory2 = item2Label.Text;
            //string outputValue = roomDescriptionTxt.Text;



            //switch (inventory1)
            //{
            //    case "knife" when inventory2 == "fishing line":
            //        if (outputValue == "use knife on fishing line" || outputValue == "use fishing line on knife")
            //        {
            //            inventory1 = "Key";
            //            roomDescriptionTxt.AppendText("\r\n You found a key!"); 
            //        }
            //        break;
            //    case "fishing line" when inventory2 == "knife":
            //        if (outputValue == "use knife on fishing line" || outputValue == "use fishing line on knife")
            //        {
            //            inventory1 = "Key";
            //            roomDescriptionTxt.AppendText("\r\n You found a key!");
            //        }
            //        break;
            //}
        }
        private void Scene()
        {
            var currentScenario = _character.CurrentScenario;

            roomDescriptionTxt.AppendText(_character.CurrentLocation.Description + "\r\n\r\n");
            roomNameLabel.Text = currentScenario.Title;
            roomPicturebox.ImageLocation = currentScenario.ImagePath;
            roomPicturebox.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        private void Moves()
        {
            if (counter >= 0)
            {
                counter++;
            }
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
    }
}
