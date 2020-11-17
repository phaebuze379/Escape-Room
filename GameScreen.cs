using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Media;
using System.Xml;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.InteropServices;

namespace Escape_Room
{
    public partial class GameScreen : UserControl
    {
        #region global variables
        //booleans
        Boolean leftArrowDown, rightArrowDown, upArrowDown, downArrowDown, pKeyDown;
        Boolean complete = false;

        //brushes
        SolidBrush white = new SolidBrush(Color.White);
        SolidBrush red = new SolidBrush(Color.Red);
        SolidBrush green = new SolidBrush(Color.Green);
        SolidBrush blue = new SolidBrush(Color.Blue);
        SolidBrush paleTurquoise = new SolidBrush(Color.PaleTurquoise);
        SolidBrush pink = new SolidBrush(Color.Pink);
        SolidBrush black = new SolidBrush(Color.Black);
        SolidBrush gray = new SolidBrush(Color.Gray);
        SolidBrush yellow = new SolidBrush(Color.Yellow);
        SolidBrush lightGreen = new SolidBrush(Color.MediumSpringGreen);
        SolidBrush purple = new SolidBrush(Color.Purple);


        //lists
        public static List<Wall> walls = new List<Wall>();
        public static List<Task> tasks = new List<Task>();
        public static List<Key> keys = new List<Key>();
        public static List<Key> inventory = new List<Key>();

        //create hero as public from hero class
        public Hero hero;
        //create door as public from door class
        public Door door;
        //create key as public from key class
        public Key key;

        //task counter starts at 3, decreases when tasks are completed
        public static int taskCounter = 3;
        //task colour varible to be set while collided with a task
        public static string taskColour;
        //lever counter set to start at level 1
        public static int levelCounter = 1;
        //score starts at 0
        public static int scoreCounter = 0;
        #endregion

        public GameScreen()
        {
            InitializeComponent();
            //stop theme music
            Form1.theme.Stop();
            //run onStart() method
            onStart();
        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //button presses
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.P:
                    pKeyDown = true;
                    break;
            }
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            //button releases
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.P:
                    pKeyDown = false;
                    break;
            }
        }



        public void onStart()
        {
            //run level() method
            level();

            //set all button presses to false.
            leftArrowDown = rightArrowDown = false;

            //for the different levels
            switch (levelCounter)
            {
                //set the door into different places
                case 1:
                    door = new Door(1100, 40, 180, 230);
                    break;
                case 2:
                    door = new Door(600, 525, 180, 230);
                    break;
                case 3:
                    door = new Door(585, 325, 180, 230);
                    break;
            }

            //for different levles
            switch (levelCounter)
            {
                //set the hero into different places
                case 1:
                    hero = new Hero(600, 400, 30, 50);
                    break;
                case 2:
                    hero = new Hero(600, 400, 30, 50);
                    break;
                case 3:
                    hero = new Hero(1000, 60, 30, 50);
                    break;
            }

        }

        private void playButton_Click(object sender, EventArgs e)
        {
            //resume the timer
            timer1.Start();
            //get rid of the buttons
            playButton.Visible = false;
            exitButton.Visible = false;
            menuButton.Visible = false;
            pauseLabel.Visible = false;
            //focus the screen
            this.Focus();
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            //go to MenuScreen
            Form f = this.FindForm();
            f.Controls.Remove(this);
            MenuScreen ms = new MenuScreen();
            f.Controls.Add(ms);
            ms.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - ms.Width) / 2,
    (Screen.PrimaryScreen.WorkingArea.Height - ms.Height) / 2);
            //focus the screen
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

        public void level()
        {
            if (levelCounter <= 3)
            {
                //current level
                complete = false;

                //variables for block x and y values
                string blockX;
                string blockY;
                string width;
                string height;

                string taskblockX;
                string taskblockY;
                string taskwidth;
                string taskheight;

                int intX;
                int intY;
                int widthx;
                int heighty;

                int taskintX;
                int taskintY;
                int taskwidthx;
                int taskheighty;

                // create xml reader
                XmlReader reader = XmlReader.Create("Resources/" + "level" + Convert.ToString(levelCounter) + ".xml");

                int c = 0;
                reader.ReadStartElement("level");
                reader.ReadToFollowing("tasks");
                //collect all 3 tasks
                while (c < 3)
                {
                    //puts valluable into varriables
                    reader.ReadToFollowing("colour");
                    taskColour = reader.ReadString();

                    reader.ReadToFollowing("x");
                    taskblockX = reader.ReadString();

                    reader.ReadToFollowing("y");
                    taskblockY = reader.ReadString();

                    reader.ReadToFollowing("width");
                    taskwidth = reader.ReadString();

                    reader.ReadToFollowing("height");
                    taskheight = reader.ReadString();
                    if (taskColour != "")
                    {
                        //put into int variables
                        taskintX = Convert.ToInt32(taskblockX);
                        taskintY = Convert.ToInt32(taskblockY);
                        taskwidthx = Convert.ToInt32(taskwidth);
                        taskheighty = Convert.ToInt32(taskheight);
                        //create task
                        Task b = new Task(taskColour, taskintX, taskintY, taskwidthx, taskheighty);
                        //add to tasks list
                        tasks.Add(b);
                    }
                    c++;
                }

                reader.ReadToFollowing("walls");
                //Grabs all the walla for the walls and adds them to the list
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Text)
                    {
                        //puts valuables into variables
                        blockX = reader.ReadString();

                        reader.ReadToFollowing("y");
                        blockY = reader.ReadString();

                        reader.ReadToFollowing("width");
                        width = reader.ReadString();

                        reader.ReadToFollowing("height");
                        height = reader.ReadString();
                        if (blockX != "")
                        {
                            //put into int values
                            intX = Convert.ToInt32(blockX);
                            intY = Convert.ToInt32(blockY);
                            widthx = Convert.ToInt32(width);
                            heighty = Convert.ToInt32(height);
                            //create wall
                            Wall b = new Wall(intX, intY, widthx, heighty);
                            //add to walls list
                            walls.Add(b);
                        }
                    }
                }
                //close reader
                reader.Close();
            }
            else if (levelCounter > 3) //if all three levels are complete
            {
                //stop the game timer
                timer1.Stop();
                //reset level counter
                levelCounter = 1;
                //go to the GameOverScreen
                Form f = this.FindForm();
                f.Controls.Remove(this);
                GameOverScreen gs = new GameOverScreen();
                f.Controls.Add(gs);
                gs.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - gs.Width) / 2,
    (Screen.PrimaryScreen.WorkingArea.Height - gs.Height) / 2);
                //focus that screen
                gs.Focus();
            }
        }

        public void paused()
        {
            //stop the game timer
            timer1.Stop();
            //show all the buttons
            playButton.Visible = true;
            exitButton.Visible = true;
            menuButton.Visible = true;
            pauseLabel.Visible = true;
            //focus the buttons
            playButton.Focus();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //every time the timer ticks, every 20 ms, add to score counter
            scoreCounter++;

            #region move
            int x = hero.x;
            int y = hero.y;

            //if the p key is pressed
            if (pKeyDown == true)
            {
                //go to paused()
                paused();
            }

            //if the left arrow is pressed
            if (leftArrowDown == true)
            {
            
                //move the hero left
                hero.move("left");
            }

            //if the right arrow is pressed
             if (rightArrowDown == true)
            {
                //move the hero right
                hero.move("right");
            }

            //if the up arrow is pressed
             if (upArrowDown == true)
            {
                //move the hero up
                hero.move("up");
            }

            //if the down arrow is pressed
             if (downArrowDown == true)
            {
                //move the hero down
                hero.move("down");
            }
            #endregion

            //display the number of tasks left
            tasksLabel.Text = tasks.Count() + "";

            //if not tasks left
            if (tasks.Count() == 0 && complete == false)
            {
                complete = true;
                switch (levelCounter)
                {
                    //draw specific key in play according to level
                    case 1:
                        key = new Key(600, 535, 70, 70);
                        break;
                    case 2:
                        key = new Key(1000, 60, 70, 70);
                        break;
                    case 3:
                        key = new Key(1000, 60, 70, 70);
                        break;
                }
                hero.hasKey = true;

                //clear the task list
                tasks.Clear();

            }

            //if hero collides with key
            if (hero.keyCollision(key))
            {
                //play sound
                Form1.key.Play();
                //move key into inventory
                key.x = 390;
                key.y = 790;
                hero.x = x;
                hero.y = y;
            }

            //if hero collides with door but does not have the key
            if (hero.doorCollision(door) && hero.hasKey == false)
            {

                //stop moving
                hero.x = x;
                hero.y = y;
            }

            //if hero collides with door and does have the key
            if (hero.doorCollision(door) && hero.hasKey == true)
            {
                //stop moving
                hero.x = x;
                hero.y = y;
                hero.hasKey = false;
                //clear the walls and tasks lists
                walls.Clear();
                tasks.Clear();
                //reset task counter
                taskCounter = 3;
                //go up on level
                levelCounter++;
                //play level up sound
                Form1.completeLevel.Play();
                //go to onStart()
                onStart();

            }

            //for each wall in the walls list
            foreach (Wall c in walls)
            {
                // if the hero collides 
                if (hero.wallCollision(c))
                {
                    //stop moving
                    hero.x = x;
                    hero.y = y;
                    break;
                }
            }

            //for each task in tasks list
            foreach (Task b in tasks)
            {
                //if the hero collides
                if (hero.taskCollision(b))
                {
                    //play task sound
                    Form1.findTask.Play();

                    //stop moving
                    hero.x = x;
                    hero.y = y;
                    leftArrowDown = false;
                    rightArrowDown = false;
                    upArrowDown = false;
                    downArrowDown = false;

                    //set taskColour to the certain colour collided with
                    taskColour = b.colour;

                   

                    //go to task screen
                    Form f = this.FindForm();
                    taskScreen ts = new taskScreen();
                    f.Controls.Add(ts);
                    ts.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - ts.Width) / 2,
                        (Screen.PrimaryScreen.WorkingArea.Height - ts.Height) / 2);
                    //focus the task screen
                    ts.Focus();
                    //bring task screen to the front
                    ts.BringToFront();
                }
            }
            //makes the timer keep running
            Refresh();
        }

        #region paint
        public void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            //for the different levels
            switch (levelCounter)
            {
                //draw the specific key and door for the level
                case 1:
                    e.Graphics.DrawImage(door.doorImage1, door.x, door.y, door.width, door.height);
                    if (hero.hasKey == true)
                    {
                        e.Graphics.DrawImage(key.keyImage1, key.x, key.y, key.width, key.height);
                    }
                    break;
                case 2:
                    e.Graphics.DrawImage(door.doorImage2, door.x, door.y, door.width, door.height);
                    if (hero.hasKey == true)
                    {
                        e.Graphics.DrawImage(key.keyImage2, key.x, key.y, key.width, key.height);
                    }
                    break;
                case 3:
                    e.Graphics.DrawImage(door.doorImage3, door.x, door.y, door.width, door.height);
                    if (hero.hasKey == true)
                    {
                        e.Graphics.DrawImage(key.keyImage3, key.x, key.y, key.width, key.height);
                    }
                    break;
            }

            //for each wall in walls list
            foreach (Wall b in walls)
            {
                //draw walls white
                e.Graphics.FillRectangle(white, b.x, b.y, b.width, b.height);

            }

            //for each task in list
            foreach (Task b in tasks)
            {
                //draw tasks according to colour
                switch (b.colour)
                {
                    case "red":
                        e.Graphics.FillRectangle(red, b.x, b.y, b.width, b.height);
                        break;
                    case "green":
                        e.Graphics.FillRectangle(green, b.x, b.y, b.width, b.height);
                        break;
                    case "blue":
                        e.Graphics.FillRectangle(blue, b.x, b.y, b.width, b.height);
                        break;
                    case "paleturquiose":
                        e.Graphics.FillRectangle(paleTurquoise, b.x, b.y, b.width, b.height);
                        break;
                    case "pink":
                        e.Graphics.FillRectangle(pink, b.x, b.y, b.width, b.height);
                        break;
                    case "black":
                        e.Graphics.FillRectangle(black, b.x, b.y, b.width, b.height);
                        break;
                    case "yellow":
                        e.Graphics.FillRectangle(yellow, b.x, b.y, b.width, b.height);
                        break;
                    case "lightgreen":
                        e.Graphics.FillRectangle(lightGreen, b.x, b.y, b.width, b.height);
                        break;
                    case "purple":
                        e.Graphics.FillRectangle(purple, b.x, b.y, b.width, b.height);
                        break;
                }
            }
            //draw hero
            e.Graphics.FillRectangle(gray, hero.x, hero.y, hero.width, hero.height);
        }
        #endregion
    }
}
