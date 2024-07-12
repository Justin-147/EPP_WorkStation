using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AppCall
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }       

        private void button1_Click(object sender, EventArgs e)
        {
            string[] names;
            OpenFileDialog opendlg1 = new OpenFileDialog();
            opendlg1.Multiselect = true;
            opendlg1.ShowDialog();
            names = opendlg1.FileNames;
            if (names.Length > 0)
                liuqi.lqSP.lqCqM2H(names);                
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] names;
            OpenFileDialog opendlg1 = new OpenFileDialog();
            opendlg1.Multiselect = true;
            opendlg1.ShowDialog();
            names = opendlg1.FileNames;
            if (names.Length > 0)
                if(textBox1.Text.Length>0)
                    if(textBox2.Text.Length>0)
                liuqi.lqSP.lqThzf(names, textBox1.Text, textBox2.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int sl = listBox1.SelectedIndex;
            string QS = textBox7.Text;
            if (QS.Length == 0)
                QS = "999999";
            if (sl >= 0 && sl <= 2)
            {
                string Fname1,Fname2,Fname3;
                OpenFileDialog opendlg1 = new OpenFileDialog();
                opendlg1.Multiselect = false;
                opendlg1.Title = "选择头部文件";
                opendlg1.ShowDialog();
                Fname1 = opendlg1.FileName;
                OpenFileDialog opendlg2 = new OpenFileDialog();
                opendlg2.Multiselect = false;
                opendlg2.Title = "选择尾部文件";
                opendlg2.ShowDialog();
                Fname2 = opendlg2.FileName;

                if (Fname1.Length > 0)
                {
                    if (Fname2.Length > 0)
                    {
                        Fname3 = AppDomain.CurrentDomain.BaseDirectory + Fname1.Substring(Fname1.LastIndexOf("\\")+1);
                        liuqi.lqSP.lqPjwj(Fname1, Fname2, Fname3, sl,QS);
                    }
                }              

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int sl = listBox1.SelectedIndex;
            string QS = textBox7.Text;
            if (QS.Length == 0)
                QS = "999999";
            if (sl >= 0 && sl <= 2)
            {
                FolderBrowserDialog FL1 = new FolderBrowserDialog();
                FL1.Description = "头部文件所在文件夹";
                FL1.ShowDialog();
                string PT1=FL1.SelectedPath;
                if (PT1.Length > 0)
                {
                    FolderBrowserDialog FL2 = new FolderBrowserDialog();
                    FL2.Description = "尾部文件所在文件夹";
                    FL2.ShowDialog();
                    string PT2 = FL2.SelectedPath;
                    if (PT2.Length > 0)
                    {
                        string[] FN1 = liuqi.lqSP.lqXzwj(PT1);                        
                        string[] FN2 = liuqi.lqSP.lqXzwj(PT2);
                        if (FN1.Length > 0)
                        {
                            if (FN2.Length > 0)
                            {
                                string tmpF1,tmpF2,tmpF3;
                                int czd;
                                System.IO.Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "\\拼接后\\");
                                for (int ii = 0; ii < FN1.Length; ii++)
                                {
                                    tmpF1 = FN1[ii].Substring(PT1.Length+1);
                                    czd = -1;
                                    for (int jj = 0; jj < FN2.Length; jj++)
                                    {
                                        tmpF2 = FN2[jj].Substring(PT2.Length + 1);
                                        if (tmpF2 == tmpF1)
                                        {
                                            czd = jj; break;
                                        }
                                    }
                                    if (czd!=-1)
                                    {
                                        tmpF3=AppDomain.CurrentDomain.BaseDirectory + "\\拼接后\\"+tmpF1;
                                        liuqi.lqSP.lqPjwj(FN1[ii],FN2[czd],tmpF3,sl,QS);
                                    }
                                }
                            }
                        }                        
                    }
                }                
            }            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string[] names;
            OpenFileDialog opendlg1 = new OpenFileDialog();
            opendlg1.Multiselect = true;
            opendlg1.ShowDialog();
            names = opendlg1.FileNames;
            if (names.Length > 0)
                liuqi.lqSP.lqCqDSJ(names);   
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string QS = textBox7.Text;
            string k1,k2,k3,C;
            k1=textBox3.Text;
            k2=textBox5.Text;
            k3=textBox6.Text;
            C=textBox4.Text;
            
            if (QS.Length == 0)
                QS = "999999";
            if (k1.Length == 0)
                k1 = "1";
            if (k2.Length == 0)
                k2 = "0";
            if (k3.Length == 0)
                k1 = "0";
            if (C.Length == 0)
                C = "0";

            string[] names;
            OpenFileDialog opendlg1 = new OpenFileDialog();
            opendlg1.Multiselect = true;
            opendlg1.ShowDialog();
            names = opendlg1.FileNames;
            if (names.Length > 0)
                liuqi.lqSP.lq3cdxs(names,double.Parse(k1),double.Parse(k2),double.Parse(k3),double.Parse(C),QS);   
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string ks,js;
            ks=textBox8.Text;
            js=textBox9.Text;

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
                    liuqi.lqSP.lqJqsj(names, ks, js);
                }
            }
            return;                
        }       
      
    }
}