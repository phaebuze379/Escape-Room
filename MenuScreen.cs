using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Escape_Room
{
    public partial class MenuScreen : UserControl
    {

        public MenuScreen()
        {
            InitializeComponent();
            //play theme music
            Form1.theme.PlayLooping();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //when play button is clicked, go to GameScreen
            Form f = this.FindForm();
            f.Controls.Remove(this);
            GameScreen gs = new GameScreen();
            f.Controls.Add(gs);
            gs.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - gs.Width) / 2,
               (Screen.PrimaryScreen.WorkingArea.Height - gs.Height) / 2);
            gs.Focus();

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            //exit
            Application.Exit();
        }

        private void highButton_Click(object sender, EventArgs e)
        {
            //remove pictures and buttons
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;

            highButton.Visible = false;
            playButton.Visible = false;
            exitButton.Visible = false;
            backButton.Visible = true;

            scoresLabel.Visible = true;
            subtitleLabel.Visible = true;

            
            scoresLabel.Text = "";
            //sort the list
            Form1.scores = Form1.scores.OrderBy(x => x.score).ToList();
            //display top 5 high scores
            for (int i = 0; i < 5; i++)
            {
                scoresLabel.Text += Form1.scores[i].name + "   " + Form1.scores[i].score + "\n";
            }            
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            //re-add pictures and buttons
            pictureBox1.Visible = true;
            pictureBox2.Visible = true;
            pictureBox3.Visible = true;
            pictureBox4.Visible = true;
            pictureBox5.Visible = true;

            highButton.Visible = true;
            playButton.Visible = true;
            exitButton.Visible = true;
            backButton.Visible = false;

            scoresLabel.Visible = false;
            subtitleLabel.Visible = false;
        }

        #region button colours
        private void playButton_Enter(object sender, EventArgs e)
        {
            playButton.BackColor = Color.Tan;
            highButton.BackColor = Color.SaddleBrown;
            exitButton.BackColor = Color.SaddleBrown;
        }

        private void highButton_Enter(object sender, EventArgs e)
        {
            playButton.BackColor = Color.SaddleBrown;
            highButton.BackColor = Color.Tan;
            exitButton.BackColor = Color.SaddleBrown;
        }

        private void exitButton_Enter(object sender, EventArgs e)
        {
            playButton.BackColor = Color.SaddleBrown;
            highButton.BackColor = Color.SaddleBrown;
            exitButton.BackColor = Color.Tan;
        }
        #endregion
    }
}
