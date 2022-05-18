using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; // namespace contain types that enable reading and writing, both synchronously and asynchronously, on data streams and files. 

namespace Kats
{
    public partial class File_IO : Form
    {
        /********************************************************************
         * We'll start by testing if this is not our firt time through and we 
         * have saved a config file from the last time.
         *******************************************************************/
        public File_IO()  // Constructor
        {
            InitializeComponent();
            //public static GlobalVars globalVars = new();
        }
    }
}
