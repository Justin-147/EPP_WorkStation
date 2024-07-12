using System;
using System.Collections.Generic;
using System.Text;

namespace liuqi
{
    public class lqSP
    {
        /// <summary>
        /// 由分钟值数据抽取成整时值数据
        /// </summary>
        /// <param name="names">输入文件名</param>
        public static void lqCqM2H(string[] names)
        {
            string fname,tmp;
            string[] ctmp,cctmp;
            int num1;

            for (int ii = 0; ii < names.Length; ii++)
            {
                fname = names[ii];                
                System.IO.StreamReader InFile = new System.IO.StreamReader(fname);
                System.IO.StreamWriter Fileout = new System.IO.StreamWriter(fname.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries)[0] + "_H.txt", false);
                tmp = InFile.ReadToEnd();
                ctmp = tmp.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);  
                num1 = ctmp.Length;
                for (int jj = 0; jj < num1; jj++)
                {
                    cctmp = ctmp[jj].Split(new string[] { " ", "\t", "," }, StringSplitOptions.RemoveEmptyEntries);
                    if(cctmp[0].Substring(10,2)=="00")
                    {
                        Fileout.WriteLine(cctmp[0].Substring(0,10) + ' ' + cctmp[1]);
                    }                       
                }
                InFile.Close();
                Fileout.Close();
                tmp = null;                ctmp = null;                cctmp = null;
            }
            return;
        }

        /// <summary>
        /// 替换文件中的指定字符
        /// </summary>
        /// <param name="names">输入文件名</param>
        /// <param name="oldone">原始字符</param>
        /// <param name="newone">替换字符</param>
        public static void lqThzf(string[] names, string oldone, string newone)
        {
            string fname, tmp;
            
            for (int ii = 0; ii < names.Length; ii++)
            {
                fname = names[ii];
                System.IO.StreamReader InFile = new System.IO.StreamReader(fname);
                System.IO.StreamWriter Fileout = new System.IO.StreamWriter(fname.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries)[0] + "_替换字符.txt", false);
                tmp = InFile.ReadToEnd();
                tmp = tmp.Replace(oldone, newone);
                Fileout.Write(tmp);
                InFile.Close();                Fileout.Close();
                tmp = null;
            }
            return;
        }

        /// <summary>
        /// 指定目录下选择文件
        /// </summary>
        /// <param name="ABpath">指定目录</param>
        /// <returns>返回所有文件名</returns>
        public static string[] lqXzwj(string ABpath)
        {
            string[] FileName;
            FileName = System.IO.Directory.GetFiles(ABpath);
            return FileName;
        }

        /// <summary>
        /// 将两文件拼接
        /// 如果选择时间+数据拼接方式，需要人工保证头文件尾和尾文件对应时间处不能为缺数
        /// </summary>
        /// <param name="File1">头文件</param>
        /// <param name="File2">尾文件</param>
        /// <param name="Fout">拼接文件</param>
        /// <param name="xzfs">拼接方式</param>
        /// <param name="QS">缺数标记</param>
        public static void lqPjwj(string File1,string File2,string Fout,int xzfs,string QS)
        {          
            string tmp1=null,tmp2=null;
            string[] ctmp=null, cctmp11=null, cctmp12,cctmp21=null,cctmp22=null;
            double jcs,ttmp;
            char dl;
            System.IO.StreamReader InFile1 = new System.IO.StreamReader(File1);
            System.IO.StreamReader InFile2 = new System.IO.StreamReader(File2);
            System.IO.StreamWriter Fileout = new System.IO.StreamWriter(Fout);
            tmp1 = InFile1.ReadToEnd();            tmp2 = InFile2.ReadToEnd();
            if (xzfs == 2)
            {
                if (tmp1[tmp1.Length-1]!='\n')
                    Fileout.Write(tmp1+"\r\n"+tmp2);
                else
                    Fileout.Write(tmp1 + tmp2);
            }
            else if (xzfs==1)
            {
                ctmp = tmp1.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                cctmp11 = ctmp[ctmp.Length-1].Split(new string[] { " ", "\t", "," }, StringSplitOptions.RemoveEmptyEntries);
                ctmp = tmp2.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                int wz = -1;
                for (int jj = 0; jj < ctmp.Length; jj++)
                {
                    cctmp21 = ctmp[jj].Split(new string[] { " ", "\t", "," }, StringSplitOptions.RemoveEmptyEntries);
                    if (cctmp21[0].CompareTo(cctmp11[0])>0)
                    {
                        wz = jj; break;
                    }
                }
                Fileout.Write(tmp1);
                if (tmp1[tmp1.Length - 1] != '\n')
                    Fileout.Write("\r\n");
                if (wz != -1)
                {
                    for (int ii = wz; ii < ctmp.Length; ii++)
                    {
                        Fileout.WriteLine(ctmp[ii]);
                    }
                }           
            }
            else if (xzfs == 0)
            {
                ctmp = tmp1.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                cctmp11 = ctmp[ctmp.Length - 1].Split(new string[] { " ", "\t", "," }, StringSplitOptions.RemoveEmptyEntries);
                cctmp12 = ctmp[ctmp.Length - 2].Split(new string[] { " ", "\t", "," }, StringSplitOptions.RemoveEmptyEntries);
                ctmp = tmp2.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                int wz = -1;

                for (int jj = 0; jj < ctmp.Length; jj++)
                {
                    cctmp21 = ctmp[jj].Split(new string[] { " ", "\t", "," }, StringSplitOptions.RemoveEmptyEntries);
                    if (cctmp21[0].CompareTo(cctmp11[0]) > 0)
                    {
                        wz = jj; break;
                    }
                }
                Fileout.Write(tmp1);
                if (tmp1[tmp1.Length - 1] != '\n')
                    Fileout.Write("\r\n");
                
                if (wz != -1)
                {
                    string fm=null;
                    if (cctmp11[0].Length == 8)
                    {
                        fm = "yyyyMMdd";
                    }
                    else if (cctmp11[0].Length == 10)
                    {
                        fm = "yyyyMMddHH";
                    }
                    else if (cctmp11[0].Length == 12)
                    {
                        fm = "yyyyMMddHHmm";
                    }
                    else if (cctmp11[0].Length == 14)
                    {
                        fm = "yyyyMMddHHmmss";
                    }
                    DateTime d21 = DateTime.ParseExact(cctmp21[0], fm, System.Globalization.CultureInfo.CurrentCulture);
                    DateTime d11 = DateTime.ParseExact(cctmp11[0], fm, System.Globalization.CultureInfo.CurrentCulture);
                    DateTime d12 = DateTime.ParseExact(cctmp12[0], fm, System.Globalization.CultureInfo.CurrentCulture);
                    TimeSpan dd = d21.Subtract(d11);
                    TimeSpan xx = d11.Subtract(d12);
                    double cc = dd.TotalSeconds / xx.TotalSeconds;
                    if (wz == 0)
                    {
                        jcs = (double.Parse(cctmp11[1]) - double.Parse(cctmp12[1])) * cc;        
                        jcs=double.Parse(cctmp11[1])+jcs-double.Parse(cctmp21[1]);
                    }
                    else
                    {
                        cctmp22 = ctmp[wz-1].Split(new string[] { " ", "\t", "," }, StringSplitOptions.RemoveEmptyEntries);
                        if (cctmp22[0].Equals(cctmp11[0]))
                        {
                            jcs = double.Parse(cctmp11[1]) - double.Parse(cctmp22[1]);
                        }
                        else
                        {
                            jcs = (double.Parse(cctmp11[1]) - double.Parse(cctmp12[1])) * cc;
                            jcs = double.Parse(cctmp11[1]) + jcs - double.Parse(cctmp21[1]);
                        }                      
                    }
                    dl = ctmp[wz][cctmp21[0].Length];
                    for (int ii = wz; ii < ctmp.Length; ii++)
                    {
                        cctmp21 = ctmp[ii].Split(new string[] { " ", "\t", "," }, StringSplitOptions.RemoveEmptyEntries);
                        if (cctmp21[1].Equals(QS))
                            ttmp = double.Parse(QS);
                        else
                            ttmp =(double.Parse(cctmp21[1]) + jcs);
                        Fileout.WriteLine(cctmp21[0] + dl + ttmp.ToString());
                    }
                }                
            }
            InFile1.Close();            InFile2.Close();
            Fileout.Close();
            tmp1 = null; tmp2 = null; ctmp = null; cctmp11 = null; cctmp12 = null; cctmp21 = null; cctmp22 = null;
            return;
        }

        /// <summary>
        /// 将原始的一列时间多列数据的文件拆分成若干个一列时间一列数据的文件
        /// </summary>
        /// <param name="names">输入文件名</param>
        public static void lqCqDSJ(string[] names)
        {
            for (int ii = 0; ii < names.Length; ii++)
            {
                string fname, tmp;
                string[] ctmp, cctmp;
                int num1, num2;

                fname = names[ii];
                System.IO.StreamReader InFile = new System.IO.StreamReader(fname);
                
                tmp = InFile.ReadToEnd();
                ctmp = tmp.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                num1 = ctmp.Length;

                cctmp = ctmp[0].Split(new string[] { " ", "\t", "," }, StringSplitOptions.RemoveEmptyEntries);
                num2 = cctmp.Length;
                if (num2>1)
                {
                    string[,] inall = new string[num1,num2];
                    for (int jj = 0; jj < num1; jj++)
                    {
                        cctmp = ctmp[jj].Split(new string[] { " ", "\t", "," }, StringSplitOptions.RemoveEmptyEntries);
                        for (int kk = 0; kk < num2; kk++)
                        {
                            inall[jj, kk] = cctmp[kk];
                        }                        
                    }
                    for (int ll = 1; ll < num2; ll++)
                    {
                        System.IO.StreamWriter Fileout = new System.IO.StreamWriter(fname.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries)[0] + "_"+ll.ToString()+".txt", false);
                        for (int mm = 0; mm < num1; mm++)
                        {
                            Fileout.WriteLine(inall[mm,0] + ' ' + inall[mm,ll]);
                        }
                        Fileout.Close();
                    }
                }
                InFile.Close();               
            }
            return;
        }

        /// <summary>
        /// 用三次多项式标定原数据
        /// </summary>
        /// <param name="names">输入文件名</param>
        /// <param name="k1">一次项系数</param>
        /// <param name="k2">二次项系数</param>
        /// <param name="k3">三次项系数</param>
        /// <param name="C">常数</param>
        /// <param name="QS">缺数标记</param>
        public static void lq3cdxs(string[] names,double k1,double k2,double k3,double C,string QS)
        {
            string fname, tmp;
            string[] ctmp, cctmp;
            int num1;
            double sc,ys;

            for (int ii = 0; ii < names.Length; ii++)
            {
                fname = names[ii];
                System.IO.StreamReader InFile = new System.IO.StreamReader(fname);
                System.IO.StreamWriter Fileout = new System.IO.StreamWriter(fname.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries)[0] + "_3cdxs.txt", false);
                tmp = InFile.ReadToEnd();
                ctmp = tmp.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                num1 = ctmp.Length;
                for (int jj = 0; jj < num1; jj++)
                {
                    cctmp = ctmp[jj].Split(new string[] { " ", "\t", "," }, StringSplitOptions.RemoveEmptyEntries);

                    if (cctmp[1].Equals(QS))
                        Fileout.WriteLine(cctmp[0] + ' ' + cctmp[1]);
                    else
                    {
                        ys = double.Parse(cctmp[1]);
                        sc = ys * k1 + ys * ys * k2 + ys * ys * ys * k3 + C;
                        Fileout.WriteLine(cctmp[0] + ' ' + sc.ToString());
                    }                    
                }
                InFile.Close();
                Fileout.Close();
                tmp = null; ctmp = null; cctmp = null;
            }
            return;
        }

        /// <summary>
        /// 截取数据
        /// </summary>
        /// <param name="names">输入文件名</param>
        /// <param name="ks">开始时间</param>
        /// <param name="js">结束时间</param>
        public static void lqJqsj(string[] names,string ks, string js)
        {
            string fname, tmp;
            string[] ctmp, cctmp;
            int num1,kswz,jswz;
            string ssk, zsk;
            kswz = 0; jswz = 0;

            for (int ii = 0; ii < names.Length; ii++)
            {
                fname = names[ii];
                System.IO.StreamReader InFile = new System.IO.StreamReader(fname);
                
                tmp = InFile.ReadToEnd();
                ctmp = tmp.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                num1 = ctmp.Length;

                cctmp = ctmp[0].Split(new string[] { " ", "\t", "," }, StringSplitOptions.RemoveEmptyEntries);
                ssk=cctmp[0];
                cctmp = ctmp[num1-1].Split(new string[] { " ", "\t", "," }, StringSplitOptions.RemoveEmptyEntries);
                zsk=cctmp[0];

                if (ks.Length != js.Length && ks.Length*js.Length!=0)
                {
                    InFile.Close();
                    tmp = null; ctmp = null; cctmp = null;
                    continue;
                }

                if (ks.Length == 0)
                    kswz = 0;
                if (js.Length == 0)
                    jswz = num1 - 1;

                if (ks.Length != 0)
                {
                    if (ks.Length != ssk.Length)
                    {
                        InFile.Close();
                        tmp = null; ctmp = null; cctmp = null;
                        continue;
                    }
                    else
                    {                        
                        if (ks.CompareTo(ssk) <= 0)
                            kswz = 0;
                        else
                        {
                            if (ks.CompareTo(zsk) > 0)
                            {
                                InFile.Close();
                                tmp = null; ctmp = null; cctmp = null;
                                continue;
                            }
                            else
                            {
                                for (int jj = 1; jj < num1; jj++)
                                {
                                    cctmp = ctmp[jj].Split(new string[] { " ", "\t", "," }, StringSplitOptions.RemoveEmptyEntries);
                                    if (ks.Equals(cctmp[0]))
                                        kswz = jj;
                                } 
                            }
                        }
                    }  
                }    

                if (js.Length != 0)
                {
                    if (js.Length != zsk.Length)
                    {
                        InFile.Close();
                        tmp = null; ctmp = null; cctmp = null;
                        continue;
                    }
                    else
                    {
                        if (js.CompareTo(zsk) >= 0)
                            jswz=num1-1;
                        else
                        {
                            if (js.CompareTo(ssk) < 0)
                            {
                                InFile.Close();
                                tmp = null; ctmp = null; cctmp = null;
                                continue;
                            }
                            else
                            {
                                for (int jj = num1-2; jj > -1; jj--)
                                {
                                    cctmp = ctmp[jj].Split(new string[] { " ", "\t", "," }, StringSplitOptions.RemoveEmptyEntries);
                                    if (js.Equals(cctmp[0]))
                                        jswz = jj;
                                }
                            }
                        }
                    }
                }

                if (kswz <= jswz)
                {
                    System.IO.StreamWriter Fileout = new System.IO.StreamWriter(fname.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries)[0] + "_jq.txt", false);
                    for (int jj = kswz; jj < jswz + 1; jj++)
                    {
                        Fileout.WriteLine(ctmp[jj]);
                    }
                    InFile.Close();
                    Fileout.Close();
                    tmp = null; ctmp = null; cctmp = null;
                }                
            }        
        }
    }
}
