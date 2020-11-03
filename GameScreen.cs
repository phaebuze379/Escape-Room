using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;
using System.Xml;

namespace Escape_Room
{
    public partial class GameScreen : UserControl
    {
        SolidBrush white = new SolidBrush(Color.White);

        List<Wall> walls = new List<Wall>();

        
        
        

        public GameScreen()
        {
            InitializeComponent();
            levelOne();
    
        }

        public void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            foreach (Wall b in walls)
            {
                e.Graphics.FillRectangle(white, b.x, b.y, b.width, b.height);
            }
        }

        public void levelOne()
        {
            // current level


            // variables for block x and y values
            string blockX;
            string blockY;
            string width;
            string height;
            int intX;
            int intY;
            int widthx;
            int heighty;

            // create xml reader
            XmlReader reader = XmlReader.Create("Resources/level1.xml");

            reader.ReadStartElement("level");


            //Grabs all the walla for the walls and adds them to the list
            while (reader.ReadToFollowing("walls"))
            {
                if (reader.NodeType == XmlNodeType.Text)
                {
                //    reader.ReadToFollowing("x");
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
            // close reader
            reader.Close();
        }
    }
}
