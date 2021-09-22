using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace mainForm
{
    public partial class ftemp : Form
    {
        private const int DataInX = 128;
        #region HIDING CLOSE BUTTON
        const int MF_BYPOSITION = 0x400;
        [DllImport("User32")]
        private static extern int RemoveMenu(IntPtr hMenu, int nPosition, int wFlags);
        [DllImport("User32")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        [DllImport("User32")]
        private static extern int GetMenuItemCount(IntPtr hWnd);
        #endregion  
        public ftemp()
        {
            InitializeComponent();
        }

        private void ftemp_Load(object sender, EventArgs e)
        {
            IntPtr hMenu = GetSystemMenu(this.Handle, false);
            int menuItemCount = GetMenuItemCount(hMenu);
            RemoveMenu(hMenu, menuItemCount - 1, MF_BYPOSITION);
        }
        public void chart_clean()
        {
            charttbpm.Series["temp"].Points.Clear();
        }
        public void insert_data(double aux_)
        {
            charttbpm.Invoke((MethodInvoker)(() => charttbpm.Series["temp"].Points.AddY(aux_)));
        }
        //QEUE AND DEQEUE
        public void qanddq(double aux_)
        {
            charttbpm.Invoke((MethodInvoker)(() => charttbpm.Series["temp"].Points.AddY(aux_)));
            if (charttbpm.Series["temp"].Points.Count > DataInX)
                charttbpm.Invoke((MethodInvoker)(() => charttbpm.Series["temp"].Points.RemoveAt(0)));
        }
    }
}
