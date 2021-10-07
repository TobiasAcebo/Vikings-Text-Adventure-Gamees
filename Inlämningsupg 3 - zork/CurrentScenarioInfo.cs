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
    public partial class CurrentScenarioInfo : Form
    {
        public CurrentScenarioInfo(Character character)
        {
            
            InitializeComponent();
            HideAllLabels();
            
            if (character.CurrentScenario.Id == 1)
                DisplayTheDocksMap(character);
            else if (character.CurrentScenario.Id == 2)
                DisplayMuddyRoadMap(character);
        }

        private void HideAllLabels()
        {
            foreach (Control item in Controls)
            {
                if(item is Label && item.Name != "labelScenarioTitle" && item.Name != "labelX" && item.Name != "labelItemsAvailable")
                    item.Hide();
            }
        }

        private void DisplayMuddyRoadMap(Character character)
        {
            throw new NotImplementedException();
        }

        private void DisplayTheDocksMap(Character character)
        {
            DisplayItemList(character);
            DisplayLabelsTheDocks();
            labelScenarioTitle.Text = character.CurrentScenario.Title;
            DisplayCurrentLocation(character);
            //if(character.CurrentLocation.Title == "starting point")

        }

        private void DisplayCurrentLocation(Character character)
        {
            if(character.CurrentLocation.Title == "starting point")
                xTheDocksStartingPoint.Show();
            else if (character.CurrentLocation.Title == "end of docks")
                xTheDocksEndOfDocks.Show();
            else if (character.CurrentLocation.Title == "boat")
                xTheDocksShip.Show();
            else if (character.CurrentLocation.Title == "west side")
                xTheDocksWestSide.Show();
            else if (character.CurrentLocation.Title == "guidance")
                xTheDocksGuide.Show();
            else if (character.CurrentLocation.Title == "gate")
                xTheDocksGate.Show();
            else if (character.CurrentLocation.Title == "water")
            {
                xTheDocksWater1.Show();
                xTheDocksWater2.Show();
                xTheDocksWater3.Show();
            }
                

        }

        private void DisplayLabelsTheDocks()
        {
            foreach (Control item in Controls)
            {
                if (item is Label && IsTheDocksLabel(item.Name))
                    item.Show();
            }
        }

        private bool IsTheDocksLabel(string labelName)
        {
            string[] theDocksLabelNames =
            {
                "labelTheDocksGuide",
                "labelTheDocksGate",
                "labelTheDocksWater1",
                "labelTheDocksWater2",
                "labelTheDocksWater3",
                "labelTheDocksShip",
                "labelTheDocksStartingPoint",
                "labelTheDocksEndOfDocks",
                "labelTheDocksWestSide" //hej

            };
            return theDocksLabelNames.Contains(labelName);
        }

        private void DisplayItemList(Character character)
        {
            var itemList = new List<Item>();
            character.CurrentScenario.LocationList.ForEach(location => itemList.AddRange(location.ItemList));
            listBoxItemsAvailable.DataSource = itemList;
            listBoxItemsAvailable.DisplayMember = "Title";
        }
    }
}
