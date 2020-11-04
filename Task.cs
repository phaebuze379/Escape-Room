using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escape_Room
{
    public class Task
    {
        public int x, y, width, height;
        public string colour;

        public Task(string _colour, int _x, int _y, int _width, int _height)
        {
            colour = _colour;
            x = _x;
            y = _y;
            width = _width;
            height = _height;

        }
    }
}
