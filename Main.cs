using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kats
{
    public partial class Main : UserControl
    {
        public Main()
        {
            MessageBox.Show("Pre InitializeComponent() in Main: UserControl");
            InitializeComponent();
            MessageBox.Show("Post InitializeComponent() in Main: UserControl");
        }
        public void LetsGoBrandon()
        {
            MessageBox.Show("LetsGoBrandon() in Main: UserControl");
            SelectComPort mainRoutine = new SelectComPort();
            mainRoutine.Show();
        }
    }
}
