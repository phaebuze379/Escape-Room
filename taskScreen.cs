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
        public taskScreen()
        {
            InitializeComponent();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            button1.Visible = true;
           // UserControl f = this.();
            f.Controls.Remove(this);
           
        }
    }
}
