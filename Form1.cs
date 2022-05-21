namespace Kats
{
    public partial class Form1 : Form
    {
        public int xxx;
        public Form1()      // The constuctor
        {
            InitializeComponent();  // This is where the main window is assembled and displayed  
        }
        /*****************************************************************************************
         * Form1_Load() is called but the system does nothing with it (ie no code is placed here )
         * You can use this tp initialize a program other than the constructor. I'm not sure.
         * To do something when the program first starts without anything being pressed or clicked, 
         * find a blank spot on the form and double click there.That will bring up "form1_load.
         * ***************************************************************************************/
        private void Form1_Load(object sender, EventArgs e)
        {
            // Debug only, this helps me understand the sequence of events
            //System.Threading.Thread.Sleep(1000);
            //MessageBox.Show("Delayed for one second"); // Nothing was displayed until this button was clicked  
            //Logo_Definition.Text = ""; //   Works !!! Erases what was there and leaves a blank for the text.
            //Form1.Controls.Remove(Logo_Definition);
            //Form1.ControlCollection.Clear();    
            //Controls.Clear();// Worked but nothing was displayed just a blank window from start to finish
            //this.Close(); // Worked !!! Window and Program both closed

            // By putting anything before here, it appear before the splash screen
            //MessageBox.Show("We get here prior to the splash screen getting displayed Form1_Load()");
        }

        private void Logo_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("This is where we get by clicking on the label \"Logo\" in the splash screen (Form1.cs)");
        }
        /**********************************************************************
         * This is where we go when we click on the button \"SplashScreenNextPage\" 
         * in the splash screen (Form1.cs).
         * This brings up the Comm Port selection window.Once we bring up the 
         * comm port dialog we need to fill in the data we read from the KATS.cfg 
         * file
         *********************************************************************/
        private void ClearSplashScreen(object sender, EventArgs e)
        {
            //MessageBox.Show("");
            Controls.Clear();// Works, leaves the window blank !!!
            SelectComPort comPort = new SelectComPort();
            comPort.ShowDialog();
            //MessageBox.Show("Returned from commPort.Show() in function ClearSplashScreen");   // With the commPort window still active so, it displays the window then relinquishes control
            CommandWindow commandWindow = new();
            commandWindow.Show();
            //MessageBox.Show("Returned from commandWindow.Show() in function ClearSplashScreen");
        }
        /**********************************************************************
         * main() : C# expects this special syntax
         *********************************************************************/
        static void Main( string[] arg)
        {
            Application.Run(new Form1()); // This brings up the splash screen.
            MessageBox.Show("In Form1.Main() post Splash screen");
            SelectComPort.Close_Comm_port();
            CommandWindow commandWindow = new();
            commandWindow.Show();
            MessageBox.Show("Ran commandWindow.Show()");
            while (true)
              if (SelectComPort.globalVars.ValueChanged)
                CommandWindow.Send_DCC_Command();
        }
    }
}