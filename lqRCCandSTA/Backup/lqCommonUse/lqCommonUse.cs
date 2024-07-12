using System;
using System.Collections.Generic;
using System.Text;

namespace liuqi
{
    public class lqCommonUse
    {
        /////////////////////////////////////////////////////////////
        /// <summary>
        /// ��������
        /// </summary>
        public static string FunctionHelp()
        {
            string fh = "���ߣ�����  �����ӡ�����ʱ�䣺2012.05.25\r\n"
                + "�������к�����\r\n"
                + "------------------------------------------------------\r\n"
                + "1.lqQsty�Ĺ���Ϊͳһ��·���ݵ�ȱ��λ�á�\r\n"
                + "2.lqMin�Ĺ���Ϊ���������ݵ���Сֵ��\r\n"
                + "3.lqMax�Ĺ���Ϊ���������ݵ����ֵ��\r\n"
                + "4.lqEqual�Ĺ���Ϊ�ж����������Ƿ���ȡ�\r\n"
                + "5.lqFdcs�Ĺ���Ϊ�������ݳ��ȡ�����������������Ҫ��ѭ�����������㳤�ȡ�\r\n"
                + "6.lqDiff�Ĺ���Ϊ������ֵ��\r\n"
                + "7.lqSum1D�Ĺ���Ϊ�����������,���غ���Ϊ��sumed������+datae-datas��\r\n"
                + "8.lqPdyh�Ĺ���Ϊ�ж��Ƿ�ɲ����Ż��㷨��\r\n"
                + "9.lqTxggsd�Ĺ���Ϊ��ѡ��·ʱ��Ĺ���ʱ�Ρ�\r\n"
                + "10.lqMean1D�Ĺ���Ϊ�����������ֵ��\r\n";            
            
            return fh;
        }



        /////////////////////////////////////////////////////////////
        ///���ܺ�����
        //1///////////////////////////////////////////////////////////
        /// <summary>
        /// ͳһ��·���ݵ�ȱ��λ��
        /// </summary>
        /// <param name="v1">��1·����</param>
        /// <param name="v2">��2·����</param>
        /// <param name="v3">��3·����</param>
        /// <param name="v4">��4·����</param>
        /// <param name="defaultValue">ȱ�����</param>
        /// <returns>�������4·����ͳһ�󷵻�</returns>
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
        /// ���������ݵ���Сֵ
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
        /// ��4���������ݵ����ֵ
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
        /// �ж�4�����������Ƿ����
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
        /// �������ݳ��ȡ�����������������Ҫ��ѭ�����������㳤��
        /// </summary>
        /// <param name="len">���ݳ���</param>
        /// <param name="chuangchang">����</param>
        /// <param name="buchang">����</param>
        /// <param name="cs">ѭ������</param>
        /// <param name="zcd">���㳤��</param>
        public static void lqFdcs(int len, int chuangchang, int buchang, ref int cs, ref int zcd)
        {
            cs = (int)Math.Floor((double)(len - chuangchang) / buchang) + 1;//��Ҫ��ѭ������
            zcd = (cs - 1) * buchang + chuangchang;//��Ҫ������ܳ���,<=len         
        }
        //6///////////////////////////////////////////////////////////
        /// <summary>
        /// ������ֵ
        /// </summary>
        /// <param name="v1">��1·����</param>
        /// <param name="v2">��2·����</param>
        /// <param name="v3">��3·����</param>
        /// <param name="v4">��4·����</param>
        /// <param name="defaultValue">ȱ�����</param>
        /// <param name="out1">��1·���ݲ�ֽ��</param>
        /// <param name="out2">��2·���ݲ�ֽ��</param>
        /// <param name="out3">��3·���ݲ�ֽ��</param>
        /// <param name="out4">��4·���ݲ�ֽ��</param>
        public static void lqDiff(double[] v1, double[] v2, double[] v3, double[] v4, double defaultValue, ref double[] out1, ref double[] out2, ref double[] out3, ref double[] out4)
        {
            int Count = v1.Length - 1;//��ֺ�������1��
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
            int Count = v1.Length - 1;//��ֺ�������1��
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
        /// �����������
        /// </summary>
        public static double lqSum1D(double[] datain, double defaultValue)
        {
            //��һά���������в�����defaultValue��Ԫ�����
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
            //�����в�����defaultValue��Ԫ�ؼ��㣬��sumed������+datae-datas
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
        /// �ж��Ƿ���Բ����Ż��㷨
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
        /// ��ѡ��·ʱ��Ĺ���ʱ��
        /// </summary>
        /// <param name="date1">��1·ʱ��</param>
        /// <param name="date2">��2·ʱ��</param>
        /// <param name="date3">��3·ʱ��</param>
        /// <param name="date4">��4·ʱ��</param>
        /// <returns>[0,0]Ϊ��ѡ�ĵ�һ·��ʼλ�ã�[0,1]Ϊ��ѡ�ĵ�1·����λ��</returns>
        public static int[,] lqTxggsd(string[] date1, string[] date2, string[] date3, string[] date4)
        {
            int len1 = date1.Length; int len2 = date2.Length;
            int len3 = date3.Length; int len4 = date4.Length;
            int [,] FH = new int[4,2];
            
            //ѡȡ��ʼʱ��
            long startdate = liuqi.lqCommonUse.lqMax(long.Parse(date1[0]), long.Parse(date2[0]), long.Parse(date3[0]), long.Parse(date4[0]));
            //ѡȡ����ʱ��
            long enddate = liuqi.lqCommonUse.lqMin(long.Parse(date1[len1 - 1]), long.Parse(date2[len2 - 1]), long.Parse(date3[len3 - 1]), long.Parse(date4[len4 - 1]));
            //�������غ�ʱ����򷵻ش�����-1
            if (enddate < startdate)
            {
                FH[0, 0] = -1;
                return FH;
            }

            //ֻҪ���غϵ�ʱ��Σ���ʹ��·���ݲ��ȳ�Ҳ���Խ�ȡ����
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
                FH[0, 0] = -1;//��ȡ��ͬʱ������ݲ��ȳ������������⣬���ش�����-1
            }
            return FH;                
        }
        public static int[,] lqTxggsd(string[] date1, string[] date2, string[] date3)
        {
            int len1 = date1.Length; int len2 = date2.Length;
            int len3 = date3.Length; 
            int[,] FH = new int[3, 2];

            //ѡȡ��ʼʱ��
            long startdate = liuqi.lqCommonUse.lqMax(long.Parse(date1[0]), long.Parse(date2[0]), long.Parse(date3[0]));
            //ѡȡ����ʱ��
            long enddate = liuqi.lqCommonUse.lqMin(long.Parse(date1[len1 - 1]), long.Parse(date2[len2 - 1]), long.Parse(date3[len3 - 1]));
            //�������غ�ʱ����򷵻ش�����-1
            if (enddate <= startdate)
            {
                FH[0, 0] = -1;
                return FH;
            }

            //ֻҪ���غϵ�ʱ��Σ���ʹ��·���ݲ��ȳ�Ҳ���Խ�ȡ����
            
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
                FH[0, 0] = -1;//��ȡ��ͬʱ������ݲ��ȳ������������⣬���ش�����-1
            }
            return FH;
        }
        public static int[,] lqTxggsd(string[] date1, string[] date2)
        {
            int len1 = date1.Length; int len2 = date2.Length;
            int[,] FH = new int[2, 2];

            //ѡȡ��ʼʱ��
            long startdate = liuqi.lqCommonUse.lqMax(long.Parse(date1[0]), long.Parse(date2[0]));
            //ѡȡ����ʱ��
            long enddate = liuqi.lqCommonUse.lqMin(long.Parse(date1[len1 - 1]), long.Parse(date2[len2 - 1]));
            //�������غ�ʱ����򷵻ش�����-1
            if (enddate <= startdate)
            {
                FH[0, 0] = -1;
                return FH;
            }

            //ֻҪ���غϵ�ʱ��Σ���ʹ��·���ݲ��ȳ�Ҳ���Խ�ȡ����

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
                FH[0, 0] = -1;//��ȡ��ͬʱ������ݲ��ȳ������������⣬���ش�����-1
            }
            return FH;
        }
        //10//////////////////////////////////////////////////////////
        /// <summary>
        /// �����������ֵ
        /// </summary>
        public static double lqMean1D(double[] datain, double defaultValue)
        {
            //��һά���������в�����defaultValue��Ԫ�����ֵ
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
