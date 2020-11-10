using System;
using System.Linq;
using System.Windows.Forms;
using System.IO.Ports; // This is important
using System.Threading;
using System.Collections.Generic;

namespace mainForm {
    public partial class mainForm : Form {
        List<double> Temp_ = new List<double>();
        public mainForm() {
            InitializeComponent();
            charttbpm.Series["temp"].Points.Clear();
            charttbpm.Visible = false;
        }
        private void delayRead_Tick(object sender, EventArgs e)
        {
            try
            {
                string indata = spCOM.ReadExisting();
                if (indata != "")
                    tempsIN(indata);                
            }
            catch (Exception ex)
            {
                //throw ex;
            }
        }
       private void Form1_onFormClosing(object sender, FormClosingEventArgs e)
       {
            if (spCOM.IsOpen)
            {
                DialogResult dialogResult = MessageBox.Show("Seguro quiere cerrar? La conexión aun esta abierta", "AVISO", MessageBoxButtons.YesNoCancel);
                if (dialogResult == DialogResult.Yes)
                {
                    spCOM.Write("b");
                    spCOM.Close();
                }
                else if (dialogResult == DialogResult.Cancel) e.Cancel = true;
            }
       }
        private void tempsIN(string in_)
        {
            double aux_ = 0;
            aux_ = Convert.ToDouble(in_);
            
            spCOM.Write("a");
            Temp_.Add(aux_);
            lblthigh.Text = ("T_MAX: " + Temp_.Max().ToString());
            lbltavg.Text = ("T_AVG: " + Temp_.Average().ToString());
            lbltmin.Text = ("T_MIN: " + Temp_.Min().ToString());

            charttbpm.Series["temp"].Points.AddY(aux_);

            
            
        }
        private void btnCOM_Click(object sender, EventArgs e)
        {
            if (!(spCOM.IsOpen))
            {
                spCOM.Open();
                btnCOM.Text = "COM - ON";
                Thread.Sleep(500);
                delayreader.Enabled = true;
                charttbpm.Visible = true;
            }
            else
            {
                spCOM.Write("b");  // Cerrar COM}
                spCOM.Close();
                btnCOM.Text = "COM - OFF";
                delayreader.Enabled = false;
                charttbpm.Visible = false;
            }
        }
    }
}
