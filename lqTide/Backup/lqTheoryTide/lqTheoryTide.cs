//计算理论固体潮汐值
//作者：刘琦
//最后调试时间：2012.05.25
//参考文献：
//郗钦文等，《固体潮汐与引潮参数》、《精密引潮位展开及某些诠释》、《新的引潮位完全展开》、《固体潮汐理论值计算》
//骆鸣津等，《地层绝对应力测量与钻孔应变测量》一书P27
//蒋骏等，《地表潮汐线应变组合观测的信息提取方法》、《潮汐线应变观测的地表平面应变状态》
using System;
using System.Collections.Generic;
using System.Text;

namespace liuqi
{
    /// <summary>
    /// 计算理论固体潮汐值
    /// </summary>
    public class lqTheoryTide
    {

        /////////////////////////////////////////////////////////////
        /// <summary>
        /// 帮助函数
        /// </summary>
        public static string FunctionHelp()
        {
            string fh = "作者：刘琦  最后添加、调试时间：2012.05.25\r\n"
                + "参考文献：\r\n"
                + "郗钦文等，《固体潮汐与引潮参数》、《精密引潮位展开及某些诠释》、《新的引潮位完全展开》、《固体潮汐理论值计算》。\r\n"
                + "骆鸣津等，《地层绝对应力测量与钻孔应变测量》一书P27。\r\n"
                + "蒋骏等，《地表潮汐线应变组合观测的信息提取方法》、《潮汐线应变观测的地表平面应变状态》。\r\n"
                + "------------------------------------------------------\r\n"
                + "lqQXTideC计算倾斜南北、东西理论固体潮汐值。\r\n"
                + "lqXQXTideC计算任意方向倾斜的理论固体潮汐值。\r\n"
                + "lqDQXTideC计算一系列方位倾斜的理论固体潮汐值。\r\n"              
                + "lqZLTideC计算重力理论固体潮汐值。\r\n"
                + "lqLTideC计算南北向及东西向线应变、剪应变的理论固体潮汐值。\r\n"
                + "lqMTideC计算面应变的理论固体潮汐值。\r\n"
                + "lqTTideC计算体应变的理论固体潮汐值。\r\n"
                + "lqTTideC23计算体应变的理论固体潮汐值(2/3面应变)。\r\n"
                + "lqXTideC计算任意方向线应变的理论固体潮汐值。\r\n"
                + "lqJTideC计算任意方向剪应变的理论固体潮汐值。\r\n"
                + "lqDXTideC计算一系列方位线应变的理论固体潮汐值。\r\n"
                + "lqDJTideC计算一系列方位剪应变的理论固体潮汐值。\r\n"
                + "lqZTideC计算理论最大、最小主应变、最大主应变方位、最大剪应变。\r\n"  
                + "lqSjxl生成时间序列。\r\n";
      
            return fh;
        }

        /////////////////////////////////////////////////////////////
        ///主功能函数区
        /////////////////////////////////////////////////////////////
        /// <summary>
        /// 计算倾斜南北、东西理论固体潮汐值(单位10^(-3)ms)
        /// </summary>
        /// <param name="latitude">纬度</param>
        /// <param name="longitude">经度</param>
        /// <param name="HH">高程</param>
        /// <param name="InDate">日期时间</param>
        /// <param name="NST">南北向</param>
        /// <param name="EWT">东西向</param>
        public static void lqQXTideC(string latitude, string longitude, string HH, string[] InDate,out double[]NST,out double[] EWT)
        {
            double Fzhd,fi,ddf,pg,pg2,pa,gg0;
            double s,h,p,n,ps,e,tz,taot;
            double dd1, dd2, dd3, dd4, dd5, dd6,dd8,dd9;
            double cr, cth;
            double crs, cths;            
            double tmp1,tmp3,tmp4,tmp6;            
 
            NST=new double[InDate.Length];
            EWT=new double[InDate.Length];
            liuqi.lqTwys.lqYS1(latitude, longitude,HH, out Fzhd,out fi,out ddf,out pg,out pg2,out pa,out gg0);

            for (int ii = 0; ii < InDate.Length; ii++)
            {
                liuqi.lqTwys.lqYS(InDate[ii], double.Parse(longitude), out s, out h, out p, out n, out ps, out e, out tz, out taot);
                s = s * Fzhd; h = h * Fzhd; p = p * Fzhd; n = n * Fzhd;
                ps = ps * Fzhd; e = e * Fzhd; tz = tz * Fzhd;
                liuqi.lqTwys.lqYS2(s, h, p, n, ps, e, tz, fi, out cr, out crs, out cth, out cths, out  dd1, out  dd2, out  dd3, out  dd4, out  dd5, out  dd6, out dd8, out dd9);
                tmp1 = Math.Pow(cr, 3);
                tmp4 = Math.Pow(cr, 4);
                tmp3 = Math.Pow(cth, 2);
                tmp6 = Math.Pow(crs, 3);

                NST[ii] = 34.833 * pg * tmp1 * cth * dd8;
                NST[ii] = NST[ii] + 0.289 * pg2 * tmp4 * (5 * tmp3 - 1) * dd8;
                NST[ii] = NST[ii] + 15.997 * pg * tmp6 * cths * dd9;
                EWT[ii] = -34.833 * pg * tmp1 * cth * dd3;
                EWT[ii] = EWT[ii] - 0.289 * pg2 * tmp4 * (5 * tmp3 - 1) * dd3;
                EWT[ii] = EWT[ii] - 15.997 * pg * tmp6 * cths * dd6;
            }
        }
        /////////////////////////////////////////////////////////////
        /// <summary>
        /// 计算任意方向倾斜的理论固体潮汐值
        /// </summary>
        /// <param name="latitude">台站纬度</param>
        /// <param name="longitude">台站经度</param>
        /// <param name="HH">高程</param>
        /// <param name="fa">方位角（从正北顺时针为正，单位度）</param>
        /// <param name="InDate">日期时间</param>
        /// <returns>任意方向倾斜的理论固体潮汐值</returns>
        public static double[] lqXQXTideC(string latitude, string longitude, string HH, string fa, string[] InDate)
        {
            double[] QXtide = new double[InDate.Length];
            double[] NST,EWT;
            double faa = double.Parse(fa) * Math.PI / 180;          

            liuqi.lqTheoryTide.lqQXTideC(latitude,longitude,HH,InDate,out NST,out EWT);
            for (int ii = 0; ii < QXtide.Length; ii++)
            {
                QXtide[ii] = NST[ii] *Math.Cos(faa) + EWT[ii] * Math.Sin(faa);
            }
            return QXtide;
        }
        /////////////////////////////////////////////////////////////
        /// <summary>
        /// 计算一系列方位倾斜的理论固体潮汐值
        /// </summary>
        /// <param name="latitude">台站纬度</param>
        /// <param name="longitude">台站经度</param>
        /// <param name="HH">高程</param>
        /// <param name="fa1">开始方位角（从正北顺时针为正，单位度）</param>
        /// <param name="dfa">角度步长（从正北顺时针为正，单位度）</param>
        /// <param name="fa2">结束方位角（从正北顺时针为正，单位度）</param>
        /// <param name="InDate">日期时间</param>
        /// <returns>一系列方位倾斜的理论固体潮汐值</returns>
        public static double[,] lqDQXTideC(string latitude, string longitude, string HH, string fa1, string dfa, string fa2, string[] InDate)
        {
            int gs = Convert.ToInt16(Math.Floor((double.Parse(fa2) - double.Parse(fa1)) / double.Parse(dfa))) + 1;
            double[,] DQXtide = new double[InDate.Length, gs];
            double[] NST,EWT;
            double faa;

            liuqi.lqTheoryTide.lqQXTideC(latitude,longitude,HH,InDate,out NST,out EWT);

            for (int jj = 0; jj < gs; jj++)
            {
                faa = (double.Parse(fa1) + jj * double.Parse(dfa)) * Math.PI / 180;
                for (int ii = 0; ii < InDate.Length; ii++)
                {
                    DQXtide[ii, jj] = NST[ii] * Math.Cos(faa) + EWT[ii] * Math.Sin(faa);
                }
            }
            return DQXtide;
        }
        /////////////////////////////////////////////////////////////
        /// <summary>
        /// 计算重力理论固体潮汐值(单位10^(-8)ms^(-2))
        /// </summary>
        /// <param name="latitude">纬度</param>
        /// <param name="longitude">经度</param>
        /// <param name="HH">高程</param>
        /// <param name="InDate">日期时间</param>
        /// <returns>重力理论固体潮汐值</returns>
        public static double[] lqZLTideC(string latitude, string longitude, string HH, string[] InDate)
        {
            double Fzhd,fi,ddf,pg,pg2,pa,gg0;
            double[] G=new double[InDate.Length];
            liuqi.lqTwys.lqYS1(latitude, longitude,HH, out Fzhd,out fi,out ddf,out pg,out pg2,out pa,out gg0);

            double s,h,p,n,ps,e,tz,taot;
            double dd1, dd2, dd3, dd4, dd5, dd6,dd8,dd9;
            double cr, cth;
            double crs, cths;            
            double tmp1, tmp3, tmp4, tmp6, tmp7; 

            for (int ii=0;ii<InDate.Length;ii++)
            {
                liuqi.lqTwys.lqYS(InDate[ii],double.Parse(longitude),out s,out h,out p,out n,out ps,out e,out tz,out taot);
                s=s*Fzhd;   h=h*Fzhd;   p=p*Fzhd;       n=n*Fzhd;
                ps=ps*Fzhd; e=e*Fzhd;   tz=tz*Fzhd;          
                liuqi.lqTwys.lqYS2(s, h, p, n, ps, e, tz, fi, out cr, out crs, out cth, out cths, out  dd1, out  dd2, out  dd3, out  dd4, out  dd5, out  dd6,out dd8,out dd9);               
                tmp1=Math.Pow(cr,3);
                tmp3=Math.Pow(cth,2);
                tmp4=Math.Pow(cr,4);
                tmp6=Math.Pow(crs,3);
                tmp7=Math.Pow(cths,2);                    

                G[ii] = -165.163 * pa * tmp1 * (tmp3 - 1.0 / 3.0);
                G[ii] = G[ii] - 1.37 * pa * pa * tmp4 * (5 * tmp3 - 3) * cth;
                G[ii]=G[ii] - 75.849 * pa * tmp6 * (tmp7 - 1.0/3.0);
            }
            return G;
        }
        /////////////////////////////////////////////////////////////
        /// <summary>
        ///  计算南北向及东西向线应变、剪应变的理论固体潮汐值
        /// </summary>
        /// <param name="latitude">台站纬度</param>
        /// <param name="longitude">台站经度</param>
        /// <param name="HH">高程</param>
        /// <param name="InDate">日期时间</param>
        /// <param name="stra1">南北向</param>
        /// <param name="stra2">东西向</param>
        /// <param name="stra3">相应剪应变</param>
        public static void lqLTideC(string latitude,string longitude,string HH,string[] InDate,out double[] stra1,out double[] stra2,out double[] stra3)
        {
            //////////////////////////////////////////////////
            double Fzhd,fi,ddf,pg,pg2,pa,gg0;
            stra1 = new double[InDate.Length];
            stra2 = new double[InDate.Length];
            stra3 = new double[InDate.Length];
            liuqi.lqTwys.lqYS1(latitude, longitude,HH, out Fzhd,out fi,out ddf,out pg,out pg2,out pa,out gg0);
            /////////////////////////////////////////////////
            double s,h,p,n,ps,e,tz,taot;
            double cr, crs, cth, cths;
            double dd1, dd2, dd3, dd4, dd5, dd6,dd8,dd9;
            double tmp1, tmp2, tmp3, tmp4, tmp5, tmp6, tmp7, tmp8, tmp9, tmp10, tmp11, tmp12, tmp13, tmp14, tmp15, tmp16, tmp17, tmp18; 
                                    
            for (int ii=0;ii<InDate.Length;ii++)
            {
                liuqi.lqTwys.lqYS(InDate[ii],double.Parse(longitude),out s,out h,out p,out n,out ps,out e,out tz,out taot);
                s=s*Fzhd;   h=h*Fzhd;   p=p*Fzhd;       n=n*Fzhd;
                ps=ps*Fzhd; e=e*Fzhd;   tz=tz*Fzhd;   taot=taot*Fzhd;     
                ///////////////////////////////////////////////////////////////////////////////////////////////////////
                //计算应变固体潮理论值
                //下列公式部分来源于郗老师《固体潮汐与引潮参数》
                liuqi.lqTwys.lqYS2(s, h, p, n, ps, e, tz, fi, out cr, out crs, out cth, out cths, out  dd1, out  dd2, out  dd3, out  dd4, out  dd5, out  dd6,out dd8,out dd9);               
                tmp16=Math.Cos(ddf);
                tmp17=Math.Sin(ddf);
                tmp18=Math.Tan(ddf);
                tmp1=Math.Pow(cr,3);
                tmp4=Math.Pow(cr,4);
                tmp6=Math.Pow(crs,3);
                tmp3=Math.Pow(cth,2);                
                tmp5=Math.Pow(cth,3);                
                tmp7=Math.Pow(cths,2);
                tmp10=Math.Pow(tmp16,2);
                tmp15=tmp16*dd3;
                tmp12=Math.Pow(tmp15,2);
                tmp11=tmp16*dd1-tmp17*dd2;
                tmp14=tmp16*dd4-tmp17*dd5;
                tmp13=Math.Pow(tmp16*dd6,2);                
                tmp2=Math.Pow(tmp11,2);                
                tmp8=Math.Pow(tmp14,2);
                tmp9=Math.Pow(tmp15,2);                
                
                stra1[ii]=14.05*pg*tmp1*(tmp2-tmp3);
                stra1[ii]=stra1[ii]+17.208*pg*tmp1*(3*tmp3-1);
                stra1[ii]=stra1[ii]+0.02*pg2*tmp4*cth*(10*tmp2-(5*tmp3-1));
                stra1[ii]=stra1[ii]+0.136*pg2*tmp4*(5*tmp5-3*cth);
                stra1[ii]=stra1[ii]+6.452*pg*tmp6*(tmp8-tmp7);
                stra1[ii]=stra1[ii]+7.903*pg*tmp6*(3*tmp7-1);//南北向应变
                
                stra2[ii]=14.05*pg*tmp1*(tmp9-cth*tmp16*dd2)/tmp10;
                stra2[ii]=stra2[ii]-14.05*pg*tmp1*cth*tmp18*tmp11;
                stra2[ii]=stra2[ii]+17.028*pg*tmp1*(3*tmp3-1);
                stra2[ii]=stra2[ii]+0.02*pg2*tmp4*(10*cth*tmp12-(5*tmp3-1)*tmp16*dd2)/tmp10;
                stra2[ii]=stra2[ii]-0.02*pg2*tmp4*tmp18*(5*tmp3-1)*tmp11;
                stra2[ii]=stra2[ii]+0.136*pg2*tmp4*(5*tmp5-3*cth);
                stra2[ii]=stra2[ii]+6.452*pg*tmp6*(tmp13-cths*tmp16*dd5)/tmp10;
                stra2[ii]=stra2[ii]-6.452*pg*tmp6*cths*tmp18*tmp14;
                stra2[ii]=stra2[ii]+7.903*pg*tmp6*(3*tmp7-1);//东西向应变

                stra3[ii]=28.1*pg*tmp1;
                stra3[ii]=stra3[ii]*(tmp11*tmp15-cth*tmp17*dd3)/tmp16;
                stra3[ii]=stra3[ii]+28.1*pg*tmp1*tmp18*cth*dd3;
                stra3[ii]=stra3[ii]+0.041*pg2*tmp4*(10*cth*tmp11*tmp15)/tmp16;
                stra3[ii]=stra3[ii]+12.905*pg*tmp6*(tmp14*tmp16*dd6-cths*tmp17*dd6)/tmp16;
                stra3[ii]=stra3[ii]+12.905*pg*tmp6*tmp18*cths*dd6;
                stra3[ii]=stra3[ii]/2;//剪应变
                //上列公式部分来源于郗老师《固体潮汐与引潮参数》
                ///////////////////////////////////////////////////////////////////////////////////////////////////////
            }
        }
        /////////////////////////////////////////////////////////////
        /// <summary>
        ///  计算面应变的理论固体潮汐值
        /// </summary>
        /// <param name="latitude">台站纬度</param>
        /// <param name="longitude">台站经度</param>
        /// <param name="HH">高程</param>
        /// <param name="InDate">日期时间</param>
        /// <returns>面应变的理论固体潮汐值</returns>
        public static double[] lqMTideC(string latitude, string longitude, string HH,string[] InDate)
        {
            double[] Mtide=new double[InDate.Length];
            double[] stra1,stra2,stra3;

            liuqi.lqTheoryTide.lqLTideC(latitude, longitude,HH, InDate, out stra1, out stra2, out stra3);
            for (int ii = 0; ii < Mtide.Length; ii++)
            {
                Mtide[ii] = stra1[ii] + stra2[ii];                
            }
            return Mtide;
        }
        /////////////////////////////////////////////////////////////
        /// <summary>
        /// 计算体应变理论固体潮汐值
        /// </summary>
        /// <param name="latitude">纬度</param>
        /// <param name="longitude">经度</param>
        /// <param name="HH">高程</param>
        /// <param name="InDate">日期时间</param>
        /// <returns>体应变理论固体潮汐值</returns>
        public static double[] lqTTideC(string latitude, string longitude, string HH, string[] InDate)
        {
            double [] Ttide=new double[InDate.Length];
            double Fzhd,fi,ddf,pg,pg2,pa,gg0;

            double s,h,p,n,ps,e,tz,taot;
            double dd1, dd2, dd3, dd4, dd5, dd6,dd8,dd9;
            double cr, cth;
            double crs, cths;            
            double tmp1,tmp3,tmp4,tmp6,tmp7; 

            liuqi.lqTwys.lqYS1(latitude, longitude,HH, out Fzhd,out fi,out ddf,out pg,out pg2,out pa,out gg0);

            for (int ii=0;ii<InDate.Length;ii++)
            {
                liuqi.lqTwys.lqYS(InDate[ii],double.Parse(longitude),out s,out h,out p,out n,out ps,out e,out tz,out taot);
                s=s*Fzhd;   h=h*Fzhd;   p=p*Fzhd;       n=n*Fzhd;
                ps=ps*Fzhd; e=e*Fzhd;   tz=tz*Fzhd;          
                liuqi.lqTwys.lqYS2(s, h, p, n, ps, e, tz, fi, out cr, out crs, out cth, out cths, out  dd1, out  dd2, out  dd3, out  dd4, out  dd5, out  dd6,out dd8,out dd9);               
                tmp1=Math.Pow(cr,3);
                tmp3=Math.Pow(cth,2);
                tmp4=Math.Pow(cr,4);
                tmp6=Math.Pow(crs,3);
                tmp7=Math.Pow(cths,2);                    

                Ttide[ii] = 40.732 * pg * tmp1 * (tmp3 - 1.0/ 3.0);
                Ttide[ii]=Ttide[ii]+ 0.127 * pg2* tmp4 * (5 * tmp3 - 3) * cth;
                Ttide[ii]=Ttide[ii]+18.706 * pg * tmp6 * (tmp7 - 1.0 / 3.0);
            }
            return Ttide; 
        }
        /////////////////////////////////////////////////////////////
        /// <summary>
        /// 计算体应变的理论固体潮汐值(2/3面应变)
        /// </summary>
        /// <param name="latitude">台站纬度</param>
        /// <param name="longitude">台站经度</param>
        /// <param name="HH">高程</param>
        /// <param name="InDate">日期时间</param>
        /// <returns>体应变的理论固体潮汐值</returns>
        public static double[] lqTTideC23(string latitude, string longitude, string HH,string[] InDate)
        {
            double[] Ttide;
            Ttide = liuqi.lqTheoryTide.lqMTideC(latitude, longitude,HH ,InDate);
            for (int ii = 0; ii < InDate.Length; ii++)
            {
                Ttide[ii] = Ttide[ii] * 2 / 3;
            }            
            return Ttide;
        }
        /////////////////////////////////////////////////////////////
        /// <summary>
        /// 计算任意方向线应变的理论固体潮汐值
        /// </summary>
        /// <param name="latitude">台站纬度</param>
        /// <param name="longitude">台站经度</param>
        /// <param name="HH">高程</param>
        /// <param name="fa">方位角（从正北顺时针为正，单位度）</param>
        /// <param name="InDate">日期时间</param>
        /// <returns>线应变的理论固体潮汐值</returns>
        public static double[] lqXTideC(string latitude, string longitude,string HH,string fa, string[] InDate)
        {
            double[] Xtide = new double[InDate.Length];
            double[] stra1, stra2, stra3;
            double faa = double.Parse(fa)*Math.PI/180;

            liuqi.lqTheoryTide.lqLTideC(latitude, longitude,HH ,InDate, out stra1, out stra2, out stra3);
            for (int ii = 0; ii < Xtide.Length; ii++)
            {
                Xtide[ii] = stra1[ii]*Math.Pow(Math.Cos(faa),2) + stra2[ii]*Math.Pow(Math.Sin(faa),2)-stra3[ii]*Math.Sin(2*faa);
            }
            return Xtide;
        }
        /////////////////////////////////////////////////////////////
        /// 计算任意方向剪应变的理论固体潮汐值
        /// </summary>
        /// <param name="latitude">台站纬度</param>
        /// <param name="longitude">台站经度</param>
        /// <param name="HH">高程</param>
        /// <param name="fa">坐标系旋转方位角（从正北顺时针为正，单位度）</param>
        /// <param name="InDate">日期时间</param>
        /// <returns>剪应变的理论固体潮汐值</returns>
        public static double[] lqJTideC(string latitude, string longitude,string HH, string fa, string[] InDate)
        {
            double[] Jtide = new double[InDate.Length];
            double[] stra1, stra2, stra3;
            double faa = double.Parse(fa) * Math.PI / 180;

            liuqi.lqTheoryTide.lqLTideC(latitude, longitude,HH ,InDate, out stra1, out stra2, out stra3);
            for (int ii = 0; ii < Jtide.Length; ii++)
            {
                Jtide[ii] = Math.Sin(2 * faa) * (stra2[ii] - stra1[ii]) /2-  Math.Cos(2 * faa) * stra3[ii];
            }
            return Jtide;
        }
        /////////////////////////////////////////////////////////////
        /// <summary>
        /// 计算一系列方位线应变的理论固体潮汐值
        /// </summary>
        /// <param name="latitude">台站纬度</param>
        /// <param name="longitude">台站经度</param>
        /// <param name="HH">高程</param>
        /// <param name="fa1">开始方位角（从正北顺时针为正，单位度）</param>
        /// <param name="dfa">角度步长（从正北顺时针为正，单位度）</param>
        /// <param name="fa2">结束方位角（从正北顺时针为正，单位度）</param>
        /// <param name="InDate">日期时间</param>
        /// <returns>一系列方位线应变的理论固体潮汐值</returns>
        public static double[,] lqDXTideC(string latitude, string longitude, string HH,string fa1, string dfa, string fa2, string[] InDate)
        {
            int gs =Convert.ToInt16(Math.Floor((double.Parse(fa2) - double.Parse(fa1)) / double.Parse(dfa))) + 1;
            double[,] DXtide = new double[InDate.Length,gs];
            double[] stra1, stra2, stra3;
            double faa;

            liuqi.lqTheoryTide.lqLTideC(latitude, longitude, HH,InDate, out stra1, out stra2, out stra3);

            for (int jj = 0; jj < gs; jj++)
            {
                faa = (double.Parse(fa1) + jj * double.Parse(dfa))*Math.PI/180;
                for (int ii = 0; ii < InDate.Length; ii++)
                {
                    DXtide[ii, jj] = stra1[ii] * Math.Pow(Math.Cos(faa), 2) + stra2[ii] * Math.Pow(Math.Sin(faa), 2) - stra3[ii] * Math.Sin(2 * faa);
                }
            }
            return DXtide;
        }
        /////////////////////////////////////////////////////////////
        /// <summary>
        /// 计算一系列方位剪应变的理论固体潮汐值
        /// </summary>
        /// <param name="latitude">台站纬度</param>
        /// <param name="longitude">台站经度</param>
        /// <param name="HH">高程</param>
        /// <param name="fa1">坐标系开始旋转方位角（从正北顺时针为正，单位度）</param>
        /// <param name="dfa">角度步长（从正北顺时针为正，单位度）</param>
        /// <param name="fa2">坐标系结束旋转方位角（从正北顺时针为正，单位度）</param>
        /// <param name="InDate">日期时间</param>
        /// <returns>一系列方位剪应变的理论固体潮汐值</returns>
        public static double[,] lqDJTideC(string latitude, string longitude, string HH,string fa1, string dfa, string fa2, string[] InDate)
        {
            int gs = Convert.ToInt16(Math.Floor((double.Parse(fa2) - double.Parse(fa1)) / double.Parse(dfa))) + 1;
            double[,] DJtide = new double[InDate.Length, gs];
            double[] stra1, stra2, stra3;
            double faa;

            liuqi.lqTheoryTide.lqLTideC(latitude, longitude,HH ,InDate, out stra1, out stra2, out stra3);

            for (int jj = 0; jj < gs; jj++)
            {
                faa = (double.Parse(fa1) + jj * double.Parse(dfa)) * Math.PI / 180;
                for (int ii = 0; ii < InDate.Length; ii++)
                {
                    DJtide[ii, jj] = Math.Sin(2 * faa) * (stra2[ii] - stra1[ii]) / 2 - Math.Cos(2 * faa) * stra3[ii];
                }
            }
            return DJtide;
        }
        /////////////////////////////////////////////////////////////
        /// <summary>
        /// 计算理论最大、最小主应变、最大主应变方位、最大剪应变
        /// </summary>
        /// <param name="latitude">台站纬度</param>
        /// <param name="longitude">台站经度</param>
        /// <param name="HH">高程</param>
        /// <param name="InDate">日期时间</param>
        /// <param name="ZDzyb">最大主应变</param>
        /// <param name="ZXzyb">最小主应变</param>
        /// <param name="FXzd">最大主应变方位</param>
        /// <param name="ZDjyb">最大剪应变</param>
        public static void lqZTideC(string latitude, string longitude,string HH,string[] InDate,out double[] ZDzyb,out double[] ZXzyb,out double[] FXzd,out double[] ZDjyb)
        {
            double[] stra1, stra2, stra3;
            double pd;
            ZDzyb = new double[InDate.Length];
            ZXzyb = new double[InDate.Length];
            ZDjyb = new double[InDate.Length];
            FXzd = new double[InDate.Length];           

            liuqi.lqTheoryTide.lqLTideC(latitude, longitude, HH,InDate, out stra1, out stra2, out stra3);
            for (int ii = 0; ii < InDate.Length; ii++)
            {
                ZDzyb[ii] = (stra1[ii] + stra2[ii]) / 2 + Math.Sqrt(Math.Pow((stra1[ii] - stra2[ii]) / 2, 2) + Math.Pow(stra3[ii], 2));
                ZXzyb[ii] = (stra1[ii] + stra2[ii]) / 2 - Math.Sqrt(Math.Pow((stra1[ii] - stra2[ii]) / 2, 2) + Math.Pow(stra3[ii], 2));
                ZDjyb[ii] = (ZDzyb[ii] - ZXzyb[ii]) / 2;

                FXzd[ii] =Math.Atan(2 * stra3[ii] / (stra2[ii] - stra1[ii]))/2;
                pd = stra1[ii] * Math.Pow(Math.Cos(FXzd[ii]), 2) + stra2[ii] * Math.Pow(Math.Sin(FXzd[ii]), 2) - stra3[ii] * Math.Sin(2 * FXzd[ii]);
                if (Math.Abs(pd - ZDzyb[ii]) > Math.Abs(pd - ZXzyb[ii]))
                    FXzd[ii] = FXzd[ii] * 180 / Math.PI + 90;
                else
                    FXzd[ii] = FXzd[ii] * 180 / Math.PI;
                //最大剪应变方位比最大主应变方位小45度，最小剪应变方位比最大主应变方位大45度。
            }
        }
        /////////////////////////////////////////////////////////////
        /// <summary>
        /// 生成时间序列
        /// </summary>
        /// <param name="sdatetime">开始日期时间</param>
        /// <param name="edatetime">结束日期时间</param>
        /// <returns>时间序列</returns>
        public static void lqSjxl(string sdatetime, string edatetime,ref System.Collections.ArrayList Xlfh)
        {
            if (sdatetime.Length != edatetime.Length)                return; 
            int len = sdatetime.Length;
            long YYs,YYe, MMs,MMe, DDs,DDe, HHours,HHoure, MMins,MMine, SSecs,SSece;
            int ii;
            long xz1,xz2,tt1,tt2,tt3;
            long tmp1,tmp2;
            long bx1, bx2, bx3, bx4, bx5;
            
            if (len == 4)//到年
            {
                YYs = long.Parse(sdatetime);                YYe = long.Parse(edatetime);
                ii=0;
                while(YYs<=YYe)
                {                    
                    Xlfh.Add(YYs.ToString());
                    YYs=YYs+1;                    ii=ii+1;
                }               
            }
            else if (len == 6)//到月
            {
                MMs = long.Parse(sdatetime.Substring(4, 2));                MMe = long.Parse(edatetime.Substring(4, 2));
                if (MMs > 12 || MMs == 0||MMe>12||MMe==0) return;
                YYs = long.Parse(sdatetime.Substring(0, 4));                YYe = long.Parse(edatetime.Substring(0, 4));
                ii = 0;
                bx1 = YYs * 100;                tmp1 = bx1 + MMs;
                bx1 = YYe * 100;                tmp2 = bx1 + MMe;
                while(tmp1<=tmp2)
                {                    
                    Xlfh.Add(tmp1.ToString());
                    MMs=MMs+1;
                    if (MMs > 12)
                    {
                        MMs = MMs - 12;                        YYs = YYs + 1;
                    }
                    bx1 = YYs * 100;                    tmp1 = bx1 + MMs;                    ii = ii + 1;
                }
            }
            else if (len == 8)//到日
            {
                MMs = long.Parse(sdatetime.Substring(4, 2));                MMe = long.Parse(edatetime.Substring(4, 2));
                if (MMs > 12 || MMs == 0 || MMe > 12 || MMe == 0) return;
                DDs = long.Parse(sdatetime.Substring(6, 2)); DDe = long.Parse(edatetime.Substring(6, 2));
                if (DDs == 0 || DDe == 0) return;

                YYs = long.Parse(sdatetime.Substring(0, 4)); YYe = long.Parse(edatetime.Substring(0, 4));
                Math.DivRem(YYs, 4, out tt1); Math.DivRem(YYs, 100, out tt2); Math.DivRem(YYs, 400, out tt3);
                if ((tt1 == 0 && tt2 != 0) || tt3 == 0) xz1 = 1;//闰年
                else xz1 = 0;
                Math.DivRem(YYe, 4, out tt1); Math.DivRem(YYe, 100, out tt2); Math.DivRem(YYe, 400, out tt3);
                if ((tt1 == 0 && tt2 != 0) || tt3 == 0) xz2 = 1;//闰年
                else xz2 = 0;
                
                if ((MMs == 1 || MMs == 3 || MMs == 5 || MMs == 7 || MMs == 8 || MMs == 10 || MMs == 12) && DDs > 31) return;//超范围
                if ((MMs == 4 || MMs == 6 || MMs == 9 || MMs == 11 ) && DDs > 30) return;//超范围
                if (MMs == 2 && DDs > 28 + xz1) return;//超范围
                if ((MMe == 1 || MMe == 3 || MMe == 5 || MMe == 7 || MMe == 8 || MMe == 10 || MMe == 12) && DDe > 31) return;//超范围
                if ((MMe == 4 || MMe == 6 || MMe == 9 || MMe == 11 ) && DDe > 30) return;//超范围
                if (MMe == 2 && DDe > 28 + xz2) return;//超范围

                ii = 0;
                bx1 = YYs * 10000;                bx2 = MMs * 100;                tmp1 = bx1 + bx2 + DDs;
                bx1 = YYe * 10000;                bx2 = MMe * 100;                tmp2 = bx1 + bx2 + DDe;
                while (tmp1 <= tmp2)
                {
                    Xlfh.Add(tmp1.ToString());
                    DDs = DDs + 1;
                    if ((MMs == 1 || MMs == 3 || MMs == 5 || MMs == 7 || MMs == 8 || MMs == 10 || MMs == 12) && DDs > 31)
                    {
                        DDs = DDs - 31; MMs = MMs + 1;
                    }
                    if ((MMs == 4 || MMs == 6 || MMs == 9 || MMs == 11 ) && DDs > 30)
                    {
                        DDs = DDs - 30; MMs = MMs + 1;
                    }
                    if (MMs == 2 && DDs > 28 + xz1)
                    {
                        DDs = DDs - 28 - xz1; MMs = MMs + 1;
                    }
                    if (MMs > 12)
                    {
                        MMs = MMs - 12; YYs = YYs + 1;
                        Math.DivRem(YYs, 4, out tt1); Math.DivRem(YYs, 100, out tt2); Math.DivRem(YYs, 400, out tt3);
                        if ((tt1 == 0 && tt2 != 0) || tt3 == 0) xz1 = 1;//闰年
                        else xz1 = 0;
                    }
                    bx1 = YYs * 10000; bx2 = MMs * 100; tmp1 = bx1 + bx2 + DDs;
                    ii = ii + 1;
                }       
            }
            else if (len == 10)//到时
            {
                MMs = long.Parse(sdatetime.Substring(4, 2));                MMe = long.Parse(edatetime.Substring(4, 2));
                if (MMs > 12 || MMs == 0 || MMe > 12 || MMe == 0) return;
                DDs = long.Parse(sdatetime.Substring(6, 2)); DDe = long.Parse(edatetime.Substring(6, 2));
                if (DDs == 0 || DDe == 0) return;
                HHours = long.Parse(sdatetime.Substring(8, 2)); HHoure = long.Parse(edatetime.Substring(8, 2));
                if (HHours > 23 || HHoure > 23) return;

                YYs = long.Parse(sdatetime.Substring(0, 4)); YYe = long.Parse(edatetime.Substring(0, 4));
                Math.DivRem(YYs, 4, out tt1); Math.DivRem(YYs, 100, out tt2); Math.DivRem(YYs, 400, out tt3);
                if ((tt1 == 0 && tt2 != 0) || tt3 == 0) xz1 = 1;//闰年
                else xz1 = 0;
                Math.DivRem(YYe, 4, out tt1); Math.DivRem(YYe, 100, out tt2); Math.DivRem(YYe, 400, out tt3);
                if ((tt1 == 0 && tt2 != 0) || tt3 == 0) xz2 = 1;//闰年
                else xz2 = 0;
                
                if ((MMs == 1 || MMs == 3 || MMs == 5 || MMs == 7 || MMs == 8 || MMs == 10 || MMs == 12) && DDs > 31) return;//超范围
                if ((MMs == 4 || MMs == 6 || MMs == 9 || MMs == 11 ) && DDs > 30) return;//超范围
                if (MMs == 2 && DDs > 28 + xz1) return;//超范围
                if ((MMe == 1 || MMe == 3 || MMe == 5 || MMe == 7 || MMe == 8 || MMe == 10 || MMe == 12) && DDe > 31) return;//超范围
                if ((MMe == 4 || MMe == 6 || MMe == 9 || MMe == 11 ) && DDe > 30) return;//超范围
                if (MMe == 2 && DDe > 28 + xz2) return;//超范围                

                ii = 0;
                bx1 = YYs * 1000000;                bx2 = MMs * 10000;                bx3 = DDs * 100;
                tmp1 = bx1 + bx2 + bx3 + HHours;
                bx1 = YYe * 1000000;                bx2 = MMe * 10000;                bx3 = DDe * 100;
                tmp2 = bx1 + bx2 + bx3 + HHoure;
                while (tmp1 <= tmp2)
                {
                    Xlfh.Add(tmp1.ToString());
                    HHours = HHours + 1;
                    if (HHours > 23)
                    {
                        HHours = HHours - 24; DDs = DDs + 1;
                    }
                    if ((MMs == 1 || MMs == 3 || MMs == 5 || MMs == 7 || MMs == 8 || MMs == 10 || MMs == 12) && DDs > 31)
                    {
                        DDs = DDs - 31; MMs = MMs + 1;
                    }
                    if ((MMs == 4 || MMs == 6 || MMs == 9 || MMs == 11 ) && DDs > 30)
                    {
                        DDs = DDs - 30; MMs = MMs + 1;
                    }
                    if (MMs == 2 && DDs > 28 + xz1)
                    {
                        DDs = DDs - 28 - xz1; MMs = MMs + 1;
                    }
                    if (MMs > 12)
                    {
                        MMs = MMs - 12; YYs = YYs + 1;
                        Math.DivRem(YYs, 4, out tt1); Math.DivRem(YYs, 100, out tt2); Math.DivRem(YYs, 400, out tt3);
                        if ((tt1 == 0 && tt2 != 0) || tt3 == 0) xz1 = 1;//闰年
                        else xz1 = 0;
                    }
                    bx1 = YYs * 1000000; bx2 = MMs * 10000; bx3 = DDs * 100;
                    tmp1 = bx1 + bx2 + bx3 + HHours;
                    ii = ii + 1;
                }
            }
            else if (len == 12)//到分
            {
                MMs = long.Parse(sdatetime.Substring(4, 2)); MMe = long.Parse(edatetime.Substring(4, 2));
                if (MMs > 12 || MMs == 0 || MMe > 12 || MMe == 0) return;
                DDs = long.Parse(sdatetime.Substring(6, 2)); DDe = long.Parse(edatetime.Substring(6, 2));
                if (DDs == 0 || DDe == 0) return;
                HHours = long.Parse(sdatetime.Substring(8, 2)); HHoure = long.Parse(edatetime.Substring(8, 2));
                if (HHours > 23 || HHoure > 23) return;
                MMins = long.Parse(sdatetime.Substring(10, 2)); MMine = long.Parse(edatetime.Substring(10, 2));
                if (MMins > 59 || MMine > 59) return;

                YYs = long.Parse(sdatetime.Substring(0, 4)); YYe = long.Parse(edatetime.Substring(0, 4));
                Math.DivRem(YYs, 4, out tt1); Math.DivRem(YYs, 100, out tt2); Math.DivRem(YYs, 400, out tt3);
                if ((tt1 == 0 && tt2 != 0) || tt3 == 0) xz1 = 1;//闰年
                else xz1 = 0;
                Math.DivRem(YYe, 4, out tt1); Math.DivRem(YYe, 100, out tt2); Math.DivRem(YYe, 400, out tt3);
                if ((tt1 == 0 && tt2 != 0) || tt3 == 0) xz2 = 1;//闰年
                else xz2 = 0;
                
                if ((MMs == 1 || MMs == 3 || MMs == 5 || MMs == 7 || MMs == 8 || MMs == 10 || MMs == 12) && DDs > 31) return;//超范围
                if ((MMs == 4 || MMs == 6 || MMs == 9 || MMs == 11 ) && DDs > 30) return;//超范围
                if (MMs == 2 && DDs > 28 + xz1) return;//超范围
                if ((MMe == 1 || MMe == 3 || MMe == 5 || MMe == 7 || MMe == 8 || MMe == 10 || MMe == 12) && DDe > 31) return;//超范围
                if ((MMe == 4 || MMe == 6 || MMe == 9 || MMe == 11 ) && DDe > 30) return;//超范围
                if (MMe == 2 && DDe > 28 + xz2) return;//超范围                

                ii = 0;
                bx1 = YYs * 100000000;                bx2 = MMs * 1000000;
                bx3 = DDs * 10000;                bx4 = HHours * 100;
                tmp1 = bx1 + bx2 + bx3 + bx4 +MMins;
                bx1 = YYe * 100000000;                bx2 = MMe * 1000000;
                bx3 = DDe * 10000;                bx4 = HHoure * 100;
                tmp2 = bx1 + bx2 + bx3 + bx4 +MMine;
                while (tmp1 <= tmp2)
                {
                    Xlfh.Add(tmp1.ToString());
                    MMins = MMins + 1;
                    if (MMins > 59)
                    {
                        MMins = MMins - 60; HHours=HHours+1;
                    }
                    if (HHours > 23)
                    {
                        HHours = HHours - 24; DDs = DDs + 1;
                    }
                    if ((MMs == 1 || MMs == 3 || MMs == 5 || MMs == 7 || MMs == 8 || MMs == 10 || MMs == 12) && DDs > 31)
                    {
                        DDs = DDs - 31; MMs = MMs + 1;
                    }
                    if ((MMs == 4 || MMs == 6 || MMs == 9 || MMs == 11 ) && DDs > 30)
                    {
                        DDs = DDs - 30; MMs = MMs + 1;
                    }
                    if (MMs == 2 && DDs > 28 + xz1)
                    {
                        DDs = DDs - 28 - xz1; MMs = MMs + 1;
                    }
                    if (MMs > 12)
                    {
                        MMs = MMs - 12; YYs = YYs + 1;
                        Math.DivRem(YYs, 4, out tt1); Math.DivRem(YYs, 100, out tt2); Math.DivRem(YYs, 400, out tt3);
                        if ((tt1 == 0 && tt2 != 0) || tt3 == 0) xz1 = 1;//闰年
                        else xz1 = 0;
                    }
                    bx1 = YYs * 100000000; bx2 = MMs * 1000000;
                    bx3 = DDs * 10000; bx4 = HHours * 100;
                    tmp1 = bx1 + bx2 + bx3 + bx4 + MMins;
                    ii = ii + 1;
                }
            }
            else if (len == 14)//到秒
            {
                MMs = long.Parse(sdatetime.Substring(4, 2)); MMe = long.Parse(edatetime.Substring(4, 2));
                if (MMs > 12 || MMs == 0 || MMe > 12 || MMe == 0) return;
                DDs = long.Parse(sdatetime.Substring(6, 2)); DDe = long.Parse(edatetime.Substring(6, 2));
                if (DDs == 0 || DDe == 0) return;
                HHours = long.Parse(sdatetime.Substring(8, 2)); HHoure = long.Parse(edatetime.Substring(8, 2));
                if (HHours > 23 || HHoure > 23) return;
                MMins = long.Parse(sdatetime.Substring(10, 2)); MMine = long.Parse(edatetime.Substring(10, 2));
                if (MMins > 59 || MMine > 59) return;
                SSecs = long.Parse(sdatetime.Substring(12, 2)); SSece = long.Parse(edatetime.Substring(12, 2));
                if (SSecs > 59 || SSece > 59) return;   

                YYs = long.Parse(sdatetime.Substring(0, 4)); YYe = long.Parse(edatetime.Substring(0, 4));
                Math.DivRem(YYs, 4, out tt1); Math.DivRem(YYs, 100, out tt2); Math.DivRem(YYs, 400, out tt3);
                if ((tt1 == 0 && tt2 != 0) || tt3 == 0) xz1 = 1;//闰年
                else xz1 = 0;
                Math.DivRem(YYe, 4, out tt1); Math.DivRem(YYe, 100, out tt2); Math.DivRem(YYe, 400, out tt3);
                if ((tt1 == 0 && tt2 != 0) || tt3 == 0) xz2 = 1;//闰年
                else xz2 = 0;
                
                if ((MMs == 1 || MMs == 3 || MMs == 5 || MMs == 7 || MMs == 8 || MMs == 10 || MMs == 12) && DDs > 31) return;//超范围
                if ((MMs == 4 || MMs == 6 || MMs == 9 || MMs == 11 ) && DDs > 30) return;//超范围
                if (MMs == 2 && DDs > 28 + xz1) return;//超范围
                if ((MMe == 1 || MMe == 3 || MMe == 5 || MMe == 7 || MMe == 8 || MMe == 10 || MMe == 12) && DDe > 31) return;//超范围
                if ((MMe == 4 || MMe == 6 || MMe == 9 || MMe == 11 ) && DDe > 30) return;//超范围
                if (MMe == 2 && DDe > 28 + xz2) return;//超范围                             

                ii = 0;
                bx1 = YYs * 10000000000;                bx2 = MMs * 100000000;                bx3 = DDs * 1000000;
                bx4 = HHours * 10000;                bx5 = MMins * 100;                tmp1 = bx1 + bx2 + bx3 + bx4 +bx5 + SSecs;
                bx1 = YYe * 10000000000;                 bx2 = MMe * 100000000;               bx3 = DDe * 1000000;
                bx4 = HHoure * 10000;                bx5 = MMine * 100;                tmp2 = bx1 + bx2 + bx3 + bx4 + bx5 + SSece; 
                while (tmp1 <= tmp2)
                {
                    Xlfh.Add(tmp1.ToString());
                    SSecs = SSecs + 1;
                    if (SSecs > 59)
                    {
                        SSecs = SSecs - 60;                        MMins = MMins + 1;
                    }
                    if (MMins > 59)
                    {
                        MMins = MMins - 60; HHours = HHours + 1;
                    }
                    if (HHours > 23)
                    {
                        HHours = HHours - 24; DDs = DDs + 1;
                    }
                    if ((MMs == 1 || MMs == 3 || MMs == 5 || MMs == 7 || MMs == 8 || MMs == 10|| MMs == 12) && DDs > 31)
                    {
                        DDs = DDs - 31; MMs = MMs + 1;
                    }
                    if ((MMs == 4 || MMs == 6 || MMs == 9 || MMs == 11) && DDs > 30)
                    {
                        DDs = DDs - 30; MMs = MMs + 1;
                    }
                    if (MMs == 2 && DDs > 28 + xz1)
                    {
                        DDs = DDs - 28 - xz1; MMs = MMs + 1;
                    }
                    if (MMs > 12)
                    {
                        MMs = MMs - 12; YYs = YYs + 1;
                        Math.DivRem(YYs, 4, out tt1); Math.DivRem(YYs, 100, out tt2); Math.DivRem(YYs, 400, out tt3);
                        if ((tt1 == 0 && tt2 != 0) || tt3 == 0) xz1 = 1;//闰年
                        else xz1 = 0;
                    }
                    bx1 = YYs * 10000000000; bx2 = MMs * 100000000; bx3 = DDs * 1000000;
                    bx4 = HHours * 10000; bx5 = MMins * 100; tmp1 = bx1 + bx2 + bx3 + bx4 + bx5 + SSecs;
                    ii = ii + 1;
                }
            }
            else return;
        }
    }
}
