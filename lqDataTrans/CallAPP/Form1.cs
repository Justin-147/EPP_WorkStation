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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {                   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] names;
            string qs = textBox1.Text;
            if (qs.Length == 0)
                qs = "999999";

            OpenFileDialog opendlg1 = new OpenFileDialog();
            opendlg1.Multiselect = true;
            opendlg1.ShowDialog();
            names = opendlg1.FileNames;

            if (names.Length > 0)
            {
                if(radioButton1.Checked==true)
                    liuqi.lqDataTrans.lqDataChi(names, qs);
                else if(radioButton2.Checked==true)
                    liuqi.lqDataTrans.lqDataOuYang(names,qs);
                else if(radioButton3.Checked==true)
                    liuqi.lqDataTrans.lqDataLi(names, qs);                
            }                
            return;         
        }


    }
}