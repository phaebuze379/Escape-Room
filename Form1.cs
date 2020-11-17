//Phaedra Buzek
//ICS 4U
//Final project: escape room
//November 17, 2020

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Escape_Room
{
    public partial class Form1 : Form
    {
        //create score list of type Score
        public static List<Score> scores = new List<Score>();

        //sounds
        public static SoundPlayer findTask = new SoundPlayer(Properties.Resources.TaskSound4);
        public static SoundPlayer completeTask = new SoundPlayer(Properties.Resources.TaskSound7);
        public static SoundPlayer completeLevel = new SoundPlayer(Properties.Resources.LevelComplete);
        public static SoundPlayer theme = new SoundPlayer(Properties.Resources.ThemeSound);
        public static SoundPlayer key = new SoundPlayer(Properties.Resources.KeySound);
        public static SoundPlayer walk = new SoundPlayer(Properties.Resources.wooden_stairs_1);

        public Form1()
        {
            InitializeComponent();

            // go to main screen
            MenuScreen ms = new MenuScreen();
            this.Controls.Add(ms);
            ms.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - ms.Width) / 2,
                (Screen.PrimaryScreen.WorkingArea.Height - ms.Height) / 2);
            ms.Focus();

            #region read
            scores.Clear();
            string playerName, playerScore;
            //int score;

            XmlReader reader = XmlReader.Create("Resources/high.xml");

            reader.ReadStartElement("scores");
            //Grabs all the scores for the scores and adds them to the list
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Text)
                {
                    playerName = reader.ReadString();

                    reader.ReadToFollowing("score");
                    playerScore = reader.ReadString();

                    if (playerName != "")
                    {
                        Score score = new Score(Convert.ToInt32(playerScore), playerName);
                        scores.Add(score);
                    }
                }
            }
            //close reader
            reader.Close();
            #endregion
        }
    }
}
