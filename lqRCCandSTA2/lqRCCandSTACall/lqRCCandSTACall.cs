//计算相对标定系数及自检内精度的预处理部分：lqRCCandSTACall
//作者：刘琦
//最后调试时间：2012.04.20
//此代码挑选并检查给定的4路数据中同时段部分，并对4路数据的缺数位置进行统一
//分段后判断每段缺数量是否足够小，之后调用lqRCCandSTA内的方法进行计算，并输出结果
//未判断数据是否有断数（数据观测时间是否连续）
using System;
using System.Collections.Generic;
using System.Text;

namespace liuqi
{
    /// <summary>
    /// 计算相对标定系数及自检内精度的预处理部分
    /// </summary>
    public class lqRCCandSTACall
    {
        
        public static void lqRCCandSTACallF(string[] date1, double[] data1, string[] date2, double[] data2, string[] date3, double[] data3, string[] date4, double[] data4,int chuangchang,int buchang,int weizhi,bool zjjnjd,bool bd,double defaultvalue,string PTT)
        {
            if (zjjnjd == false && bd == false) return;//什么结果都不要？！！直接返回
            if (buchang <= 0||buchang>chuangchang) return;//计算窗长为负、计算窗始终停留在原位置、计算窗间断，这些都不允许
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
            if (FH[0, 0] == -1) return;//没有公共时段直接返回
           
            int len = FH[0,1] - FH[0,0] + 1;//截取的数据长度
            if (len < chuangchang) return;//截取的数据不足一个窗长，则直接返回
            int cs = 0, zcd = 0;
            liuqi.lqCommonUse.lqFdcs(len, chuangchang, buchang, ref cs, ref zcd);//返回循环次数和可计算长度

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
            liuqi.lqCommonUse.lqQsty(ref v1, ref v2, ref v3, ref v4, defaultvalue);//统一缺数位置

            int qsgs;//统计每个窗内缺数的个数
            int xzyxgs;//统计每次循环新增有效个数
            double[] Ktmp=new double[4];//每个窗计算得到的相对标定系数
            double[,] Kall = new double[cs, 4];//所有相对标定系数
            double[] tmp1 = new double[chuangchang]; double[] tmp2 = new double[chuangchang];
            double[] tmp3 = new double[chuangchang]; double[] tmp4 = new double[chuangchang];
            double[] sumed = new double[15];

            ////////////////////////首先都需要计算相对标定系数/////////////////////////
            if (liuqi.lqCommonUse.lqPdyh(cs, chuangchang, buchang)==false)//不必优化
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
                    if (sumed[0] < chuangchang / 2)//如果计算窗内有效个数少于一半，则不计算,结果直接用缺数值表示
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
            else//可优化 ///////////////////////////////////////////////////////////////////////////
            {          
                double[] tmpa1 = new double[buchang]; double[] tmpa2 = new double[buchang];
                double[] tmpa3 = new double[buchang]; double[] tmpa4 = new double[buchang];
                double[] tmpb1 = new double[buchang]; double[] tmpb2 = new double[buchang];
                double[] tmpb3 = new double[buchang]; double[] tmpb4 = new double[buchang];

                ////第一次循环与之后不一样
                qsgs = 0;
                for (int jj = 0; jj < chuangchang; jj++)
                {
                    tmp1[jj] = v1[jj]; tmp2[jj] = v2[jj];
                    tmp3[jj] = v3[jj]; tmp4[jj] = v4[jj];
                    if (tmp1[jj] == defaultvalue) qsgs += 1;
                }
                sumed[0] = chuangchang - qsgs;
                if (sumed[0] < chuangchang / 2)//如果计算窗内有效个数少于一半，则不计算,结果直接用缺数值表示
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
                ////第一次循环与之后不一样               
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
                    if (sumed[0] < chuangchang / 2)//如果计算窗内有效个数少于一半，则不计算,结果直接用缺数值表示
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
            ////////////////////////相对标定系数计算完毕///////////////////////////////
            if(zjjnjd)
            {
                //输出相对标定系数及自检内精度值
                double[] Aall = liuqi.lqRCCandSTA.lqSTA(Kall);//所有自检内精度
                System.IO.StreamWriter Filexsnjd = new System.IO.StreamWriter(PTT + "\\" + "相对标定系数及自检内精度.txt",false);
                for (int ii = 0; ii < cs; ii++)
                {
                    Filexsnjd.WriteLine(date1[FH[0,0] + weizhijia + ii * buchang] + " " + Kall[ii, 0].ToString() + " " + Kall[ii, 1].ToString() + " " + Kall[ii, 2].ToString() + " " + Kall[ii, 3].ToString() + " " + Aall[ii].ToString());
                }
                Filexsnjd.Close();
                if (bd)//同时输出相对标定后的结果
                {
                    double[] qz = new double[zcd];
                    double[] vout1 = new double[zcd];
                    double[] vout2 = new double[zcd];
                    double[] vout3 = new double[zcd];
                    double[] vout4 = new double[zcd];

                    liuqi.lqRCCandSTA.lqRC(v1, v2, v3, v4, Kall, zcd, chuangchang, buchang, cs, defaultvalue, ref vout1, ref vout2, ref vout3, ref vout4, ref qz);

                    System.IO.StreamWriter Fileout1 = new System.IO.StreamWriter(PTT + "\\" + "第1路-相对标定后.txt", false);
                    System.IO.StreamWriter Fileout2 = new System.IO.StreamWriter(PTT + "\\" + "第2路-相对标定后.txt", false);
                    System.IO.StreamWriter Fileout3 = new System.IO.StreamWriter(PTT + "\\" + "第3路-相对标定后.txt", false);
                    System.IO.StreamWriter Fileout4 = new System.IO.StreamWriter(PTT + "\\" + "第4路-相对标定后.txt", false);
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
                //只输出相对标定后的结果
                double[] qz = new double[zcd];
                double[] vout1 = new double[zcd];
                double[] vout2 = new double[zcd];
                double[] vout3 = new double[zcd];
                double[] vout4 = new double[zcd];

                liuqi.lqRCCandSTA.lqRC(v1, v2, v3, v4, Kall, zcd, chuangchang, buchang, cs, defaultvalue, ref vout1, ref vout2, ref vout3, ref vout4, ref qz);

                System.IO.StreamWriter Fileout1 = new System.IO.StreamWriter(PTT + "\\" + "第1路-相对标定后.txt", false);
                System.IO.StreamWriter Fileout2 = new System.IO.StreamWriter(PTT + "\\" + "第2路-相对标定后.txt", false);
                System.IO.StreamWriter Fileout3 = new System.IO.StreamWriter(PTT + "\\" + "第3路-相对标定后.txt", false);
                System.IO.StreamWriter Fileout4 = new System.IO.StreamWriter(PTT + "\\" + "第4路-相对标定后.txt", false);
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
        /// 帮助函数
        /// </summary>
        public static string FunctionHelp()
        {
            string fh = "lqRCCandSTACallF为计算相对标定系数及自检内精度的预处理部分。\r\n"
                + "作者：刘琦。\r\n"
                + "最后调试时间：2012.04.20\r\n"
                + "------------------------------------------------------\r\n"
                + "此代码挑选并检查给定的4路数据中同时段部分，并对4路数据的缺数位置进行统一。\r\n"
                + "分段后判断每段缺数量是否足够小，之后调用lqRCCandSTA内的方法进行计算，并输出结果。\r\n"
                + "未判断数据是否有断数（数据观测时间是否连续）。\r\n";

            return fh;
        }
    }
}
