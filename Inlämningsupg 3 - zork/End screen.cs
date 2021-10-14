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
        

        public EndScreen(int moves, int minutes, int seconds)
        {
            InitializeComponent();
            movesLabel.Text = moves.ToString();
            timeLabel.Text = $"{minutes}:{seconds}";
        }

        private void playBtn_Click(object sender, EventArgs e)
        {
            StartScreen startScreen = new StartScreen();
            EndScreen.ActiveForm.Hide();
            startScreen.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
