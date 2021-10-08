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
    public partial class FrmInfoMuddyRoad : Form, IFrmInfo
    {
        public FrmInfoMuddyRoad(Character character)
        {
            InitializeComponent();
            HideAllLocationMarks();
            DisplayItemList(character);
            DisplayCurrentLocationMark(character);
        }

        public void HideAllLocationMarks()
        {
            xStartingPoint.Hide();
            xHouseNextToWaterWell.Hide();
            xHouseWithAShieldOnTheWall.Hide();
            xHouseWithCarpetMadeOfFur.Hide();
            xHouseWithStackFullOfLogs.Hide();
            xMiddleOfTheRoad.Hide();
            xGate.Hide();
        }

        public void DisplayItemList(Character character)
        {
            var itemList = new List<Item>();
            character.CurrentScenario.LocationList.ForEach(location => itemList.AddRange(location.ItemList));
            listBoxItemsAvailable.DataSource = itemList;
            listBoxItemsAvailable.DisplayMember = "Title";
        }


        public void DisplayCurrentLocationMark(Character character)
        {
            if (character.CurrentLocation.Title == "starting point")
                xStartingPoint.Show();
            else if (character.CurrentLocation.Title == "house with stack full of logs")
                xHouseWithStackFullOfLogs.Show();
            else if (character.CurrentLocation.Title == "house with a shield on the wall")
                xHouseWithAShieldOnTheWall.Show();
            else if (character.CurrentLocation.Title == "middle of the road")
                xMiddleOfTheRoad.Show();
            else if (character.CurrentLocation.Title == "house with carpet made of fur")
                xHouseWithCarpetMadeOfFur.Show();
            else if (character.CurrentLocation.Title == "house next to a water well")
                xHouseNextToWaterWell.Show();
            else if (character.CurrentLocation.Title == "gate")
                xGate.Show();
        }
    }
}
