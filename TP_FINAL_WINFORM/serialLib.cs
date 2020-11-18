using System;
using System.IO.Ports;
using System.Threading;

namespace mainForm
{
    class serialLib
    {
        const char SEP = '\n';
        const char END = '\0';

        private Func<string, bool> methodRETURN;
        Timer portOUT;

        SerialPort serialOb = new SerialPort();
        string dataIN;
        public void init(Func<string, bool> a_)
        {
            #region PORT SEARCH
            string[] ports = SerialPort.GetPortNames(); //Names of all available PORT in system
            foreach (string port in ports)
                serialOb.PortName = port; //SAVING first avaible PORT found
            serialOb.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
            #endregion

            methodRETURN = a_;
        }
        public bool setPortValues(int baudrate = 9600, int Databits = 8, Parity parity = Parity.None)
        {
            if(serialOb.PortName != "") //Setting PORT configuration
            {
                serialOb.BaudRate  = baudrate;
                serialOb.Parity    = parity;
                serialOb.StopBits  = StopBits.One;
                serialOb.DataBits  = Databits;
                serialOb.Handshake = Handshake.None;
                serialOb.RtsEnable = true;
                serialOb.WriteBufferSize = 2;
                return true;
            } return false;
        }
        public bool portToggle() //Toggle PORT door
        {
            if (serialOb.IsOpen)
            {
                serialOb.WriteLine("i");
                Thread.Sleep(250); //Require!! To avoid PORT closing before sending message.
                serialOb.Close();
                portOUT.Dispose();
                dataIN = null;
                return true;
            } else
            {
                serialOb.Open();
                serialOb.WriteLine("a");
                
                return false;
            }
        }
        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            charReader(Convert.ToChar(serialOb.ReadChar())); //Reading char by char
        }
        private void charReader(char c_)
        {
            switch (c_)
            {
                case END:
                    {

                        break;
                    }
                case SEP:
                    {
                        methodRETURN(dataIN);
                        dataIN = null;
                        serialOb.WriteLine("a");
                        break;
                    }
                default:
                    {
                        dataIN += c_;
                        break;
                    }
            }
        }
    }
}
