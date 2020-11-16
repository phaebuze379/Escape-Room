using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escape_Room
{
    public partial class GameOverScreen : UserControl
    {

        public static string name;
        public int score;

        public static List<Score> scores = new List<Score>();

        public GameOverScreen()
        {
            InitializeComponent();
            scoreText.Text = 200 + "";
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);
            GameScreen gs = new GameScreen();
            f.Controls.Add(gs);
            gs.Location = new Point((this.Width - gs.Width) / 2, (this.Height - gs.Height) / 2);
            gs.Focus();
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);
            MenuScreen ms = new MenuScreen();
            f.Controls.Add(ms);
            ms.Location = new Point((this.Width - ms.Width) / 2, (this.Height - ms.Height) / 2);
            ms.Focus();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            name = textBox.Text;
            score = Convert.ToInt32(scoreText.Text);
            Score highscore = new Score(score, name);



            scores.Add(highscore);

            nameLabel.Visible = false;
            textBox.Visible = false;
            addButton.Visible = false;
            exitButton.Visible = true;
            menuButton.Visible = true;
            playButton.Visible = true;
        }
    }
}
