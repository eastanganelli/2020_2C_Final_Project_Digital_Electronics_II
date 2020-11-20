using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace mainForm {   
    public partial class mainForm : Form {
        #region VARS
        ftemp tempchart = new ftemp();
        List<double> Temp_ = new List<double>();
        rscomLIB porti = null;
        private bool portST = false;
        #endregion
        public mainForm() {
            InitializeComponent();
            tempchart.chart_clean();
            //tempchart.Dispose();
        }
        #region FORM Methods
        private void mainForm_Load(object sender, EventArgs e)
        {

        }
        private void Form1_onFormClosing(object sender, FormClosingEventArgs e)
        {
            if (portST)
            {
                DialogResult dialogResult = MessageBox.Show("Seguro quiere cerrar? La conexión aun esta abierta", "AVISO", MessageBoxButtons.YesNoCancel);
                if (dialogResult == DialogResult.Yes)
                    porti.closePORT();
                else if (dialogResult == DialogResult.Cancel || dialogResult == DialogResult.No) e.Cancel = true;
            }
        }
        #endregion
        #region btSTATE
        private void btnCOM_Click(object sender, EventArgs e)
        {
            btnToogleSTRInvoker();
        }
        //METHOD REQUIRE TO CHANGE BTN STATE WITH INVOKER (MULTITHREADED TASK)
        private bool btnToogleSTRInvoker(bool l = true)
        {
            if (!portST)
            {
                porti = new rscomLIB(save2array, btnToogleSTRInvoker, 5000, true);
                porti.setPortValues();
                btnCOM.Invoke((MethodInvoker)(() => btnCOM.Text = "COM - ON"));
            }
            else
                btnCOM.Invoke((MethodInvoker)(() => btnCOM.Text = "COM - OFF"));
            portST = porti.portToggle();
            return l;
        }
        #endregion
        //SHOW CHART
        private void btnTChart_Click(object sender, EventArgs e)
        {
            if (!tempchart.Visible)
                tempchart.Show();
            else tempchart.Hide();
        }
        #region OTHERS
        //METHOD REQUIRE TO PASS DATA FROM LIB TO LIST
        private bool save2array(string e)
        {
            if (e.Contains('t') && e != null)
            {
                double value_ = (5.0 * Convert.ToInt16(e.Remove(0, 1)) * 100.0) / 1024.0;
                Temp_.Add(value_);
                #region LABELS INFO & CHART
                lblthigh.Invoke((MethodInvoker)(() => lblthigh.Text = "T MAX:" + Temp_.Max().ToString("##.##")));
                lbltavg.Invoke((MethodInvoker) (() => lbltavg.Text  = "T AVG:" + Temp_.Average().ToString("##.##")));
                lbltmin.Invoke((MethodInvoker) (() => lbltmin.Text  = "T MIN:" + Temp_.Min().ToString("##.##")));
                if (CheckOpened(tempchart.Name))
                    tempchart.qanddq(value_);
                #endregion
            }
            return true;
        }
        private bool CheckOpened(string name)
        {
            FormCollection fc = Application.OpenForms;

            foreach (Form frm in fc)
                if (frm.Text == name)
                    return true;
            return false;
        }
        //CLEAR ALL DATA IN SOFTWARE
        private void btnCLEAR_Click(object sender, EventArgs e)
        {
            Temp_.Clear();
            tempchart.chart_clean();
        }
        #endregion
    }
}
