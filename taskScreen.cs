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
    public partial class taskScreen : UserControl
    {
        Boolean pic1 = false;
        Boolean pic2 = false;
        Boolean pic3 = false;

        int counter1 = 0;
        int counter2 = 0;
        int counter3 = 0;
        string colour1, colour2, colour3;
        public taskScreen()
        {
            InitializeComponent();
            switch (GameScreen.taskColour)
            {
                case "green":
                    taskGreen();
                    break;
                case "red":
                    taskRed();
                    break;
                case "blue":
                    taskBlue();
                    break;
                case "pink":
                    taskPink();
                    break;
                case "paleturquiose":
                    taskTurquoise();
                    break;
                case "black":
                    break;


            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);

        }

        public void taskGreen()
        {

            Label.Text = "PINK PINK PINK";

            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            checkButton.Visible = true;
        }

        public void taskRed()
        {
            Label.Text = "CODE: 26793";
            textBox1.Visible = true;
            checkButton.Visible = true;
        }

        public void taskBlue()
        {
            Label.Text = "Which ones match?";
            sunBox.Visible = true;
            rainBox.Visible = true;
            sunBox2.Visible = true;
            checkButton.Visible = true;
        }

        public void taskPink()
        {
            doorBox1.Visible = true;
            doorBox2.Visible = true;
            doorBox3.Visible = true;
            doorBox4.Visible = true;
            doorBox5.Visible = true;
            doorBox6.Visible = true;
            doorBox7.Visible = true;
            Label.Visible = true;
        }

        public void taskTurquoise()
        {
            Label.Text = "What is 2 + 4?";
            textBox1.Visible = true;
            checkButton.Visible = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pic1 = true;
            sunBox.BackColor = Color.Green;


        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pic2 = true;
            rainBox.BackColor = Color.Red;


        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pic3 = true;
            sunBox2.BackColor = Color.Green;



        }

        private void button1_Click(object sender, EventArgs e)
        {

            Boolean click = true;
            if (click == true)
            {
                counter1++;
                click = false;
            }


            if (counter1 == 0)
            {
                button1.BackColor = Color.DarkGray;
            }
            if (counter1 == 1)
            {
                button1.BackColor = Color.Blue;
            }

            if (counter1 == 2)
            {
                button1.BackColor = Color.Green;
            }

            if (counter1 == 3)
            {
                colour1 = "pink";
                button1.BackColor = Color.Pink;
                counter1 = -1;
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {


            Boolean click = true;
            if (click == true)
            {
                counter2++;
                click = false;
            }


            if (counter2 == 0)
            {
                button2.BackColor = Color.DarkGray;
            }
            if (counter2 == 1)
            {
                button2.BackColor = Color.Blue;
            }

            if (counter2 == 2)
            {
                button2.BackColor = Color.Green;
            }

            if (counter2 == 3)
            {
                colour2 = "pink";
                button2.BackColor = Color.Pink;
                counter2 = -1;
            }


        }

        private void button5_Click(object sender, EventArgs e)
        {
            foreach (Task t in GameScreen.tasks)
            {
                switch (t.colour)
                {
                    case "green":
                        if (colour1 == "pink" && colour2 == "pink" && colour3 == "pink")
                        {
                            GameScreen.taskCounter++;

                            GameScreen.tasks.Remove(t);

                            Form f = this.FindForm();
                            f.Controls.Remove(this);

                        }
                        break;
                    case "red":
                        int code = Convert.ToInt32(textBox1.Text);
                        if (code == 26793)
                        {
                            GameScreen.taskCounter++;

                            GameScreen.tasks.Remove(t);
                            break;
                            Form f = this.FindForm();
                            f.Controls.Remove(this);
                        }
                        break;
                    case "blue":
                        if (pic2 == true && pic1 == true)
                        {
                            pic1 = pic2 = pic3 = false;
                            sunBox.BackColor = rainBox.BackColor = sunBox2.BackColor = Color.PaleTurquoise;
                        }

                        if (pic2 == true && pic3 == true)
                        {

                            pic1 = pic2 = pic3 = false;
                            sunBox.BackColor = rainBox.BackColor = sunBox2.BackColor = Color.PaleTurquoise;
                        }

                        if (pic1 == true && pic3 == true)
                        {
                            GameScreen.taskCounter++;

                            GameScreen.tasks.Remove(t);
                            break;
                            Form f = this.FindForm();
                            f.Controls.Remove(this);
                        }
                        break;
                    case "pink":
                        break;
                    case "paleturquiose":
                        int math = Convert.ToInt32(textBox1.Text);

                        if (math == 6)
                        {
                            GameScreen.taskCounter++;

                            GameScreen.tasks.Remove(t);
                            Form f = this.FindForm();
                            f.Controls.Remove(this);
                        }
                        break;
                    case "black":
                        break;


                }
            }



        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            GameScreen.taskCounter++;
            foreach (Task t in GameScreen.tasks)
            {
                if (t.colour == "pink")
                {
                    GameScreen.tasks.Remove(t);
                    break;
                }
                else
                {

                }

            }

            Form f = this.FindForm();
            f.Controls.Remove(this);
        }


        private void button3_Click(object sender, EventArgs e)
        {


            Boolean click = true;
            if (click == true)
            {
                counter3++;
                click = false;
            }


            if (counter3 == 0)
            {
                button3.BackColor = Color.DarkGray;
            }
            if (counter3 == 1)
            {
                button3.BackColor = Color.Blue;
            }

            if (counter3 == 2)
            {
                button3.BackColor = Color.Green;
            }

            if (counter3 == 3)
            {
                colour3 = "pink";
                button3.BackColor = Color.Pink;
                counter3 = -1;
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            string code = textBox1.Text;
            if (code == "26793")
            {
                GameScreen.taskCounter++;
                foreach (Task t in GameScreen.tasks)
                {
                    if (t.colour == "red")
                    {
                        GameScreen.tasks.Remove(t);
                        break;
                    }
                    else
                    {

                    }

                }

                Form f = this.FindForm();
                f.Controls.Remove(this);
            }
        }
    }
}
