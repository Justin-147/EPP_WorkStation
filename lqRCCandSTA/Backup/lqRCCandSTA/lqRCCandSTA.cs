//计算相对标定系数及自检内精度的实际操作部分：lqRCCandSTA
//作者：刘琦
//最后调试时间：2012.04.20
//参考文献：
//邱泽华等，《四分量钻孔应变观测的实地相对标定》，大地测量与地球动力学，2005，25（1）
//唐磊等，《钻孔四分量应变观测自检内精度分析》，大地测量与地球动力学，2010，30 Supp.（II）
//此代码内部仅负责给定数据后进行计算
//调用部分需检查挑选给定的4路数据中同时段部分，并对4路数据的缺数位置进行统一，分段后判断每段缺数量是否足够小。
//假定数据没有断数（数据观测时间连续），否则需要先进行预处理。
using System;
using System.Collections.Generic;
using System.Text;

namespace liuqi
{
    /// <summary>
    /// 计算相对标定系数及自检内精度的实际操作部分
    /// </summary>
    public class lqRCCandSTA
    {
        /////////////////////////////////////////////////////////////
        /// <summary>
        /// 帮助函数
        /// </summary>
        public static string FunctionHelp()
        {
            string fh = "作者：刘琦  最后添加、调试时间：2012.04.20\r\n"
                + "参考文献：\r\n"
                + "邱泽华等，《四分量钻孔应变观测的实地相对标定》，大地测量与地球动力学，2005，25（1）。\r\n"
                + "唐磊等，《钻孔四分量应变观测自检内精度分析》，大地测量与地球动力学，2010，30 Supp.（II）,公式8。\r\n"
                + "------------------------------------------------------\r\n"
                + "lqRCC此代码内部仅负责给定数据后进行计算。\r\n"
                + "调用部分需检查挑选给定的4路数据中同时段部分，并对4路数据的缺数位置进行统一，分段后判断每段缺数量是否足够小。\r\n"
                + "假定数据没有断数（数据观测时间连续），否则需要先进行预处理。\r\n"
                + "lqRCC的重载函数为其对应的优化算法，当滑动步长很小、循环次数较多时使用。\r\n"
                + "lqSTA为自检内精度计算，需要以相对标定系数为输入参数。\r\n"
                + "lqRC输出数据进行相对标定后的结果，需要以相对标定系数为输入参数。\r\n";

            return fh;
        }


        
        /////////////////////////////////////////////////////////////
        ///主功能函数区
        /////////////////////////////////////////////////////////////
        /// <summary>
        /// 相对标定系数计算,原始算法
        /// </summary>
        /// <param name="v1">第1路数据</param>
        /// <param name="v2">第2路数据</param>
        /// <param name="v3">第3路数据</param>
        /// <param name="v4">第4路数据</param>
        /// <param name="defaultValue">缺数标记</param>
        /// <returns>返回相对标定系数</returns>
        public static double[] lqRCC(double[] v1,double[]v2,double[]v3,double[]v4,ref double[] sumed, double defaultValue)
        {
            double [,] A=new double[4,4];//存放反演方程左边的系数矩阵
            double [,] B = new double[4,1];//存放反演方程右边的结果项
            double [,] Ktmp = new double[4,1];
            double [] K = new double[4];//按照k1s1+k3s3=k2s2+k4s4+C进行反演，C值不进行返回

            //
            sumed[1] = liuqi.lqCommonUse.lqSum1D(v1, defaultValue);//sum1
            sumed[2] = liuqi.lqCommonUse.lqSum1D(v2, defaultValue);//sum2
            sumed[3] = liuqi.lqCommonUse.lqSum1D(v3, defaultValue);//sum3
            sumed[4] = liuqi.lqCommonUse.lqSum1D(v4, defaultValue);//sum4
            //
            sumed[5] = liuqi.lqCommonUse.lqSum1D(yanwei.ywMatrixOperate.ywMultiply_Point(v1, v1, defaultValue), defaultValue);//sum11
            sumed[6] = liuqi.lqCommonUse.lqSum1D(yanwei.ywMatrixOperate.ywMultiply_Point(v1, v2, defaultValue), defaultValue);//sum12
            sumed[7] = liuqi.lqCommonUse.lqSum1D(yanwei.ywMatrixOperate.ywMultiply_Point(v1, v3, defaultValue), defaultValue);//sum13
            sumed[8] = liuqi.lqCommonUse.lqSum1D(yanwei.ywMatrixOperate.ywMultiply_Point(v1, v4, defaultValue), defaultValue);//sum14
            //
            sumed[9] = liuqi.lqCommonUse.lqSum1D(yanwei.ywMatrixOperate.ywMultiply_Point(v2, v2, defaultValue), defaultValue);//sum22
            sumed[10] = liuqi.lqCommonUse.lqSum1D(yanwei.ywMatrixOperate.ywMultiply_Point(v2, v3, defaultValue), defaultValue);//sum23
            sumed[11] = liuqi.lqCommonUse.lqSum1D(yanwei.ywMatrixOperate.ywMultiply_Point(v2, v4, defaultValue), defaultValue);//sum24
            //
            sumed[12] = liuqi.lqCommonUse.lqSum1D(yanwei.ywMatrixOperate.ywMultiply_Point(v3, v3, defaultValue), defaultValue);//sum33
            sumed[13] = liuqi.lqCommonUse.lqSum1D(yanwei.ywMatrixOperate.ywMultiply_Point(v3, v4, defaultValue), defaultValue);//sum34
            //
            sumed[14] = liuqi.lqCommonUse.lqSum1D(yanwei.ywMatrixOperate.ywMultiply_Point(v4, v4, defaultValue), defaultValue);//sum44

            A[0, 0] = sumed[2];             A[0, 1] = -sumed[3];             A[0, 2] = sumed[4];             A[0, 3] = sumed[0];
            A[1, 0] = sumed[9];             A[1, 1] = -sumed[10];            A[1, 2] = sumed[11];            A[1, 3] = sumed[2];
            A[2, 0] = sumed[10];            A[2, 1] = -sumed[12];            A[2, 2] = sumed[13];            A[2, 3] = sumed[3];
            A[3, 0] = sumed[11];            A[3, 1] = -sumed[13];            A[3, 2] = sumed[14];            A[3, 3] = sumed[4];
            B[0, 0] = sumed[1];             B[1,0] = sumed[6];               B[2,0] = sumed[7];              B[3,0] = sumed[8];
            Ktmp = yanwei.ywMatrixOperate.ywMultiply_Cross(yanwei.ywMatrixOperate.ywInverse(A, defaultValue),B,defaultValue);
            K[0] = 1;                       K[1] = Ktmp[0,0];                K[2] = Ktmp[1,0];               K[3] = Ktmp[2,0];

            A[0, 0] = sumed[1];             A[0, 1] = sumed[3];              A[0, 2] = -sumed[4];            A[0, 3] = -sumed[0];
            A[1, 0] = sumed[5];             A[1, 1] = sumed[7];              A[1, 2] = -sumed[8];            A[1, 3] = -sumed[1];
            A[2, 0] = sumed[7];             A[2, 1] = sumed[12];             A[2, 2] = -sumed[13];           A[2, 3] = -sumed[3];
            A[3, 0] = sumed[8];             A[3, 1] = sumed[13];             A[3, 2] = -sumed[14];           A[3, 3] = -sumed[4];
            B[0, 0] = sumed[2];             B[1, 0] = sumed[6];              B[2, 0] = sumed[10];            B[3, 0] = sumed[11];
            Ktmp = yanwei.ywMatrixOperate.ywMultiply_Cross(yanwei.ywMatrixOperate.ywInverse(A, defaultValue), B, defaultValue);
            K[0] += Ktmp[0,0];              K[1] += 1;                       K[2] += Ktmp[1,0];              K[3] += Ktmp[2,0];

            A[0, 0] = -sumed[1];            A[0, 1] = sumed[2];              A[0, 2] = sumed[4];             A[0, 3] = sumed[0];
            A[1, 0] = -sumed[5];            A[1, 1] = sumed[6];              A[1, 2] = sumed[8];             A[1, 3] = sumed[1];
            A[2, 0] = -sumed[6];            A[2, 1] = sumed[9];              A[2, 2] = sumed[11];            A[2, 3] = sumed[2];
            A[3, 0] = -sumed[8];            A[3, 1] = sumed[11];             A[3, 2] = sumed[14];            A[3, 3] = sumed[4];
            B[0, 0] = sumed[3];             B[1, 0] = sumed[7];              B[2, 0] = sumed[10];            B[3, 0] = sumed[13];
            Ktmp = yanwei.ywMatrixOperate.ywMultiply_Cross(yanwei.ywMatrixOperate.ywInverse(A, defaultValue), B, defaultValue);
            K[0] += Ktmp[0,0];              K[1] += Ktmp[1,0];               K[2] += 1;                      K[3] += Ktmp[2,0];

            A[0, 0] = sumed[1];             A[0, 1] = -sumed[2];             A[0, 2] = sumed[3];             A[0, 3] = -sumed[0];
            A[1, 0] = sumed[5];             A[1, 1] = -sumed[6];             A[1, 2] = sumed[7];             A[1, 3] = -sumed[1];
            A[2, 0] = sumed[6];             A[2, 1] = -sumed[9];             A[2, 2] = sumed[10];            A[2, 3] = -sumed[2];
            A[3, 0] = sumed[7];             A[3, 1] = -sumed[10];            A[3, 2] = sumed[12];            A[3, 3] = -sumed[3];
            B[0, 0] = sumed[4];             B[1, 0] = sumed[8];              B[2, 0] = sumed[11];            B[3, 0] = sumed[13];
            Ktmp = yanwei.ywMatrixOperate.ywMultiply_Cross(yanwei.ywMatrixOperate.ywInverse(A, defaultValue), B, defaultValue);
            K[0] += Ktmp[0,0];              K[1] += Ktmp[1,0];               K[2] += Ktmp[2,0];              K[3] += 1;

            for (int jj = 0; jj < 4; jj++)
            {
                K[jj] = K[jj] / 4;
            }
            return K;
        }
        /// 相对标定系数计算,优化算法
        /// <param name="vs1">该减掉的数据前部</param>
        /// <param name="ve1">该增加的数据后部</param>
        /// <param name="sumed">不必重复计算的结果</param>    
        public static double[] lqRCC(double[] vs1,double[] ve1,double[] vs2,double[] ve2,double[] vs3,double[] ve3,double[] vs4,double[] ve4,double defaultValue,ref double[] sumed)
        {
            double[,] A = new double[4, 4];//存放反演方程左边的系数矩阵
            double[,] B = new double[4, 1];//存放反演方程右边的结果项
            double[,] Ktmp = new double[4, 1];
            double[] K = new double[4];//按照k1s1+k3s3=k2s2+k4s4+C进行反演，C值不进行返回
                        
            //
            sumed[1] = liuqi.lqCommonUse.lqSum1D(vs1, ve1, sumed[1], defaultValue);//sum1
            sumed[2] = liuqi.lqCommonUse.lqSum1D(vs2, ve2, sumed[2], defaultValue);//sum2
            sumed[3] = liuqi.lqCommonUse.lqSum1D(vs3, ve3, sumed[3], defaultValue);//sum3
            sumed[4] = liuqi.lqCommonUse.lqSum1D(vs4, ve4, sumed[4], defaultValue);//sum4            
            //
            sumed[5] = liuqi.lqCommonUse.lqSum1D(yanwei.ywMatrixOperate.ywMultiply_Point(vs1, vs1, defaultValue), yanwei.ywMatrixOperate.ywMultiply_Point(ve1, ve1, defaultValue), sumed[5], defaultValue);//sum11        
            sumed[6] = liuqi.lqCommonUse.lqSum1D(yanwei.ywMatrixOperate.ywMultiply_Point(vs1, vs2, defaultValue), yanwei.ywMatrixOperate.ywMultiply_Point(ve1, ve2, defaultValue), sumed[6], defaultValue);//sum12        
            sumed[7] = liuqi.lqCommonUse.lqSum1D(yanwei.ywMatrixOperate.ywMultiply_Point(vs1, vs3, defaultValue), yanwei.ywMatrixOperate.ywMultiply_Point(ve1, ve3, defaultValue), sumed[7], defaultValue);//sum13
            sumed[8] = liuqi.lqCommonUse.lqSum1D(yanwei.ywMatrixOperate.ywMultiply_Point(vs1, vs4, defaultValue), yanwei.ywMatrixOperate.ywMultiply_Point(ve1, ve4, defaultValue), sumed[8], defaultValue);//sum14        
            //
            sumed[9] = liuqi.lqCommonUse.lqSum1D(yanwei.ywMatrixOperate.ywMultiply_Point(vs2, vs2, defaultValue), yanwei.ywMatrixOperate.ywMultiply_Point(ve2, ve2, defaultValue), sumed[9], defaultValue);//sum22
            sumed[10] = liuqi.lqCommonUse.lqSum1D(yanwei.ywMatrixOperate.ywMultiply_Point(vs2, vs3, defaultValue), yanwei.ywMatrixOperate.ywMultiply_Point(ve2, ve3, defaultValue), sumed[10], defaultValue);//sum23
            sumed[11] = liuqi.lqCommonUse.lqSum1D(yanwei.ywMatrixOperate.ywMultiply_Point(vs2, vs4, defaultValue), yanwei.ywMatrixOperate.ywMultiply_Point(ve2, ve4, defaultValue), sumed[11], defaultValue);//sum24
            //
            sumed[12] = liuqi.lqCommonUse.lqSum1D(yanwei.ywMatrixOperate.ywMultiply_Point(vs3, vs3, defaultValue), yanwei.ywMatrixOperate.ywMultiply_Point(ve3, ve3, defaultValue), sumed[12], defaultValue);//sum33
            sumed[13] = liuqi.lqCommonUse.lqSum1D(yanwei.ywMatrixOperate.ywMultiply_Point(vs3, vs4, defaultValue), yanwei.ywMatrixOperate.ywMultiply_Point(ve3, ve4, defaultValue), sumed[13], defaultValue);//sum34
            //
            sumed[14] = liuqi.lqCommonUse.lqSum1D(yanwei.ywMatrixOperate.ywMultiply_Point(vs4, vs4, defaultValue), yanwei.ywMatrixOperate.ywMultiply_Point(ve4, ve4, defaultValue), sumed[14], defaultValue);//sum44        
            
            A[0, 0] = sumed[2];             A[0, 1] = -sumed[3];             A[0, 2] = sumed[4];             A[0, 3] = sumed[0];
            A[1, 0] = sumed[9];             A[1, 1] = -sumed[10];            A[1, 2] = sumed[11];            A[1, 3] = sumed[2];
            A[2, 0] = sumed[10];            A[2, 1] = -sumed[12];            A[2, 2] = sumed[13];            A[2, 3] = sumed[3];
            A[3, 0] = sumed[11];            A[3, 1] = -sumed[13];            A[3, 2] = sumed[14];            A[3, 3] = sumed[4];
            B[0, 0] = sumed[1];             B[1, 0] = sumed[6];              B[2, 0] = sumed[7];             B[3, 0] = sumed[8];
            Ktmp = yanwei.ywMatrixOperate.ywMultiply_Cross(yanwei.ywMatrixOperate.ywInverse(A, defaultValue), B, defaultValue);
            K[0] = 1;                       K[1] = Ktmp[0, 0];               K[2] = Ktmp[1, 0];              K[3] = Ktmp[2, 0];

            A[0, 0] = sumed[1];             A[0, 1] = sumed[3];              A[0, 2] = -sumed[4];            A[0, 3] = -sumed[0];
            A[1, 0] = sumed[5];             A[1, 1] = sumed[7];              A[1, 2] = -sumed[8];            A[1, 3] = -sumed[1];
            A[2, 0] = sumed[7];             A[2, 1] = sumed[12];             A[2, 2] = -sumed[13];           A[2, 3] = -sumed[3];
            A[3, 0] = sumed[8];             A[3, 1] = sumed[13];             A[3, 2] = -sumed[14];           A[3, 3] = -sumed[4];
            B[0, 0] = sumed[2];             B[1, 0] = sumed[6];              B[2, 0] = sumed[10];            B[3, 0] = sumed[11];
            Ktmp = yanwei.ywMatrixOperate.ywMultiply_Cross(yanwei.ywMatrixOperate.ywInverse(A, defaultValue), B, defaultValue);
            K[0] += Ktmp[0, 0];             K[1] += 1;                       K[2] += Ktmp[1, 0];             K[3] += Ktmp[2, 0];

            A[0, 0] = -sumed[1];            A[0, 1] = sumed[2];              A[0, 2] = sumed[4];             A[0, 3] = sumed[0];
            A[1, 0] = -sumed[5];            A[1, 1] = sumed[6];              A[1, 2] = sumed[8];             A[1, 3] = sumed[1];
            A[2, 0] = -sumed[6];            A[2, 1] = sumed[9];              A[2, 2] = sumed[11];            A[2, 3] = sumed[2];
            A[3, 0] = -sumed[8];            A[3, 1] = sumed[11];             A[3, 2] = sumed[14];            A[3, 3] = sumed[4];
            B[0, 0] = sumed[3];             B[1, 0] = sumed[7];              B[2, 0] = sumed[10];            B[3, 0] = sumed[13];
            Ktmp = yanwei.ywMatrixOperate.ywMultiply_Cross(yanwei.ywMatrixOperate.ywInverse(A, defaultValue), B, defaultValue);
            K[0] += Ktmp[0, 0];             K[1] += Ktmp[1, 0];              K[2] += 1;                      K[3] += Ktmp[2, 0];

            A[0, 0] = sumed[1];             A[0, 1] = -sumed[2];             A[0, 2] = sumed[3];             A[0, 3] = -sumed[0];
            A[1, 0] = sumed[5];             A[1, 1] = -sumed[6];             A[1, 2] = sumed[7];             A[1, 3] = -sumed[1];
            A[2, 0] = sumed[6];             A[2, 1] = -sumed[9];             A[2, 2] = sumed[10];            A[2, 3] = -sumed[2];
            A[3, 0] = sumed[7];             A[3, 1] = -sumed[10];            A[3, 2] = sumed[12];            A[3, 3] = -sumed[3];
            B[0, 0] = sumed[4];             B[1, 0] = sumed[8];              B[2, 0] = sumed[11];            B[3, 0] = sumed[13];
            Ktmp = yanwei.ywMatrixOperate.ywMultiply_Cross(yanwei.ywMatrixOperate.ywInverse(A, defaultValue), B, defaultValue);
            K[0] += Ktmp[0, 0];             K[1] += Ktmp[1, 0];              K[2] += Ktmp[2, 0];             K[3] += 1;

            for (int jj = 0; jj < 4; jj++)
            {
                K[jj] = K[jj] / 4;
            }
            return K;
        }
        /////////////////////////////////////////////////////////////
        /// <summary>
        /// 自检内精度计算
        /// </summary>
        /// <param name="K">相对标定系数</param>
        /// <returns>返回自检内精度</returns>
        public static double lqSTA(double[] K)
        {
            //依据唐磊等，《钻孔四分量应变观测自检内精度分析》，大地测量与地球动力学，2010，30 Supp.（II）中公式8的方法
            double S=0,R=0,tmp,a;
            for (int i = 0; i < 4; i++)
            {
                tmp=K[i]-1;
                S += tmp * tmp;
                R += K[i];
            }
            a = Math.Sqrt(S / 4) / R * 4;
            return a;
        }
        public static double[] lqSTA(double[,] K)
        {
            double S, R , tmp;
            int len = K.GetUpperBound(0) + 1;
            double[] Aall = new double[len];
            for (int j = 0; j < len; j++)
            {
                S = 0;                R = 0;
                for (int i = 0; i < 4; i++)
                {
                    tmp = K[j,i] - 1;
                    S += tmp * tmp;
                    R += K[j,i];
                }
                Aall[j] = Math.Sqrt(S / 4) / R * 4;
            }            
            return Aall;
        } 
        /////////////////////////////////////////////////////////////
        /// <summary>
        /// 进行相对标定
        /// </summary>
        public static void lqRC(double[] v1, double[] v2, double[] v3, double[] v4, double[,] Kall, int zcd, int chuangchang, int buchang, int cs, double defaultValue, ref double[]vout1,ref double[]vout2,ref double[]vout3,ref double[]vout4,ref double[]qz)
        {
            int innn;
            for (int ii = 0; ii < zcd; ii++)//初始化
            {
                qz[ii] = 0;
                vout1[ii] = 0; vout2[ii] = 0; vout3[ii] = 0; vout4[ii] = 0;
            }
            for (int ii = 0; ii < cs; ii++)
            {
                for (int jj = 0; jj < chuangchang; jj++)
                {
                    innn = jj + ii * buchang;
                    if (v1[innn] == defaultValue)
                    {
                        qz[innn] = 1;
                        vout1[innn] = defaultValue; vout2[innn] = defaultValue;
                        vout3[innn] = defaultValue; vout4[innn] = defaultValue;
                    }
                    else
                    {
                        qz[innn] += 1;
                        vout1[innn] += v1[innn] * Kall[ii, 0];
                        vout2[innn] += v2[innn] * Kall[ii, 1];
                        vout3[innn] += v3[innn] * Kall[ii, 2];
                        vout4[innn] += v4[innn] * Kall[ii, 3];
                    }
                }
            }
        }
    }
}
