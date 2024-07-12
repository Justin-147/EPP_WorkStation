//返回自检结果：lqZJ
//作者：刘琦
//最后调试时间：2012.05.25
//此代码挑选并检查给定的4路数据中同时段部分，并对4路数据的缺数位置进行统一
//之后输出结果自检结果
//未判断数据是否有断数（数据观测时间是否连续）
using System;
using System.Collections.Generic;
using System.Text;

namespace liuqi
{
    /// <summary>
    /// 返回自检结果
    /// </summary>
    public class lqZJ
    {
        /// <summary>
        /// 返回计算的自检结果
        /// </summary>
        /// <param name="date1">第1路时间</param>
        /// <param name="data1">第1路数据</param>
        /// <param name="date2">第2路时间</param>
        /// <param name="data2">第2路数据</param>
        /// <param name="date3">第3路时间</param>
        /// <param name="data3">第3路数据</param>
        /// <param name="date4">第4路时间</param>
        /// <param name="data4">第4路数据</param>
        /// <param name="defaultvalue">缺数标记</param>
        /// <param name="S13">1+3面应变</param>
        /// <param name="S24">2+4面应变</param>
        /// <param name="dateg">公共时间段</param>
        public static void lqZJs(string[] date1, double[] data1, string[] date2, double[] data2, string[] date3, double[] data3, string[] date4, double[] data4, double defaultvalue, out double[] S13, out double[] S24, out string[] dateg)
        {
            int[,] FH = new int[4, 2];
            FH = liuqi.lqCommonUse.lqTxggsd(date1, date2, date3, date4);
            if (FH[0, 0] == -1)//没有公共时段
            {
                S13 = new double[0];
                S24 = new double[0];
                dateg = new string[0];
            }
            else
            {
                int len = FH[0, 1] - FH[0, 0] + 1;//截取的数据长度
                S13 = new double[len];
                S24 = new double[len];
                dateg = new string[len];
                double tmp1, tmp2, tmp3, tmp4;

                for (int jj = 0; jj < len; jj++)
                {
                    tmp1 = data1[FH[0, 0] + jj];
                    tmp2 = data2[FH[1, 0] + jj];
                    tmp3 = data3[FH[2, 0] + jj];
                    tmp4 = data4[FH[3, 0] + jj];
                    if (tmp1 == defaultvalue || tmp2 == defaultvalue || tmp3 == defaultvalue || tmp4 == defaultvalue)
                    {
                        S13[jj] = defaultvalue;
                        S24[jj] = defaultvalue;
                    }
                    else
                    {
                        S13[jj] = tmp1 + tmp3;
                        S24[jj] = tmp2 + tmp4;
                    }
                    dateg[jj] = date1[FH[0, 0] + jj];
                }
                double meanC = liuqi.lqCommonUse.lqMean1D(S13, defaultvalue) - liuqi.lqCommonUse.lqMean1D(S24, defaultvalue);
                S24 = yanwei.ywMatrixOperate.ywAdd(S24, meanC, defaultvalue);
            }
        }

        /// <summary>
        /// 返回计算的差应变
        /// </summary>
        /// <param name="date1">第1路时间</param>
        /// <param name="data1">第1路数据</param>
        /// <param name="date2">第2路时间</param>
        /// <param name="data2">第2路数据</param>
        /// <param name="date3">第3路时间</param>
        /// <param name="data3">第3路数据</param>
        /// <param name="date4">第4路时间</param>
        /// <param name="data4">第4路数据</param>
        /// <param name="defaultvalue">缺数标记</param>
        /// <param name="C13">1-3差应变</param>
        /// <param name="C24">2-4差应变</param>
        /// <param name="dateg">公共时间段</param>
        public static void lqZJc(string[] date1, double[] data1, string[] date2, double[] data2, string[] date3, double[] data3, string[] date4, double[] data4, double defaultvalue, out double[] C13, out double[] C24, out string[] dateg)
        {
            int[,] FH = new int[4, 2];
            FH = liuqi.lqCommonUse.lqTxggsd(date1, date2, date3, date4);
            if (FH[0, 0] == -1)//没有公共时段
            {
                C13 = new double[0];
                C24 = new double[0];
                dateg = new string[0];
            }
            else
            {
                int len = FH[0, 1] - FH[0, 0] + 1;//截取的数据长度
                C13 = new double[len];
                C24 = new double[len];
                dateg = new string[len];
                double tmp1, tmp2, tmp3, tmp4;

                for (int jj = 0; jj < len; jj++)
                {
                    tmp1 = data1[FH[0, 0] + jj];
                    tmp2 = data2[FH[1, 0] + jj];
                    tmp3 = data3[FH[2, 0] + jj];
                    tmp4 = data4[FH[3, 0] + jj];
                    if (tmp1 == defaultvalue || tmp2 == defaultvalue || tmp3 == defaultvalue || tmp4 == defaultvalue)
                    {
                        C13[jj] = defaultvalue;
                        C24[jj] = defaultvalue;
                    }
                    else
                    {
                        C13[jj] = tmp1 - tmp3;
                        C24[jj] = tmp2 - tmp4;
                    }
                    dateg[jj] = date1[FH[0, 0] + jj];
                }
                double meanC = liuqi.lqCommonUse.lqMean1D(C13, defaultvalue) - liuqi.lqCommonUse.lqMean1D(C24, defaultvalue);
                C24 = yanwei.ywMatrixOperate.ywAdd(C24, meanC, defaultvalue);
            }

        }
    }

}
