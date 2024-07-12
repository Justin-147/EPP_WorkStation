using System;
using System.Collections.Generic;
using System.Text;

namespace liuqi
{
    public class lqDataTrans
    {
        /// <summary>
        /// 池顺良格式的分钟值数据
        /// </summary>
        /// <param name="names">输入文件名</param>
        /// <param name="qs">缺数标记</param>
        public static void lqDataChi(string[] names,string qs)
        {
            string[] ctmp;
            string fname, tmp, datej;
            int num1;
            DateTime dd;
            int[] numu = new int[names.Length];
            if (names.Length > 1)
            {
                if (names[0].CompareTo(names[1]) > 0)
                {
                    for (int ij = 0; ij < names.Length - 1; ij++)
                    {
                        numu[ij] = ij + 1;
                    }
                    numu[names.Length - 1] = 0;
                }
                else
                {
                    for (int ij = 0; ij < names.Length; ij++)
                    {
                        numu[ij] = ij;
                    }
                }
            }
            else
            {
                numu[0] = 0;
            }
            System.IO.StreamWriter Fileout1 = new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\" + "第1分量_池.txt", false);
            System.IO.StreamWriter Fileout2 = new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\" + "第2分量_池.txt", false);
            System.IO.StreamWriter Fileout3 = new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\" + "第3分量_池.txt", false);
            System.IO.StreamWriter Fileout4 = new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\" + "第4分量_池.txt", false);
            System.IO.StreamWriter Fileout5 = new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\" + "水位_池.txt", false);
            System.IO.StreamWriter Fileout6 = new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\" + "气压_池.txt", false);
            for (int ii = 0; ii < names.Length; ii++)
            {
                fname = names[numu[ii]];
                System.IO.StreamReader InFile = new System.IO.StreamReader(fname);
                tmp = InFile.ReadToEnd();
                ctmp = tmp.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                datej = ctmp[1].Substring(0, 4) + '-' + ctmp[1].Substring(4, 2) + '-' + ctmp[1].Substring(6, 2);
                dd = DateTime.Parse(datej);
                num1 = (ctmp.Length/6)*6;
                for (int jj = 12; jj < num1; jj = jj + 6)
                {
                    for (int mm = 0; mm < 6; mm++)
                    {
                        if (ctmp[jj + mm] == "NULL")
                        {
                            ctmp[jj + mm] = qs;
                        }
                    }
                    Fileout1.WriteLine(dd.AddMinutes((jj - 12) / 6).ToString("yyyyMMddHHmm") + ' ' + ctmp[jj]);
                    Fileout2.WriteLine(dd.AddMinutes((jj - 12) / 6).ToString("yyyyMMddHHmm") + ' ' + ctmp[jj + 1]);
                    Fileout3.WriteLine(dd.AddMinutes((jj - 12) / 6).ToString("yyyyMMddHHmm") + ' ' + ctmp[jj + 2]);
                    Fileout4.WriteLine(dd.AddMinutes((jj - 12) / 6).ToString("yyyyMMddHHmm") + ' ' + ctmp[jj + 3]);
                    Fileout5.WriteLine(dd.AddMinutes((jj - 12) / 6).ToString("yyyyMMddHHmm") + ' ' + ctmp[jj + 4]);
                    Fileout6.WriteLine(dd.AddMinutes((jj - 12) / 6).ToString("yyyyMMddHHmm") + ' ' + ctmp[jj + 5]);

                }
                InFile.Close();
                tmp = null;
                ctmp = null;
            }
            Fileout1.Close();
            Fileout2.Close();
            Fileout3.Close();
            Fileout4.Close();
            Fileout5.Close();
            Fileout6.Close();
            return;
        }

        /// <summary>
        /// 欧阳祖熙格式的分钟值数据
        /// </summary>
        /// <param name="names">输入文件名</param>
        /// <param name="qs">缺数标记</param>
        public static void lqDataOuYang(string[] names, string qs)
        {
            string[] ctmp,cctmp,utmp;
            string fname, tmp, datej;
            int num1;
            int[] numu = new int[names.Length];
            if (names.Length > 1)
            {
                if (names[0].CompareTo(names[1]) > 0)
                {
                    for (int ij = 0; ij < names.Length - 1; ij++)
                    {
                        numu[ij] = ij + 1;
                    }
                    numu[names.Length - 1] = 0;
                }
                else
                {
                    for (int ij = 0; ij < names.Length; ij++)
                    {
                        numu[ij] = ij;
                    }
                }
            }
            else
            {
                numu[0] = 0;
            }
            System.IO.StreamWriter Fileout1 = new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\" + "YB01_欧阳.txt", false);
            System.IO.StreamWriter Fileout2 = new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\" + "YB02_欧阳.txt", false);
            System.IO.StreamWriter Fileout3 = new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\" + "YB03_欧阳.txt", false);
            System.IO.StreamWriter Fileout4 = new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\" + "YB04_欧阳.txt", false);
            System.IO.StreamWriter Fileout5 = new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\" + "CK05_欧阳.txt", false);
            System.IO.StreamWriter Fileout6 = new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\" + "JW_欧阳.txt", false);
            System.IO.StreamWriter Fileout7 = new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\" + "SW_欧阳.txt", false);
            System.IO.StreamWriter Fileout8 = new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\" + "QY_欧阳.txt", false);
            System.IO.StreamWriter Fileout9 = new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\" + "ZHYB13_欧阳.txt", false);
            System.IO.StreamWriter Fileout10 = new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\" + "ZHYB24_欧阳.txt", false);
            for (int ii = 0; ii < names.Length; ii++)
            {
                fname = names[numu[ii]];
                System.IO.StreamReader InFile = new System.IO.StreamReader(fname);
                tmp = InFile.ReadToEnd();
                ctmp = tmp.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                num1 = (ctmp.Length/6)*6;
                for (int jj = 1; jj < num1; jj++)
                {
                    cctmp = ctmp[jj].Split(new string[] { " ", "\t", "," }, StringSplitOptions.RemoveEmptyEntries);
                    utmp = cctmp[0].Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries);
                    if (utmp[1].Length == 1)
                    {
                        utmp[1] = '0' + utmp[1];
                    }
                    if (utmp[2].Length == 1)
                    {
                        utmp[2] = '0' + utmp[2];
                    }
                    datej = utmp[0] + utmp[1] + utmp[2] + cctmp[1].Replace(":", "");
                    datej = datej.Substring(0, datej.Length - 2);

                    for (int mm = 2; mm < 12; mm++)
                    {
                        if (cctmp[mm] == "--")
                        {
                            cctmp[mm] = qs;
                        }
                    }
                    Fileout1.WriteLine(datej + ' ' + cctmp[2]);
                    Fileout2.WriteLine(datej + ' ' + cctmp[3]);
                    Fileout3.WriteLine(datej + ' ' + cctmp[4]);
                    Fileout4.WriteLine(datej + ' ' + cctmp[5]);
                    Fileout5.WriteLine(datej + ' ' + cctmp[6]);
                    Fileout6.WriteLine(datej + ' ' + cctmp[7]);
                    Fileout7.WriteLine(datej + ' ' + cctmp[8]);
                    Fileout8.WriteLine(datej + ' ' + cctmp[9]);
                    Fileout9.WriteLine(datej + ' ' + cctmp[10]);
                    Fileout10.WriteLine(datej + ' ' + cctmp[11]);
                }
                InFile.Close();
                tmp = null;
                ctmp = null;
                cctmp = null;
            }
            Fileout1.Close();
            Fileout2.Close();
            Fileout3.Close();
            Fileout4.Close();
            Fileout5.Close();
            Fileout6.Close();
            Fileout7.Close();
            Fileout8.Close();
            Fileout9.Close();
            Fileout10.Close();
        }

        /// <summary>
        /// 李海亮格式的分钟值数据
        /// </summary>
        /// <param name="names">输入文件名</param>
        /// <param name="qs">缺数标记</param>
        public static void lqDataLi(string[] names, string qs)
        {
            string[] ctmp,cctmp;
            string fname,tmp,datej;
            int num1;
            DateTime dd;
            int[] numu = new int[names.Length];
            if (names.Length > 1)
            {
                if (names[0].CompareTo(names[1]) > 0)
                {
                    for (int ij = 0; ij < names.Length - 1; ij++)
                    {
                        numu[ij] = ij + 1;
                    }
                    numu[names.Length - 1] = 0;
                }
                else
                {
                    for (int ij = 0; ij < names.Length; ij++)
                    {
                        numu[ij] = ij;
                    }
                }
            }
            else
            {
                numu[0] = 0;
            }
            System.IO.StreamWriter Fileout1 = new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\" + "第1分量_李.txt", false);
            System.IO.StreamWriter Fileout2 = new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\" + "第2分量_李.txt", false);
            System.IO.StreamWriter Fileout3 = new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\" + "第3分量_李.txt", false);
            System.IO.StreamWriter Fileout4 = new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\" + "第4分量_李.txt", false);
            for (int ii = 0; ii < names.Length; ii++)
            {
                fname = names[numu[ii]];
                datej = fname.Substring(fname.Length - 12, 4) + "-" + fname.Substring(fname.Length - 8, 2) + "-" + fname.Substring(fname.Length - 6, 2);
                dd = DateTime.Parse(datej);
                System.IO.StreamReader InFile = new System.IO.StreamReader(fname);
                tmp = InFile.ReadToEnd();
                ctmp = tmp.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                num1 = (ctmp.Length/6)*6;
                for (int jj = 0; jj < num1; jj++)
                {
                    cctmp = ctmp[jj].Split(new string[] { " ", "\t", "," }, StringSplitOptions.RemoveEmptyEntries);
                    for (int mm = 0; mm < 4; mm++)
                    {
                        if (cctmp[mm] == "NULL")
                        {
                            cctmp[mm] = qs;
                        }
                    }
                    Fileout1.WriteLine(dd.AddMinutes(jj).ToString("yyyyMMddHHmm") + ' ' + cctmp[0]);
                    Fileout2.WriteLine(dd.AddMinutes(jj).ToString("yyyyMMddHHmm") + ' ' + cctmp[1]);
                    Fileout3.WriteLine(dd.AddMinutes(jj).ToString("yyyyMMddHHmm") + ' ' + cctmp[2]);
                    Fileout4.WriteLine(dd.AddMinutes(jj).ToString("yyyyMMddHHmm") + ' ' + cctmp[3]);
                }
                InFile.Close();
                tmp = null;
                ctmp = null;
                cctmp = null;
            }
            Fileout1.Close();
            Fileout2.Close();
            Fileout3.Close();
            Fileout4.Close();
        }

    }
}
