//���㳱ϫ�������漰������Ԫ��
//���ߣ�����
//������ʱ�䣺2012.05.25
//�ο����ף�
//ۭ���ĵȣ������峱ϫ������������������������λչ����ĳЩڹ�͡������µ�����λ��ȫչ�����������峱ϫ����ֵ���㡷
//������ȣ����ز����Ӧ�����������Ӧ�������һ��P27
using System;
using System.Collections.Generic;
using System.Text;

namespace liuqi
{
    /// <summary>
    /// ���㳱ϫ�������漰������Ԫ��
    /// </summary>
    public class lqTwys
    {
        int IHS = 8;//IHS��ʾʱ��ϵͳ��8��ʾʹ�õĲ����Ǳ���ʱ��0��ʾʹ�õ�������ʱ
        int DT = 67;//ۭ��ʦԭ�������56S��Դ�ԡ���������λչ����ĳЩڹ�͡�
        //56SΪ1988�����Ƶ�����ѧʱTDT������ʱUT1֮�����ʱӦ����������ѧʱTDB��ӦTDB��TDT����΢С�����Ա仯���ʲ����֡�
        //���ݡ������㷨����2000���ֵԼ67S

        /////////////////////////////////////////////////////////////
        /// <summary>
        /// ��������
        /// </summary>
        public static string FunctionHelp()
        {
            string fh = "���ߣ�����  �����ӡ�����ʱ�䣺2012.05.25\r\n"
                + "�ο����ף�\r\n"
                + "ۭ���ĵȣ������峱ϫ������������������������λչ����ĳЩڹ�͡������µ�����λ��ȫչ�����������峱ϫ����ֵ���㡷��\r\n"
                + "������ȣ����ز����Ӧ�����������Ӧ�������һ��P27��\r\n"
                + "------------------------------------------------------\r\n"
                + "lqJD����Ҫ���������ʱ�䡢�������J2000.��Ԫ�����������ı���������������ı��������������С�����ֵı�����\r\n"
                + "lqYS���㳱ϫ��������Ҫ�õ��Ĳ�������Ԫ��(���ص�λΪ��),J2000.��Ԫ��\r\n"
                + "lqYS1���ع̶�̨վ�Ĺ���������\r\n"
                + "lqYS2���㳱ϫ����������Ҫ�Ĳ������Ĳ�����ϡ�\r\n";
                          
            return fh;
        }

        /////////////////////////////////////////////////////////////
        ///�����ܺ�����
        /////////////////////////////////////////////////////////////
        /// <summary>
        /// ����������JD��J2000.��Ԫ������������������2000��1��1��12ʱ��JD=2451545.0TDB�������������
        /// </summary>
        /// <param name="DateTimeIn">����ʱ��</param>
        /// <param name="JCN">J2000.��Ԫ������������</param>
        /// <param name="JD">������</param>
        /// <param name="XS">������С������</param>
        public static void lqJD(string DateTimeIn, ref double JCN, ref double JD, ref double XS)
        {
            int len = DateTimeIn.Length;
            int YY, MM, DD, HHour, MMin, SSec;
            int tt1, tt2, tt3, xz;
            MM = 1; DD = 1; HHour = 0; MMin = 0; SSec = 0;

            if (len == 4)//����
            {
                YY = int.Parse(DateTimeIn);
            }
            else if (len == 6)//����
            {
                MM = int.Parse(DateTimeIn.Substring(4, 2));
                if (MM > 12 || MM == 0) return;
                YY = int.Parse(DateTimeIn.Substring(0, 4));
            }
            else if (len == 8)//����
            {
                MM = int.Parse(DateTimeIn.Substring(4, 2));
                if (MM > 12 || MM == 0) return;
                DD = int.Parse(DateTimeIn.Substring(6, 2));
                if (DD == 0 ) return;

                YY = int.Parse(DateTimeIn.Substring(0, 4));
                Math.DivRem(YY, 4, out tt1); Math.DivRem(YY, 100, out tt2); Math.DivRem(YY, 400, out tt3);
                if ((tt1 == 0 && tt2 != 0) || tt3 == 0) xz = 1;//����
                else xz = 0;                
                if ((MM == 1 || MM == 3 || MM == 5 || MM == 7 || MM == 8 || MM == 10 || MM == 12) && DD > 31) return;//����Χ
                if ((MM == 4 || MM == 6 || MM == 9 || MM == 11) && DD > 30) return;//����Χ
                if (MM == 2 && DD > 28 + xz) return;//����Χ                
            }
            else if (len == 10)//��ʱ
            {
                MM = int.Parse(DateTimeIn.Substring(4, 2));
                if (MM > 12 || MM == 0) return;
                DD = int.Parse(DateTimeIn.Substring(6, 2));
                if (DD == 0) return;
                HHour = int.Parse(DateTimeIn.Substring(8, 2));
                if (HHour > 23) return;

                YY = int.Parse(DateTimeIn.Substring(0, 4));
                Math.DivRem(YY, 4, out tt1); Math.DivRem(YY, 100, out tt2); Math.DivRem(YY, 400, out tt3);
                if ((tt1 == 0 && tt2 != 0) || tt3 == 0) xz = 1;//����
                else xz = 0;
                if ((MM == 1 || MM == 3 || MM == 5 || MM == 7 || MM == 8 || MM == 10 || MM == 12) && DD > 31) return;//����Χ
                if ((MM == 4 || MM == 6 || MM == 9 || MM == 11) && DD > 30) return;//����Χ
                if (MM == 2 && DD > 28 + xz) return;//����Χ          
            }
            else if (len == 12)//����
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
                if ((tt1 == 0 && tt2 != 0) || tt3 == 0) xz = 1;//����
                else xz = 0;
                if ((MM == 1 || MM == 3 || MM == 5 || MM == 7 || MM == 8 || MM == 10 || MM == 12) && DD > 31) return;//����Χ
                if ((MM == 4 || MM == 6 || MM == 9 || MM == 11) && DD > 30) return;//����Χ
                if (MM == 2 && DD > 28 + xz) return;//����Χ                 
            }
            else if (len == 14)//����
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
                if ((tt1 == 0 && tt2 != 0) || tt3 == 0) xz = 1;//����
                else xz = 0;
                if ((MM == 1 || MM == 3 || MM == 5 || MM == 7 || MM == 8 || MM == 10 || MM == 12) && DD > 31) return;//����Χ
                if ((MM == 4 || MM == 6 || MM == 9 || MM == 11) && DD > 30) return;//����Χ
                if (MM == 2 && DD > 28 + xz) return;//����Χ
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
            XS = (HHour - new lqTwys().IHS) / 24.0 + MMin / 1440.0 + (SSec + new lqTwys().DT) / 86400.0;//������С������

            JD = J + XS;//������
            double DJ = JD - 2451545.0;//��2000��1��1��12ʱ��JD=2451545.0TDB�������������
            JCN = DJ / 36525.0;//J2000.��Ԫ������������
        }
        /////////////////////////////////////////////////////////////
        /// <summary>
        /// ���㳱ϫ��������Ҫ�õ�������Ԫ��,J2000.��Ԫ
        /// </summary>
        /// <param name="DateTimeIn">����ʱ��</param>
        /// <param name="FL">���ȣ��ȣ�</param>
        /// <param name="S">����ƽ�ƾ����ȣ�</param>
        /// <param name="H">̫��ƽ�ƾ����ȣ�</param>
        /// <param name="P">�������ص�ƽ�ƾ����ȣ�</param>
        /// <param name="N">����������ƽ�ƾ����ȣ�</param>
        /// <param name="PS">̫�����ص�ƽ�ƾ����ȣ�</param>
        /// <param name="EE">ƽ�Ƴཻ�ǣ��ȣ�</param>
        /// <param name="TZ">ƽ�����ط�ʱ���ȣ�</param>
        /// <param name="TAOT">���ͷ�������õ�һ�������ȣ�</param>
        public static void lqYS(string DateTimeIn, double FL, out double S, out double H, out double P, out double N, out double PS, out double EE, out double TZ, out double TAOT)
        {
            S = 0; H = 0; P = 0; TZ = 0;
            N = 0; PS = 0; EE = 0; TAOT=0;
            double T = -999999, tmp = -999999, XS = 0.0;
            liuqi.lqTwys.lqJD(DateTimeIn, ref T, ref tmp, ref XS);
            if (T == -999999) return;
            double H0 = 180 / Math.PI;
            S = 218.31643 + (481267.88128 - (0.00161 - 0.000005 * T) * T) * T;//����ƽ�ƾ�   
            H = 280.46607 + (36000.76980 + 0.00030 * T) * T;//̫��ƽ�ƾ�
            P = 83.35345 + (4069.01388 - (0.01031 + 0.00001 * T) * T) * T;//�������ص�ƽ�ƾ�
            N = 125.04452 - (1934.13626 - (0.00207 + 0.000002 * T) * T) * T;//����������ƽ�ƾ�
            PS = 282.93835 + (1.71946 + (0.00046 + 0.000003 * T) * T) * T;//̫�����ص�ƽ�ƾ�
            EE = 23.43929 - (0.01300 + (0.00000016 - 0.0000005 * T) * T) * T;//ƽ�Ƴཻ��
            //Դ�ԡ���������λչ����ĳЩڹ�͡�
            double DL = -0.00478 * Math.Sin(N / H0) - 0.00037 * Math.Sin(2 * H / H0);//�ƾ��¶�����
            //���Ӹ���
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
            double rs = (18.6973746 + (2400.0513369 + (0.0000258622 - 0.0000000017222 * T1) * T1) * T1) * 15;//ƽ̫���ྭ��ת���ɽǶȣ��ྭ�ĵ�λ��ʱ�䣬1h=15�ȣ�,��Դ�ڡ���������λչ����ĳЩڹ�͡�
            TZ = XS * 24 * 15 + rs - 180 + FL;//ƽ�����ط�ʱ��
            //ۭ��ʦ���ͷ��������
            TAOT = XS * 24 * 15 + rs - S + FL;
            TAOT = FX(TAOT);            
        }
        /////////////////////////////////////////////////////////////
        /// <summary>
        /// ���ع̶�̨վ�Ĺ�������
        /// </summary>
        /// <param name="latitude">γ��</param>
        /// <param name="longitude">����</param>
        /// <param name="HH">�߳�</param>
        /// <param name="Fzhd">�Ƕ�ת����Ҫ�˵�ϵ��</param>
        /// <param name="fi">����γ��(����)</param>
        /// <param name="ddf">����γ�ȣ����ȣ�</param>
        /// <param name="pg">pa * gg0</param>
        /// <param name="pg2">pa^2 * gg0</param>
        /// <param name="pa">������/����뾶</param>
        /// <param name="gg0">ƽ���������ٶ�/�������ٶ�</param>
        public static void lqYS1(string latitude, string longitude, string HH, out double Fzhd,out double fi,out double ddf,out double pg,out double pg2,out double pa,out double gg0)
        {
            double weid = double.Parse(latitude);//γ��
            double jingd = double.Parse(longitude);//����
            Fzhd = Math.PI / 180;
            fi = weid * Fzhd;//ת���ɻ�����
            ddf = fi;//����γ��
            fi = fi - 0.192424 * Fzhd * Math.Sin(2 * fi);//�۲�վ֮����γ��
            //��Դ��ۭ��ʦ�����峱ϫ������������
            pa = 1 - 0.00332479 * Math.Pow(Math.Sin(ddf), 2) + double.Parse(HH) / 6378140;//������/����뾶����Դ��ۭ��ʦ�����峱ϫ������������
            gg0 = 1 / (1 + 0.0053024 * Math.Pow(Math.Sin(ddf), 2) - 0.0000059 * Math.Pow(Math.Sin(2 * ddf), 2));//ƽ���������ٶ�/�������ٶȣ���Դ��ۭ��ʦ�����峱ϫ������������
            pg = pa * gg0;
            pg2 = Math.Pow(pa, 2) * gg0;
        }
        /////////////////////////////////////////////////////////////
        /// <summary>
        /// ���㳱ϫ����������Ҫ�Ĳ������Ĳ������
        /// </summary>
        /// <param name="s">����ƽ�ƾ����ȣ�</param>
        /// <param name="h">̫��ƽ�ƾ����ȣ�</param>
        /// <param name="p">�������ص�ƽ�ƾ����ȣ�</param>
        /// <param name="n">����������ƽ�ƾ����ȣ�</param>
        /// <param name="ps">̫�����ص�ƽ�ƾ����ȣ�</param>
        /// <param name="e">ƽ�Ƴཻ�ǣ��ȣ�</param>
        /// <param name="tz">����ʱ���м������ȣ�</param>
        /// <param name="fi">����γ��(����)</param>
        /// <param name="cr">������c/R</param>
        /// <param name="crs">̫����c/R</param>
        /// <param name="cth">���������춥�������</param>
        /// <param name="cths">̫�������춥�������</param>
        /// <param name="dd1">��������γ����</param>
        /// <param name="dd2">��������γ����*�ط�ʱ������</param>
        /// <param name="dd3">��������γ����*�ط�ʱ������</param>
        /// <param name="dd4">̫������γ����</param>
        /// <param name="dd5">̫������γ����*�ط�ʱ������</param>
        /// <param name="dd6">̫������γ����*�ط�ʱ������</param>
        /// <param name="dd8">cf * dd1 + sf * dd2</param>
        /// <param name="dd9">cf * dd4 + sf * dd5</param>
        public static void lqYS2(double s,double h, double p, double n,double ps,double e, double tz,double fi,out double cr,out double crs,out double cth,out double cths,out double dd1,out double dd2,out double dd3,out double dd4,out double dd5,out double dd6,out double dd8,out double dd9)
        {
            double x, b, xs;
            double cx, ce, cb,ct, cxs, cts, cf, sx, se, sb, st, sxs, sts, sf;
            double taos,tao;
            double dd0, dd7;

            //calculating  x, b, cr,xs, bs, crs
            //���й�ʽ������Դ��ۭ��ʦ�����峱ϫ����ֵ���㡷
            x = s - 0.0032 * Math.Sin(h - ps) - 0.001 * Math.Sin(2 * h - 2 * p) + 0.001 * Math.Sin(s - 3 * h + p + ps) + 0.0222 * Math.Sin(s - 2 * h + p);
            x = x + 0.0007 * Math.Sin(s - h - p + ps) - 0.0006 * Math.Sin(s - h) + 0.1098 * Math.Sin(s - p) - 0.0005 * Math.Sin(s + h - p - ps);
            x = x + 0.0008 * Math.Sin(2 * s - 3 * h + ps) + 0.0115 * Math.Sin(2 * s - 2 * h) + 0.0037 * Math.Sin(2 * s - 2 * p);
            x = x - 0.002 * Math.Sin(2 * s - 2 * n) + 0.0009 * Math.Sin(3 * s - 2 * h - p);//�����ƾ�
            b = -0.0048 * Math.Sin(p - n) - 0.0008 * Math.Sin(2 * h - p - n) + 0.003 * Math.Sin(s - 2 * h + n) + 0.0895 * Math.Sin(s - n);
            b = b + 0.001 * Math.Sin(2 * s - 2 * h + p - n) + 0.0049 * Math.Sin(2 * s - p - n) + 0.0006 * Math.Sin(3 * s - 2 * h - n);//������γ
            cr = 1 + 0.01 * Math.Cos(s - 2 * h + p) + 0.0545 * Math.Cos(s - p) + 0.003 * Math.Cos(2 * s - 2 * p);
            cr = cr + 0.0009 * Math.Cos(3 * s - 2 * h - p) + 0.0006 * Math.Cos(2 * s - 3 * h + ps) + 0.0082 * Math.Cos(2 * s - 2 * h);//������c/R
            crs = 1 + 0.016709 * Math.Cos(h - ps) + 0.000279 * Math.Cos(2 * h - 2 * ps);//̫����c/R����Դ��ۭ��ʦ���µ�����λ��ȫչ����
            xs = h + 0.033417 * Math.Sin(h - ps) + 0.000349 * Math.Sin(2 * h - 2 * ps);//̫���Ļƾ�����Դ��ۭ��ʦ���µ�����λ��ȫչ����
            
            //bs = 0;//̫���Ļ�γ
            //���й�ʽ������Դ��ۭ��ʦ�����峱ϫ����ֵ���㡷

            ///////////////////////////////////////////////////////////////////////////////////////////////////////
            ce = Math.Cos(e); cb = Math.Cos(b); cx = Math.Cos(x); 
            cxs = Math.Cos(xs); cf = Math.Cos(fi);            
            se = Math.Sin(e); sb = Math.Sin(b); sx = Math.Sin(x);
            sxs = Math.Sin(xs); sf = Math.Sin(fi);          

            dd0 = ce * cb * sx - se * sb;//��������γ����*�ྭ���ң���Դ��ۭ��ʦ�����峱ϫ����ֵ���㡷
            dd1 = se * cb * sx + ce * sb;//��������γ���ң���Դ��ۭ��ʦ�����峱ϫ����ֵ���㡷
            dd4 = se * sxs;//bs=0��̫������γ���ң���Դ��ۭ��ʦ�����峱ϫ����ֵ���㡷
            dd7 = ce * sxs;//̫������γ����*�ྭ����

            tao = tz;            taos = tz;
            ////////////////////////////
             
            ct = Math.Cos(tao); cts = Math.Cos(taos);
            st = Math.Sin(tao); sts = Math.Sin(taos);            

            dd2 = dd0 * st + cb * cx * ct;//��������γ����*�ط�ʱ�����ң��Ƶ��ã������������޸�
            dd3 = cb * cx * st - ct * dd0;//��������γ����*�ط�ʱ�����ң��Ƶ��ã������������޸�
            dd5 = cxs * cts + sts * sxs * ce;//bs=0��̫������γ����*�ط�ʱ�����ң��Ƶ��ã������������޸�
            dd6 = cxs * sts - cts * sxs * ce;//bs=0��̫������γ����*�ط�ʱ�����ң��Ƶ��ã������������޸�
            cth = sf * dd1 + cf * dd2;//���������춥�������
            dd8 = cf * dd1 - sf * dd2;
            cths = sf * dd4 + cf * dd5;//̫�������춥�������
            dd9 = cf * dd4 - sf * dd5;
        }
        /////////////////////////////////////////////////////////////
        ///�����ܺ�����
        /////////////////////////////////////////////////////////////
        /// <summary>
        /// ȥ�������360������
        /// </summary>
        public static double FX(double datain)
        {
            double y = datain - Math.Floor(datain / 360.0) * 360.0;//%ȥ�������360������
            return y;
        }
        

    }
}