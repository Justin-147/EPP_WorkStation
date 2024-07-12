//计算潮汐计算里涉及的天文元素
//作者：刘琦
//最后调试时间：2012.05.25
//参考文献：
//郗钦文等，《固体潮汐与引潮参数》、《精密引潮位展开及某些诠释》、《新的引潮位完全展开》、《固体潮汐理论值计算》
//骆鸣津等，《地层绝对应力测量与钻孔应变测量》一书P27
using System;
using System.Collections.Generic;
using System.Text;

namespace liuqi
{
    /// <summary>
    /// 计算潮汐计算里涉及的天文元素
    /// </summary>
    public class lqTwys
    {
        int IHS = 8;//IHS表示时间系统，8表示使用的参数是北京时，0表示使用的是世界时
        int DT = 67;//郗老师原程序采用56S，源自《精密引潮位展开及某些诠释》
        //56S为1988年外推地球力学时TDT与世界时UT1之差，计算时应采用质心力学时TDB，应TDB与TDT仅存微小周期性变化，故不区分。
        //根据《天文算法》，2000年插值约67S

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
                + "------------------------------------------------------\r\n"
                + "lqJD输入要计算的日期时间、用来存放J2000.历元儒略世纪数的变量、存放儒略数的变量、存放儒略数小数部分的变量。\r\n"
                + "lqYS计算潮汐分析里需要用到的部分天文元素(返回单位为度),J2000.历元。\r\n"
                + "lqYS1返回固定台站的公共参数。\r\n"
                + "lqYS2计算潮汐分析里所需要的部分天文参数组合。\r\n";
                          
            return fh;
        }

        /////////////////////////////////////////////////////////////
        ///主功能函数区
        /////////////////////////////////////////////////////////////
        /// <summary>
        /// 计算儒略数JD和J2000.历元的儒略世纪数，即自2000年1月1日12时（JD=2451545.0TDB）算起的世纪数
        /// </summary>
        /// <param name="DateTimeIn">日期时间</param>
        /// <param name="JCN">J2000.历元的儒略世纪数</param>
        /// <param name="JD">儒略数</param>
        /// <param name="XS">儒略数小数部分</param>
        public static void lqJD(string DateTimeIn, ref double JCN, ref double JD, ref double XS)
        {
            int len = DateTimeIn.Length;
            int YY, MM, DD, HHour, MMin, SSec;
            int tt1, tt2, tt3, xz;
            MM = 1; DD = 1; HHour = 0; MMin = 0; SSec = 0;

            if (len == 4)//到年
            {
                YY = int.Parse(DateTimeIn);
            }
            else if (len == 6)//到月
            {
                MM = int.Parse(DateTimeIn.Substring(4, 2));
                if (MM > 12 || MM == 0) return;
                YY = int.Parse(DateTimeIn.Substring(0, 4));
            }
            else if (len == 8)//到日
            {
                MM = int.Parse(DateTimeIn.Substring(4, 2));
                if (MM > 12 || MM == 0) return;
                DD = int.Parse(DateTimeIn.Substring(6, 2));
                if (DD == 0 ) return;

                YY = int.Parse(DateTimeIn.Substring(0, 4));
                Math.DivRem(YY, 4, out tt1); Math.DivRem(YY, 100, out tt2); Math.DivRem(YY, 400, out tt3);
                if ((tt1 == 0 && tt2 != 0) || tt3 == 0) xz = 1;//闰年
                else xz = 0;                
                if ((MM == 1 || MM == 3 || MM == 5 || MM == 7 || MM == 8 || MM == 10 || MM == 12) && DD > 31) return;//超范围
                if ((MM == 4 || MM == 6 || MM == 9 || MM == 11) && DD > 30) return;//超范围
                if (MM == 2 && DD > 28 + xz) return;//超范围                
            }
            else if (len == 10)//到时
            {
                MM = int.Parse(DateTimeIn.Substring(4, 2));
                if (MM > 12 || MM == 0) return;
                DD = int.Parse(DateTimeIn.Substring(6, 2));
                if (DD == 0) return;
                HHour = int.Parse(DateTimeIn.Substring(8, 2));
                if (HHour > 23) return;

                YY = int.Parse(DateTimeIn.Substring(0, 4));
                Math.DivRem(YY, 4, out tt1); Math.DivRem(YY, 100, out tt2); Math.DivRem(YY, 400, out tt3);
                if ((tt1 == 0 && tt2 != 0) || tt3 == 0) xz = 1;//闰年
                else xz = 0;
                if ((MM == 1 || MM == 3 || MM == 5 || MM == 7 || MM == 8 || MM == 10 || MM == 12) && DD > 31) return;//超范围
                if ((MM == 4 || MM == 6 || MM == 9 || MM == 11) && DD > 30) return;//超范围
                if (MM == 2 && DD > 28 + xz) return;//超范围          
            }
            else if (len == 12)//到分
            {
                MM = int.Parse(DateTimeIn.Substring(4, 2));
                if (MM > 12 || MM == 0) return;
                DD = int.Parse(DateTimeIn.Substring(6, 2));
                if (DD == 0) return;
                HHour = int.Parse(DateTimeIn.Substring(8, 2));
                if (HHour > 23) return;
                MMin = int.Parse(DateTimeIn.Substring(10, 2));
                if (MMin > 59) return;

                YY = int.Parse(DateTimeIn.Substring(0, 4));
                Math.DivRem(YY, 4, out tt1); Math.DivRem(YY, 100, out tt2); Math.DivRem(YY, 400, out tt3);
                if ((tt1 == 0 && tt2 != 0) || tt3 == 0) xz = 1;//闰年
                else xz = 0;
                if ((MM == 1 || MM == 3 || MM == 5 || MM == 7 || MM == 8 || MM == 10 || MM == 12) && DD > 31) return;//超范围
                if ((MM == 4 || MM == 6 || MM == 9 || MM == 11) && DD > 30) return;//超范围
                if (MM == 2 && DD > 28 + xz) return;//超范围                 
            }
            else if (len == 14)//到秒
            {
                MM = int.Parse(DateTimeIn.Substring(4, 2));
                if (MM > 12 || MM == 0) return;
                DD = int.Parse(DateTimeIn.Substring(6, 2));
                if (DD == 0) return;
                HHour = int.Parse(DateTimeIn.Substring(8, 2));
                if (HHour > 23) return;
                MMin = int.Parse(DateTimeIn.Substring(10, 2));
                if (MMin > 59) return;
                SSec = int.Parse(DateTimeIn.Substring(12, 2));
                if (SSec > 59) return;

                YY = int.Parse(DateTimeIn.Substring(0, 4));
                Math.DivRem(YY, 4, out tt1); Math.DivRem(YY, 100, out tt2); Math.DivRem(YY, 400, out tt3);
                if ((tt1 == 0 && tt2 != 0) || tt3 == 0) xz = 1;//闰年
                else xz = 0;
                if ((MM == 1 || MM == 3 || MM == 5 || MM == 7 || MM == 8 || MM == 10 || MM == 12) && DD > 31) return;//超范围
                if ((MM == 4 || MM == 6 || MM == 9 || MM == 11) && DD > 30) return;//超范围
                if (MM == 2 && DD > 28 + xz) return;//超范围
            }
            else return;

            int ff, gg;
            if (MM >= 3)
            {
                ff = YY; gg = MM;
            }
            else
            {
                ff = YY - 1; gg = MM + 12;
            }

            double mid1 = Math.Floor(365.25 * ff);
            double mid2 = Math.Floor(30.6001 * (gg + 1));
            double A = 2 - Math.Floor(ff / 100.0) + Math.Floor(ff / 400.0);
            double J = mid1 + mid2 + DD + A + 1720994.5;
            XS = (HHour - new lqTwys().IHS) / 24.0 + MMin / 1440.0 + (SSec + new lqTwys().DT) / 86400.0;//儒略数小数部分

            JD = J + XS;//儒略数
            double DJ = JD - 2451545.0;//自2000年1月1日12时（JD=2451545.0TDB）算起的儒略数
            JCN = DJ / 36525.0;//J2000.历元的儒略世纪数
        }
        /////////////////////////////////////////////////////////////
        /// <summary>
        /// 计算潮汐分析里需要用到的天文元素,J2000.历元
        /// </summary>
        /// <param name="DateTimeIn">日期时间</param>
        /// <param name="FL">经度（度）</param>
        /// <param name="S">月亮平黄经（度）</param>
        /// <param name="H">太阳平黄经（度）</param>
        /// <param name="P">月亮近地点平黄经（度）</param>
        /// <param name="N">月亮升交点平黄经（度）</param>
        /// <param name="PS">太阳近地点平黄经（度）</param>
        /// <param name="EE">平黄赤交角（度）</param>
        /// <param name="TZ">平月亮地方时（度）</param>
        /// <param name="TAOT">调和分析里调用的一个量（度）</param>
        public static void lqYS(string DateTimeIn, double FL, out double S, out double H, out double P, out double N, out double PS, out double EE, out double TZ, out double TAOT)
        {
            S = 0; H = 0; P = 0; TZ = 0;
            N = 0; PS = 0; EE = 0; TAOT=0;
            double T = -999999, tmp = -999999, XS = 0.0;
            liuqi.lqTwys.lqJD(DateTimeIn, ref T, ref tmp, ref XS);
            if (T == -999999) return;
            double H0 = 180 / Math.PI;
            S = 218.31643 + (481267.88128 - (0.00161 - 0.000005 * T) * T) * T;//月亮平黄经   
            H = 280.46607 + (36000.76980 + 0.00030 * T) * T;//太阳平黄经
            P = 83.35345 + (4069.01388 - (0.01031 + 0.00001 * T) * T) * T;//月亮近地点平黄经
            N = 125.04452 - (1934.13626 - (0.00207 + 0.000002 * T) * T) * T;//月亮升交点平黄经
            PS = 282.93835 + (1.71946 + (0.00046 + 0.000003 * T) * T) * T;//太阳近地点平黄经
            EE = 23.43929 - (0.01300 + (0.00000016 - 0.0000005 * T) * T) * T;//平黄赤交角
            //源自《精密引潮位展开及某些诠释》
            double DL = -0.00478 * Math.Sin(N / H0) - 0.00037 * Math.Sin(2 * H / H0);//黄经章动改正
            //附加改正
            double DS = 0.00396 * Math.Sin((60.57 - 132.87 * T) / H0) + 0.00202 * Math.Sin(N / H0);
            ////////////
            double DH = 0.00178 * Math.Sin((251.39 + 20.20 * T) / H0);
            DH = DH + (1.866 - 0.016 * T) / 3600 * Math.Sin((207.51 + 150.27 * T) / H0);
            DH = DH - 0.00479 * (T + 0.003 * T * T) * Math.Sin((H - PS) / H0);
            DH = DH - 0.00200 * Math.Sin((67.20 + 32964.47 * T) / H0);
            DH = DH - 0.00154 * Math.Sin((16.85 - 45036.89 * T) / H0);
            DH = DH + 0.00134 * Math.Sin((81.51 + 22518.44 * T) / H0);
            DH = DH + 0.00179 * Math.Sin((S - H) / H0);
            ////////////
            double DP = -0.00058 * Math.Sin((71.40 + 20.20 * T) / H0) - 0.00058 * Math.Sin(N / H0);
            double DN = 0.02666 * Math.Sin(N / H0) + 0.00433 * Math.Sin((N + 272.75 - 2.30 * T) / H0) + 0.00052 * Math.Sin((N + 288.75 - 0.90 * T) / H0);
            S = S + DS + DL; S = FX(S); H = H + DH + DL; H = FX(H);
            P = P + DP + DL; P = FX(P); N = N + DN + DL; N = FX(N);
            PS = PS + DL; PS = FX(PS);
            double T1 = T - new lqTwys().DT/ 3600.0 / 876600.0;//UT1
            double rs = (18.6973746 + (2400.0513369 + (0.0000258622 - 0.0000000017222 * T1) * T1) * T1) * 15;//平太阳赤经（转换成角度，赤经的单位是时间，1h=15度）,来源于《精密引潮位展开及某些诠释》
            TZ = XS * 24 * 15 + rs - 180 + FL;//平月亮地方时？
            //郗老师调和分析里调用
            TAOT = XS * 24 * 15 + rs - S + FL;
            TAOT = FX(TAOT);            
        }
        /////////////////////////////////////////////////////////////
        /// <summary>
        /// 返回固定台站的公共参数
        /// </summary>
        /// <param name="latitude">纬度</param>
        /// <param name="longitude">经度</param>
        /// <param name="HH">高程</param>
        /// <param name="Fzhd">角度转弧度要乘的系数</param>
        /// <param name="fi">地心纬度(弧度)</param>
        /// <param name="ddf">地理纬度（弧度）</param>
        /// <param name="pg">pa * gg0</param>
        /// <param name="pg2">pa^2 * gg0</param>
        /// <param name="pa">地心向径/赤道半径</param>
        /// <param name="gg0">平均重力加速度/重力加速度</param>
        public static void lqYS1(string latitude, string longitude, string HH, out double Fzhd,out double fi,out double ddf,out double pg,out double pg2,out double pa,out double gg0)
        {
            double weid = double.Parse(latitude);//纬度
            double jingd = double.Parse(longitude);//经度
            Fzhd = Math.PI / 180;
            fi = weid * Fzhd;//转换成弧度制
            ddf = fi;//地理纬度
            fi = fi - 0.192424 * Fzhd * Math.Sin(2 * fi);//观测站之地心纬度
            //来源于郗老师《固体潮汐与引潮参数》
            pa = 1 - 0.00332479 * Math.Pow(Math.Sin(ddf), 2) + double.Parse(HH) / 6378140;//地心向径/赤道半径，来源于郗老师《固体潮汐与引潮参数》
            gg0 = 1 / (1 + 0.0053024 * Math.Pow(Math.Sin(ddf), 2) - 0.0000059 * Math.Pow(Math.Sin(2 * ddf), 2));//平均重力加速度/重力加速度，来源于郗老师《固体潮汐与引潮参数》
            pg = pa * gg0;
            pg2 = Math.Pow(pa, 2) * gg0;
        }
        /////////////////////////////////////////////////////////////
        /// <summary>
        /// 计算潮汐分析里所需要的部分天文参数组合
        /// </summary>
        /// <param name="s">月亮平黄经（度）</param>
        /// <param name="h">太阳平黄经（度）</param>
        /// <param name="p">月亮近地点平黄经（度）</param>
        /// <param name="n">月亮升交点平黄经（度）</param>
        /// <param name="ps">太阳近地点平黄经（度）</param>
        /// <param name="e">平黄赤交角（度）</param>
        /// <param name="tz">计算时角中间量（度）</param>
        /// <param name="fi">地心纬度(弧度)</param>
        /// <param name="cr">月亮的c/R</param>
        /// <param name="crs">太阳的c/R</param>
        /// <param name="cth">月亮地心天顶距的余弦</param>
        /// <param name="cths">太阳地心天顶距的余弦</param>
        /// <param name="dd1">月亮：赤纬正弦</param>
        /// <param name="dd2">月亮：赤纬余弦*地方时角余弦</param>
        /// <param name="dd3">月亮：赤纬余弦*地方时角正弦</param>
        /// <param name="dd4">太阳：赤纬正弦</param>
        /// <param name="dd5">太阳：赤纬余弦*地方时角余弦</param>
        /// <param name="dd6">太阳：赤纬余弦*地方时角正弦</param>
        /// <param name="dd8">cf * dd1 + sf * dd2</param>
        /// <param name="dd9">cf * dd4 + sf * dd5</param>
        public static void lqYS2(double s,double h, double p, double n,double ps,double e, double tz,double fi,out double cr,out double crs,out double cth,out double cths,out double dd1,out double dd2,out double dd3,out double dd4,out double dd5,out double dd6,out double dd8,out double dd9)
        {
            double x, b, xs;
            double cx, ce, cb,ct, cxs, cts, cf, sx, se, sb, st, sxs, sts, sf;
            double taos,tao;
            double dd0, dd7;

            //calculating  x, b, cr,xs, bs, crs
            //下列公式部分来源于郗老师《固体潮汐理论值计算》
            x = s - 0.0032 * Math.Sin(h - ps) - 0.001 * Math.Sin(2 * h - 2 * p) + 0.001 * Math.Sin(s - 3 * h + p + ps) + 0.0222 * Math.Sin(s - 2 * h + p);
            x = x + 0.0007 * Math.Sin(s - h - p + ps) - 0.0006 * Math.Sin(s - h) + 0.1098 * Math.Sin(s - p) - 0.0005 * Math.Sin(s + h - p - ps);
            x = x + 0.0008 * Math.Sin(2 * s - 3 * h + ps) + 0.0115 * Math.Sin(2 * s - 2 * h) + 0.0037 * Math.Sin(2 * s - 2 * p);
            x = x - 0.002 * Math.Sin(2 * s - 2 * n) + 0.0009 * Math.Sin(3 * s - 2 * h - p);//月亮黄经
            b = -0.0048 * Math.Sin(p - n) - 0.0008 * Math.Sin(2 * h - p - n) + 0.003 * Math.Sin(s - 2 * h + n) + 0.0895 * Math.Sin(s - n);
            b = b + 0.001 * Math.Sin(2 * s - 2 * h + p - n) + 0.0049 * Math.Sin(2 * s - p - n) + 0.0006 * Math.Sin(3 * s - 2 * h - n);//月亮黄纬
            cr = 1 + 0.01 * Math.Cos(s - 2 * h + p) + 0.0545 * Math.Cos(s - p) + 0.003 * Math.Cos(2 * s - 2 * p);
            cr = cr + 0.0009 * Math.Cos(3 * s - 2 * h - p) + 0.0006 * Math.Cos(2 * s - 3 * h + ps) + 0.0082 * Math.Cos(2 * s - 2 * h);//月亮的c/R
            crs = 1 + 0.016709 * Math.Cos(h - ps) + 0.000279 * Math.Cos(2 * h - 2 * ps);//太阳的c/R，来源于郗老师《新的引潮位完全展开》
            xs = h + 0.033417 * Math.Sin(h - ps) + 0.000349 * Math.Sin(2 * h - 2 * ps);//太阳的黄经，来源于郗老师《新的引潮位完全展开》
            
            //bs = 0;//太阳的黄纬
            //上列公式部分来源于郗老师《固体潮汐理论值计算》

            ///////////////////////////////////////////////////////////////////////////////////////////////////////
            ce = Math.Cos(e); cb = Math.Cos(b); cx = Math.Cos(x); 
            cxs = Math.Cos(xs); cf = Math.Cos(fi);            
            se = Math.Sin(e); sb = Math.Sin(b); sx = Math.Sin(x);
            sxs = Math.Sin(xs); sf = Math.Sin(fi);          

            dd0 = ce * cb * sx - se * sb;//月亮：赤纬余弦*赤经正弦，来源于郗老师《固体潮汐理论值计算》
            dd1 = se * cb * sx + ce * sb;//月亮：赤纬正弦，来源于郗老师《固体潮汐理论值计算》
            dd4 = se * sxs;//bs=0，太阳：赤纬正弦，来源于郗老师《固体潮汐理论值计算》
            dd7 = ce * sxs;//太阳：赤纬余弦*赤经正弦

            tao = tz;            taos = tz;
            ////////////////////////////
             
            ct = Math.Cos(tao); cts = Math.Cos(taos);
            st = Math.Sin(tao); sts = Math.Sin(taos);            

            dd2 = dd0 * st + cb * cx * ct;//月亮：赤纬余弦*地方时角余弦，推导得，这里我做了修改
            dd3 = cb * cx * st - ct * dd0;//月亮：赤纬余弦*地方时角正弦，推导得，这里我做了修改
            dd5 = cxs * cts + sts * sxs * ce;//bs=0，太阳：赤纬余弦*地方时角余弦，推导得，这里我做了修改
            dd6 = cxs * sts - cts * sxs * ce;//bs=0，太阳：赤纬余弦*地方时角正弦，推导得，这里我做了修改
            cth = sf * dd1 + cf * dd2;//月亮地心天顶距的余弦
            dd8 = cf * dd1 - sf * dd2;
            cths = sf * dd4 + cf * dd5;//太阳地心天顶距的余弦
            dd9 = cf * dd4 - sf * dd5;
        }
        /////////////////////////////////////////////////////////////
        ///辅助能函数区
        /////////////////////////////////////////////////////////////
        /// <summary>
        /// 去掉多余的360度周期
        /// </summary>
        public static double FX(double datain)
        {
            double y = datain - Math.Floor(datain / 360.0) * 360.0;//%去掉多余的360度周期
            return y;
        }
        

    }
}