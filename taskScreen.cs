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
        #region global variables
        Boolean pic1 = false;
        Boolean pic2 = false;
        Boolean pic3 = false;
        Boolean left = false;

        Image duckLeft = Properties.Resources.duck___Copy;
        Image duckRight = Properties.Resources.duck;

        int counter1 = 0;
        int counter2 = 0;
        int counter3 = 0;

        int leftCount = 0;
        int rightCount = 0;

        string colour1, colour2, colour3;
        #endregion 

        public taskScreen()
        {
            InitializeComponent();

            //for whatever colour task you have, load that method
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
                    taskBlack();
                    break;
                case "yellow":
                    taskYellow();
                    break;
                case "lightgreen":
                    taskLightGreen();
                    break;
                case "purple":
                    taskPurple();
                    break;
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            //close screen
            Form f = this.FindForm();
            f.Controls.Remove(this);

        }

        #region task methods
        public void taskGreen()
        {
            //clue label
            Label.Text = "PINK PINK PINK";

            //buttons visible
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            checkButton.Visible = true;
        }

        public void taskRed()
        {
            //clue label
            Label.Text = "CODE: 26793";

            //button and text box visible
            textBox1.Visible = true;
            checkButton.Visible = true;
        }

        public void taskBlue()
        {
            //clue label
            Label.Text = "Which ones match?";

            //objects visible
            sunBox.Visible = true;
            rainBox.Visible = true;
            sunBox2.Visible = true;
            checkButton.Visible = true;
        }

        public void taskPink()
        {
            //doors visible
            doorBox1.Visible = true;
            doorBox2.Visible = true;
            doorBox3.Visible = true;
            doorBox4.Visible = true;
            doorBox5.Visible = true;
            doorBox6.Visible = true;
            doorBox7.Visible = true;

            //clue label
            Label.Visible = true;
        }

        public void taskTurquoise()
        {
            //clue label
            Label.Text = "What is 2 + 4?";

            // text box and button visible
            textBox1.Visible = true;
            checkButton.Visible = true;
        }

        public void taskBlack()
        {
            //clue label
            Label.Text = "DO NOT CLICK THE BUTTON ;)";

            //button visible
            button.Visible = true;
        }

        public void taskYellow()
        {
            //clue label
            Label.Text = "<--     -->      -->      <--";

            //picutres and button visible
            checkButton.Visible = true;
            duck1.Visible = true;
            duck2.Visible = true;
            duck3.Visible = true;
            duck4.Visible = true;

            //set all ducks facing right
            duck1.Image = duckRight;
            duck2.Image = duckRight;
            duck3.Image = duckRight;
            duck4.Image = duckRight;
        }

        public void taskLightGreen()
        {
            //buttons visible
            label1.Visible = true;
            leftButton.Visible = true;
            rightButton.Visible = true;

            //clue label
            Label.Text = "L R R L R";
        }

        public void taskPurple()
        {
            //doors visible
            label1.Visible = true;
            doorBox1.Visible = true;
            doorBox2.Visible = true;
            doorBox3.Visible = true;
            doorBox4.Visible = true;
            doorBox5.Visible = true;
            doorBox6.Visible = true;
            doorBox7.Visible = true;
            doorBox8.Visible = true;
            doorBox9.Visible = true;
            doorBox10.Visible = true;
            doorBox11.Visible = true;
            doorBox12.Visible = true;
        }
        #endregion

        #region blue task
        private void sunBox_Click(object sender, EventArgs e)
        {
            //set variable to true
            pic1 = true;
            //set colour to green
            sunBox.BackColor = Color.Green;
        }

        private void rainBox_Click(object sender, EventArgs e)
        {
            //set variable to true
            pic2 = true;
            //set colour to red
            rainBox.BackColor = Color.Red;
        }

        private void sunBox2_Click(object sender, EventArgs e)
        {
            //set variable to true
            pic3 = true;
            //set colour to green
            sunBox2.BackColor = Color.Green;
        }
        #endregion

        #region green task
        private void button1_Click(object sender, EventArgs e)
        {
            //counter to change the colours
            Boolean click = true;
            if (click == true)
            {
                counter1++;
                click = false;
            }

            //change colours for how many clicks
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
                //reset counter
                counter1 = -1;
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {

            //counter to change the colours
            Boolean click = true;
            if (click == true)
            {
                counter2++;
                click = false;
            }

            //change colours for how many clicks
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
                //reset counter
                counter2 = -1;
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {

            //counter to change the colours
            Boolean click = true;
            if (click == true)
            {
                counter3++;
                click = false;
            }

            //change colours for how many clicks
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
                //reset counter
                counter3 = -1;
            }


        }
        #endregion

        #region check button tasks
        private void checkButton_Click(object sender, EventArgs e)
        {
            // for each task colour
            switch (GameScreen.taskColour)
            {
                case "green":
                    //if all buttons are pink
                    if (colour1 == "pink" && colour2 == "pink" && colour3 == "pink")
                    {
                        //add to task counter
                        GameScreen.taskCounter++;
                        foreach (Task t in GameScreen.tasks)
                        {
                            if (t.colour == "green")
                            {
                                //remove task from task list
                                GameScreen.tasks.Remove(t);
                                //play complete task sound
                                Form1.completeTask.Play();
                                break;
                            }
                            else
                            {
                            }
                        }
                        //go back
                        Form f = this.FindForm();
                        f.Controls.Remove(this);
                    }
                    break;
                case "red":
                    if (textBox1.Text != "26793")
                    {
                        label2.Text = "wrong code";
                    }
                    else
                    {
                        //task code from text box
                        int code = Convert.ToInt32(textBox1.Text);

                        //if code is correct
                        if (code == 26793)
                        {
                            //add to task counter
                            GameScreen.taskCounter++;
                            foreach (Task t in GameScreen.tasks)
                            {
                                if (t.colour == "red")
                                {
                                    //remove task from task list
                                    GameScreen.tasks.Remove(t);
                                    //play complete task sound
                                    Form1.completeTask.Play();
                                    break;
                                }
                                else
                                {
                                }
                            }
                            //go back
                            Form f = this.FindForm();
                            f.Controls.Remove(this);
                        }
                    }
                    break;
                case "blue":
                    //if wrong combo
                    if (pic2 == true && pic1 == true)
                    {
                        //reset back colours
                        pic1 = pic2 = pic3 = false;
                        sunBox.BackColor = rainBox.BackColor = sunBox2.BackColor = Color.PaleTurquoise;
                    }

                    //if wrong combo
                    if (pic2 == true && pic3 == true)
                    {
                        //reset back colours
                        pic1 = pic2 = pic3 = false;
                        sunBox.BackColor = rainBox.BackColor = sunBox2.BackColor = Color.PaleTurquoise;
                    }

                    //if the two pictures selected are correct
                    if (pic1 == true && pic3 == true)
                    {
                        //add to task counter
                        GameScreen.taskCounter++;
                        foreach (Task t in GameScreen.tasks)
                        {
                            if (t.colour == "blue")
                            {
                                //remove task from task list
                                GameScreen.tasks.Remove(t);
                                //play complete task sound
                                Form1.completeTask.Play();
                                break;
                            }
                            else
                            {
                            }
                        }
                        //go back
                        Form f = this.FindForm();
                        f.Controls.Remove(this);
                    }
                    break;
                case "paleturquiose":
                    if (textBox1.Text != "6")
                    {
                        label2.Text = "wrong answer";
                    }
                    else
                    {
                        //get answer from text box
                        int math = Convert.ToInt32(textBox1.Text);

                        //if answer is right
                        if (math == 6)
                        {
                            //add to task counter
                            GameScreen.taskCounter++;
                            foreach (Task t in GameScreen.tasks)
                            {
                                if (t.colour == "paleturquiose")
                                {
                                    //remove task from task list
                                    GameScreen.tasks.Remove(t);
                                    //play complete task sound
                                    Form1.completeTask.Play();
                                    break;
                                }
                                else
                                {
                                }
                            }
                            //go back
                            Form f = this.FindForm();
                            f.Controls.Remove(this);
                        }
                    }
                    break;
                case "yellow":
                    //if ducks are facing the correct way
                    if (duck1.Image == duckLeft &&
                        duck2.Image == duckRight &&
                        duck3.Image == duckRight &&
                        duck4.Image == duckLeft)
                    {
                        //add to task counter
                        GameScreen.taskCounter++;
                        foreach (Task t in GameScreen.tasks)
                        {
                            if (t.colour == "yellow")
                            {
                                //remove task from task list
                                GameScreen.tasks.Remove(t);
                                //play complete task sound
                                Form1.completeTask.Play();
                                break;
                            }
                            else
                            {
                            }
                        }
                        //go back
                        Form f = this.FindForm();
                        f.Controls.Remove(this);
                    }
                    break;
            }
        }
        #endregion

        private void doorBox6_Click(object sender, EventArgs e)
        {
            //if clicked the right door
            //add to task counter
            GameScreen.taskCounter++;
            foreach (Task t in GameScreen.tasks)
            {
                if (t.colour == "pink")
                {
                    //remove task from task list
                    GameScreen.tasks.Remove(t);
                    //play complete task sound
                    Form1.completeTask.Play();
                    break;
                }
                else
                {
                }
            }
            //go back
            Form f = this.FindForm();
            f.Controls.Remove(this);
        }

        private void button_Click(object sender, EventArgs e)
        {
            //if you clicked the button
            //add to taks counter
            GameScreen.taskCounter++;
            foreach (Task t in GameScreen.tasks)
            {
                if (t.colour == "black")
                {
                    //remove task from task list
                    GameScreen.tasks.Remove(t);
                    //play complete task sound
                    Form1.completeTask.Play();
                    break;
                }
                else
                {
                }
            }
            //go back
            Form f = this.FindForm();
            f.Controls.Remove(this);
        }

        #region left and right 
        private void buttonLeft_Click(object sender, EventArgs e)
        {
            //if left button isn't pressed before
            if (leftCount == 0)
            {
                //add one to counter
                label1.Text = "";
                leftCount++;
            }
            else if (rightCount == 2 && leftCount == 1) //if left button is pressed once and right button is pressed twice
            {
                //add one to counter
                leftCount++;
            }
            else //if anything else - ex. right button pressed more than two times
            {
                //add one to counter
                leftCount++;
            }

            //if clicked more
            if (rightCount > 2 && leftCount > 2)
            {
                //reset counters and say wrong code
                label1.Text = "wrong code";
                leftCount = 0;
                rightCount = 0;
            }

        }

        private void buttonRight_Click(object sender, EventArgs e)
        {
            //if left is pressed once
            if (leftCount == 1 && rightCount == 0)
            {
                //add to the counter
                label1.Text = "";
                rightCount++;
            }
            else if (rightCount == 1 && leftCount == 1) //if right is pressed 2 times and left is once
            {
                //add to counter
                rightCount++;
            }
            else if (leftCount == 2 && rightCount == 2) //if correct code
            {
                //add completed tasks
                GameScreen.taskCounter++;
                foreach (Task t in GameScreen.tasks)
                {
                    if (t.colour == "lightgreen")
                    {
                        //remove task from task list
                        GameScreen.tasks.Remove(t);
                        //play complete task sound
                        Form1.completeTask.Play();
                        break;
                    }
                    else
                    {

                    }

                }
                //go back
                Form f = this.FindForm();
                f.Controls.Remove(this);
            }
            else //if anything else
            {
                rightCount++;
            }

            //if wrong code
            if (rightCount > 2 && leftCount > 2)
            {
                label1.Text = "wrong code";
                leftCount = 0;
                rightCount = 0;
            }
        }
        #endregion

        #region ducks
        private void duck1_Click(object sender, EventArgs e)
        {
            //if clicked
            counter1++;
            if (left == false)
            {
                //look left
                duck1.Image = duckLeft;
                left = true;
            }

            //if clicked again
            if (left == true && counter1 == 2)
            {
                //loor right
                left = false;
                duck1.Image = duckRight;
                counter1 = 0;
            }
        }

        private void duck2_Click(object sender, EventArgs e)
        {
            //if clicked
            counter1++;
            if (left == false)
            {
                //look left
                duck2.Image = duckLeft;
                left = true;
            }

            //if clicked again
            if (left == true && counter1 == 2)
            {
                //look right
                left = false;
                duck2.Image = duckRight;
                counter1 = 0;
            }
        }

        private void duck3_Click(object sender, EventArgs e)
        {
            //if clicked
            counter1++;
            if (left == false)
            {
                //look left
                duck3.Image = duckLeft;
                left = true;
            }

            //if clicked again
            if (left == true && counter1 == 2)
            {
                //look right
                left = false;
                duck3.Image = duckRight;
                counter1 = 0;
            }
        }

        private void duck4_Click(object sender, EventArgs e)
        {
            //if clicked
            counter1++;
            if (left == false)
            {
                //look left
                duck4.Image = duckLeft;
                left = true;
            }

            //if clicked again
            if (left == true && counter1 == 2)
            {
                //look right
                left = false;
                duck4.Image = duckRight;
                counter1 = 0;
            }
        }
        #endregion

        private void doorBox10_Click(object sender, EventArgs e)
        {
            //if clicked the right door
            //add to task counter
            GameScreen.taskCounter++;
            foreach (Task t in GameScreen.tasks)
            {
                if (t.colour == "purple")
                {
                    //remove task from task list
                    GameScreen.tasks.Remove(t);
                    //play complete task sound
                    Form1.completeTask.Play();
                    break;
                }
                else
                {
                }
            }
            //go back
            Form f = this.FindForm();
            f.Controls.Remove(this);
        }
    }
}