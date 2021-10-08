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
    public partial class FrmInfoTheDocks : Form, IFrmInfo
    {
        public FrmInfoTheDocks(Character character)
        {
            
            InitializeComponent();
            HideAllLocationMarks();
            DisplayItemList(character);
            DisplayCurrentLocationMark(character);
        }

        public void HideAllLocationMarks()
        {
            xTheDocksStartingPoint.Hide();
            xTheDocksEndOfDocks.Hide();
            xTheDocksShip.Hide();
            xTheDocksWestSide.Hide();
            xTheDocksGuide.Hide();
            xTheDocksGate.Hide();
            xTheDocksWater1.Hide();
            xTheDocksWater2.Hide();
            xTheDocksWater3.Hide();
        }

        public void DisplayCurrentLocationMark(Character character)
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

        public void DisplayItemList(Character character)
        {
            var itemList = new List<Item>();
            character.CurrentScenario.LocationList.ForEach(location => itemList.AddRange(location.ItemList));
            listBoxItemsAvailable.DataSource = itemList;
            listBoxItemsAvailable.DisplayMember = "Title";
        }
    }
}
