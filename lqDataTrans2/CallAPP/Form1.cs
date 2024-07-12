using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CallAPP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            string qs = textBox1.Text;
            if (qs.Length == 0)
                qs = "999999";
            FolderBrowserDialog FL = new FolderBrowserDialog();
            FL.Description = "台站数据上层文件夹";
            FL.ShowDialog();
            string PT = FL.SelectedPath;

            string[] PTT;
            string[] names;
            if (PT.Length == 0)
                return;
            PTT = System.IO.Directory.GetDirectories(PT);
            for (int ii = 0; ii < PTT.Length; ii++)
            {
                names = System.IO.Directory.GetFiles(PTT[ii]);
                if (names.Length > 0)
                {
                    liuqi.lqDataTrans.lqDataChi(names, qs,PTT[ii]);
                }
            }
            return;         
        }
    }
}