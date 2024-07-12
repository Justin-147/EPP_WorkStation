using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TideCall
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string KS = textBox1.Text;
            string JS = textBox2.Text;

            string latitue = textBox3.Text;
            string longitude = textBox4.Text;
            string HH = textBox5.Text;
            string fa1 = textBox9.Text;
            string fa2 = textBox11.Text;
            string dfa = textBox10.Text;
            string tmp;

            System.Collections.ArrayList sj = new System.Collections.ArrayList();
            liuqi.lqTheoryTide.lqSjxl(KS, JS, ref sj);
            int zcd = sj.Count;
            string[] InDate = new string[zcd];
            for (int ii = 0; ii < zcd; ii++)
            {
                InDate[ii] = sj[ii].ToString();
            }

            if (listBox1.SelectedIndex == 0)//计算重力理论固体潮汐值
            {
                double[] ZL;
                ZL = liuqi.lqTheoryTide.lqZLTideC(latitue, longitude, HH, InDate);
                System.IO.StreamWriter Fileout1 = new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\" + "重力.txt", false);
                for (int ii = 0; ii < zcd; ii++)
                {
                    Fileout1.WriteLine(InDate[ii] + ' ' + ZL[ii].ToString());
                }
                Fileout1.Close();
            }
            else if (listBox1.SelectedIndex == 1)//计算南北向及东西向线应变、剪应变的理论固体潮汐值
            {
                double[] stra1, stra2, stra3;
                liuqi.lqTheoryTide.lqLTideC(latitue, longitude, HH, InDate, out stra1, out stra2, out stra3);
                System.IO.StreamWriter Fileout1 = new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\" + "理论应变.txt", false);
                for (int ii = 0; ii < zcd; ii++)
                {
                    Fileout1.WriteLine(InDate[ii] + ' ' + stra1[ii].ToString() + ' ' + stra2[ii].ToString() + ' ' + stra3[ii].ToString());
                }
                Fileout1.Close();
            }
            else if (listBox1.SelectedIndex == 2)//计算面应变的理论固体潮汐值
            {
                double[] Mtide;
                Mtide = liuqi.lqTheoryTide.lqMTideC(latitue, longitude, HH, InDate);
                System.IO.StreamWriter Fileout1 = new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\" + "面应变.txt", false);
                for (int ii = 0; ii < zcd; ii++)
                {
                    Fileout1.WriteLine(InDate[ii] + ' ' + Mtide[ii].ToString());
                }
                Fileout1.Close();
            }
            else if (listBox1.SelectedIndex == 3)//计算体应变的理论固体潮汐值
            {
                double[] Ttide;
                Ttide = liuqi.lqTheoryTide.lqTTideC(latitue, longitude, HH, InDate);
                System.IO.StreamWriter Fileout1 = new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\" + "体应变.txt", false);
                for (int ii = 0; ii < zcd; ii++)
                {
                    Fileout1.WriteLine(InDate[ii] + ' ' + Ttide[ii].ToString());
                }
                Fileout1.Close();
            }

            else if (listBox1.SelectedIndex == 4)//计算一系列方位线应变的理论固体潮汐值
            {
                double[,] DXtide;
                DXtide = liuqi.lqTheoryTide.lqDXTideC(latitue, longitude, HH, fa1, dfa, fa2, InDate);
                System.IO.StreamWriter Fileout1 = new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\" + "多个线应变.txt", false);
                for (int ii = 0; ii < zcd; ii++)
                {
                    tmp = "";
                    for (int jj = 0; jj < DXtide.GetUpperBound(1) + 1; jj++)
                    {
                        tmp = string.Concat(tmp, DXtide[ii, jj].ToString(), " ");
                    }
                    Fileout1.WriteLine(InDate[ii] + ' ' + tmp);
                }
                Fileout1.Close();
            }
            else if (listBox1.SelectedIndex == 5)//计算一系列方位剪应变的理论固体潮汐值
            {
                double[,] DJtide;
                DJtide = liuqi.lqTheoryTide.lqDJTideC(latitue, longitude, HH, fa1, dfa, fa2, InDate);
                System.IO.StreamWriter Fileout1 = new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\" + "多个剪应变.txt", false);
                for (int ii = 0; ii < zcd; ii++)
                {
                    tmp = "";
                    for (int jj = 0; jj < DJtide.GetUpperBound(1) + 1; jj++)
                    {
                        tmp = string.Concat(tmp, DJtide[ii, jj].ToString(), " ");
                    }
                    Fileout1.WriteLine(InDate[ii] + ' ' + tmp);
                }
                Fileout1.Close();
            }
            else if (listBox1.SelectedIndex == 6)//计算理论最大、最小主应变、最大主应变方位、最大剪应变
            {
                double[] zdzyb, zxzyb, zdjyb, fwzd;
                liuqi.lqTheoryTide.lqZTideC(latitue, longitude, HH, InDate, out zdzyb, out zxzyb, out fwzd, out zdjyb);
                System.IO.StreamWriter Fileout1 = new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\" + "主应变.txt", false);
                for (int ii = 0; ii < zcd; ii++)
                {
                    Fileout1.WriteLine(InDate[ii] + ' ' + zdzyb[ii].ToString() + ' ' + zxzyb[ii].ToString() + ' ' + fwzd[ii].ToString() + ' ' + zdjyb[ii].ToString());
                }
                Fileout1.Close();
            }
            else if (listBox1.SelectedIndex == 7)//计算倾斜南北、东西理论固体潮汐值
            {
                double[] NST, EWT;
                liuqi.lqTheoryTide.lqQXTideC(latitue, longitude, HH, InDate, out NST, out EWT);
                System.IO.StreamWriter Fileout1 = new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\" + "倾斜.txt", false);
                for (int ii = 0; ii < zcd; ii++)
                {
                    Fileout1.WriteLine(InDate[ii] + ' ' + NST[ii].ToString()+' '+EWT[ii].ToString());
                }
                Fileout1.Close();        
            }
            else if (listBox1.SelectedIndex == 8)//计算一系列方位倾斜的理论固体潮汐值
            {
                double[,] DQY;
                DQY=liuqi.lqTheoryTide.lqDQXTideC(latitue,longitude,HH,fa1,dfa,fa2,InDate);
                System.IO.StreamWriter Fileout1 = new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\" + "多个倾斜.txt", false);
                for (int ii = 0; ii < zcd; ii++)
                {
                    tmp = "";
                    for (int jj = 0; jj < DQY.GetUpperBound(1) + 1; jj++)
                    {
                        tmp = string.Concat(tmp, DQY[ii, jj].ToString(), " ");
                    }
                    Fileout1.WriteLine(InDate[ii] + ' ' + tmp);
                }
                Fileout1.Close();
            }
            else
                return;        
        }
    }
}