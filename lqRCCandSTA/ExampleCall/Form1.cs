using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//�����򲿷ֽ����𴫵����ݺͲ���
namespace ExampleCall
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(liuqi.lqRCCandSTACall.FunctionHelp());
        }

        private void Choose1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opendlg1 = new OpenFileDialog();
            opendlg1.ShowDialog();
            textBox1.Text = opendlg1.FileName;
        }

        private void Choose2_Click(object sender, EventArgs e)
        {
            OpenFileDialog opendlg2 = new OpenFileDialog();
            opendlg2.ShowDialog();
            textBox2.Text = opendlg2.FileName;
        }

        private void Choose3_Click(object sender, EventArgs e)
        {
            OpenFileDialog opendlg3 = new OpenFileDialog();
            opendlg3.ShowDialog();
            textBox3.Text = opendlg3.FileName;
        }

        private void Choose4_Click(object sender, EventArgs e)
        {
            OpenFileDialog opendlg4 = new OpenFileDialog();
            opendlg4.ShowDialog();
            textBox4.Text = opendlg4.FileName;
        }

        private void StartCompute_Click(object sender, EventArgs e)
        {
            string Filename1 = textBox1.Text;
            string Filename2 = textBox2.Text;
            string Filename3 = textBox3.Text;
            string Filename4 = textBox4.Text;
            string tmp = null;
            string[] ctmp = null;
            string[] cctmp = null;
            //�����1·����
            System.IO.StreamReader FirstFile = new System.IO.StreamReader(Filename1);
            tmp = FirstFile.ReadToEnd();
            ctmp = tmp.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            int num1 = ctmp.Length;
            double[] data1 = new double[num1];
            string[] date1 = new string[num1];
            for (int ii = 0; ii < num1; ii++)
            {
                cctmp = ctmp[ii].Split(new string[] { " ", "\t", "," }, StringSplitOptions.RemoveEmptyEntries);
                //��ֹ����
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
            //�����2·����
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
                //��ֹ����
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
            //�����3·����
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
                //��ֹ����
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
            //�����4·����
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
                //��ֹ����
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

            //��Ա궨���Լ��ھ���
            liuqi.lqRCCandSTACall.lqRCCandSTACallF(date1, data1, date2, data2, date3, data3, date4, data4, int.Parse(ChuangchangDian.Text), int.Parse(HuadongDian.Text), listBox1.SelectedIndex, checkBox1.Checked, checkBox3.Checked, double.Parse(queshu.Text));

            //�Լ���
            if (checkBox2.Checked)
            {
                double[] S13, S24;
                string[] dateg;
                liuqi.lqZJ.lqZJs(date1, data1, date2, data2, date3, data3, date4, data4, double.Parse(queshu.Text), out S13, out S24, out dateg);
                if (dateg.Length != 0)
                {
                    System.IO.StreamWriter Fileout1 = new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\" + "�Լ���.txt", false);
                    int zcd = dateg.Length;
                    for (int ii = 0; ii < zcd; ii++)
                    {
                        Fileout1.WriteLine(dateg[ii] + ' ' + S13[ii].ToString() + ' ' + S24[ii].ToString());
                    }
                    Fileout1.Close();
                }
            }

            //��Ӧ��
            if (checkBox4.Checked)
            {
                double[] C13, C24;
                string[] dateg;
                liuqi.lqZJ.lqZJc(date1, data1, date2, data2, date3, data3, date4, data4, double.Parse(queshu.Text), out C13, out C24, out dateg);
                if (dateg.Length != 0)
                {
                    System.IO.StreamWriter Fileout1 = new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\" + "��Ӧ��.txt", false);
                    int zcd = dateg.Length;
                    for (int ii = 0; ii < zcd; ii++)
                    {
                        Fileout1.WriteLine(dateg[ii] + ' ' + C13[ii].ToString() + ' ' + C24[ii].ToString());
                    }
                    Fileout1.Close();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}