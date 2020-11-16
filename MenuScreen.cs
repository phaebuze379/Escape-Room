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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);

            //GameScreen gs = new GameScreen();
            //f.Controls.Add(gs);
            //gs.Focus();
            GameOverScreen gs = new GameOverScreen();
            f.Controls.Add(gs);
            gs.Focus();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void highButton_Click(object sender, EventArgs e)
        {
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

            string playerName;
            string playScore;

            int playerScore;

            XmlReader reader = XmlReader.Create("Resources/highScores.xml");

            reader.ReadStartElement("score");

            //Grabs all the walla for the walls and adds them to the list
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Text)
                {
                   reader.ReadToFollowing("name");
                    playerName = reader.ReadString();

                    reader.ReadToFollowing("score");
                    playScore = reader.ReadString();


                    if (playerName != "")
                    {
                        playerScore = Convert.ToInt32(playScore);

                        Score score = new Score(playerScore, playerName);

                        GameOverScreen.scores.Add(score);
                    }
                }
            }
            //close reader
            reader.Close();

            foreach (Score s in GameOverScreen.scores)
            {
                scoresLabel.Text += s;
            }

        }

        private void backButton_Click(object sender, EventArgs e)
        {
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
        }
    }
}
