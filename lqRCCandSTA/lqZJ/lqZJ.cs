//�����Լ�����lqZJ
//���ߣ�����
//������ʱ�䣺2012.05.25
//�˴�����ѡ����������4·������ͬʱ�β��֣�����4·���ݵ�ȱ��λ�ý���ͳһ
//֮���������Լ���
//δ�ж������Ƿ��ж��������ݹ۲�ʱ���Ƿ�������
using System;
using System.Collections.Generic;
using System.Text;

namespace liuqi
{
    /// <summary>
    /// �����Լ���
    /// </summary>
    public class lqZJ
    {
        /// <summary>
        /// ���ؼ�����Լ���
        /// </summary>
        /// <param name="date1">��1·ʱ��</param>
        /// <param name="data1">��1·����</param>
        /// <param name="date2">��2·ʱ��</param>
        /// <param name="data2">��2·����</param>
        /// <param name="date3">��3·ʱ��</param>
        /// <param name="data3">��3·����</param>
        /// <param name="date4">��4·ʱ��</param>
        /// <param name="data4">��4·����</param>
        /// <param name="defaultvalue">ȱ�����</param>
        /// <param name="S13">1+3��Ӧ��</param>
        /// <param name="S24">2+4��Ӧ��</param>
        /// <param name="dateg">����ʱ���</param>
        public static void lqZJs(string[] date1, double[] data1, string[] date2, double[] data2, string[] date3, double[] data3, string[] date4, double[] data4, double defaultvalue, out double[] S13, out double[] S24, out string[] dateg)
        {
            int[,] FH = new int[4, 2];
            FH = liuqi.lqCommonUse.lqTxggsd(date1, date2, date3, date4);
            if (FH[0, 0] == -1)//û�й���ʱ��
            {
                S13 = new double[0];
                S24 = new double[0];
                dateg = new string[0];
            }
            else
            {
                int len = FH[0, 1] - FH[0, 0] + 1;//��ȡ�����ݳ���
                S13 = new double[len];
                S24 = new double[len];
                dateg = new string[len];
                double tmp1, tmp2, tmp3, tmp4;

                for (int jj = 0; jj < len; jj++)
                {
                    tmp1 = data1[FH[0, 0] + jj];
                    tmp2 = data2[FH[1, 0] + jj];
                    tmp3 = data3[FH[2, 0] + jj];
                    tmp4 = data4[FH[3, 0] + jj];
                    if (tmp1 == defaultvalue || tmp2 == defaultvalue || tmp3 == defaultvalue || tmp4 == defaultvalue)
                    {
                        S13[jj] = defaultvalue;
                        S24[jj] = defaultvalue;
                    }
                    else
                    {
                        S13[jj] = tmp1 + tmp3;
                        S24[jj] = tmp2 + tmp4;
                    }
                    dateg[jj] = date1[FH[0, 0] + jj];
                }
                double meanC = liuqi.lqCommonUse.lqMean1D(S13, defaultvalue) - liuqi.lqCommonUse.lqMean1D(S24, defaultvalue);
                S24 = yanwei.ywMatrixOperate.ywAdd(S24, meanC, defaultvalue);
            }
        }

        /// <summary>
        /// ���ؼ���Ĳ�Ӧ��
        /// </summary>
        /// <param name="date1">��1·ʱ��</param>
        /// <param name="data1">��1·����</param>
        /// <param name="date2">��2·ʱ��</param>
        /// <param name="data2">��2·����</param>
        /// <param name="date3">��3·ʱ��</param>
        /// <param name="data3">��3·����</param>
        /// <param name="date4">��4·ʱ��</param>
        /// <param name="data4">��4·����</param>
        /// <param name="defaultvalue">ȱ�����</param>
        /// <param name="C13">1-3��Ӧ��</param>
        /// <param name="C24">2-4��Ӧ��</param>
        /// <param name="dateg">����ʱ���</param>
        public static void lqZJc(string[] date1, double[] data1, string[] date2, double[] data2, string[] date3, double[] data3, string[] date4, double[] data4, double defaultvalue, out double[] C13, out double[] C24, out string[] dateg)
        {
            int[,] FH = new int[4, 2];
            FH = liuqi.lqCommonUse.lqTxggsd(date1, date2, date3, date4);
            if (FH[0, 0] == -1)//û�й���ʱ��
            {
                C13 = new double[0];
                C24 = new double[0];
                dateg = new string[0];
            }
            else
            {
                int len = FH[0, 1] - FH[0, 0] + 1;//��ȡ�����ݳ���
                C13 = new double[len];
                C24 = new double[len];
                dateg = new string[len];
                double tmp1, tmp2, tmp3, tmp4;

                for (int jj = 0; jj < len; jj++)
                {
                    tmp1 = data1[FH[0, 0] + jj];
                    tmp2 = data2[FH[1, 0] + jj];
                    tmp3 = data3[FH[2, 0] + jj];
                    tmp4 = data4[FH[3, 0] + jj];
                    if (tmp1 == defaultvalue || tmp2 == defaultvalue || tmp3 == defaultvalue || tmp4 == defaultvalue)
                    {
                        C13[jj] = defaultvalue;
                        C24[jj] = defaultvalue;
                    }
                    else
                    {
                        C13[jj] = tmp1 - tmp3;
                        C24[jj] = tmp2 - tmp4;
                    }
                    dateg[jj] = date1[FH[0, 0] + jj];
                }
                double meanC = liuqi.lqCommonUse.lqMean1D(C13, defaultvalue) - liuqi.lqCommonUse.lqMean1D(C24, defaultvalue);
                C24 = yanwei.ywMatrixOperate.ywAdd(C24, meanC, defaultvalue);
            }

        }
    }

}
