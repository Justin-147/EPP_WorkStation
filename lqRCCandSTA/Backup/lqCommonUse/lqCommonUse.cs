using System;
using System.Collections.Generic;
using System.Text;

namespace liuqi
{
    public class lqCommonUse
    {
        /////////////////////////////////////////////////////////////
        /// <summary>
        /// 帮助函数
        /// </summary>
        public static string FunctionHelp()
        {
            string fh = "作者：刘琦  最后添加、调试时间：2012.05.25\r\n"
                + "包含下列函数：\r\n"
                + "------------------------------------------------------\r\n"
                + "1.lqQsty的功能为统一几路数据的缺数位置。\r\n"
                + "2.lqMin的功能为求输入数据的最小值。\r\n"
                + "3.lqMax的功能为求输入数据的最大值。\r\n"
                + "4.lqEqual的功能为判断输入数据是否相等。\r\n"
                + "5.lqFdcs的功能为根据数据长度、窗长、步长返回需要的循环次数及可算长度。\r\n"
                + "6.lqDiff的功能为计算差分值。\r\n"
                + "7.lqSum1D的功能为输入数据求和,重载函数为在sumed基础上+datae-datas。\r\n"
                + "8.lqPdyh的功能为判断是否可采用优化算法。\r\n"
                + "9.lqTxggsd的功能为挑选几路时间的公共时段。\r\n"
                + "10.lqMean1D的功能为输入数据求均值。\r\n";            
            
            return fh;
        }



        /////////////////////////////////////////////////////////////
        ///功能函数区
        //1///////////////////////////////////////////////////////////
        /// <summary>
        /// 统一几路数据的缺数位置
        /// </summary>
        /// <param name="v1">第1路数据</param>
        /// <param name="v2">第2路数据</param>
        /// <param name="v3">第3路数据</param>
        /// <param name="v4">第4路数据</param>
        /// <param name="defaultValue">缺数标记</param>
        /// <returns>对输入的4路数据统一后返回</returns>
        public static void lqQsty(ref double[] v1, ref double[] v2, ref double[] v3, ref double[] v4, double defaultValue)
        {
            for (int i = 0; i < v1.Length; i++)
            {
                if (v1[i] == defaultValue || v2[i] == defaultValue || v3[i] == defaultValue || v4[i] == defaultValue)
                {
                    v1[i] = defaultValue;
                    v2[i] = defaultValue;
                    v3[i] = defaultValue;
                    v4[i] = defaultValue;
                }
            }
            return;
        }
        public static void lqQsty(ref double[] v1, ref double[] v2, ref double[] v3, double defaultValue)
        {
            for (int i = 0; i < v1.Length; i++)
            {
                if (v1[i] == defaultValue || v2[i] == defaultValue || v3[i] == defaultValue )
                {
                    v1[i] = defaultValue;
                    v2[i] = defaultValue;
                    v3[i] = defaultValue;
                }
            }
            return;
        }
        public static void lqQsty(ref double[] v1, ref double[] v2, double defaultValue)
        {
            for (int i = 0; i < v1.Length; i++)
            {
                if (v1[i] == defaultValue || v2[i] == defaultValue)
                {
                    v1[i] = defaultValue;
                    v2[i] = defaultValue;
                }
            }
            return;
        }
        //2///////////////////////////////////////////////////////////
        /// <summary>
        /// 求输入数据的最小值
        /// </summary>
        public static long lqMin(long a, long b, long c, long d)
        {
            long oo = a;
            if (b < oo) oo = b;
            if (c < oo) oo = c;
            if (d < oo) oo = d;
            return oo;
        }
        public static long lqMin(long a, long b, long c)
        {
            long oo = a;
            if (b < oo) oo = b;
            if (c < oo) oo = c;            
            return oo;
        }
        public static long lqMin(long a, long b)
        {
            long oo = a;
            if (b < oo) oo = b;
            return oo;
        }
        public static int lqMin(int a, int b, int c, int d)
        {
            int oo = a;
            if (b < oo) oo = b;
            if (c < oo) oo = c;
            if (d < oo) oo = d;
            return oo;
        }
        public static int lqMin(int a, int b, int c)
        {
            int oo = a;
            if (b < oo) oo = b;
            if (c < oo) oo = c;
            return oo;
        }
        public static int lqMin(int a, int b)
        {
            int oo = a;
            if (b < oo) oo = b;
            return oo;
        }        
        public static double lqMin(double a, double b, double c, double d)
        {
            double oo = a;
            if (b < oo) oo = b;
            if (c < oo) oo = c;
            if (d < oo) oo = d;
            return oo;
        }
        public static double lqMin(double a, double b, double c)
        {
            double oo = a;
            if (b < oo) oo = b;
            if (c < oo) oo = c;
            return oo;
        }
        public static double lqMin(double a, double b)
        {
            double oo = a;
            if (b < oo) oo = b;
            return oo;
        }
        //3///////////////////////////////////////////////////////////
        /// <summary>
        /// 求4个输入数据的最大值
        /// </summary>
        public static long lqMax(long a, long b, long c, long d)
        {
            long oo = a;
            if (b > oo) oo = b;
            if (c > oo) oo = c;
            if (d > oo) oo = d;
            return oo;
        }
        public static long lqMax(long a, long b, long c)
        {
            long oo = a;
            if (b > oo) oo = b;
            if (c > oo) oo = c;
            return oo;
        }
        public static long lqMax(long a, long b)
        {
            long oo = a;
            if (b > oo) oo = b;
            return oo;
        }
        public static int lqMax(int a, int b, int c, int d)
        {
            int oo = a;
            if (b > oo) oo = b;
            if (c > oo) oo = c;
            if (d > oo) oo = d;
            return oo;
        }
        public static int lqMax(int a, int b, int c)
        {
            int oo = a;
            if (b > oo) oo = b;
            if (c > oo) oo = c;
            return oo;
        }
        public static int lqMax(int a, int b)
        {
            int oo = a;
            if (b > oo) oo = b;
            return oo;
        }
        public static double lqMax(double a, double b, double c, double d)
        {
            double oo = a;
            if (b > oo) oo = b;
            if (c > oo) oo = c;
            if (d > oo) oo = d;
            return oo;
        }
        public static double lqMax(double a, double b, double c)
        {
            double oo = a;
            if (b > oo) oo = b;
            if (c > oo) oo = c;
            return oo;
        }
        public static double lqMax(double a, double b)
        {
            double oo = a;
            if (b > oo) oo = b;
            return oo;
        }
        //4///////////////////////////////////////////////////////////
        /// <summary>
        /// 判断4个输入数据是否相等
        /// </summary>
        public static bool lqEqual(int a, int b, int c, int d)
        {
            if (a == b)
            {
                if (b == c)
                {
                    if (c == d)
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }
            else
                return false;
        }
        public static bool lqEqual(int a, int b, int c)
        {
            if (a == b)
            {
                if (b == c)
                    return true;                  
                else
                    return false;
            }
            else
                return false;
        }
        public static bool lqEqual(int a, int b)
        {
            if (a == b)
                return true;
            else
                return false;           
        }
        public static bool lqEqual(long a, long b, long c, long d)
        {
            if (a == b)
            {
                if (b == c)
                {
                    if (c == d)
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }
            else
                return false;
        }
        public static bool lqEqual(long a, long b, long c)
        {
            if (a == b)
            {
                if (b == c)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
        public static bool lqEqual(long a, long b)
        {
            if (a == b)
                return true;
            else
                return false;
        }
        public static bool lqEqual(double a, double b, double c, double d)
        {
            if (a == b)
            {
                if (b == c)
                {
                    if (c == d)
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }
            else
                return false;
        }
        public static bool lqEqual(double a, double b, double c)
        {
            if (a == b)
            {
                if (b == c)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
        public static bool lqEqual(double a, double b)
        {
            if (a == b)
                return true;
            else
                return false;
        }
        //5///////////////////////////////////////////////////////////
        /// <summary>
        /// 根据数据长度、窗长、步长返回需要的循环次数及可算长度
        /// </summary>
        /// <param name="len">数据长度</param>
        /// <param name="chuangchang">窗长</param>
        /// <param name="buchang">步长</param>
        /// <param name="cs">循环次数</param>
        /// <param name="zcd">可算长度</param>
        public static void lqFdcs(int len, int chuangchang, int buchang, ref int cs, ref int zcd)
        {
            cs = (int)Math.Floor((double)(len - chuangchang) / buchang) + 1;//需要的循环次数
            zcd = (cs - 1) * buchang + chuangchang;//需要处理的总长度,<=len         
        }
        //6///////////////////////////////////////////////////////////
        /// <summary>
        /// 计算差分值
        /// </summary>
        /// <param name="v1">第1路数据</param>
        /// <param name="v2">第2路数据</param>
        /// <param name="v3">第3路数据</param>
        /// <param name="v4">第4路数据</param>
        /// <param name="defaultValue">缺数标记</param>
        /// <param name="out1">第1路数据差分结果</param>
        /// <param name="out2">第2路数据差分结果</param>
        /// <param name="out3">第3路数据差分结果</param>
        /// <param name="out4">第4路数据差分结果</param>
        public static void lqDiff(double[] v1, double[] v2, double[] v3, double[] v4, double defaultValue, ref double[] out1, ref double[] out2, ref double[] out3, ref double[] out4)
        {
            int Count = v1.Length - 1;//差分后数据少1行
            for (int i = 0; i < Count; i++)
            {
                if (v1[i] != defaultValue && v1[i + 1] != defaultValue)
                {
                    out1[i] = v1[i + 1] - v1[i];
                    out2[i] = v2[i + 1] - v2[i];
                    out3[i] = v3[i + 1] - v3[i];
                    out4[i] = v4[i + 1] - v4[i];
                }
                else
                {
                    out1[i] = defaultValue;
                    out2[i] = defaultValue;
                    out3[i] = defaultValue;
                    out4[i] = defaultValue;
                }
            }
            return;
        }
        public static void lqDiff(double[] v1, double defaultValue, ref double[] out1)
        {
            int Count = v1.Length - 1;//差分后数据少1行
            for (int i = 0; i < Count; i++)
            {
                if (v1[i] != defaultValue && v1[i + 1] != defaultValue)
                {
                    out1[i] = v1[i + 1] - v1[i];
                }
                else
                {
                    out1[i] = defaultValue;
                }
            }
            return;
        }
        //7///////////////////////////////////////////////////////////
        /// <summary>
        /// 输入数据求和
        /// </summary>
        public static double lqSum1D(double[] datain, double defaultValue)
        {
            //对一维数组内所有不等于defaultValue的元素求和
            double sumout = 0;
            for (int i = 0; i < datain.Length; i++)
            {
                if (datain[i] != defaultValue)
                {
                    sumout += datain[i];
                }
            }
            return sumout;
        }
        public static double lqSum1D(double[] datas, double[] datae, double sumed, double defaultValue)
        {
            //对所有不等于defaultValue的元素计算，在sumed基础上+datae-datas
            double sumout = sumed;
            for (int i = 0; i < datas.Length; i++)
            {
                if (datas[i] != defaultValue)
                {
                    sumout -= datas[i];
                }
            }
            for (int i = 0; i < datae.Length; i++)
            {
                if (datae[i] != defaultValue)
                {
                    sumout += datae[i];
                }
            }
            return sumout;
        }
        //8///////////////////////////////////////////////////////////
        /// <summary>
        /// 判断是否可以采用优化算法
        /// </summary>
        public static bool lqPdyh(int cs,int chuangchang,int buchang)
        {
            bool outpd=false;
            if (cs >= 2)
            {
                if (2 * buchang < chuangchang - 1) outpd = true;
            }
            return outpd;
        }
        //9///////////////////////////////////////////////////////////
        /// <summary>
        /// 挑选几路时间的公共时段
        /// </summary>
        /// <param name="date1">第1路时间</param>
        /// <param name="date2">第2路时间</param>
        /// <param name="date3">第3路时间</param>
        /// <param name="date4">第4路时间</param>
        /// <returns>[0,0]为挑选的第一路开始位置，[0,1]为挑选的第1路结束位置</returns>
        public static int[,] lqTxggsd(string[] date1, string[] date2, string[] date3, string[] date4)
        {
            int len1 = date1.Length; int len2 = date2.Length;
            int len3 = date3.Length; int len4 = date4.Length;
            int [,] FH = new int[4,2];
            
            //选取开始时间
            long startdate = liuqi.lqCommonUse.lqMax(long.Parse(date1[0]), long.Parse(date2[0]), long.Parse(date3[0]), long.Parse(date4[0]));
            //选取结束时间
            long enddate = liuqi.lqCommonUse.lqMin(long.Parse(date1[len1 - 1]), long.Parse(date2[len2 - 1]), long.Parse(date3[len3 - 1]), long.Parse(date4[len4 - 1]));
            //不存在重合时间段则返回错误标记-1
            if (enddate < startdate)
            {
                FH[0, 0] = -1;
                return FH;
            }

            //只要有重合的时间段，即使几路数据不等长也可以截取出来
            //int is1 = 0, ie1 = 0, is2 = 0, ie2 = 0, is3 = 0, ie3 = 0, is4 = 0, ie4 = 0;

            for (int ii = 0; ii < len1; ii++)
            {
                if (long.Parse(date1[ii]) == startdate) FH[0,0] = ii;
                if (long.Parse(date1[len1 - ii - 1]) == enddate) FH[0,1] = len1 - ii - 1;
            }
            for (int ii = 0; ii < len2; ii++)
            {
                if (long.Parse(date2[ii]) == startdate) FH[1,0] = ii;
                if (long.Parse(date2[len2 - ii - 1]) == enddate) FH[1,1] = len2 - ii - 1;
            }
            for (int ii = 0; ii < len3; ii++)
            {
                if (long.Parse(date3[ii]) == startdate) FH[2,0] = ii;
                if (long.Parse(date3[len3 - ii - 1]) == enddate) FH[2,1] = len3 - ii - 1;
            }
            for (int ii = 0; ii < len4; ii++)
            {
                if (long.Parse(date4[ii]) == startdate) FH[3,0] = ii;
                if (long.Parse(date4[len4 - ii - 1]) == enddate) FH[3,1] = len4 - ii - 1;
            }
            if (liuqi.lqCommonUse.lqEqual(FH[0, 1] - FH[0, 0], FH[1, 1] - FH[1, 0], FH[2, 1] - FH[2, 0], FH[3, 1] - FH[3, 0]) == false)
            {
                FH[0, 0] = -1;//截取的同时间段数据不等长，数据有问题，返回错误标记-1
            }
            return FH;                
        }
        public static int[,] lqTxggsd(string[] date1, string[] date2, string[] date3)
        {
            int len1 = date1.Length; int len2 = date2.Length;
            int len3 = date3.Length; 
            int[,] FH = new int[3, 2];

            //选取开始时间
            long startdate = liuqi.lqCommonUse.lqMax(long.Parse(date1[0]), long.Parse(date2[0]), long.Parse(date3[0]));
            //选取结束时间
            long enddate = liuqi.lqCommonUse.lqMin(long.Parse(date1[len1 - 1]), long.Parse(date2[len2 - 1]), long.Parse(date3[len3 - 1]));
            //不存在重合时间段则返回错误标记-1
            if (enddate <= startdate)
            {
                FH[0, 0] = -1;
                return FH;
            }

            //只要有重合的时间段，即使几路数据不等长也可以截取出来
            
            for (int ii = 0; ii < len1; ii++)
            {
                if (long.Parse(date1[ii]) == startdate) FH[0, 0] = ii;
                if (long.Parse(date1[len1 - ii - 1]) == enddate) FH[0, 1] = len1 - ii - 1;
            }
            for (int ii = 0; ii < len2; ii++)
            {
                if (long.Parse(date2[ii]) == startdate) FH[1, 0] = ii;
                if (long.Parse(date2[len2 - ii - 1]) == enddate) FH[1, 1] = len2 - ii - 1;
            }
            for (int ii = 0; ii < len3; ii++)
            {
                if (long.Parse(date3[ii]) == startdate) FH[2, 0] = ii;
                if (long.Parse(date3[len3 - ii - 1]) == enddate) FH[2, 1] = len3 - ii - 1;
            }
            if (liuqi.lqCommonUse.lqEqual(FH[0, 1] - FH[0, 0], FH[1, 1] - FH[1, 0], FH[2, 1] - FH[2, 0]) == false)
            {
                FH[0, 0] = -1;//截取的同时间段数据不等长，数据有问题，返回错误标记-1
            }
            return FH;
        }
        public static int[,] lqTxggsd(string[] date1, string[] date2)
        {
            int len1 = date1.Length; int len2 = date2.Length;
            int[,] FH = new int[2, 2];

            //选取开始时间
            long startdate = liuqi.lqCommonUse.lqMax(long.Parse(date1[0]), long.Parse(date2[0]));
            //选取结束时间
            long enddate = liuqi.lqCommonUse.lqMin(long.Parse(date1[len1 - 1]), long.Parse(date2[len2 - 1]));
            //不存在重合时间段则返回错误标记-1
            if (enddate <= startdate)
            {
                FH[0, 0] = -1;
                return FH;
            }

            //只要有重合的时间段，即使几路数据不等长也可以截取出来

            for (int ii = 0; ii < len1; ii++)
            {
                if (long.Parse(date1[ii]) == startdate) FH[0, 0] = ii;
                if (long.Parse(date1[len1 - ii - 1]) == enddate) FH[0, 1] = len1 - ii - 1;
            }
            for (int ii = 0; ii < len2; ii++)
            {
                if (long.Parse(date2[ii]) == startdate) FH[1, 0] = ii;
                if (long.Parse(date2[len2 - ii - 1]) == enddate) FH[1, 1] = len2 - ii - 1;
            }
            if (liuqi.lqCommonUse.lqEqual(FH[0, 1] - FH[0, 0], FH[1, 1] - FH[1, 0]) == false)
            {
                FH[0, 0] = -1;//截取的同时间段数据不等长，数据有问题，返回错误标记-1
            }
            return FH;
        }
        //10//////////////////////////////////////////////////////////
        /// <summary>
        /// 输入数据求均值
        /// </summary>
        public static double lqMean1D(double[] datain, double defaultValue)
        {
            //对一维数组内所有不等于defaultValue的元素求均值
            double sumout = 0;
            int js = 0;
            for (int i = 0; i < datain.Length; i++)
            {
                if (datain[i] != defaultValue)
                {
                    sumout += datain[i];
                    js = js + 1;
                }
            }
            return sumout/js;
        }


    }
}
