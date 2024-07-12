using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//本程序部分仅负责传递数据和参数
namespace ExampleCall
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void StartCompute_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FL = new FolderBrowserDialog();
            FL.Description = "台站数据上层文件夹";
            FL.ShowDialog();
            string PT = FL.SelectedPath;

            string[] PTT;
            string[] names;
            if (PT.Length == 0)
                return;
            PTT = System.IO.Directory.GetDirectories(PT);
            for (int jj = 0; jj < PTT.Length; jj++)
            {
                names = System.IO.Directory.GetFiles(PTT[jj]);
                if (names.Length ==4)
                {
                    string Filename1 = names[0];
                    string Filename2 = names[1];
                    string Filename3 = names[2];
                    string Filename4 = names[3];
                    string tmp = null;
                    string[] ctmp = null;
                    string[] cctmp = null;
                    //读入第1路数据
                    System.IO.StreamReader FirstFile = new System.IO.StreamReader(Filename1);
                    tmp = FirstFile.ReadToEnd();
                    ctmp = tmp.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                    int num1 = ctmp.Length;
                    double[] data1 = new double[num1];
                    string[] date1 = new string[num1];
                    for (int ii = 0; ii < num1; ii++)
                    {
                        cctmp = ctmp[ii].Split(new string[] { " ", "\t", "," }, StringSplitOptions.RemoveEmptyEntries);
                        //防止空数
                        if (cctmp.Length == 1)
                        {
                            data1[ii] = double.Parse(queshu.Text);
                        }
                        else
                        {
                            data1[ii] = double.Parse(cctmp[1]);
                        }
                        date1[ii] = cctmp[0];
                    }
                    FirstFile.Close();
                    //读入第2路数据
                    tmp = null;
                    ctmp = null;
                    cctmp = null;
                    System.IO.StreamReader SecondFile = new System.IO.StreamReader(Filename2);
                    tmp = SecondFile.ReadToEnd();
                    ctmp = tmp.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                    int num2 = ctmp.Length;
                    double[] data2 = new double[num2];
                    string[] date2 = new string[num2];
                    for (int ii = 0; ii < num2; ii++)
                    {
                        cctmp = ctmp[ii].Split(new string[] { " ", "\t", "," }, StringSplitOptions.RemoveEmptyEntries);
                        //防止空数
                        if (cctmp.Length == 1)
                        {
                            data2[ii] = double.Parse(queshu.Text);
                        }
                        else
                        {
                            data2[ii] = double.Parse(cctmp[1]);
                        }
                        date2[ii] = cctmp[0];
                    }
                    SecondFile.Close();
                    //读入第3路数据
                    tmp = null;
                    ctmp = null;
                    cctmp = null;
                    System.IO.StreamReader ThirdFile = new System.IO.StreamReader(Filename3);
                    tmp = ThirdFile.ReadToEnd();
                    ctmp = tmp.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                    int num3 = ctmp.Length;
                    double[] data3 = new double[num3];
                    string[] date3 = new string[num3];
                    for (int ii = 0; ii < num3; ii++)
                    {
                        cctmp = ctmp[ii].Split(new string[] { " ", "\t", "," }, StringSplitOptions.RemoveEmptyEntries);
                        //防止空数
                        if (cctmp.Length == 1)
                        {
                            data3[ii] = double.Parse(queshu.Text);
                        }
                        else
                        {
                            data3[ii] = double.Parse(cctmp[1]);
                        }
                        date3[ii] = cctmp[0];
                    }
                    ThirdFile.Close();
                    //读入第4路数据
                    tmp = null;
                    ctmp = null;
                    cctmp = null;
                    System.IO.StreamReader FourthFile = new System.IO.StreamReader(Filename4);
                    tmp = FourthFile.ReadToEnd();
                    ctmp = tmp.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                    int num4 = ctmp.Length;
                    double[] data4 = new double[num4];
                    string[] date4 = new string[num4];
                    for (int ii = 0; ii < num4; ii++)
                    {
                        cctmp = ctmp[ii].Split(new string[] { " ", "\t", "," }, StringSplitOptions.RemoveEmptyEntries);
                        //防止空数
                        if (cctmp.Length == 1)
                        {
                            data4[ii] = double.Parse(queshu.Text);
                        }
                        else
                        {
                            data4[ii] = double.Parse(cctmp[1]);
                        }
                        date4[ii] = cctmp[0];
                    }
                    FourthFile.Close();
                    tmp = null;
                    ctmp = null;
                    cctmp = null;

                    //相对标定及自检内精度
                    liuqi.lqRCCandSTACall.lqRCCandSTACallF(date1, data1, date2, data2, date3, data3, date4, data4, int.Parse(ChuangchangDian.Text), int.Parse(HuadongDian.Text), listBox1.SelectedIndex, checkBox1.Checked, checkBox3.Checked, double.Parse(queshu.Text),PTT[jj]);

                    //自检结果
                    if (checkBox2.Checked)
                    {
                        double[] S13, S24;
                        string[] dateg;
                        liuqi.lqZJ.lqZJs(date1, data1, date2, data2, date3, data3, date4, data4, double.Parse(queshu.Text), out S13, out S24, out dateg);
                        if (dateg.Length != 0)
                        {
                            System.IO.StreamWriter Fileout1 = new System.IO.StreamWriter(PTT[jj] + "\\" + "自检结果.txt", false);
                            int zcd = dateg.Length;
                            for (int ii = 0; ii < zcd; ii++)
                            {
                                Fileout1.WriteLine(dateg[ii] + ' ' + S13[ii].ToString() + ' ' + S24[ii].ToString());
                            }
                            Fileout1.Close();
                        }
                    }

                    //差应变
                    if (checkBox4.Checked)
                    {
                        double[] C13, C24;
                        string[] dateg;
                        liuqi.lqZJ.lqZJc(date1, data1, date2, data2, date3, data3, date4, data4, double.Parse(queshu.Text), out C13, out C24, out dateg);
                        if (dateg.Length != 0)
                        {
                            System.IO.StreamWriter Fileout1 = new System.IO.StreamWriter(PTT[jj] + "\\" + "差应变.txt", false);
                            int zcd = dateg.Length;
                            for (int ii = 0; ii < zcd; ii++)
                            {
                                Fileout1.WriteLine(dateg[ii] + ' ' + C13[ii].ToString() + ' ' + C24[ii].ToString());
                            }
                            Fileout1.Close();
                        }
                    }
                }
            }
            return;
        }
    }
}