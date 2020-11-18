using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mainForm
{
    public partial class ftemp : Form
    {
        public ftemp()
        {
            InitializeComponent();
        }

        private void ftemp_Load(object sender, EventArgs e)
        {

        }
        public void chart_clean()
        {
            charttbpm.Series["temp"].Points.Clear();
        }
        public void insert_data(double aux_)
        {
            charttbpm.Series["temp"].Points.AddY(aux_);
        }
    }
}
