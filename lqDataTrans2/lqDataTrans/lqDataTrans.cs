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
        public static void lqDataChi(string[] names,string qs,string PTT)
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
            System.IO.StreamWriter Fileout1 = new System.IO.StreamWriter(PTT + "\\" + "第1分量_池.txt", false);
            System.IO.StreamWriter Fileout2 = new System.IO.StreamWriter(PTT + "\\" + "第2分量_池.txt", false);
            System.IO.StreamWriter Fileout3 = new System.IO.StreamWriter(PTT + "\\" + "第3分量_池.txt", false);
            System.IO.StreamWriter Fileout4 = new System.IO.StreamWriter(PTT + "\\" + "第4分量_池.txt", false);
            System.IO.StreamWriter Fileout5 = new System.IO.StreamWriter(PTT + "\\" + "水位_池.txt", false);
            System.IO.StreamWriter Fileout6 = new System.IO.StreamWriter(PTT + "\\" + "气压_池.txt", false);
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
    }
}
