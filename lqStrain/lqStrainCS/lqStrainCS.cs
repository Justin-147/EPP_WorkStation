//利用观测值求解应变参数
//作者：刘琦
//最后调试时间：2012.05.24
//参考文献：
//郗钦文等，《固体潮汐与引潮参数》、《精密引潮位展开及某些诠释》、《新的引潮位完全展开》、《固体潮汐理论值计算》
//蒋骏等，《地表潮汐线应变组合观测的信息提取方法》、《潮汐线应变观测的地表平面应变状态》
using System;
using System.Collections.Generic;
using System.Text;

namespace liuqi
{
    /// <summary>
    /// 利用观测值求解应变参数
    /// </summary>
    public class lqStrainCS
    {
        /////////////////////////////////////////////////////////////
        /// <summary>
        /// 帮助函数
        /// </summary>
        public static string FunctionHelp()
        {
            string fh = "作者：刘琦  最后添加、调试时间：2012.05.24\r\n"
                + "参考文献：\r\n"
                + "郗钦文等，《固体潮汐与引潮参数》、《精密引潮位展开及某些诠释》、《新的引潮位完全展开》、《固体潮汐理论值计算》。\r\n"
                + "蒋骏等，《地表潮汐线应变组合观测的信息提取方法》、《潮汐线应变观测的地表平面应变状态》。\r\n"
                + "------------------------------------------------------\r\n"
                + "lqStrainCSL依据几组线应变观测求解南北、东西线应变和剪应变。\r\n"
                + "lqStrainCSZ依据几组线应变观测计算实际最大、最小主应变、最大主应变方位、最大剪应变。\r\n"
                + "lqStrainCSX依据几组线应变观测计算任意方向线应变。\r\n"
                + "lqStrainCSJ依据几组线应变观测计算任意方向剪应变。\r\n"
                + "lqStrainCSDX依据几组线应变观测计算一系列方位线应变。\r\n"
                + "lqStrainCSDJ依据几组线应变观测计算一系列方位剪应变。\r\n"
                + "lqStrainCSM依据几组线应变观测计算面应变。\r\n"
                + "lqStrainCST依据几组线应变观测计算体应变。\r\n"  
                + "lqStrainL2Z由南北、东西线应变及剪应变计算实际最大、最小主应变、最大主应变方位、最大剪应变。\r\n"
                + "lqStrainL2X由南北、东西线应变及剪应变计算任意方向线应变。\r\n"
                + "lqStrainL2J由南北、东西线应变及剪应变计算任意剪应变。\r\n"
                + "lqStrainL2DX由南北、东西线应变及剪应变计算一系列方位线应变。\r\n"
                + "lqStrainL2DJ由南北、东西线应变及剪应变计算一系列方位剪应变。\r\n"
                + "lqStrainL2M由南北、东西线应变计算面应变。\r\n"
                + "lqStrainL2T由南北、东西线应变计算体应变。\r\n";

            return fh;
        }

        /////////////////////////////////////////////////////////////
        ///主功能函数区
        /////////////////////////////////////////////////////////////
        /// <summary>
        /// 依据几组线应变观测求解南北、东西线应变和剪应变
        /// </summary>
        /// <param name="s1">第1路线应变</param>
        /// <param name="fa1">第1路方位角</param>
        /// <param name="s2">第2路线应变</param>
        /// <param name="fa2">第2路方位角</param>
        /// <param name="s3">第3路线应变</param>
        /// <param name="fa3">第3路方位角</param>
        /// <param name="defaultvalue">缺数标记</param>
        /// <param name="stra1">南北线应变</param>
        /// <param name="stra2">东西线应变</param>
        /// <param name="stra3">剪应变</param>
        public static void lqStrainCSL(double[] s1,double fa1, double[] s2,double fa2, double[] s3,double fa3,double defaultvalue,out double[]stra1,out double[]stra2,out double[]stra3)
        {
            double[,] A = new double[3, 3];
            double[] fa=new double[3];
            fa[0] = fa1 * Math.PI / 180;
            fa[1] = fa2 * Math.PI / 180;
            fa[2] = fa3 * Math.PI / 180;
            double[,] B = new double[3, 1];
            double[,] Etmp = new double[3, 1];
            stra1 = new double[s1.Length];//南北线应变
            stra2 = new double[s1.Length];//东西线应变
            stra3 = new double[s1.Length];//剪应变
                       
            for (int ii = 0; ii < 3; ii++)//共用的系数矩阵，不改变
            {
                A[ii, 0] =Math.Pow(Math.Cos(fa[ii]),2);
                A[ii, 1] = Math.Pow(Math.Sin(fa[ii]),2);
                A[ii, 2] = -Math.Sin(2*fa[ii]);
            }

            for (int jj = 0; jj < s1.Length; jj++)
            {
                if (s1[jj] == defaultvalue || s2[jj] == defaultvalue || s3[jj] == defaultvalue )
                {
                    stra1[jj] = defaultvalue;
                    stra2[jj] = defaultvalue;
                    stra3[jj] = defaultvalue;
                }
                else
                {
                    B[0,0] = s1[jj]; B[1,0] = s2[jj]; B[2,0] = s3[jj];
                    Etmp = yanwei.ywMatrixOperate.ywMultiply_Cross(yanwei.ywMatrixOperate.ywInverse(A, defaultvalue), B, defaultvalue);
                    stra1[jj] = Etmp[0,0];
                    stra2[jj] = Etmp[1,0];
                    stra3[jj] = Etmp[2,0];
                }       
            }          
        }
        public static void lqStrainCSL(double[] s1, double fa1, double[] s2, double fa2, double[] s3, double fa3, double[]s4,double fa4, double defaultvalue, out double[] stra1, out double[] stra2, out double[] stra3)
        {
            double[,] A = new double[3, 3];
            double[] fa = new double[4];
            fa[0] = fa1 * Math.PI / 180;
            fa[1] = fa2 * Math.PI / 180;
            fa[2] = fa3 * Math.PI / 180;
            fa[3] = fa4 * Math.PI / 180;
            double[,] B = new double[3, 1];
            double[,] Etmp = new double[3, 1];
            double[] CC = new double[4];
            double[] SS = new double[4];
            double[] S2 = new double[4];
            double[] EG = new double[4];
            stra1 = new double[s1.Length];//南北线应变
            stra2 = new double[s1.Length];//东西线应变
            stra3 = new double[s1.Length];//剪应变

            for (int mm = 0; mm < 4; mm++)
            {
                CC[mm] = Math.Pow(Math.Cos(fa[mm]), 2);
                SS[mm] = Math.Pow(Math.Sin(fa[mm]), 2);
                S2[mm] = -Math.Sin(2 * fa[mm]); 
            }
            //共用的系数矩阵，不改变
            A[0, 0] = liuqi.lqCommonUse.lqSum1D(yanwei.ywMatrixOperate.ywMultiply_Point(CC, CC, defaultvalue), defaultvalue);
            A[0, 1] = liuqi.lqCommonUse.lqSum1D(yanwei.ywMatrixOperate.ywMultiply_Point(SS, CC, defaultvalue), defaultvalue);
            A[0, 2] = liuqi.lqCommonUse.lqSum1D(yanwei.ywMatrixOperate.ywMultiply_Point(S2, CC, defaultvalue), defaultvalue);
            A[1, 0] = A[0, 1];
            A[1, 1] = liuqi.lqCommonUse.lqSum1D(yanwei.ywMatrixOperate.ywMultiply_Point(SS, SS, defaultvalue), defaultvalue);
            A[1, 2] = liuqi.lqCommonUse.lqSum1D(yanwei.ywMatrixOperate.ywMultiply_Point(S2, SS, defaultvalue), defaultvalue);
            A[2, 0] = A[0, 2];
            A[2, 1] = A[1, 2];
            A[2, 2] = liuqi.lqCommonUse.lqSum1D(yanwei.ywMatrixOperate.ywMultiply_Point(S2, S2, defaultvalue), defaultvalue);


            for (int jj = 0; jj < s1.Length; jj++)
            {
                if (s1[jj] == defaultvalue || s2[jj] == defaultvalue || s3[jj] == defaultvalue||s4[jj]==defaultvalue)
                {
                    stra1[jj] = defaultvalue;
                    stra2[jj] = defaultvalue;
                    stra3[jj] = defaultvalue;
                }
                else
                {
                    EG[0] = s1[jj]; EG[1] = s2[jj]; EG[2] = s3[jj]; EG[3] = s4[jj];
                    B[0, 0] = liuqi.lqCommonUse.lqSum1D(yanwei.ywMatrixOperate.ywMultiply_Point(EG, CC, defaultvalue), defaultvalue);
                    B[1, 0] = liuqi.lqCommonUse.lqSum1D(yanwei.ywMatrixOperate.ywMultiply_Point(EG, SS, defaultvalue), defaultvalue);
                    B[2, 0] = liuqi.lqCommonUse.lqSum1D(yanwei.ywMatrixOperate.ywMultiply_Point(EG, S2, defaultvalue), defaultvalue);

                    Etmp = yanwei.ywMatrixOperate.ywMultiply_Cross(yanwei.ywMatrixOperate.ywInverse(A, defaultvalue), B, defaultvalue);
                    stra1[jj] = Etmp[0, 0];
                    stra2[jj] = Etmp[1, 0];
                    stra3[jj] = Etmp[2, 0];
                }
            }
        }
        /////////////////////////////////////////////////////////////
        /// <summary>
        /// 依据几组线应变观测计算实际最大、最小主应变、最大主应变方位、最大剪应变
        /// </summary>
        /// <param name="s1">第1路线应变</param>
        /// <param name="fa1">第1路方位角</param>
        /// <param name="s2">第2路线应变</param>
        /// <param name="fa2">第2路方位角</param>
        /// <param name="s3">第3路线应变</param>
        /// <param name="fa3">第3路方位角</param>
        /// <param name="defaultvalue">缺数标记</param>
        /// <param name="ZDzyb">最大主应变</param>
        /// <param name="ZXzyb">最小主应变</param>
        /// <param name="FXzd">最大主应变方位</param>
        /// <param name="ZDjyb">最大剪应变</param>
        public static void lqStrainCSZ(double[] s1, double fa1, double[] s2, double fa2, double[] s3, double fa3, double defaultvalue, out double[] ZDzyb, out double[] ZXzyb, out double[] FXzd, out double[] ZDjyb)
        {
            double[] stra1, stra2, stra3;
            liuqi.lqStrainCS.lqStrainCSL(s1, fa1, s2, fa2, s3, fa3, defaultvalue, out stra1, out stra2, out stra3);
            liuqi.lqStrainCS.lqStrainL2Z(stra1, stra2, stra3, defaultvalue, out ZDzyb, out ZXzyb, out FXzd, out ZDjyb);
        }
        public static void lqStrainCSZ(double[] s1, double fa1, double[] s2, double fa2, double[] s3, double fa3, double[] s4, double fa4, double defaultvalue, out double[] ZDzyb, out double[] ZXzyb, out double[] FXzd, out double[] ZDjyb)
        {
            double[] stra1, stra2, stra3;
            liuqi.lqStrainCS.lqStrainCSL(s1, fa1, s2, fa2, s3, fa3,s4,fa4, defaultvalue, out stra1, out stra2, out stra3);
            liuqi.lqStrainCS.lqStrainL2Z(stra1, stra2, stra3, defaultvalue, out ZDzyb, out ZXzyb, out FXzd, out ZDjyb);
        }
        /////////////////////////////////////////////////////////////
        /// <summary>
        /// 依据几组线应变观测计算任意方向线应变
        /// </summary>
        /// <param name="s1">第1路线应变</param>
        /// <param name="fa1">第1路方位角</param>
        /// <param name="s2">第2路线应变</param>
        /// <param name="fa2">第2路方位角</param>
        /// <param name="s3">第3路线应变</param>
        /// <param name="fa3">第3路方位角</param>
        /// <param name="fa">方位角（从正北顺时针为正，单位度）</param>
        /// <param name="defaultvalue">缺数标记</param>
        /// <returns>线应变</returns>
        public static double[] lqStrainCSX(double[] s1, double fa1, double[] s2, double fa2, double[] s3, double fa3, double fa, double defaultvalue)
        {
            double[] stra1, stra2, stra3,Xtide;
            liuqi.lqStrainCS.lqStrainCSL(s1, fa1, s2, fa2, s3, fa3, defaultvalue, out stra1, out stra2, out stra3);
            Xtide=liuqi.lqStrainCS.lqStrainL2X(stra1,stra2,stra3,fa,defaultvalue);
            return Xtide;
        }
        public static double[] lqStrainCSX(double[] s1, double fa1, double[] s2, double fa2, double[] s3, double fa3,double[] s4, double fa4, double fa, double defaultvalue)
        {
            double[] stra1, stra2, stra3, Xtide;
            liuqi.lqStrainCS.lqStrainCSL(s1, fa1, s2, fa2, s3, fa3, s4,fa4,defaultvalue, out stra1, out stra2, out stra3);
            Xtide = liuqi.lqStrainCS.lqStrainL2X(stra1, stra2, stra3, fa, defaultvalue);
            return Xtide;
        }
        /////////////////////////////////////////////////////////////
        /// <summary>
        /// 依据几组线应变观测计算任意方向剪应变
        /// </summary>
        /// <param name="s1">第1路线应变</param>
        /// <param name="fa1">第1路方位角</param>
        /// <param name="s2">第2路线应变</param>
        /// <param name="fa2">第2路方位角</param>
        /// <param name="s3">第3路线应变</param>
        /// <param name="fa3">第3路方位角</param>
        /// <param name="fa">坐标系旋转方位角（从正北顺时针为正，单位度）</param>
        /// <param name="defaultvalue">缺数标记</param>
        /// <returns>剪应变</returns>
        public static double[] lqStrainCSJ(double[] s1, double fa1, double[] s2, double fa2, double[] s3, double fa3, double fa, double defaultvalue)
        {
            double[] stra1, stra2, stra3, Jtide;
            liuqi.lqStrainCS.lqStrainCSL(s1, fa1, s2, fa2, s3, fa3, defaultvalue, out stra1, out stra2, out stra3);
            Jtide = liuqi.lqStrainCS.lqStrainL2J(stra1, stra2, stra3, fa, defaultvalue);
            return Jtide;
        }
        public static double[] lqStrainCSJ(double[] s1, double fa1, double[] s2, double fa2, double[] s3, double fa3, double[] s4, double fa4, double fa, double defaultvalue)
        {
            double[] stra1, stra2, stra3, Jtide;
            liuqi.lqStrainCS.lqStrainCSL(s1, fa1, s2, fa2, s3, fa3, s4,fa4,defaultvalue, out stra1, out stra2, out stra3);
            Jtide = liuqi.lqStrainCS.lqStrainL2J(stra1, stra2, stra3, fa, defaultvalue);
            return Jtide;
        }
        /////////////////////////////////////////////////////////////
        /// <summary>
        /// 依据几组线应变观测计算一系列方位线应变
        /// </summary>
        /// <param name="s1">第1路线应变</param>
        /// <param name="fa1">第1路方位角</param>
        /// <param name="s2">第2路线应变</param>
        /// <param name="fa2">第2路方位角</param>
        /// <param name="s3">第3路线应变</param>
        /// <param name="fa3">第3路方位角</param>
        /// <param name="ffa1">开始方位角（从正北顺时针为正，单位度）</param>
        /// <param name="ddfa">角度步长（从正北顺时针为正，单位度）</param>
        /// <param name="ffa2">结束方位角（从正北顺时针为正，单位度）</param>
        /// <param name="defaultvalue">缺数标记</param>
        /// <returns>一系列方位线应变</returns>
        public static double[,] lqStrainCSDX(double[] s1, double fa1, double[] s2, double fa2, double[] s3, double fa3, double ffa1, double ddfa, double ffa2, double defaultvalue)
        {
            double[] stra1, stra2, stra3;
            double[,] DXtide;
            liuqi.lqStrainCS.lqStrainCSL(s1, fa1, s2, fa2, s3, fa3, defaultvalue, out stra1, out stra2, out stra3);            
            DXtide = liuqi.lqStrainCS.lqStrainL2DX(stra1, stra2, stra3, ffa1, ddfa, ffa2, defaultvalue);
            return DXtide;
        }
        public static double[,] lqStrainCSDX(double[] s1, double fa1, double[] s2, double fa2, double[] s3, double fa3, double[] s4, double fa4, double ffa1, double ddfa, double ffa2, double defaultvalue)
        {
            double[] stra1, stra2, stra3;
            double[,] DXtide;
            liuqi.lqStrainCS.lqStrainCSL(s1, fa1, s2, fa2, s3, fa3, s4,fa4,defaultvalue, out stra1, out stra2, out stra3);
            DXtide = liuqi.lqStrainCS.lqStrainL2DX(stra1, stra2, stra3, ffa1, ddfa, ffa2, defaultvalue);
            return DXtide;
        }
        /////////////////////////////////////////////////////////////
        /// <summary>
        /// 依据几组线应变观测计算一系列方位剪应变
        /// </summary>
        /// <param name="s1">第1路线应变</param>
        /// <param name="fa1">第1路方位角</param>
        /// <param name="s2">第2路线应变</param>
        /// <param name="fa2">第2路方位角</param>
        /// <param name="s3">第3路线应变</param>
        /// <param name="fa3">第3路方位角</param>
        /// <param name="ffa1">坐标系开始旋转方位角（从正北顺时针为正，单位度）</param>
        /// <param name="ddfa">角度步长（从正北顺时针为正，单位度）</param>
        /// <param name="ffa2">坐标系结束旋转方位角（从正北顺时针为正，单位度）</param>
        /// <param name="defaultvalue">缺数标记</param>
        /// <returns>一系列方位线应变</returns>
        public static double[,] lqStrainCSDJ(double[] s1, double fa1, double[] s2, double fa2, double[] s3, double fa3, double ffa1, double ddfa, double ffa2, double defaultvalue)
        {
            double[] stra1, stra2, stra3;
            double[,] DJtide;
            liuqi.lqStrainCS.lqStrainCSL(s1, fa1, s2, fa2, s3, fa3, defaultvalue, out stra1, out stra2, out stra3);
            DJtide = liuqi.lqStrainCS.lqStrainL2DJ(stra1, stra2, stra3, ffa1, ddfa, ffa2, defaultvalue);
            return DJtide;
        }
        public static double[,] lqStrainCSDJ(double[] s1, double fa1, double[] s2, double fa2, double[] s3, double fa3, double[] s4, double fa4, double ffa1, double ddfa, double ffa2, double defaultvalue)
        {
            double[] stra1, stra2, stra3;
            double[,] DJtide;
            liuqi.lqStrainCS.lqStrainCSL(s1, fa1, s2, fa2, s3, fa3,s4,fa4, defaultvalue, out stra1, out stra2, out stra3);
            DJtide = liuqi.lqStrainCS.lqStrainL2DJ(stra1, stra2, stra3, ffa1, ddfa, ffa2, defaultvalue);
            return DJtide;
        }
        /////////////////////////////////////////////////////////////
        /// <summary>
        /// 依据几组线应变观测计算面应变
        /// </summary>
        /// <param name="s1">第1路线应变</param>
        /// <param name="fa1">第1路方位角</param>
        /// <param name="s2">第2路线应变</param>
        /// <param name="fa2">第2路方位角</param>
        /// <param name="s3">第3路线应变</param>
        /// <param name="fa3">第3路方位角</param>
        /// <param name="defaultvalue">缺数标记</param>
        /// <returns>面应变</returns>
        public static double[] lqStrainCSM(double[] s1, double fa1, double[] s2, double fa2, double[] s3, double fa3, double defaultvalue)
        {
            double[] stra1, stra2, stra3, Mtide;
            liuqi.lqStrainCS.lqStrainCSL(s1, fa1, s2, fa2, s3, fa3, defaultvalue, out stra1, out stra2, out stra3);
            Mtide = liuqi.lqStrainCS.lqStrainL2M(stra1, stra2, defaultvalue);
            return Mtide;
        }
        public static double[] lqStrainCSM(double[] s1, double fa1, double[] s2, double fa2, double[] s3, double fa3,double[]s4,double fa4,double defaultvalue)
        {
            double[] stra1, stra2, stra3, Mtide;
            liuqi.lqStrainCS.lqStrainCSL(s1, fa1, s2, fa2, s3, fa3, s4,fa4,defaultvalue, out stra1, out stra2, out stra3);
            Mtide = liuqi.lqStrainCS.lqStrainL2M(stra1, stra2, defaultvalue);
            return Mtide;
        }
        /////////////////////////////////////////////////////////////
        /// <summary>
        /// 依据几组线应变观测计算体应变
        /// </summary>
        /// <param name="s1">第1路线应变</param>
        /// <param name="fa1">第1路方位角</param>
        /// <param name="s2">第2路线应变</param>
        /// <param name="fa2">第2路方位角</param>
        /// <param name="s3">第3路线应变</param>
        /// <param name="fa3">第3路方位角</param>
        /// <param name="defaultvalue">缺数标记</param>
        /// <returns>体应变</returns>
        public static double[] lqStrainCST(double[] s1, double fa1, double[] s2, double fa2, double[] s3, double fa3, double defaultvalue)
        {
            double[] stra1, stra2, stra3, Ttide;
            liuqi.lqStrainCS.lqStrainCSL(s1, fa1, s2, fa2, s3, fa3, defaultvalue, out stra1, out stra2, out stra3);
            Ttide = liuqi.lqStrainCS.lqStrainL2T(stra1, stra2, defaultvalue);
            return Ttide;
        }
        public static double[] lqStrainCST(double[] s1, double fa1, double[] s2, double fa2, double[] s3, double fa3, double[] s4, double fa4, double defaultvalue)
        {
            double[] stra1, stra2, stra3, Ttide;
            liuqi.lqStrainCS.lqStrainCSL(s1, fa1, s2, fa2, s3, fa3, s4, fa4, defaultvalue, out stra1, out stra2, out stra3);
            Ttide = liuqi.lqStrainCS.lqStrainL2T(stra1, stra2, defaultvalue);
            return Ttide;
        }
        /////////////////////////////////////////////////////////////
        /// <summary>
        /// 由南北、东西线应变及剪应变计算实际最大、最小主应变、最大主应变方位、最大剪应变
        /// </summary>
        /// <param name="stra1">南北线应变</param>
        /// <param name="stra2">东西线应变</param>
        /// <param name="stra3">剪应变</param>
        /// <param name="defaultvalue">缺数标记</param>
        /// <param name="ZDzyb">最大主应变</param>
        /// <param name="ZXzyb">最小主应变</param>
        /// <param name="FXzd">最大主应变方位</param>
        /// <param name="ZDjyb">最大剪应变</param>
        public static void lqStrainL2Z(double[] stra1, double[] stra2, double[] stra3, double defaultvalue, out double[] ZDzyb, out double[] ZXzyb, out double[] FXzd, out double[] ZDjyb)
        {
            double pd;
            ZDzyb = new double[stra1.Length];
            ZXzyb = new double[stra1.Length];
            ZDjyb = new double[stra1.Length];
            FXzd = new double[stra1.Length];

            for (int ii = 0; ii <stra1.Length; ii++)
            {
                if (stra1[ii] == defaultvalue || stra2[ii] == defaultvalue || stra3[ii] == defaultvalue)
                {
                    ZDzyb[ii] = defaultvalue;
                    ZXzyb[ii] = defaultvalue;
                    ZDjyb[ii] = defaultvalue;
                    FXzd[ii] = defaultvalue;
                }
                else
                {
                    ZDzyb[ii] = (stra1[ii] + stra2[ii]) / 2 + Math.Sqrt(Math.Pow((stra1[ii] - stra2[ii]) / 2, 2) + Math.Pow(stra3[ii], 2));
                    ZXzyb[ii] = (stra1[ii] + stra2[ii]) / 2 - Math.Sqrt(Math.Pow((stra1[ii] - stra2[ii]) / 2, 2) + Math.Pow(stra3[ii], 2));
                    ZDjyb[ii] = (ZDzyb[ii] - ZXzyb[ii]) / 2;

                    FXzd[ii] = Math.Atan(2 * stra3[ii] / (stra2[ii] - stra1[ii])) / 2;
                    pd = stra1[ii] * Math.Pow(Math.Cos(FXzd[ii]), 2) + stra2[ii] * Math.Pow(Math.Sin(FXzd[ii]), 2) - stra3[ii] * Math.Sin(2 * FXzd[ii]);
                    if (Math.Abs(pd - ZDzyb[ii]) > Math.Abs(pd - ZXzyb[ii]))
                        FXzd[ii] = FXzd[ii] * 180 / Math.PI + 90;
                    else
                        FXzd[ii] = FXzd[ii] * 180 / Math.PI;
                    //最大剪应变方位比最大主应变方位小45度，最小剪应变方位比最大主应变方位大45度。
                }
            }
        }
        /////////////////////////////////////////////////////////////
        /// <summary>
        /// 由南北、东西线应变及剪应变计算任意方向线应变
        /// </summary>
        /// <param name="stra1">南北线应变</param>
        /// <param name="stra2">东西线应变</param>
        /// <param name="stra3">剪应变</param>
        /// <param name="fa">方位角（从正北顺时针为正，单位度）</param>
        /// <param name="defaultvalue">缺数标记</param>
        /// <returns>线应变</returns>
        public static double[] lqStrainL2X(double[] stra1, double[] stra2, double[] stra3, double fa,double defaultvalue)
        {
            double[] Xtide = new double[stra1.Length];
            double faa = fa * Math.PI / 180;
            
            for (int ii = 0; ii < Xtide.Length; ii++)
            {
                if (stra1[ii]==defaultvalue||stra2[ii]==defaultvalue||stra3[ii]==defaultvalue) 
                    Xtide[ii]=defaultvalue;
                else
                    Xtide[ii] = stra1[ii] * Math.Pow(Math.Cos(faa), 2) + stra2[ii] * Math.Pow(Math.Sin(faa), 2) - stra3[ii] * Math.Sin(2 * faa);
            }
            return Xtide;
        }
        /////////////////////////////////////////////////////////////
        /// <summary>
        /// 由南北、东西线应变及剪应变计算任意剪应变
        /// </summary>
        /// <param name="stra1">南北线应变</param>
        /// <param name="stra2">东西线应变</param>
        /// <param name="stra3">剪应变</param>
        /// <param name="fa">坐标系旋转方位角（从正北顺时针为正，单位度）</param>
        /// <param name="defaultvalue">缺数标记</param>
        /// <returns>剪应变</returns>
        public static double[] lqStrainL2J(double[] stra1, double[] stra2, double[] stra3, double fa, double defaultvalue)
        {
            double[] Jtide = new double[stra1.Length];            
            double faa = fa * Math.PI / 180;

            for (int ii = 0; ii < Jtide.Length; ii++)
            {
                if (stra1[ii] == defaultvalue || stra2[ii] == defaultvalue || stra3[ii] == defaultvalue)
                    Jtide[ii] = defaultvalue;
                else
                    Jtide[ii] = Math.Sin(2 * faa) * (stra2[ii] - stra1[ii]) / 2 - Math.Cos(2 * faa) * stra3[ii];
            }
            return Jtide;
        }
        /////////////////////////////////////////////////////////////
        /// <summary>
        /// 由南北、东西线应变及剪应变计算一系列方位线应变
        /// </summary>
        /// <param name="stra1">南北线应变</param>
        /// <param name="stra2">东西线应变</param>
        /// <param name="stra3">剪应变</param>
        /// <param name="fa1">开始方位角（从正北顺时针为正，单位度）</param>
        /// <param name="dfa">角度步长（从正北顺时针为正，单位度）</param>
        /// <param name="fa2">结束方位角（从正北顺时针为正，单位度）</param>
        /// <param name="defaultvalue">缺数标记</param>
        /// <returns>一系列方位线应变</returns>
        public static double[,] lqStrainL2DX(double[] stra1, double[] stra2, double[] stra3, double fa1, double dfa, double fa2, double defaultvalue)
        {
            int gs;
            if (dfa == 0) gs = 1;
            else
                gs = Convert.ToInt16(Math.Floor((fa2 - fa1) / dfa)) + 1;

            double[,] DXtide = new double[stra1.Length, gs];
            double faa;

            for (int jj = 0; jj < gs; jj++)
            {
                faa = (fa1 + jj * dfa) * Math.PI / 180;
                for (int ii = 0; ii < stra1.Length; ii++)
                {
                    if (stra1[ii] == defaultvalue || stra2[ii] == defaultvalue || stra3[ii] == defaultvalue)
                        DXtide[ii, jj] = defaultvalue;
                    else
                        DXtide[ii, jj] = stra1[ii] * Math.Pow(Math.Cos(faa), 2) + stra2[ii] * Math.Pow(Math.Sin(faa), 2) - stra3[ii] * Math.Sin(2 * faa);
                }
            }
            return DXtide;
        }
        /////////////////////////////////////////////////////////////
        /// <summary>
        /// 由南北、东西线应变及剪应变计算一系列方位剪应变
        /// </summary>
        /// <param name="stra1">南北线应变</param>
        /// <param name="stra2">东西线应变</param>
        /// <param name="stra3">剪应变</param>
        /// <param name="fa1">坐标系开始旋转方位角（从正北顺时针为正，单位度）</param>
        /// <param name="dfa">角度步长（从正北顺时针为正，单位度）</param>
        /// <param name="fa2">坐标系结束旋转方位角（从正北顺时针为正，单位度）</param>
        /// <param name="defaultvalue">缺数标记</param>
        /// <returns>一系列方位剪应变</returns>
        public static double[,] lqStrainL2DJ(double[] stra1, double[] stra2, double[] stra3, double fa1, double dfa, double fa2, double defaultvalue)
        {
            int gs;
            if (dfa==0) gs=1;
            else
                gs = Convert.ToInt16(Math.Floor((fa2 - fa1) / dfa)) + 1;

            double[,] DJtide = new double[stra1.Length, gs];
            double faa;

            for (int jj = 0; jj < gs; jj++)
            {
                faa = (fa1 + jj * dfa) * Math.PI / 180;
                for (int ii = 0; ii < stra1.Length; ii++)
                {
                    if (stra1[ii] == defaultvalue || stra2[ii] == defaultvalue || stra3[ii] == defaultvalue)
                        DJtide[ii, jj] = defaultvalue;
                    else
                        DJtide[ii, jj] = Math.Sin(2 * faa) * (stra2[ii] - stra1[ii]) / 2 - Math.Cos(2 * faa) * stra3[ii];
                }
            }
            return DJtide;
        }
        /////////////////////////////////////////////////////////////
        /// <summary>
        /// 由南北、东西线应变计算面应变
        /// </summary>
        /// <param name="stra1">南北线应变</param>
        /// <param name="stra2">东西线应变</param>
        /// <param name="defaultvalue">缺数标记</param>
        /// <returns>面应变</returns>
        public static double[] lqStrainL2M(double[] stra1, double[] stra2, double defaultvalue)
        {
            double[] Mtide = new double[stra1.Length];

            for (int ii = 0; ii < Mtide.Length; ii++)
            {
                if (stra1[ii] == defaultvalue || stra2[ii] == defaultvalue )
                    Mtide[ii] = defaultvalue;
                else
                    Mtide[ii] = stra1[ii] + stra2[ii] ;
            }
            return Mtide;
        }
        /////////////////////////////////////////////////////////////
        /// <summary>
        /// 由南北、东西线应变计算体应变
        /// </summary>
        /// <param name="stra1">南北线应变</param>
        /// <param name="stra2">东西线应变</param>
        /// <param name="defaultvalue">缺数标记</param>
        /// <returns>体应变</returns>
        public static double[] lqStrainL2T(double[] stra1, double[] stra2, double defaultvalue)
        {
            double[] Ttide = new double[stra1.Length];

            for (int ii = 0; ii < Ttide.Length; ii++)
            {
                if (stra1[ii] == defaultvalue || stra2[ii] == defaultvalue)
                    Ttide[ii] = defaultvalue;
                else
                    Ttide[ii] = (stra1[ii] + stra2[ii])*2/3;
            }
            return Ttide;
        }
    }
}
