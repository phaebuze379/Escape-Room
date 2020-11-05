using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escape_Room
{
   public  class Door
    {
        public int x, y, width, height;


        public Image doorImage1 = Properties.Resources.Door_1;
        public Image doorImage2 = Properties.Resources.Door2__1_;

        public Door(int _x, int _y, int _width, int _height)
        {
            x = _x;
            y = _y;
            width = _width;
            height = _height;

        }
    }
}
