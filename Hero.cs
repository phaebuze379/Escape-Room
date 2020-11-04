using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escape_Room
{
    public class Hero
    {
        public int x, y, width, height;
        public int speed = 50;

        public static string direction;

        public Hero(int _x, int _y, int _width, int _height)
        {
            x = _x;
            y = _y;
            width = _width;
            height = _height;

        }

        public void move(string _direction)
        {
            direction = _direction;
            switch (direction)
            {
                case "left":
                    x -= 5;
                    break;
                case "right":
                    x += 5;
                    break;
                case "up":
                    y -= 5;
                    break;
                case "down":
                    y += 5;
                    break;
            }
                
            }
        public Boolean wallCollision(Wall b)
        {
            Rectangle hero = new Rectangle(x, y, width, height);
            Rectangle wall = new Rectangle(b.x, b.y, b.width, b.height);
           


            return wall.IntersectsWith(hero);
        }

        public Boolean taskCollision(Task b)
        {
            Rectangle hero = new Rectangle(x, y, width, height);
            Rectangle task = new Rectangle(b.x, b.y, b.width, b.height);



            return task.IntersectsWith(hero);
        }
    }
   
}
