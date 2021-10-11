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
    public partial class FrmInfoTown : Form, IFrmInfo
    {
        public FrmInfoTown(Character character)
        {
            InitializeComponent();
            HideAllLocationMarks();
            DisplayItemList(character);
            DisplayCurrentLocationMark(character);
        }

        public void HideAllLocationMarks()
        {
            xStartingPoint.Hide();
            xArmorSmith.Hide();
            xBoatHouse.Hide();
            xFountain.Hide();
            xPub.Hide();
            xStairs.Hide();
            xGate.Hide();
            xSwordSmith.Hide();
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
            else if (character.CurrentLocation.Title == "fountain")
                xFountain.Show();
            else if (character.CurrentLocation.Title == "armorsmith")
                xArmorSmith.Show();
            else if (character.CurrentLocation.Title == "boat house")
                xBoatHouse.Show();
            else if (character.CurrentLocation.Title == "stairs")
                xStairs.Show();
            else if (character.CurrentLocation.Title == "swordsmith")
                xSwordSmith.Show();
            else if(character.CurrentLocation.Title == "pub")
                xPub.Show();
            else if (character.CurrentLocation.Title == "great halls gate")
                xGate.Show();
        }
    }
}
