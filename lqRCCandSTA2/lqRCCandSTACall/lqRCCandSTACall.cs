//������Ա궨ϵ�����Լ��ھ��ȵ�Ԥ�����֣�lqRCCandSTACall
//���ߣ�����
//������ʱ�䣺2012.04.20
//�˴�����ѡ����������4·������ͬʱ�β��֣�����4·���ݵ�ȱ��λ�ý���ͳһ
//�ֶκ��ж�ÿ��ȱ�����Ƿ��㹻С��֮�����lqRCCandSTA�ڵķ������м��㣬��������
//δ�ж������Ƿ��ж��������ݹ۲�ʱ���Ƿ�������
using System;
using System.Collections.Generic;
using System.Text;

namespace liuqi
{
    /// <summary>
    /// ������Ա궨ϵ�����Լ��ھ��ȵ�Ԥ������
    /// </summary>
    public class lqRCCandSTACall
    {
        
        public static void lqRCCandSTACallF(string[] date1, double[] data1, string[] date2, double[] data2, string[] date3, double[] data3, string[] date4, double[] data4,int chuangchang,int buchang,int weizhi,bool zjjnjd,bool bd,double defaultvalue,string PTT)
        {
            if (zjjnjd == false && bd == false) return;//ʲô�������Ҫ������ֱ�ӷ���
            if (buchang <= 0||buchang>chuangchang) return;//���㴰��Ϊ�������㴰ʼ��ͣ����ԭλ�á����㴰��ϣ���Щ��������
            int weizhijia=0;
            if (zjjnjd)
            {
                if (weizhi == 1)
                {
                    weizhijia = chuangchang - 1;
                }
                else if (weizhi == 2)
                {
                    weizhijia = chuangchang / 2;
                }
                else if (weizhi == 0)
                {
                    weizhijia = 0;
                }
                else return;
            }

            int[,] FH = new int[4, 2];
            FH = liuqi.lqCommonUse.lqTxggsd(date1, date2, date3, date4);
            if (FH[0, 0] == -1) return;//û�й���ʱ��ֱ�ӷ���
           
            int len = FH[0,1] - FH[0,0] + 1;//��ȡ�����ݳ���
            if (len < chuangchang) return;//��ȡ�����ݲ���һ����������ֱ�ӷ���
            int cs = 0, zcd = 0;
            liuqi.lqCommonUse.lqFdcs(len, chuangchang, buchang, ref cs, ref zcd);//����ѭ�������Ϳɼ��㳤��

            double[] v1 = new double[zcd]; double[] v2 = new double[zcd];
            double[] v3 = new double[zcd]; double[] v4 = new double[zcd];
            for (int ii = 0; ii < zcd; ii++)
            {
                v1[ii] = data1[FH[0,0] + ii];
                v2[ii] = data2[FH[1,0] + ii];
                v3[ii] = data3[FH[2,0] + ii];
                v4[ii] = data4[FH[3,0] + ii];
            }
            
            data1 = null;                data2 = null;                data3 = null;                data4 = null;
            date2 = null;            date3 = null;            date4 = null;
            liuqi.lqCommonUse.lqQsty(ref v1, ref v2, ref v3, ref v4, defaultvalue);//ͳһȱ��λ��

            int qsgs;//ͳ��ÿ������ȱ���ĸ���
            int xzyxgs;//ͳ��ÿ��ѭ��������Ч����
            double[] Ktmp=new double[4];//ÿ��������õ�����Ա궨ϵ��
            double[,] Kall = new double[cs, 4];//������Ա궨ϵ��
            double[] tmp1 = new double[chuangchang]; double[] tmp2 = new double[chuangchang];
            double[] tmp3 = new double[chuangchang]; double[] tmp4 = new double[chuangchang];
            double[] sumed = new double[15];

            ////////////////////////���ȶ���Ҫ������Ա궨ϵ��/////////////////////////
            if (liuqi.lqCommonUse.lqPdyh(cs, chuangchang, buchang)==false)//�����Ż�
            {                
                for (int ii = 0; ii < cs; ii++)
                {
                    qsgs = 0;
                    for (int jj = 0; jj < chuangchang; jj++)
                    {
                        tmp1[jj] = v1[jj + ii * buchang]; tmp2[jj] = v2[jj + ii * buchang];
                        tmp3[jj] = v3[jj + ii * buchang]; tmp4[jj] = v4[jj + ii * buchang];
                        if (tmp1[jj] == defaultvalue) qsgs += 1;
                    }
                    sumed[0] = chuangchang - qsgs;
                    if (sumed[0] < chuangchang / 2)//������㴰����Ч��������һ�룬�򲻼���,���ֱ����ȱ��ֵ��ʾ
                    {
                        for (int mm = 0; mm < 4; mm++)
                        {
                            Kall[ii, mm] = defaultvalue;
                        }
                    }
                    else
                    {                        
                        Ktmp = liuqi.lqRCCandSTA.lqRCC(tmp1, tmp2, tmp3, tmp4, ref sumed, defaultvalue);
                        for (int mm = 0; mm < 4; mm++)
                        {
                            Kall[ii, mm] = Ktmp[mm];
                        }
                    }
                }
            }
            else//���Ż� ///////////////////////////////////////////////////////////////////////////
            {          
                double[] tmpa1 = new double[buchang]; double[] tmpa2 = new double[buchang];
                double[] tmpa3 = new double[buchang]; double[] tmpa4 = new double[buchang];
                double[] tmpb1 = new double[buchang]; double[] tmpb2 = new double[buchang];
                double[] tmpb3 = new double[buchang]; double[] tmpb4 = new double[buchang];

                ////��һ��ѭ����֮��һ��
                qsgs = 0;
                for (int jj = 0; jj < chuangchang; jj++)
                {
                    tmp1[jj] = v1[jj]; tmp2[jj] = v2[jj];
                    tmp3[jj] = v3[jj]; tmp4[jj] = v4[jj];
                    if (tmp1[jj] == defaultvalue) qsgs += 1;
                }
                sumed[0] = chuangchang - qsgs;
                if (sumed[0] < chuangchang / 2)//������㴰����Ч��������һ�룬�򲻼���,���ֱ����ȱ��ֵ��ʾ
                {
                    for (int mm = 0; mm < 4; mm++)
                    {
                        Kall[0, mm] = defaultvalue;
                    }
                }
                else
                {
                    Ktmp = liuqi.lqRCCandSTA.lqRCC(tmp1, tmp2, tmp3, tmp4, ref sumed, defaultvalue);
                    for (int mm = 0; mm < 4; mm++)
                    {
                        Kall[0, mm] = Ktmp[mm];
                    }
                }
                ////��һ��ѭ����֮��һ��               
                for (int ii = 1; ii < cs; ii++)
                {
                    xzyxgs = 0;
                    for (int jj = 0; jj < buchang; jj++)
                    {
                        tmpa1[jj] = v1[jj + (ii - 1) * buchang];
                        tmpa2[jj] = v2[jj + (ii - 1) * buchang];
                        tmpa3[jj] = v3[jj + (ii - 1) * buchang];
                        tmpa4[jj] = v4[jj + (ii - 1) * buchang];
                        tmpb1[jj] = v1[jj + (ii - 1) * buchang + chuangchang];
                        tmpb2[jj] = v2[jj + (ii - 1) * buchang + chuangchang];
                        tmpb3[jj] = v3[jj + (ii - 1) * buchang + chuangchang];
                        tmpb4[jj] = v4[jj + (ii - 1) * buchang + chuangchang];
                        if (tmpa1[jj] != defaultvalue) xzyxgs -= 1;
                        if (tmpb1[jj] != defaultvalue) xzyxgs += 1;
                    }
                    sumed[0] += xzyxgs;
                    if (sumed[0] < chuangchang / 2)//������㴰����Ч��������һ�룬�򲻼���,���ֱ����ȱ��ֵ��ʾ
                    {
                        for (int mm = 0; mm < 4; mm++)
                        {
                            Kall[ii, mm] = defaultvalue;
                        }
                    }
                    else
                    {
                        Ktmp = liuqi.lqRCCandSTA.lqRCC(tmpa1, tmpb1, tmpa2, tmpb2, tmpa3, tmpb3, tmpa4, tmpb4, defaultvalue, ref sumed);
                        for (int mm = 0; mm < 4; mm++)
                        {
                            Kall[ii, mm] = Ktmp[mm];
                        }
                    }
                }
            }
            ////////////////////////��Ա궨ϵ���������///////////////////////////////
            if(zjjnjd)
            {
                //�����Ա궨ϵ�����Լ��ھ���ֵ
                double[] Aall = liuqi.lqRCCandSTA.lqSTA(Kall);//�����Լ��ھ���
                System.IO.StreamWriter Filexsnjd = new System.IO.StreamWriter(PTT + "\\" + "��Ա궨ϵ�����Լ��ھ���.txt",false);
                for (int ii = 0; ii < cs; ii++)
                {
                    Filexsnjd.WriteLine(date1[FH[0,0] + weizhijia + ii * buchang] + " " + Kall[ii, 0].ToString() + " " + Kall[ii, 1].ToString() + " " + Kall[ii, 2].ToString() + " " + Kall[ii, 3].ToString() + " " + Aall[ii].ToString());
                }
                Filexsnjd.Close();
                if (bd)//ͬʱ�����Ա궨��Ľ��
                {
                    double[] qz = new double[zcd];
                    double[] vout1 = new double[zcd];
                    double[] vout2 = new double[zcd];
                    double[] vout3 = new double[zcd];
                    double[] vout4 = new double[zcd];

                    liuqi.lqRCCandSTA.lqRC(v1, v2, v3, v4, Kall, zcd, chuangchang, buchang, cs, defaultvalue, ref vout1, ref vout2, ref vout3, ref vout4, ref qz);

                    System.IO.StreamWriter Fileout1 = new System.IO.StreamWriter(PTT + "\\" + "��1·-��Ա궨��.txt", false);
                    System.IO.StreamWriter Fileout2 = new System.IO.StreamWriter(PTT + "\\" + "��2·-��Ա궨��.txt", false);
                    System.IO.StreamWriter Fileout3 = new System.IO.StreamWriter(PTT + "\\" + "��3·-��Ա궨��.txt", false);
                    System.IO.StreamWriter Fileout4 = new System.IO.StreamWriter(PTT + "\\" + "��4·-��Ա궨��.txt", false);
                    int wz;
                    for (int ii = 0; ii < zcd; ii++)
                    {
                        wz=FH[0,0]+ii;
                        Fileout1.WriteLine(date1[wz] + " " + (vout1[ii] / qz[ii]).ToString());
                        Fileout2.WriteLine(date1[wz] + " " + (vout2[ii] / qz[ii]).ToString());
                        Fileout3.WriteLine(date1[wz] + " " + (vout3[ii] / qz[ii]).ToString());
                        Fileout4.WriteLine(date1[wz] + " " + (vout4[ii] / qz[ii]).ToString());
                    }
                    Fileout1.Close();
                    Fileout2.Close();
                    Fileout3.Close(); 
                    Fileout4.Close();
                }                
            }
            else
            {
                //ֻ�����Ա궨��Ľ��
                double[] qz = new double[zcd];
                double[] vout1 = new double[zcd];
                double[] vout2 = new double[zcd];
                double[] vout3 = new double[zcd];
                double[] vout4 = new double[zcd];

                liuqi.lqRCCandSTA.lqRC(v1, v2, v3, v4, Kall, zcd, chuangchang, buchang, cs, defaultvalue, ref vout1, ref vout2, ref vout3, ref vout4, ref qz);

                System.IO.StreamWriter Fileout1 = new System.IO.StreamWriter(PTT + "\\" + "��1·-��Ա궨��.txt", false);
                System.IO.StreamWriter Fileout2 = new System.IO.StreamWriter(PTT + "\\" + "��2·-��Ա궨��.txt", false);
                System.IO.StreamWriter Fileout3 = new System.IO.StreamWriter(PTT + "\\" + "��3·-��Ա궨��.txt", false);
                System.IO.StreamWriter Fileout4 = new System.IO.StreamWriter(PTT + "\\" + "��4·-��Ա궨��.txt", false);
                int wz;
                for (int ii = 0; ii < zcd; ii++)
                {
                    wz = FH[0,0] + ii;
                    Fileout1.WriteLine(date1[wz] + " " + (vout1[ii] / qz[ii]).ToString());
                    Fileout2.WriteLine(date1[wz] + " " + (vout2[ii] / qz[ii]).ToString());
                    Fileout3.WriteLine(date1[wz] + " " + (vout3[ii] / qz[ii]).ToString());
                    Fileout4.WriteLine(date1[wz] + " " + (vout4[ii] / qz[ii]).ToString());
                }
                Fileout1.Close();
                Fileout2.Close();
                Fileout3.Close();
                Fileout4.Close();
            }
            return;
        }       
        /////////////////////////////////////////////////////////////
        /// <summary>
        /// ��������
        /// </summary>
        public static string FunctionHelp()
        {
            string fh = "lqRCCandSTACallFΪ������Ա궨ϵ�����Լ��ھ��ȵ�Ԥ�����֡�\r\n"
                + "���ߣ�������\r\n"
                + "������ʱ�䣺2012.04.20\r\n"
                + "------------------------------------------------------\r\n"
                + "�˴�����ѡ����������4·������ͬʱ�β��֣�����4·���ݵ�ȱ��λ�ý���ͳһ��\r\n"
                + "�ֶκ��ж�ÿ��ȱ�����Ƿ��㹻С��֮�����lqRCCandSTA�ڵķ������м��㣬����������\r\n"
                + "δ�ж������Ƿ��ж��������ݹ۲�ʱ���Ƿ���������\r\n";

            return fh;
        }
    }
}
