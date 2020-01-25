using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;

namespace RelentAttachProcess
{
    public partial class frmQuestLogger : Form
    {

        const ushort LBAVer = 1;
        DateTime start;
        Mem mem;
        Items quest = new Items(LBAVer);
        int[] oldValues;
        int[] newValues;
        int oldChapter;
        int newChapter;

        public frmQuestLogger()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            start = DateTime.Now;
            if (tmrTime.Enabled)
            {
                tmrTime.Stop();
                btnStart.Text = "Start";
            }
            else
            {
                tmrTime.Start();
                btnStart.Text = "Stop";
                mem = new Mem();
                getInitialValues();
            }
        }

        public void getInitialValues()
        {
            int val;
            oldValues = new int[quest.Quest.Length];
            newValues = new int[quest.Quest.Length];
            for(int i = 0; i < quest.Quest.Length; i++)
            {
                val = mem.getVal(LBAVer, quest.Quest[i]);
                oldValues[i] = val;
                newValues[i] = val;
            }
            oldChapter = mem.readAddress(1, 0xE28, 1);
            newChapter = oldChapter;
            lblChapter.Text = "Chapter: " + newChapter;
            //SetDoubleBuffered(lvProcesses);
        }

        #region setDoubleBuffered
        /**
         * Used to stop flickering on interface update
         * caused by constantly updating with times
         */
        public static void SetDoubleBuffered(Control control)
        {
            // set instance non-public property with name "DoubleBuffered" to true
            typeof(Control).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, control, new object[] { true });
        }
        #endregion
        public void addLine()
        {
            DateTime current = DateTime.Now;
            ListViewItem lvi;

            newValues = new int[quest.Quest.Length];
            for (int i = 0; i < quest.Quest.Length; i++)
            {
                newValues[i] = mem.getVal(LBAVer, quest.Quest[i]);
            }

            for (int i =0; i< quest.Quest.Length;i++)
            {
                if(oldValues[i] != newValues[i])
                {
                    lvi = new ListViewItem();
                    lvi.Text = quest.Quest[i].memoryOffset.ToString();
                    lvi.SubItems.Add(quest.Quest[i].name);
                    lvi.SubItems.Add(newValues[i].ToString());
                    lvi.SubItems.Add(timeSpanToString(current - start, false));
                    lvProcesses.Items.Insert(0, lvi);
                    //lvProcesses.Items.Add(lvi);
                }
            }
            /*lvProcesses.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
            lvProcesses.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.ColumnContent);
            lvProcesses.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.HeaderSize);
            lvProcesses.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.HeaderSize);*/

            oldValues = newValues;
        }
        private string timeSpanToString(TimeSpan ts, bool addPlusMinus)
        {
            int precisionDigits = 3;
            
            string posNeg;
            string time = "";
            if (addPlusMinus)
            {
                posNeg = "+";
                if (0 > ts.Ticks)
                {
                    ts = new TimeSpan(ts.Ticks * -1);
                    posNeg = "-";
                }
            }
            else
                posNeg = "";
            if (0 < ts.Hours)
                time += ts.Hours.ToString("0") + ":";
            if (0 < ts.Minutes || 0 != time.Length)
            {
                string s = ts.Minutes.ToString("00");
                //If no hours and less than 10 minutes drop first 0
                if (0 == time.Length && '0' == s.Substring(0, 1)[0])
                    time += s.Substring(1);
                else
                    time += ts.Minutes.ToString("00");
                time += ":";
            }
            if (0 < ts.Seconds || 0 != time.Length)
                time += ts.Seconds.ToString("00");
            if (0 != precisionDigits)
            {
                if (0 != time.Length)
                    time += ".";
                time += ts.Milliseconds.ToString("000").Substring(0, precisionDigits);//ToDo: Need to retrieve all 3 milliseconds then trim as per options
            }
            return posNeg + time;
        }

        private void TmrTime_Tick(object sender, EventArgs e)
        {
            addLine();
            newChapter = mem.readAddress(1, 0xE28, 1);
            if (newChapter != oldChapter)
            {
                oldChapter = newChapter;
                if(chkAnnoyMe.Checked) MessageBox.Show("Chapter: " + newChapter);
                lblChapter.Text = "Chapter: " + newChapter;
            }
        }
    }
}
