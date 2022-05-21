using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using System.IO.Ports;          // For SerialPort class & ReadByte
//#include "DCC.h"
namespace Kats
{
    public partial class SelectComPort : Form
    {
        //public static char xmitMsg[10]; declared in Command.c no longer used here
        public static byte[] recvMsg = new byte[10];
        public struct GlobalVars
        {
            public byte Command;
            public string ComPort;      // The physical Comm port the USB is using
            public byte LocoAddr;        // Let the DCC controller know which Locomotive it is talking to
            public byte Speed;           // Locomotive speed/velocity
            public bool ValueChanged;   // Lets the system know we need to send a new command to the DCC controller
            public byte Direction;
        };
        public static GlobalVars globalVars = new();
        public static SerialPort _serialPort;
        public static string RxBuff; //commented this out to get rid of warning
        /*********************************************************************************
         * SelectComPort : Constructor
        *********************************************************************************/
        public SelectComPort()  // Constructor
        {
            InitializeComponent();
            //globalVars.FirstTimeThru = true;
            GetListOfSerialPortNames();
            //public static cfgFile = new();
            //globalVars.ComPort = null;         // This will be changed if there is a config file

            // Get the current directory.
            string path = Directory.GetCurrentDirectory();
            string filePath = path + "\\KATS.cfg";

            /*********************************************************************************
             * If config file exists, get the config data. 
            *********************************************************************************/
            if (File.Exists(filePath))
            {
                StreamReader cfgFile = new StreamReader(filePath);
                globalVars.ComPort = cfgFile.ReadLine();  // Get the Comm Port and save it
                //numericUpDown = int32.Parse(cfgFile.ReadLine());//Write the Locomotive number
                numericUpDown.Value = Convert.ToInt32(cfgFile.ReadLine());//Write the Locomotive number
                globalVars.LocoAddr = (byte)numericUpDown.Value;
                globalVars.Direction = 1;    // Depends on how the train was placed on the track
                //locoAddrTextBox = int.Parse(globalVars.LocoAddr);
                cfgFile.Close();
            }
           // If a Comm Port has been selected, select it's radio button
            if (globalVars.ComPort != null)
            {
                switch (globalVars.ComPort)
                {
                    case "COM1":
                        rbCom1.Checked = true;
                        break;
                    case "COM2":
                        rbCom2.Checked = true;
                        break;
                    case "COM3":
                        rbCom3.Checked = true;
                        break;
                    case "COM4":
                        rbCom4.Checked = true;
                        break;
                    case "COM5":
                        rbCom5.Checked = true;
                        break;
                    case "COM6":
                        rbCom6.Checked = true;
                        break;
                    case "COM7":
                        rbCom7.Checked = true;
                        break;
                }
            }
        }
/*********************************************************************************\
*                                 OpenCommPort
* Once a port is selected check if it is was previously opened by another process. 
* If it is close it then re-open it.. If it was not previously open then open it now.
* When a port is open aatach a C# Event Handler function to receive data
********************************************************************************/
    private void OpenCommPort()
    {
        int status;
        // Create the serial port with basic settings
        _serialPort = new SerialPort(globalVars.ComPort, 115200, Parity.None, 8, StopBits.One);
        if(_serialPort.IsOpen)     // Check to see if it's already open
            _serialPort.Close();    // If it is, close it
        try
        {
            _serialPort.Open();     // Otherwise, just open it
        }
        catch
        {
            MessageBox.Show("The STM32 Comm Port is not available, reset the STM32 ??");
        }
        
            //MessageBox.Show(String.Format("{0} is open now", globalVars.ComPort));
            // Attach a method to be called when there is data waiting in the port's buffer
            _serialPort.DataReceived += new SerialDataReceivedEventHandler(Port_DataReceived);
    }
    /********************************************************************************
     * C# Event Handler function to receive data we attached in the OpenCommPort() 
     * function.
     * https://stackoverflow.com/questions/1243070/how-to-read-and-write-from-the-serial-port
     *******************************************************************************/
    private static void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //int i = 0;
            // Show all the incoming data in the port's buffer
            RxBuff = string.Format(_serialPort.ReadExisting());
            /* the above lines seem to work making the following lines redundant
                        do
                        {
                            recvMsg[i] = (byte)_serialPort.ReadByte();
                        }
                        while (recvMsg[i++] != -1);
            */
            CommandWindow.Wait4response = true;
        }
        /*****************************************************************************************
        Get a list of available serial port names. Later we can change the code to lisy only 
        those ports available for use  instead of listing comm 1 thru 7 as we do now. Even if they 
        are not available.  We'll circle back later.
        ******************************************************************************************/
        private static void GetListOfSerialPortNames()
        {
            string[] ports = SerialPort.GetPortNames();
            // Debug only !!! Display each port name to the console.            
             foreach (string port in ports)
             {
                 System.Diagnostics.Debug.WriteLine("Found {0}", port);// Print to debuggers output window
             }
        }
        /********************************************************************************
        * Here we save our settings to the configuration file. First we open the file,
        * then write the data and finally close the file.
        ********************************************************************************/
        private static void SaveConfigData()
        {
            //FileStream cfgFile;
            // Get the current directory.
            string path = Directory.GetCurrentDirectory();
            string filePath = path + "\\KATS.cfg";
            /*********************************************************************************
             * If config file exists, get the config data. If the file doesn't exist create
             * one and put write the data into it 
            *********************************************************************************/
            if (File.Exists(filePath))
            {
                StreamWriter cfgFile = new StreamWriter(filePath);
                cfgFile.WriteLine(globalVars.ComPort);  //Write the default Comm Port to the config file                
                cfgFile.WriteLine(globalVars.LocoAddr);//Write the defaultLocomotive number as a string
                cfgFile.Close();
            }
            else
            {
                StreamWriter cfgFile = File.CreateText(filePath);
                cfgFile.WriteLine(globalVars.ComPort);  //Write the default Comm Port to the config file                
                cfgFile.WriteLine(globalVars.LocoAddr.ToString());//Write the defaultLocomotive number as a string
                cfgFile.Close();
            }
        }
        /********************************************************************************
        * Here we deal with receiving data from the USB serial port
        * https://stackoverflow.com/questions/1243070/how-to-read-and-write-from-the-serial-port
        ********************************************************************************/
        /********************************************************************************
        * Here we deal with the com port radio buttons as they are selected.
        * The first radio button is selected by default. 
        * For now when SelectCom_1 is called we uncheck its radio button (rbCom1) then 
        * and only then we set FirstTimeThru == false. The order is VERY VERY sensitive.
        * Setting the radio button checked to false instigates another interrupt and you 
        * don't want FirstTimeThru set to false BEFORE that happens so, set the button 
        * to false before disabling FirstTimeThru.
        ********************************************************************************/
        /// <summary>
        /// </summary>
        private void SelectCom_1(object sender, EventArgs e)
        {
           globalVars.ComPort = "COM1";
            OpenCommPort();
        }
        private void SelectCom_2(object sender, EventArgs e)
        {
           globalVars.ComPort = "COM2";
            OpenCommPort();
        }
        private void SelectCom_3(object sender, EventArgs e)
        {
            globalVars.ComPort = "COM3";
            OpenCommPort();
        }
        private void SelectCom_4(object sender, EventArgs e)
        {
           globalVars.ComPort = "COM4";
            OpenCommPort();
        }

        private void SelectCom_5(object sender, EventArgs e)
        {
           globalVars.ComPort = "COM5";
            OpenCommPort();
        }

        private void SelectCom_6(object sender, EventArgs e)
        {
           globalVars.ComPort = "COM6";
            OpenCommPort();
        }

        private void SelectCom_7(object sender, EventArgs e)
        {
           globalVars.ComPort = "COM7";
            OpenCommPort();
        }
    /*****************************************************************************************
    *                      Close_Comm_port
    * Since the first radio buttin is enabled by the system, COM1 in our case, we need to
    * close it.
    ******************************************************************************************/
    public static void Close_Comm_port()
        {
            if (_serialPort.IsOpen)     // Check to see if it's already open
            {
                _serialPort.Close();     // If it is, close it
            }
        }
        /******************************************************************************
         * CloseOpenPort() : Closes any ports we have opened previously and have forgotten. 
         * Note that this only works if its a port we opened, that's because it relies 
         * on globalVars.ComPort
         *****************************************************************************/
        private void CloseOpenPort()
        {
            if (String.IsNullOrEmpty(globalVars.ComPort ))
            {
                MessageBox.Show(String.Format("Found no avtive comm port {0}",globalVars.ComPort));
            }
            else
            {
                if (_serialPort.IsOpen) // If we have a Com Port 
                {
                    _serialPort.Close();// close it
                    MessageBox.Show(String.Format("Closing comm port {0}",globalVars.ComPort));
                }
            }
        }
        /******************************************************************************
         * When we're done with selecting com port, make it go away
         * BUT !!! where does control of the program go from here ???
         *****************************************************************************/
        private void DoneComPort(object sender, EventArgs e)
        {
            string mymsg;
            int i;
            int delay;
            //mymsg = locoAddrTextBox.Text;
            //Int32.TryParse(mymsg, out i);
            if (globalVars.ComPort != null)
            {
                CommandWindow.AssemblePollPkt();
                SaveConfigData();
                delay = 0;
                while ((CommandWindow.Wait4response == false) && (delay < 100) ) // Delay for up to 1 Second
                {
                    Thread.Sleep(10);       // Sleep for 10 mSec
                    delay++;                // Keep track of number of 10 mSec delays         
                }
                if(delay > 100)               // Then we timed out
                   MessageBox.Show(String.Format("Communication with the KATS (DCC) station timed out"));
                else
                {
                    if (CommandWindow.Wait4response)
                    {
                        if (RxBuff[0] == CommandWindow.POLL_ACKNOWLEDGE)
                        {
                            MessageBox.Show(String.Format("Successful handshake with KATS (DCC) station\n\n KATS is now in remote mode (PC Controlled)"));
                        }
                    }
                    else
                    {
                        MessageBox.Show(String.Format("KATS (DCC) station did not respond to handshake"));
                    }
                }
            }
            else
            {
                MessageBox.Show(String.Format("You must choose a Comm Port to communicate to the KATS (DCC) station"));
                return;
            }
            this.Close();    // Close the SelectComPort winForm for debugging puposes. Removefor real life
        }
        /******************************************************************************
         *                      LocoAddrChanged
         * The address of the Locomotive has been changed by the user
         *****************************************************************************/
        private void LocoAddrChanged(object sender, EventArgs e)
        {
            globalVars.LocoAddr = (byte)numericUpDown.Value;
        }
    }
}
