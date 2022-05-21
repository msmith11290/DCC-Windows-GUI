
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/******************************************************************************
 * A command has 5 bytes. 
Byte 0 is the command. Byte 1 is the Locomotive Address, Bytes 2 & 3 are the data
byte 4 is reserved and byte 5 is the Checksum or XOR of bytes 0 thru 4.
Since C# works with strings and not numeric values the commands are the letters
A thru Z. Data like speed may be 0 upwards so they may present a problem, we'll
see.
 *****************************************************************************/
namespace Kats
{
    public partial class CommandWindow : Form
    {
        public struct DCC_cmdMsg
        {
            public byte command;
            public byte LocoAddr;  // No such thing as a unsigned byte
            public byte speed;
            public byte direction;
            public byte misc;
            public byte crc;
        };
        public static volatile bool Wait4response;
        //private byte[] cmdArray = new byte[6];
        public static DCC_cmdMsg DCC_CmdMsg = new();
        //static string testMsg;
       //private const char MSG_SIZE = (char)6;  // can't use this with String 
        private const char POLL =  (char)1;      // Used to see if DCC controller is awake & communicating
        public const char POLL_ACKNOWLEDGE = (char)2;      // Used to see if DCC controller is awake & communicating with us
        private const char SPEED_CMD = (char)3;
        private const char COMMAND_ACK = (char)4;
        private const char DIRECTION_CMD = (char)5;
        public CommandWindow()
        {
            InitializeComponent(); // The Maximum property sets the value of the track bar when

            trackBar1.Maximum = 30; // the slider is all the way to the right.
            trackBar1.Minimum = 0; // the slider is all the way to the right.
        }
        /**********************************************************************
         * Since C# string's are 16 bits conversion of bytes goes from char to 
         * 16 bit int. The STM recieves 'A'
         *********************************************************************/
            private static byte CalculateChecksum( )//byte *cmdList)
            {
                byte crc = 0;

                crc = DCC_CmdMsg.command;
                crc ^= DCC_CmdMsg.LocoAddr;// Let the DCC controller know which Locomotive it is talking to
                crc ^= DCC_CmdMsg.speed;
                crc ^= DCC_CmdMsg.direction;
                crc ^= DCC_CmdMsg.misc;
                DCC_CmdMsg.crc = crc;
               
        return crc;
    }
        /*********************************************************************************
         * send_DCC_Command();
         * My original thought were to
            DCC_CmdMsg.command = (byte)SPEED_CMD;
            DCC_CmdMsg.LocoAddr = SelectComPort.globalVars.LocoAddr;// Let the DCC controller know which Locomotive it is talking to
            DCC_CmdMsg.speed = SelectComPort.globalVars.Speed;
            DCC_CmdMsg.direction = SelectComPort.globalVars.Direction;
            DCC_CmdMsg.misc = 0;
            DCC_CmdMsg.crc = CalculateChecksum();
        But serial comm port wants a string so, I changed the structure to bytes but 
        couldn't find a way to convert a struct to a string so I went with an array of bytes.
        The array of bytes duplicates ( in order ) the DCC_CmdMsg structure.
        *********************************************************************************/
        public static void Send_DCC_Command()
        {
            byte[] cmd = new byte[6];

            cmd[0] = (byte)SelectComPort.globalVars.Command;
            cmd[5] = (byte)SelectComPort.globalVars.Command;       // Calculate the checksum on the fly
            cmd[1] = SelectComPort.globalVars.LocoAddr;
            cmd[5] ^= cmd[1];       // Calculate the checksum on the fly
            cmd[2] = SelectComPort.globalVars.Speed;
            cmd[5] ^= cmd[2];       // Calculate the checksum on the fly
            cmd[3] = SelectComPort.globalVars.Direction;
            cmd[5] ^= cmd[3];       // Calculate the checksum on the fly
            cmd[4] = (byte)0;
            SelectComPort._serialPort.Write(cmd, 0, 6);
        }

        /*********************************************************************************
         *                      AssemblePollPkt()
         * This command is just a "Hello anyone there ?" command. A response to this 
         * message is expected
        *********************************************************************************/
        public static void AssemblePollPkt()
        {
            byte[] cmd = new byte[6];

            cmd[0] = (byte)POLL;
            for (int i = 1; i < 4; i++)
                cmd[i] = (byte)0x00;
            cmd[5] = (byte)POLL;            // Since all but the first is "0" the checksum will be the first
                                            // string s = System.Text.Encoding.UTF8.GetString(cmd, 0, cmd.Length);
            SelectComPort._serialPort.Write(cmd, 0, 6);// Send data to DCC controller
            Wait4response = false;
            //Send_DCC_Command();
        }

        private void TrackBarMoved(object sender, EventArgs e)
        {
            int i;
            trkBarReadout.Text = trackBar1.Value.ToString(); // Copy track bar value to label for a human read out
            SelectComPort.globalVars.Speed = (byte)trackBar1.Value;
            SelectComPort.globalVars.Command = (byte)SPEED_CMD;
            SelectComPort.globalVars.ValueChanged = true;   // Lets the system know we need to send a new command to the DCC controller
            Send_DCC_Command();
        }

        private void DirectionChange(object sender, EventArgs e)
        {
            if (SelectComPort.globalVars.Direction == 1)
                SelectComPort.globalVars.Direction = 0;
            else
                SelectComPort.globalVars.Direction = 1;
            SelectComPort.globalVars.Command = (byte)DIRECTION_CMD;
            Send_DCC_Command();
        }
    }
}
