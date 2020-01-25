using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RelentAttachProcess
{

    public partial class frmOffsetToFixed : Form
    {
        const ushort LBAVer = 1;
        Mem mem = new Mem();

        public frmOffsetToFixed()
        {
            InitializeComponent();
        }


        public void addLine()
        {
            ListViewItem lvi;
            /*
            lvi = new ListViewItem();
            lvi.Text = getDOSBoxBase().ToString("X");
            lvi.SubItems.Add(new Mem().getBaseAddress(1).ToString("X"));
            lvi.SubItems.Add(newValues[i].ToString());
            lvi.SubItems.Add(timeSpanToString(current - start, false));
            */
        }

        private string getDOSBoxBase()
        {
            return "";
        }
        private void TmrTime_Tick(object sender, EventArgs e)
        {
            addLine();
        }

        private void BtnScan_Click(object sender, EventArgs e)
        {
            Process[] p = Process.GetProcessesByName("DOSBox");
            if (0== p.Length) return;
            
            ListViewItem lvi = new ListViewItem();

            lvi.Text = p[0].MainModule.BaseAddress.ToString("X");
            lvi.SubItems.Add(new Mem().getBaseAddress(1).ToString("X"));
            lvi.SubItems.Add(p[0].MainModule.EntryPointAddress.ToString("X"));
            //p[0].
            //lvOffsetToFixed.Items.Add(lvi);         
        }
    }
}