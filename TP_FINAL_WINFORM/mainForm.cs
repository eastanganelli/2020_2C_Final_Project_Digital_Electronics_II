using System;
using System.Linq;
using System.Windows.Forms;
using System.IO.Ports; // This is important
using System.Threading;
using System.Collections.Generic;

namespace mainForm {
    public partial class mainForm : Form {
        #region VARS
        ftemp tempchart = new ftemp();
        List<float> Temp_ = new List<float>();
        serialLib porti = new serialLib();
        private bool portST = false;
        #endregion

        public mainForm() {
            InitializeComponent();
            tempchart.chart_clean();
            porti.init(save2array);
        }
        private void mainForm_Load(object sender, EventArgs e)
        {
            
        }
        private void delayRead_Tick(object sender, EventArgs e)
        {

        }
       private void Form1_onFormClosing(object sender, FormClosingEventArgs e)
       {
            if (!portST)
            {
                DialogResult dialogResult = MessageBox.Show("Seguro quiere cerrar? La conexión aun esta abierta", "AVISO", MessageBoxButtons.YesNoCancel);
                if (dialogResult == DialogResult.Yes)
                    porti.portToggle();
                else if (dialogResult == DialogResult.Cancel) e.Cancel = true;
            }
        }
        private bool save2array(string e)
        {
            Console.WriteLine(e);
            return true;
        }
        private void btnCOM_Click(object sender, EventArgs e)
        {
            portST = porti.portToggle();
            if (!portST)
                btnCOM.Text = "COM - ON";
            else
                btnCOM.Text = "COM - OFF";
        }

        private void btnTChart_Click(object sender, EventArgs e)
        {
            tempchart.Show();
        }
    }
}
