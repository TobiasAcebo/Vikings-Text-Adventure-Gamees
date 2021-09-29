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
        int counter = 0;
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
            Moves();
            Scene();
            inventory();
        }

        private void inventory() 
        {
            var currentInventory = _character.ItemList;
            string inventory1 = item1Label.Text;
            string inventory2 = item2Label.Text;
            string outputValue = roomDescriptionTxt.Text;

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
                        inventory2 = "knife";
                        
                        else
                        outputValue = "Inventory is full"; // skriver den över all text eller adderar en rad?
                        break;

                    case "fishing line":
                        if (inventory1 == "" && inventory2 == "")
                        inventory1 = "Fishing line";
                        
                        else if (inventory1 != "" && inventory2 == "")
                        inventory2 = "Fishing line";
                        
                        else if (inventory1 == "" && inventory2 != "")
                        inventory2 = "Fishing line";
                        
                        else
                        outputValue = "Inventory is full"; // skriver den över all text eller adderar en rad?
                         break;
                }

            }
        }

        private void Scene()
        {
            var currentScenario = _character.CurrentScenario;

            if (currentScenario.Id == 1)
            {
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

        private void PrintExceptionMessage(string inputExceptionMessage)
        {
            throw new NotImplementedException();
        }
    }
}
