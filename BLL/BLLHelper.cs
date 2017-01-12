using System;
using System.Collections.Generic;
using System.Text;

namespace MOD.BLL {
    public class BLLHelper {
        //静态类，通用函数
        /// <summary>
        /// 提取一个阶梯数的大小(用于分类中的插入子类)
        /// 该数组以 1 递增，模拟寻找插入一个阶梯数的大小
        /// 如：[2，3]，应该插入的数为1，[1，2，3]应该插入4，[1，2，7]，应该插入3
        /// </summary>
        /// <param name="a">一个已经排序（从小到大的整型数组）</param>
        /// <returns></returns>
        public static int GetIndex( int[] a ) {
            //step 为 1
            int nRet = 1;
            int nlen = a.Length;
            if (nlen == 0) {//没有任何数，插入肯定为 1             
                nRet = 1;
            } else if (nlen == 1) { //为1一个元素，为1，或者 2（1+1）            
                if (a[0] == 1) {
                    nRet = 1 + 1;  //2
                } else {
                    nRet = 1; //1
                }
            } else if (nlen >= 2) {//复杂：为1，为中间的某个数字，为最大的数字+1
                for (int i = 0; i <= a.Length - 1; i++) {
                    if (i == 0 && a[0] != 1) {
                        nRet = 1;
                        break;
                    } else if (i > 0) {
                        if (a[i] == a[i - 1] + 1) {
                            if (i == nlen - 1) {
                                nRet = a[i] + 1;
                                break;
                            }
                        } else if (a[i] > a[i - 1] + 1) {
                            nRet = a[i - 1] + 1;
                            break;
                        }
                    }
                }
            }
            return nRet;
        }


        /// <summary>
        /// 将节目的时间(ms)转化为: 时:分:秒
        /// </summary>
        /// <param name="ms">PDuration</param>
        /// <returns></returns>
        public static string FormatTime( int ms ) {
            int lMs, lHour, lMin, lSec;
            string FormatProgramTime = string.Empty;

            lMs = ms;
            lHour = Convert.ToInt32(lMs / (1000 * 60 * 60));
            lMin = Convert.ToInt32(lMs / (1000 * 60) - Convert.ToInt32(lHour * 60));
            lSec = Convert.ToInt32(Convert.ToInt32(Convert.ToInt32(lMs / 1000) - Convert.ToInt32(lMin * 60) - Convert.ToInt32(lHour * 60 * 60)));

            string strHour = lHour.ToString();
            string strMin = lMin.ToString();
            string strSec = lSec.ToString();
            if (strHour.Length == 1)
                strHour = "0" + strHour;
            if (strMin.Length == 1)
                strMin = "0" + strMin;
            if (strSec.Length == 1)
                strSec = "0" + strSec;

            FormatProgramTime = strHour + ":" + strMin + ":" + strSec;
            return FormatProgramTime;
        }


        /// <summary>
        /// 节目播放的码率
        /// </summary>
        /// <param name="h">SizeHigh</param>
        /// <param name="l">SizeLow</param>
        /// <param name="d">Duration</param>
        /// <returns>码率数值(不含单位nkbps)</returns>
        public static string GetKbps( int h, int l, int d ) {

            string strReturn;
            int intReturn;
            double dblD, dblL;
            double gh, hl, ul;
            if (d != 0) {
                if (h != 0) {
                    gh = Convert.ToDouble(Convert.ToDecimal(h) * 4294967296);
                } else {
                    gh = 0;
                }
                dblL = Convert.ToDouble(l);
                if (l < 0) {
                    int uls = 2147483647;
                    ul = Convert.ToDouble((l & uls) + 2147483648);
                } else {
                    ul = l;
                }
                hl = Convert.ToDouble(gh + Convert.ToDouble(ul));
                dblD = Convert.ToDouble(d);
                intReturn = Convert.ToInt32(Convert.ToDouble((hl / (1024.00 * dblD)) * 8000));
            } else {
                intReturn = 0;
            }
            strReturn = intReturn.ToString("n");
            string[] temp = strReturn.Split(".".ToCharArray());
            strReturn = temp[0];
            return strReturn;   //+"Kbps";

        }

        public static bool BoolFreeTime( DateTime dtNow, String strFirstPlayTime ) {
            int maxFreeTime = int.Parse((new Setting()).GetValue(SETTING_TYPE.KEY_FREETIME, "0"));
            if (maxFreeTime == 0) {
                return false;
            } else {
                if (string.IsNullOrEmpty(strFirstPlayTime)) {
                    return false;
                } else {
                    DateTime dtFirstPlayTime = DateTime.Parse(strFirstPlayTime);
                    TimeSpan tspan = dtNow.Subtract(dtFirstPlayTime);
                    tspan = tspan.Duration();
                    int diffminutes = (tspan.Days * 24 + tspan.Hours) * 60 + tspan.Minutes;
                    if (diffminutes < maxFreeTime) {
                        return true;
                    }
                    return false;
                }
            }
        }


    }
}