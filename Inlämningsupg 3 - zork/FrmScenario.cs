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
        public FrmScenario(Character character)
        {
            _character = character;
            _game = new Game(_character);
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
            string inventory1 = item1Label.Text;
            string inventory2 = item2Label.Text;

            foreach (var item in currentInventory)
            {
                switch (item.Title)
                {
                    case "knife":
                        if (inventory1 == "" && inventory2 == "")
                            inventory1 = "Knife";

                        else if (inventory1 != "" && inventory2 == "")
                            inventory2 = "knife";

                        else if (inventory1 == "" && inventory2 != "")
                            inventory1 = "knife";

                        else
                            roomDescriptionTxt.AppendText("\r\n Inventory is full!");
                        break;

                    case "fishing line":
                        if (inventory1 == "" && inventory2 == "")
                            inventory1 = "Fishing line";

                        else if (inventory1 != "" && inventory2 == "")
                            inventory2 = "Fishing line";

                        else if (inventory1 == "" && inventory2 != "")
                            inventory1 = "Fishing line";

                        else
                            roomDescriptionTxt.AppendText("\r\n Inventory is full!");
                        break;
                }

            }
        }
        private void KeyTheDocks()
        {
            string inventory1 = item1Label.Text;
            string inventory2 = item2Label.Text;
            string outputValue = roomDescriptionTxt.Text;



            switch (inventory1)
            {
                case "knife" when inventory2 == "fishing line":
                    if (outputValue == "use knife on fishing line" || outputValue == "use fishing line on knife")
                    {
                        inventory1 = "Key";
                        roomDescriptionTxt.AppendText("\r\n You found a key!"); 
                    }
                    break;
                case "fishing line" when inventory2 == "knife":
                    if (outputValue == "use knife on fishing line" || outputValue == "use fishing line on knife")
                    {
                        inventory1 = "Key";
                        roomDescriptionTxt.AppendText("\r\n You found a key!");
                    }
                    break;
            }
        }
        private void Scene()
        {
            var currentScenario = _character.CurrentScenario;

            if (currentScenario.Id == 1)
            {
                if (counter == 0)
                {
                    roomDescriptionTxt.Text = currentScenario.Description + "\r\n\r\n";
                }
                else
                {
                    roomDescriptionTxt.AppendText("\r\n" + _character.CurrentLocation.Description);
                }
                roomNameLabel.Text = "The docks";
                roomPicturebox.ImageLocation = @"C:\Users\tedha\source\repos\Inlämningsupg 3 - zork\Inlämningsupg 3 - zork\docks.jpg";
                roomPicturebox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else if (currentScenario.Id == 2)
            {
                roomNameLabel.Text = "Muddy road";
                roomPicturebox.ImageLocation = @"C:\Users\tedha\source\repos\Inlämningsupg 3 - zork\Inlämningsupg 3 - zork\muddy road.jpg";
                roomPicturebox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else if (currentScenario.Id == 3)
            {
                roomNameLabel.Text = "Town";
                roomPicturebox.ImageLocation = @"C:\Users\tedha\source\repos\Inlämningsupg 3 - zork\Inlämningsupg 3 - zork\town.jpg";
                roomPicturebox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
        private void Moves()
        {
            if (counter >= 0)
            {
                counter++;
            }
            movesLabel.Text = "Moves: " + counter.ToString();
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
            roomDescriptionTxt.AppendText(inputExceptionMessage + "\r\n");
    }

        private void pickUpItemBtn_Click(object sender, EventArgs e)
        {
            
        }

        private void userInputTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;
            

            string inputExceptionMessage = InputHandler.GetInputExceptionMessage(_character, userInputTxt.Text);
            

            if (!string.IsNullOrEmpty(inputExceptionMessage))
                PrintExceptionMessage(inputExceptionMessage);
            else
            {
                _game.ExecuteInput(userInputTxt.Text);

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
