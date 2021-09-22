using System;
using System.IO.Ports;
using System.Threading;

namespace mainForm
{
    class rscomLIB
    {
        #region CONST
        const char SEP = '\n';
        const char END = '\0';
        #endregion
        #region VARIABLES
        private Func<string, bool> methodRETURN;
        private Func<bool, bool> stateChange;
        private System.Timers.Timer timer;

        private SerialPort serialOb = new SerialPort();
        private string dataIN = null;
        #endregion
        public rscomLIB(Func<string, bool> a_, Func<bool, bool> b_, int t_ = 5000, bool tt_ = false)
        {
            #region PORT SEARCH
            string[] ports = SerialPort.GetPortNames(); //Names of all available PORT in system
            foreach (string port in ports)
                serialOb.PortName = port; //SAVING first avaible PORT found
            serialOb.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
            #endregion

            methodRETURN = a_; //Saving method that will bypass data
            stateChange = b_; //Saving method that will bypass serial state
            #region TIMER INIT
            timer = new System.Timers.Timer(t_);
            timer.Enabled = tt_;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(_timer_Elapsed);
            #endregion
        }
        public bool setPortValues(int baudrate = 9600, int Databits = 8, Parity parity = Parity.None)
        {
            if (serialOb.PortName != "") //Setting PORT configuration
            {
                serialOb.BaudRate = baudrate;
                serialOb.Parity = parity;
                serialOb.StopBits = StopBits.One;
                serialOb.DataBits = Databits;
                serialOb.Handshake = Handshake.None;
                serialOb.RtsEnable = true;
                serialOb.WriteBufferSize = 2;
                return true; //Able to set params
            }
            return false; //Unable to set params
        }
        //RESET TIMER
        private void timerReset()
        {
            timer.Stop();
            timer.Start();
        }
        #region PORT DOOR
        public bool portToggle() //Toggle PORT door
        {
            if (serialOb.IsOpen)
            {
                closePORT();
                return false;
            }
            openPORT();
            return true;
        }
        public void closePORT()
        {
            serialOb.WriteLine("i");
            Thread.Sleep(250); //Require!! To avoid PORT closing before sending message.
            serialOb.Close();
            dataIN = null;
            timer.Stop();
        }
        private void openPORT()
        {
            serialOb.Open();
            Thread.Sleep(250);
            serialOb.WriteLine("a");
            timer.Enabled = true;
            timer.Start();
        }
        #endregion
        #region DATA READING, PROCESSING ADN TIMEOUT READ
        //EVENT HANDLER THAT READ IF THERE'S ACTIVITY IN SERIAL PORT
        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            charReader(Convert.ToChar(serialOb.ReadChar())); //Reading char by char
        }
        //CHECK IF CHAR IS A SEP, END OR VALUE
        private void charReader(char c_)
        {
            switch (c_)
            {
                case END:
                    {
                        stateChange(true);
                        break;
                    }
                case SEP:
                    {
                        methodRETURN(dataIN);
                        dataIN = null;
                        timerReset();
                        serialOb.WriteLine("a");
                        break;
                    }
                default:
                    {
                        dataIN += c_;
                        timerReset();
                        break;
                    }
            }
        }
        //EVENT HANDLER FOR TIMER TO CLOSE PORT IF AFTER 6.5 SECONDS THERE'S NO DATA READ (SIMULATE A TIMEOUT)
        private void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            stateChange(true);
        }
        #endregion
    }
}