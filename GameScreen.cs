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
        Boolean leftArrowDown, rightArrowDown, upArrowDown, downArrowDown;
        Boolean stop = false;
        Boolean complete = false;

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



        public static List<Wall> walls = new List<Wall>();
        public static List<Task> tasks = new List<Task>();

        public static List<Key> keys = new List<Key>();
        public static List<Key> inventory = new List<Key>();

        public Hero hero;

        public Door door;
        public Key key;

        public static int taskCounter = 3;
        public static string taskColour;

        public static int levelCounter = 3;

        public GameScreen()
        {
            InitializeComponent();
            onStart();
        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //player 1 button presses
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
            }
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            //player 1 button releases
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
            }
        }



        public void onStart()
        {
            level();

            //set all button presses to false.
            leftArrowDown = rightArrowDown = false;

            switch (levelCounter)
            {
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

            switch (levelCounter)
            {
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
                while (c < 3)
                {
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
                        taskintX = Convert.ToInt32(taskblockX);
                        taskintY = Convert.ToInt32(taskblockY);
                        taskwidthx = Convert.ToInt32(taskwidth);
                        taskheighty = Convert.ToInt32(taskheight);
                        Task b = new Task(taskColour, taskintX, taskintY, taskwidthx, taskheighty);
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
                        blockX = reader.ReadString();

                        reader.ReadToFollowing("y");
                        blockY = reader.ReadString();

                        reader.ReadToFollowing("width");
                        width = reader.ReadString();

                        reader.ReadToFollowing("height");
                        height = reader.ReadString();
                        if (blockX != "")
                        {
                            intX = Convert.ToInt32(blockX);
                            intY = Convert.ToInt32(blockY);
                            widthx = Convert.ToInt32(width);
                            heighty = Convert.ToInt32(height);
                            Wall b = new Wall(intX, intY, widthx, heighty);
                            walls.Add(b);
                        }
                    }
                }
                //close reader
                reader.Close();
            }
            else
            {
                timer1.Stop();
                Form f = this.FindForm();
                f.Controls.Remove(this);
                GameOverScreen gs = new GameOverScreen();
                f.Controls.Add(gs);
                gs.Location = new Point((this.Width - gs.Width) / 2, (this.Height - gs.Height) / 2);
                gs.Focus();
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {

            if (leftArrowDown == true)
            {
                hero.move("left");
            }
            if (rightArrowDown == true)
            {
                hero.move("right");
            }
            if (upArrowDown == true)
            {
                hero.move("up");

            }
            if (downArrowDown == true)
            {
                hero.move("down");

            }


            tasksLabel.Text = tasks.Count() + "";



            if (tasks.Count() == 0 && complete == false)
            {
                complete = true;
                switch (levelCounter)
                {
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
                tasks.Clear();

            }


            if (hero.keyCollision(key))
            {
                key.x = 390;
                key.y = 790;
                stop = true;
            }

            if (hero.doorCollision(door) && hero.hasKey == false)
            {
                stop = true;
            }

            if (hero.doorCollision(door) && hero.hasKey == true)
            {

                stop = true;
                hero.hasKey = false;
                walls.Clear();
                tasks.Clear();
                taskCounter = 3;
                levelCounter++;
                onStart();

            }



            foreach (Wall c in walls)
            {
                if (hero.wallCollision(c))
                {
                    stop = true;
                    break;
                }
            }

            foreach (Task b in tasks)
            {
                if (hero.taskCollision(b))
                {
                    stop = true;
                    leftArrowDown = false;
                    rightArrowDown = false;
                    upArrowDown = false;
                    downArrowDown = false;

                    taskColour = b.colour;

                    Form f = this.FindForm();
                    taskScreen ts = new taskScreen();
                    f.Controls.Add(ts);

                    ts.Location = new Point((this.Width - ts.Width) / 2, (this.Height - ts.Height) / 2);

                    ts.Focus();
                    ts.BringToFront();
                }
            }

            if (stop == true)
            {
                switch (Hero.direction)
                {
                    case "left":
                        hero.move("right");
                        break;
                    case "right":
                        hero.move("left");
                        break;
                    case "up":
                        hero.move("down");
                        break;
                    case "down":
                        hero.move("up");
                        break;
                }
                stop = false;
            }


            Refresh();
        }
        public void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            switch (levelCounter)
            {
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

            foreach (Wall b in walls)
            {
                e.Graphics.FillRectangle(white, b.x, b.y, b.width, b.height);

            }
            foreach (Task b in tasks)
            {
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

            e.Graphics.FillRectangle(gray, hero.x, hero.y, hero.width, hero.height);
        }
    }
}
