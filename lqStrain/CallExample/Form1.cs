using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CallExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ///////////////打开文件
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opendlg1 = new OpenFileDialog();
            opendlg1.ShowDialog();
            textBox1.Text = opendlg1.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog opendlg2 = new OpenFileDialog();
            opendlg2.ShowDialog();
            textBox2.Text = opendlg2.FileName;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog opendlg3 = new OpenFileDialog();
            opendlg3.ShowDialog();
            textBox3.Text = opendlg3.FileName;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog opendlg4 = new OpenFileDialog();
            opendlg4.ShowDialog();
            textBox4.Text = opendlg4.FileName;
        }

        ///////////////开始计算
        private void button5_Click(object sender, EventArgs e)
        {
            string Filename1 = textBox1.Text;
            string Filename2 = textBox2.Text;
            string Filename3 = textBox3.Text;
            string Filename4 = textBox4.Text;
            int qsd=0;
            string tmp = null;
            string[] ctmp = null;
            string[] cctmp = null;
            double defaultvalue=double.Parse(textBox12.Text);
            double ffa1 = double.Parse(textBox9.Text);
            double ddfa = double.Parse(textBox10.Text);
            double ffa2 = double.Parse(textBox11.Text);
                        
            //读入第1路数据
            System.IO.StreamReader FirstFile = new System.IO.StreamReader(Filename1);
            tmp = FirstFile.ReadToEnd();
            ctmp = tmp.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            int num1 = ctmp.Length;
            double[] data1 = new double[num1];
            string[] date1 = new string[num1];
            for (int ii = 0; ii < num1; ii++)
            {
                cctmp = ctmp[ii].Split(new string[] { " ","\t","," }, StringSplitOptions.RemoveEmptyEntries);
                //防止空数
                if (cctmp.Length == 1)
                {
                    data1[ii] = defaultvalue;
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
                    data2[ii] = defaultvalue;
                }
                else
                {
                    data2[ii] = double.Parse(cctmp[1]);
                }
                date2[ii] = cctmp[0];
            }
            SecondFile.Close();

            if (radioButton2.Checked||radioButton1.Checked)
            {
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
                        data3[ii] = defaultvalue;
                    }
                    else
                    {
                        data3[ii] = double.Parse(cctmp[1]);
                    }
                    date3[ii] = cctmp[0];
                }
                ThirdFile.Close();

                if (radioButton1.Checked)//四路求解
                {
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
                            data4[ii] = defaultvalue;
                        }
                        else
                        {
                            data4[ii] = double.Parse(cctmp[1]);
                        }
                        date4[ii] = cctmp[0];
                    }
                    FourthFile.Close();

                    int[,] FH ;
                    FH = liuqi.lqCommonUse.lqTxggsd(date1, date2, date3, date4);
                    if (FH[0, 0] == -1) return;//没有公共时段直接返回
                    else
                    {
                        int len = FH[0, 1] - FH[0, 0] + 1;//截取的数据长度
                        double[] s1, s2, s3, s4;
                        s1 = new double[len];
                        s2 = new double[len];
                        s3 = new double[len];
                        s4 = new double[len];

                        for (int jj = 0; jj < len; jj++)
                        {
                            s1[jj] = data1[FH[0, 0] + jj];
                            s2[jj] = data2[FH[1, 0] + jj];
                            s3[jj] = data3[FH[2, 0] + jj];
                            s4[jj] = data4[FH[3, 0] + jj];
                        }
                        liuqi.lqCommonUse.lqQsty(ref s1, ref s2, ref s3, ref s4, defaultvalue);//统一缺数位置

                        for (int mm = 0; mm < len; mm++)
                        {
                            if (s1[mm] != defaultvalue)
                            {
                                qsd = mm;//第1个非空点
                                break;
                            }
                        }
                        double[] ss1 = new double[len - qsd];
                        double[] ss2 = new double[len - qsd];
                        double[] ss3 = new double[len - qsd];
                        double[] ss4 = new double[len - qsd];
                        string[] ddo = new string[len - qsd];

                        for (int nn = 0; nn < len - qsd; nn++)
                        {
                            if (s1[nn + qsd] == defaultvalue)
                            {
                                ss1[nn] = defaultvalue;
                                ss2[nn] = defaultvalue;
                                ss3[nn] = defaultvalue;
                                ss4[nn] = defaultvalue;
                            }
                            else
                            {
                                ss1[nn] = s1[nn + qsd] - s1[qsd];//以第1个非空点为0点起算
                                ss2[nn] = s2[nn + qsd] - s2[qsd];
                                ss3[nn] = s3[nn + qsd] - s3[qsd];
                                ss4[nn] = s4[nn + qsd] - s4[qsd];
                            }
                            ddo[nn] = date1[FH[0, 0] + nn + qsd];
                        }
                        ss1[0] = defaultvalue;//0点不参与计算
                        ss2[0] = defaultvalue;
                        ss3[0] = defaultvalue;
                        ss4[0] = defaultvalue;

                        double fa1 = double.Parse(textBox5.Text);
                        double fa2 = double.Parse(textBox6.Text);
                        double fa3 = double.Parse(textBox7.Text);
                        double fa4 = double.Parse(textBox8.Text);

                        if (listBox1.SelectedIndex == 0)//求解南北、东西线应变和剪应变
                        {
                            double[] stra1, stra2, stra3;//南北应变,东西应变,剪应变
                            liuqi.lqStrainCS.lqStrainCSL(ss1, fa1, ss2, fa2, ss3, fa3, ss4, fa4, defaultvalue, out stra1, out stra2, out stra3);

                            System.IO.StreamWriter Fileout1 = new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\" + "南北-东西-剪.txt", false);
                            int zcd = ddo.Length;
                            for (int ii = 0; ii < zcd; ii++)
                            {
                                Fileout1.WriteLine(ddo[ii] + ' ' + stra1[ii].ToString() + ' ' + stra2[ii].ToString() + ' ' + stra3[ii].ToString());
                            }
                            Fileout1.Close();
                        }
                        else if (listBox1.SelectedIndex == 1)//计算实际最大、最小主应变、最大主应变方位、最大剪应变
                        {
                            double[] ZDzyb, ZXzyb, FXzd, ZDjyb;//最大主应变,最小主应变,最大主应变方位,最大剪应变
                            liuqi.lqStrainCS.lqStrainCSZ(ss1, fa1, ss2, fa2, ss3, fa3, ss4, fa4, defaultvalue, out ZDzyb, out ZXzyb, out FXzd, out ZDjyb);

                            System.IO.StreamWriter Fileout1 = new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\" + "最大最小主应变主方向最大剪应变.txt", false);
                            int zcd = ddo.Length;
                            for (int ii = 0; ii < zcd; ii++)
                            {
                                Fileout1.WriteLine(ddo[ii] + ' ' + ZDzyb[ii].ToString() + ' ' + ZXzyb[ii].ToString() + ' ' + FXzd[ii].ToString() + ' ' + ZDjyb[ii].ToString());
                            }
                            Fileout1.Close();
                        }
                        else if (listBox1.SelectedIndex == 2)//计算一系列方位线应变
                        {
                            double[,] DXtide;//一系列方位线应变
                            DXtide = liuqi.lqStrainCS.lqStrainCSDX(ss1, fa1, ss2, fa2, ss3, fa3, ss4, fa4, ffa1, ddfa, ffa2, defaultvalue);
                            System.IO.StreamWriter Fileout1 = new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\" + "线应变序列.txt", false);
                            int zcd = ddo.Length;
                            for (int ii = 0; ii < zcd; ii++)
                            {
                                tmp = "";
                                for (int jj = 0; jj < DXtide.GetUpperBound(1) + 1; jj++)
                                {
                                    tmp = string.Concat(tmp, DXtide[ii, jj].ToString(), " ");
                                }
                                Fileout1.WriteLine(ddo[ii] + ' ' + tmp);
                            }
                            Fileout1.Close();
                        }
                        else if (listBox1.SelectedIndex == 3)//计算一系列方位剪应变
                        {
                            double[,] DJtide;//一系列方位剪应变
                            DJtide = liuqi.lqStrainCS.lqStrainCSDJ(ss1, fa1, ss2, fa2, ss3, fa3, ss4, fa4, ffa1, ddfa, ffa2, defaultvalue);
                            System.IO.StreamWriter Fileout1 = new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\" + "剪应变序列.txt", false);
                            int zcd = ddo.Length;
                            for (int ii = 0; ii < zcd; ii++)
                            {
                                tmp = "";
                                for (int jj = 0; jj < DJtide.GetUpperBound(1) + 1; jj++)
                                {
                                    tmp = string.Concat(tmp, DJtide[ii, jj].ToString(), " ");
                                }
                                Fileout1.WriteLine(ddo[ii] + ' ' + tmp);
                            }
                            Fileout1.Close();
                        }
                        else if (listBox1.SelectedIndex == 4)//求解面应变
                        {
                            double[] Mtide;//面应变
                            Mtide = liuqi.lqStrainCS.lqStrainCSM(ss1, fa1, ss2, fa2, ss3, fa3, ss4, fa4,defaultvalue);
                            System.IO.StreamWriter Fileout1 = new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\" + "面应变.txt", false);
                            int zcd = ddo.Length;
                            for (int ii = 0; ii < zcd; ii++)
                            {
                                Fileout1.WriteLine(ddo[ii] + ' ' + Mtide[ii].ToString());
                            }
                            Fileout1.Close();
                        }
                        else if (listBox1.SelectedIndex == 5)//求解体应变
                        {
                            double[] Ttide;//体应变
                            Ttide = liuqi.lqStrainCS.lqStrainCST(ss1, fa1, ss2, fa2, ss3, fa3, ss4, fa4, defaultvalue);
                            System.IO.StreamWriter Fileout1 = new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\" + "体应变.txt", false);
                            int zcd = ddo.Length;
                            for (int ii = 0; ii < zcd; ii++)
                            {
                                Fileout1.WriteLine(ddo[ii] + ' ' + Ttide[ii].ToString());
                            }
                            Fileout1.Close();
                        }
                        else return;
                    }
                }
                else//三路求解
                {
                    int[,] FH;
                    FH = liuqi.lqCommonUse.lqTxggsd(date1, date2, date3);
                    if (FH[0, 0] == -1) return;//没有公共时段直接返回
                    else
                    {
                        int len = FH[0, 1] - FH[0, 0] + 1;//截取的数据长度
                        double[] s1, s2, s3;
                        s1 = new double[len];
                        s2 = new double[len];
                        s3 = new double[len];

                        for (int jj = 0; jj < len; jj++)
                        {
                            s1[jj] = data1[FH[0, 0] + jj];
                            s2[jj] = data2[FH[1, 0] + jj];
                            s3[jj] = data3[FH[2, 0] + jj];
                        }
                        liuqi.lqCommonUse.lqQsty(ref s1, ref s2, ref s3, defaultvalue);//统一缺数位置

                        for (int mm = 0; mm < len; mm++)
                        {
                            if (s1[mm] != defaultvalue)
                            {
                                qsd = mm;//第1个非空点
                                break;
                            }
                        }
                        double[] ss1 = new double[len - qsd];
                        double[] ss2 = new double[len - qsd];
                        double[] ss3 = new double[len - qsd];
                        string[] ddo = new string[len - qsd];

                        for (int nn = 0; nn < len - qsd; nn++)
                        {
                            if (s1[nn + qsd] == defaultvalue)
                            {
                                ss1[nn] = defaultvalue;
                                ss2[nn] = defaultvalue;
                                ss3[nn] = defaultvalue;
                            }
                            else
                            {
                                ss1[nn] = s1[nn + qsd] - s1[qsd];//以第1个非空点为0点起算
                                ss2[nn] = s2[nn + qsd] - s2[qsd];
                                ss3[nn] = s3[nn + qsd] - s3[qsd];
                            }
                            ddo[nn] = date1[FH[0, 0] + nn + qsd];
                        }
                        ss1[0] = defaultvalue;//0点不参与计算
                        ss2[0] = defaultvalue;
                        ss3[0] = defaultvalue;

                        double fa1 = double.Parse(textBox5.Text);
                        double fa2 = double.Parse(textBox6.Text);
                        double fa3 = double.Parse(textBox7.Text);

                        if (listBox1.SelectedIndex == 0)//求解南北、东西线应变和剪应变
                        {
                            double[] stra1, stra2, stra3;//南北应变,东西应变,剪应变
                            liuqi.lqStrainCS.lqStrainCSL(ss1, fa1, ss2, fa2, ss3, fa3, defaultvalue, out stra1, out stra2, out stra3);

                            System.IO.StreamWriter Fileout1 = new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\" + "南北-东西-剪.txt", false);
                            int zcd = ddo.Length;
                            for (int ii = 0; ii < zcd; ii++)
                            {
                                Fileout1.WriteLine(ddo[ii] + ' ' + stra1[ii].ToString() + ' ' + stra2[ii].ToString() + ' ' + stra3[ii].ToString());
                            }
                            Fileout1.Close();
                        }
                        else if (listBox1.SelectedIndex == 1)//计算实际最大、最小主应变、最大主应变方位、最大剪应变
                        {
                            double[] ZDzyb, ZXzyb, FXzd, ZDjyb;//最大主应变,最小主应变,最大主应变方位,最大剪应变
                            liuqi.lqStrainCS.lqStrainCSZ(ss1, fa1, ss2, fa2, ss3, fa3, defaultvalue, out ZDzyb, out ZXzyb, out FXzd, out ZDjyb);

                            System.IO.StreamWriter Fileout1 = new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\" + "最大最小主应变主方向最大剪应变.txt", false);
                            int zcd = ddo.Length;
                            for (int ii = 0; ii < zcd; ii++)
                            {
                                Fileout1.WriteLine(ddo[ii] + ' ' + ZDzyb[ii].ToString() + ' ' + ZXzyb[ii].ToString() + ' ' + FXzd[ii].ToString() + ' ' + ZDjyb[ii].ToString());
                            }
                            Fileout1.Close();
                        }
                        else if (listBox1.SelectedIndex == 2)//计算一系列方位线应变
                        {
                            double[,] DXtide;//一系列方位线应变
                            DXtide = liuqi.lqStrainCS.lqStrainCSDX(ss1, fa1, ss2, fa2, ss3, fa3, ffa1, ddfa, ffa2, defaultvalue);
                            System.IO.StreamWriter Fileout1 = new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\" + "线应变序列.txt", false);
                            int zcd = ddo.Length;
                            for (int ii = 0; ii < zcd; ii++)
                            {
                                tmp = "";
                                for (int jj = 0; jj < DXtide.GetUpperBound(1) + 1; jj++)
                                {
                                    tmp = string.Concat(tmp, DXtide[ii, jj].ToString(), " ");
                                }
                                Fileout1.WriteLine(ddo[ii] + ' ' + tmp);
                            }
                            Fileout1.Close();
                        }
                        else if (listBox1.SelectedIndex == 3)//计算一系列方位剪应变
                        {
                            double[,] DJtide;//一系列方位剪应变
                            DJtide = liuqi.lqStrainCS.lqStrainCSDJ(ss1, fa1, ss2, fa2, ss3, fa3, ffa1, ddfa, ffa2, defaultvalue);
                            System.IO.StreamWriter Fileout1 = new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\" + "剪应变序列.txt", false);
                            int zcd = ddo.Length;
                            for (int ii = 0; ii < zcd; ii++)
                            {
                                tmp = "";
                                for (int jj = 0; jj < DJtide.GetUpperBound(1) + 1; jj++)
                                {
                                    tmp = string.Concat(tmp, DJtide[ii, jj].ToString(), " ");
                                }
                                Fileout1.WriteLine(ddo[ii] + ' ' + tmp);
                            }
                            Fileout1.Close();
                        }
                        else if (listBox1.SelectedIndex == 4)//求解面应变
                        {
                            double[] Mtide;//面应变
                            Mtide = liuqi.lqStrainCS.lqStrainCSM(ss1, fa1, ss2, fa2, ss3, fa3, defaultvalue);
                            System.IO.StreamWriter Fileout1 = new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\" + "面应变.txt", false);
                            int zcd = ddo.Length;
                            for (int ii = 0; ii < zcd; ii++)
                            {
                                Fileout1.WriteLine(ddo[ii] + ' ' + Mtide[ii].ToString());
                            }
                            Fileout1.Close();
                        }
                        else if (listBox1.SelectedIndex == 5)//求解体应变
                        {
                            double[] Ttide;//体应变
                            Ttide = liuqi.lqStrainCS.lqStrainCST(ss1, fa1, ss2, fa2, ss3, fa3, defaultvalue);
                            System.IO.StreamWriter Fileout1 = new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\" + "体应变.txt", false);
                            int zcd = ddo.Length;
                            for (int ii = 0; ii < zcd; ii++)
                            {
                                Fileout1.WriteLine(ddo[ii] + ' ' + Ttide[ii].ToString());
                            }
                            Fileout1.Close();
                        }
                        else
                            return;
                    }
                }
            }          
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}