using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escape_Room
{
    public class Key
    {
        public int x, y, width, height;

        public Image keyImage1 = Properties.Resources.EscapeKey1__2_;
        public Image keyImage2 = Properties.Resources.EscapeKey2;
        public Image keyImage3 = Properties.Resources.EsacpeKey3;
        public Image keyImage4 = Properties.Resources.EscapeKey4;
        public Image keyImage5 = Properties.Resources.EscapeKey5;

        public Key(int _x, int _y, int _width, int _height)
        {
            x = _x;
            y = _y;
            width = _width;
            height = _height;

        }
    }
}
