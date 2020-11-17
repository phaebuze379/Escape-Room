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
    public partial class GameOverScreen : UserControl
    {

        string name;
        int score;


        public GameOverScreen()
        {
            InitializeComponent();
            //display score
            scoreText.Text = GameScreen.scoreCounter / 20 + "";
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            //play again, go to GameScreen
            Form f = this.FindForm();
            f.Controls.Remove(this);
            GameScreen gs = new GameScreen();
            f.Controls.Add(gs);
            gs.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - gs.Width) / 2,
   (Screen.PrimaryScreen.WorkingArea.Height - gs.Height) / 2);
            gs.Focus();
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            //go to menu
            Form f = this.FindForm();
            f.Controls.Remove(this);
            MenuScreen ms = new MenuScreen();
            f.Controls.Add(ms);
            ms.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - ms.Width) / 2,
    (Screen.PrimaryScreen.WorkingArea.Height - ms.Height) / 2);
            ms.Focus();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            //exit
            Application.Exit();
        }

        #region button colours
        private void playButton_Enter(object sender, EventArgs e)
        {
            playButton.BackColor = Color.Tan;
            menuButton.BackColor = Color.SaddleBrown;
            exitButton.BackColor = Color.SaddleBrown;
        }

        private void menuButton_Enter(object sender, EventArgs e)
        {
            playButton.BackColor = Color.SaddleBrown;
            menuButton.BackColor = Color.Tan;
            exitButton.BackColor = Color.SaddleBrown;
        }

        private void exitButton_Enter(object sender, EventArgs e)
        {
            playButton.BackColor = Color.SaddleBrown;
            menuButton.BackColor = Color.SaddleBrown;
            exitButton.BackColor = Color.Tan;
        }
        #endregion

        private void addButton_Click(object sender, EventArgs e)
        {
            //set name variable to entered name
            name = textBox.Text;

            //if it doesn't have anything or has spaces
            if (name.Length == 0 || name.Contains(" "))
            {
                errorLabel.Visible = true;
            }
            else 
            {
                //display buttons
                errorLabel.Visible = false;
                nameLabel.Visible = false;
                textBox.Visible = false;
                addButton.Visible = false;
                exitButton.Visible = true;
                menuButton.Visible = true;
                playButton.Visible = true;

                //add score and name to list of type Score
                score = Convert.ToInt32(scoreText.Text);
                Score highscore = new Score(score, name);
                Form1.scores.Add(highscore);

                XmlWriter writer = XmlWriter.Create("Resources/high.xml", null);

                // start writer
                writer.WriteStartElement("scores");

                // write every score in high score list
                foreach (Score s in Form1.scores)
                {
                    writer.WriteElementString("name", s.name);
                    writer.WriteElementString("score", Convert.ToString(s.score));

                }

                // end and close writer
                writer.WriteEndElement();
                writer.Close();
            }

        }


    }

}


