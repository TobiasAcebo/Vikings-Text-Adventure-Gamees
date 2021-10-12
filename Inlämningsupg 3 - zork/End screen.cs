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
    public partial class EndScreen : Form
    {
        Repository repository;

        public EndScreen(Character character)
        {
            repository = new Repository();

            repository.SaveResult(character);//I SaveResult lägger en ny rad för spelare så läggs den in i textfilen
            //List<CharacterResult> highScoreLista = repository.GetHighScoreList();
            InitializeComponent();


        }
    }
}
