using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Xml;
using System.Text.RegularExpressions;
using MOD.BLL;

namespace MOD.WebUtility {
    public class WebHelper {
        // 静态帮助类


        #region ==========加密解密
        /// <summary>
        /// 加密Pid
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public static string EncryptPid( Int32 pid ) {
            float rndtmp = 0;
            string rndTmpStr = string.Empty;
            int eii = 0;
            string eTmpStr = "";

            string EncryptPid = "";
            if (Convert.ToString(pid) != "") {
                int ei = 0;
                int eiLen = 0;
                eiLen = Convert.ToString(pid).Length;

                Random rnd = new Random();
                for (ei = 0; ei < eiLen; ei++) {
                    rndtmp = (Convert.ToSingle(rnd.NextDouble()) * (float)10000.0 + (float)1.0);
                    while (rndtmp < (float)1000.0) {
                        rndtmp = (Convert.ToSingle(rnd.NextDouble()) * (float)10000.0 + (float)1.0);
                    }

                    rndTmpStr = "";
                    for (eii = 0; eii < 4.0; eii++) {
                        string temp = Convert.ToString(rndtmp).Substring(eii, 1);
                        int itemp = Convert.ToInt32(temp) + 65;
                        rndTmpStr = rndTmpStr + (Convert.ToChar(itemp)).ToString().ToUpper();
                    }
                    if (eTmpStr == "") {
                        eTmpStr = rndTmpStr.Substring(0, 1) + (Convert.ToString((char)(Convert.ToInt32(Convert.ToString(pid).Substring(ei, 1)) + 65))).ToUpper() + rndTmpStr.Substring(rndTmpStr.Length - 3);
                    } else {
                        string temp = Convert.ToString(pid).Substring(ei, 1);
                        string strTemp1 = (Convert.ToString((char)(Convert.ToInt32(temp) + 65))).ToUpper();
                        eTmpStr = eTmpStr + "-" + rndTmpStr.Substring(0, 1) + strTemp1 + rndTmpStr.Substring(rndTmpStr.Length - 3);
                    }
                }
                EncryptPid = eTmpStr;
            }
            return EncryptPid;
        }


        /// <summary>
        /// 解密已经加密的PID
        /// </summary>
        /// <param name="secpid"></param>
        /// <returns></returns>
        public static int DecryptPid( string secpid ) {
            string[] dArr = null;
            int diLen = 0;
            int di = 0;
            string dTmpPid = "";

            string strSecPid = secpid;

            string DecryptPid = "";
            if (strSecPid != string.Empty) {
                dArr = strSecPid.Split("-".ToCharArray());
                diLen = dArr.GetUpperBound(0);

                for (; di <= diLen; di++) {
                    if (dArr[di].Length == 5) {
                        ASCIIEncoding ASC = new ASCIIEncoding();
                        byte[] tempbyte = ASC.GetBytes((dArr[di]).Substring(1, 1));
                        dTmpPid = dTmpPid + "" + Convert.ToString(tempbyte[0] - 65);
                    }
                }
                DecryptPid = dTmpPid;
            }

            return Convert.ToInt32(DecryptPid);
        }

        public static string GetPwd( string str ) {
            string strReturn = string.Empty;
            if (str != "") {
                ASCIIEncoding AE = new ASCIIEncoding();
                byte[] BA = AE.GetBytes(str);// BA  : btyeArray
                for (int i = 0; i < BA.Length; i++) {
                    if (BA[i] == 48)
                        BA[i] = 57;
                    else if (BA[i] == 65)
                        BA[i] = 90;
                    else if (BA[i] == 97)
                        BA[i] = 122;
                    else
                        BA[i]--;
                }
                char[] charArray = AE.GetChars(BA);
                for (int i = 0; i < charArray.Length; i++) {
                    strReturn += charArray[i].ToString();
                }

            }
            return strReturn;

        }

        /// <summary>
        /// 设置加密密码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string PutPwd( string str ) {
            string strReturn = string.Empty;
            if (str != "") {
                ASCIIEncoding AE = new ASCIIEncoding();
                byte[] BA = AE.GetBytes(str);// BA  : btyeArray
                for (int i = 0; i < BA.Length; i++) {
                    if (BA[i] == 57)
                        BA[i] = 48;
                    else if (BA[i] == 90)
                        BA[i] = 65;
                    else if (BA[i] == 122)
                        BA[i] = 97;
                    else
                        BA[i]++;

                }
                char[] charArray = AE.GetChars(BA);
                for (int i = 0; i < charArray.Length; i++) {
                    strReturn += charArray[i].ToString();
                }
            }
            return strReturn;

        }

        #endregion


        public static string GetShowUrl() {
            string strPath = HttpContext.Current.Request.Path;
            string[] strArray = null;
            strArray = strPath.Split("/".ToCharArray());
            return strArray[strArray.Length - 1];
        }

        /// <summary>
        /// 取 媒体类型
        /// </summary>
        /// <param name="iMediaType"></param>
        /// <returns></returns> 
        public static string GetMediaType( int iMediaType ) {
            Define.ENUM_PROGRAM_TYPE prmtype = (Define.ENUM_PROGRAM_TYPE)iMediaType;
            string GetMediaType = string.Empty;
            switch (prmtype) {
                case Define.ENUM_PROGRAM_TYPE.t_unknown:
                    GetMediaType = "m_icon_media_unknown.gif";
                    break;
                case Define.ENUM_PROGRAM_TYPE.t_mp3:
                    GetMediaType = "m_icon_media_mp3.gif";
                    break;
                case Define.ENUM_PROGRAM_TYPE.t_mpv:
                    GetMediaType = "m_icon_media_mpv.gif";
                    break;
                case Define.ENUM_PROGRAM_TYPE.t_mpeg1:
                    GetMediaType = "m_icon_media_mpeg1.gif";
                    break;
                case Define.ENUM_PROGRAM_TYPE.t_mpeg2:
                    GetMediaType = "m_icon_media_mpeg2.gif";
                    break;
                case Define.ENUM_PROGRAM_TYPE.t_avi:
                    GetMediaType = "m_icon_media_avi.gif";
                    break;
                case Define.ENUM_PROGRAM_TYPE.t_real:
                    GetMediaType = "m_icon_media_real.gif";
                    break;
                case Define.ENUM_PROGRAM_TYPE.t_asfwmv:
                    GetMediaType = "m_icon_media_asfwmv.gif";
                    break;
                case Define.ENUM_PROGRAM_TYPE.t_wave:
                    GetMediaType = "m_icon_media_wave.gif";
                    break;
                case Define.ENUM_PROGRAM_TYPE.t_rtp:
                    GetMediaType = "m_icon_media_asfwmv.gif";
                    break;
                case Define.ENUM_PROGRAM_TYPE.t_course:
                    GetMediaType = "m_icon_media_course.gif";
                    break;
                default:
                    GetMediaType = "m_icon_media_unknown.gif";
                    break;
            }

            return GetMediaType;
        }
        #region  输入输出字符处理
        /// <summary>
        /// 取字符串子串
        /// </summary>
        /// <param name="text">检查对象</param>
        /// <param name="maxLength">所允许的字符最大长度</param>
        /// <param name="replace">Empty 不在结尾附加任何东西，非空则附加</param>
        /// <returns></returns>
        public static string SubText( string text, int maxLength, string replace ) {
            if (string.IsNullOrEmpty(text))
                return string.Empty;
            if (text.Length > maxLength)
                text = text.Substring(0, maxLength) + replace;

            return text;
        }
        public static int GetStringLength( string str ) {
            return Regex.Replace(str , "[\u4e00-\u9fa5]", "zz", RegexOptions.IgnoreCase).Length;
        }
        /// <summary>
        /// 截取 由中文，字符，符号组成的字符串， 中文算两位长度，其他一位
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="maxLength">Length of the max.</param>
        /// <param name="replace">The replace.</param>
        /// <returns></returns>
        public static string SubMixText( string text, int maxLength, string replace ) {
            if (string.IsNullOrEmpty(text)) {
                return string.Empty;
            } else {
                string strReturn = "";
                string strTemp = text;

                if (GetStringLength(strTemp) <= maxLength) {
                    strReturn = strTemp;
                } else {
                    for (int i = strTemp.Length; i >= 0; i--) {
                        strTemp = strTemp.Substring(0, i);
                        if (GetStringLength(strTemp) <= maxLength) {
                            strReturn = strTemp + replace;
                            break;
                        }
                    }
                }
                return strReturn;
            }

        }


        public static String HtmlEncode( String strIn ) {
            if (strIn.Length == 0)
                return "";
            else {
                String strOut = HttpContext.Current.Server.HtmlEncode(strIn);
                strOut = strOut.Replace("\r\n", "<br/>").Replace("\n", "<br/>");
                return strOut;
            }
        }
        //// str.Replace("<", "&lt;").Replace(">", "&gt;").Replace("\r\n","<br/>")
        //.Replace("\n", "<br>").Replace("\r", "<br>").Replace("\"", "&quot;");


        /// <summary>
        /// 替换html中的特殊字符
        /// </summary>
        /// <param name="theString">需要进行替换的文本。</param>
        /// <returns>替换完的文本。</returns>
        public static string TextIn( string theString ) {
            theString = theString.Replace(">", "&gt;");
            theString = theString.Replace("<", "&lt;");
            theString = theString.Replace("  ", " &nbsp;");
            theString = theString.Replace("  ", " &nbsp;");
            theString = theString.Replace("\"", "&quot;");
            theString = theString.Replace("\'", "&#39;");
            theString = theString.Replace("\r\n", "<br/>");
            theString = theString.Replace("\r", "<br/>");
            theString = theString.Replace("\n", "<br/>");
            return theString;
        }

        /// <summary>
        /// 恢复html中的特殊字符
        /// </summary>
        /// <param name="theString">需要恢复的文本。</param>
        /// <returns>恢复好的文本。</returns>
        public static string TextOut( string theString ) {
            theString = theString.Replace("&gt;", ">");
            theString = theString.Replace("&lt;", "<");
            theString = theString.Replace("&nbsp;", " ");
            theString = theString.Replace(" &nbsp;", "  ");
            theString = theString.Replace("&quot;", "\"");
            theString = theString.Replace("&#39;", "\'");
            theString = theString.Replace("<br/>", "\n");
            return theString;
        }

        /// <summary>
        /// Method to make sure that user's inputs are not malicious
        /// 可用于非段落性字符的检验，如用户帐号的输入
        /// </summary>
        /// <param name="text">User's Input</param>
        /// <param name="maxLength">Maximum length of input</param>
        /// <returns>The cleaned up version of the input</returns>
        public static string InputText( string text, int maxLength ) {
            text = text.Trim();
            if (string.IsNullOrEmpty(text))
                return string.Empty;
            if (text.Length > maxLength)
                text = text.Substring(0, maxLength);
            text = Regex.Replace(text, "[\\s]{2,}", " ");	//two or more spaces
            text = Regex.Replace(text, "(<[b|B][r|R]/*>)+|(<[p|P](.|\\n)*?>)", "\n");	//<br>
            text = Regex.Replace(text, "(\\s*&[n|N][b|B][s|S][p|P];\\s*)+", " ");	//&nbsp;
            text = Regex.Replace(text, "<(.|\\n)*?>", string.Empty);	//any other tags
            text = text.Replace("'", "''");
            return text;
        }
        public static string InputText( string text ) {
            text = text.Trim();
            if (string.IsNullOrEmpty(text))
                return string.Empty;
            text = Regex.Replace(text, "[\\s]{2,}", " ");	//two or more spaces
            text = Regex.Replace(text, "(<[b|B][r|R]/*>)+|(<[p|P](.|\\n)*?>)", "\n");	//<br>
            text = Regex.Replace(text, "(\\s*&[n|N][b|B][s|S][p|P];\\s*)+", " ");	//&nbsp;
            text = Regex.Replace(text, "<(.|\\n)*?>", string.Empty);	//any other tags
            text = text.Replace("'", "''");
            return text;
        }

        #endregion

        #region  分页器
        public static String PageList( String strUrl, Int32 nAll, Int32 nCurPage, Int32 nPageSize) {
            return PageList(strUrl, nAll, nCurPage, nPageSize, 10);
        }
        // output page list
        public static String PageList( String strUrl, Int32 nAll, Int32 nCurPage, Int32 nPageSize,Int32 nPageShow ) {
            Int32 PAGESHOW = nPageShow;
            if (nAll == 0)  return String.Empty;


            String strGoUrl = "";
            int m_nPageSize = nPageSize;

            int nMaxPage;
            if ((nAll % m_nPageSize) == 0)
                nMaxPage = (int)(nAll / (int)m_nPageSize);
            else
                nMaxPage = (int)(nAll / (int)m_nPageSize) + 1;

            if (strUrl.IndexOf("?") > 0)
                strGoUrl = strUrl + "&page=";
            else
                strGoUrl = strUrl + "?page=";

            // out page numbers, out 5 pages one time
            int nPrevBound = nCurPage - (int)(PAGESHOW / 2);
            int nNextBound = nCurPage + (int)(PAGESHOW / 2);
            if (nPrevBound <= 0) {
                nPrevBound = 1;
                nNextBound = PAGESHOW;
            }

            if (nNextBound > nMaxPage) {
                nNextBound = nMaxPage;
                nPrevBound = nMaxPage - PAGESHOW;
            }

            if (nPrevBound <= 0)
                nPrevBound = 1;

            StringBuilder sbOut = new StringBuilder();
            sbOut.Append("<div class=\"page\">");
            if (nMaxPage == 1)
                sbOut.Append(" <span class=\"pageCur\">1</span>");
            else {
                if (nPrevBound > 1)
                    sbOut.Append("<a class=\"pageNor\" href=\"" + strGoUrl + "1\">&lt;&lt;</a>");
                else
                    sbOut.Append("<span class=\"pageDis\">&lt;&lt;</span>");

                if (nCurPage > 1)
                    sbOut.Append("<a class=\"pageNor\" href=\"" + strGoUrl + (nCurPage - 1) + "\">&lt;</a>");
                else
                    sbOut.Append("<span class=\"pageDis\">&lt;</span>");

                for (int i = nPrevBound; i <= nNextBound; i++) {
                    if (nCurPage == i)
                        sbOut.Append("<span class=\"pageCur\">" + i.ToString() + "</span>");
                    else if (i <= nMaxPage)
                        sbOut.Append("<a class=\"pageNor\" href=\"" + strGoUrl + i.ToString() + "\">" + i.ToString() + "</a>");
                }

                if (nCurPage < nMaxPage)
                    sbOut.Append("<a class=\"pageNor\" href=\"" + strGoUrl + (nCurPage + 1) + "\">&gt;</a>");
                else
                    sbOut.Append("<span class=\"pageDis\">&gt;</span>");

                if (nNextBound < nMaxPage)
                    sbOut.Append("<a class=\"pageNor\"  href=\"" + strGoUrl + nMaxPage.ToString() + "\">&gt;&gt;</a>");
                else
                    sbOut.Append("<span class=\"pageDis\">&gt;&gt;</span>");
            }
            sbOut.Append("</div>");
            return sbOut.ToString();
        }


        public static String AjaxPager( String strOnClick, Int32 nAll, Int32 nCurPage, Int32 nPageSize ) {
            return AjaxPager( strOnClick, nAll, nCurPage, nPageSize,10);
        }

        /// <summary>
        /// Ajax 分页器
        /// </summary>
        /// <param name="strOnClick">this String Like:    getPager({0},"其他参数"),然后用 Format格式化</param>        
        /// <returns></returns>
        public static String AjaxPager( String strOnClick, Int32 nAll, Int32 nCurPage, Int32 nPageSize,Int32 nPageShow ) {
            Int32 PAGESHOW = nPageShow;
            if (nAll == 0)
                return String.Empty;
            int m_nPageSize = nPageSize;
            int nMaxPage;


            if ((nAll % m_nPageSize) == 0)
                nMaxPage = (int)(nAll / (int)m_nPageSize);
            else
                nMaxPage = (int)(nAll / (int)m_nPageSize) + 1;



            // out page numbers
            // out 5 pages one time
            int nPrevBound = nCurPage - (int)(PAGESHOW / 2);
            int nNextBound = nCurPage + (int)(PAGESHOW / 2);
            if (nPrevBound <= 0) {
                nPrevBound = 1;
                nNextBound = PAGESHOW;
            }

            if (nNextBound > nMaxPage) {
                nNextBound = nMaxPage;
                nPrevBound = nMaxPage - PAGESHOW;
            }

            if (nPrevBound <= 0)
                nPrevBound = 1;

            StringBuilder sbOut = new StringBuilder();
            sbOut.Append("<div class=\"page\">");
            if (nMaxPage == 1)
                sbOut.Append(" <span class=\"pageCur\">1</span>");
            else {
                if (nPrevBound > 1)
                    sbOut.Append("<a class=\"pageNor\" href=\"javascript:" + string.Format(strOnClick, 1) + "\">&lt;&lt;</a>");
                else
                    sbOut.Append("<span class=\"pageDis\">&lt;&lt;</span>");

                if (nCurPage > 1)
                    sbOut.Append("<a class=\"pageNor\" href=\"javascript:" + string.Format(strOnClick, (nCurPage - 1)) + "\">&lt;</a>");
                else
                    sbOut.Append("<span class=\"pageDis\">&lt;</span>");

                for (int i = nPrevBound; i <= nNextBound; i++) {
                    if (nCurPage == i)
                        sbOut.Append("<span class=\"pageCur\">" + i.ToString() + "</span>");
                    else if (i <= nMaxPage)
                        sbOut.Append("<a class=\"pageNor\" href=\"javascript:" + string.Format(strOnClick, i) + "\">" + i.ToString() + "</a>");
                }

                if (nCurPage < nMaxPage)
                    sbOut.Append("<a class=\"pageNor\" href=\"javascript:" + string.Format(strOnClick, (nCurPage + 1)) + "\">&gt;</a>");
                else
                    sbOut.Append("<span class=\"pageDis\">&gt;</span>");

                if (nNextBound < nMaxPage)
                    sbOut.Append("<a class=\"pageNor\"  href=\"javascript:" + string.Format(strOnClick, nMaxPage) + "\">&gt;&gt;</a>");
                else
                    sbOut.Append("<span class=\"pageDis\">&gt;&gt;</span>");//scroll(0,0);
            }
            sbOut.Append("</div>");
            return sbOut.ToString();
        }
        public static String AjaxPager2( String strOnClick, Int32 nAll, Int32 nCurPage, Int32 nPageSize, Int32 nPageShow ) {
            Int32 PAGESHOW = nPageShow;
            if (nAll == 0)
                return String.Empty;
            int m_nPageSize = nPageSize;
            int nMaxPage;


            if ((nAll % m_nPageSize) == 0)
                nMaxPage = (int)(nAll / (int)m_nPageSize);
            else
                nMaxPage = (int)(nAll / (int)m_nPageSize) + 1;



            // out page numbers
            // out 5 pages one time
            int nPrevBound = nCurPage - (int)(PAGESHOW / 2);
            int nNextBound = nCurPage + (int)(PAGESHOW / 2);
            if (nPrevBound <= 0) {
                nPrevBound = 1;
                nNextBound = PAGESHOW;
            }

            if (nNextBound > nMaxPage) {
                nNextBound = nMaxPage;
                nPrevBound = nMaxPage - PAGESHOW;
            }

            if (nPrevBound <= 0)
                nPrevBound = 1;

            StringBuilder sbOut = new StringBuilder();
            sbOut.Append("<div class=\"page\">");
            if (nMaxPage == 1)
                sbOut.Append(" <span class=\"pageCur\">1</span>");
            else {
                if (nPrevBound > 1)
                    sbOut.Append("<a class=\"pageNor\" href=\"javascript:" + string.Format(strOnClick, 1) + "\">&lt;&lt;</a>");
                else
                    sbOut.Append("<span class=\"pageDis\">&lt;&lt;</span>");

                if (nCurPage > 1)
                    sbOut.Append("<a class=\"pageNor\" href=\"javascript:" + string.Format(strOnClick, (nCurPage - 1)) + "\">&lt;</a>");
                else
                    sbOut.Append("<span class=\"pageDis\">&lt;</span>");

                for (int i = nPrevBound; i <= nNextBound; i++) {
                    if (nCurPage == i)
                        sbOut.Append("<span class=\"pageCur\">" + i.ToString() + "</span>");
                    else if (i <= nMaxPage)
                        sbOut.Append("<a class=\"pageNor\" href=\"javascript:" + string.Format(strOnClick, i) + "\">" + i.ToString() + "</a>");
                }

                if (nCurPage < nMaxPage)
                    sbOut.Append("<a class=\"pageNor\" href=\"javascript:" + string.Format(strOnClick, (nCurPage + 1)) + "\">&gt;</a>");
                else
                    sbOut.Append("<span class=\"pageDis\">&gt;</span>");

                if (nNextBound < nMaxPage)
                    sbOut.Append("<a class=\"pageNor\"  href=\"javascript:" + string.Format(strOnClick, nMaxPage) + "\">&gt;&gt;</a>");
                else
                    sbOut.Append("<span class=\"pageDis\">&gt;&gt;</span>");
            }
            sbOut.Append("</div>");
            return sbOut.ToString();
        }
        #endregion

        #region 参数获取并转换（Request, Session）
        public static String GetRequest( String strKey ) {
            if (HttpContext.Current.Request[strKey] != null)
                return HttpContext.Current.Request[strKey].ToString();
            return String.Empty;
        }

        /// <summary>
        /// 获取时间参数
        /// </summary>
        /// <param name="strKey">The STR key.</param>
        /// <param name="DefaultDate">The default date.</param>
        /// <returns></returns>
        public static DateTime GetRequest( String strKey, DateTime DefaultDate ) {
            if (string.IsNullOrEmpty(HttpContext.Current.Request[strKey])) {
                return DefaultDate;
            } else if (!IsStringDate(HttpContext.Current.Request[strKey])) {
                return DefaultDate;
            } else {
                return DateTime.Parse(HttpContext.Current.Request[strKey]);
            }
        }

        /// <summary>
        /// 将Request到的参数转化为 int
        /// </summary>
        /// <param name="strKey">参数名</param>
        /// <param name="nDefaultNum">当参数为Null,Empty时指定返回的默认数值</param>
        /// <returns></returns>
        public static Int32 GetRequest( String strKey, Int32 nDefaultNum ) {
            string strRequest = HttpContext.Current.Request[strKey];

            if (string.IsNullOrEmpty(strRequest)) {
                return nDefaultNum;
            }

            try {
                return Convert.ToInt32(strRequest);
            } catch {
                return nDefaultNum;
            }

        }

        public static String GetSession( String strKey ) {
            if (HttpContext.Current.Session[strKey] == null || HttpContext.Current.Session[strKey].ToString() == string.Empty) {
                return string.Empty;
            } else {
                return HttpContext.Current.Session[strKey].ToString();
            }
        }

        public static Int32 GetSession( String strKey, Int32 nDefaultNum ) {


            if (HttpContext.Current.Session[strKey] == null || HttpContext.Current.Session[strKey].ToString() == string.Empty) {
                return nDefaultNum;
            } else {
                try {
                    return Convert.ToInt32(HttpContext.Current.Session[strKey].ToString());
                } catch {
                    return nDefaultNum;
                }

            }
        }

        /// <summary>
        /// 取Web.Config Xml 文件里面设置的数值参数
        /// </summary>
        /// <param name="strKey">keys</param>
        /// <param name="nCount">如果没有该参数或转换出错时,指定的默认数值</param>
        /// <returns></returns>
        public static Int32 GetAppSetting( string strKey, Int32 nCount ) {
            string appsetting = ConfigurationManager.AppSettings[strKey];

            if (string.IsNullOrEmpty(appsetting)) {
                return nCount;
            } else if (!IsNumberId(appsetting)) {
                return nCount;
            } else {
                return Convert.ToInt32(appsetting);
            }
        }

        /// <summary>
        /// 取Web.Config Xml 文件里面设置的String参数
        /// </summary>
        /// <param name="strKey"></param>
        /// <returns></returns>
        public static string GetAppSetting( string strKey ) {
            return ConfigurationManager.AppSettings[strKey];// null,empty,非空
        }

        /// <summary>
        /// Formats the search date time.
        /// </summary>       
        /// <param name="nType">0 begin,1 end </param>
        /// <returns></returns>
        public static DateTime FormatDateTime( DateTime dtInput, Int32 nType ) {
            String strTime = (nType == 0) ? "00:00:00" : "23:59:59";
            return DateTime.Parse(dtInput.ToShortDateString() + " " + strTime);
        }

        //通过Asp.net控件获得其相应的HTML字符串表示
        public static string GetStringByControl( System.Web.UI.Control c ) {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            System.IO.StringWriter writer = new System.IO.StringWriter(sb);
            System.Web.UI.HtmlTextWriter htw = new System.Web.UI.HtmlTextWriter(writer);
            c.RenderControl(htw);
            return sb.ToString();
        }
        #endregion



        #region  ==========引用自NBear
        /// <summary>
        /// Gets the string param.
        /// </summary>
        /// <param name="paramName">Name of the param.</param>
        /// <param name="errorReturn">The error return.</param>
        /// <returns></returns>
        public static string GetStringParam( System.Web.HttpRequest request, string paramName, string errorReturn ) {
            string retStr = request.Form[paramName];
            if (retStr == null) {
                retStr = request.QueryString[paramName];
            }
            if (retStr == null) {
                return errorReturn;
            }
            return retStr;
        }

        /// <summary>
        /// Gets the int param.
        /// </summary>
        /// <param name="paramName">Name of the param.</param>
        /// <param name="errorReturn">The error return.</param>
        /// <returns></returns>
        public static int GetIntParam( System.Web.HttpRequest request, string paramName, int errorReturn ) {
            string retStr = request.Form[paramName];
            if (retStr == null) {
                retStr = request.QueryString[paramName];
            }
            if (retStr == null || retStr.Trim() == string.Empty) {
                return errorReturn;
            }
            try {
                return Convert.ToInt32(retStr);
            } catch {
                return errorReturn;
            }
        }

        /// <summary>
        /// Gets the date time param.
        /// </summary>
        /// <param name="paramName">Name of the param.</param>
        /// <param name="errorReturn">The error return.</param>
        /// <returns></returns>
        public static DateTime GetDateTimeParam( System.Web.HttpRequest request, string paramName, DateTime errorReturn ) {
            string retStr = request.Form[paramName];
            if (retStr == null) {
                retStr = request.QueryString[paramName];
            }
            if (retStr == null || retStr.Trim() == string.Empty) {
                return errorReturn;
            }
            try {
                return Convert.ToDateTime(retStr);
            } catch {
                return errorReturn;
            }
        }
        #endregion

        public static void MsgBox( String strMsg, bool bBack, String strJumpUrl ) {
            StringBuilder sbOut = new StringBuilder();
            sbOut.Append("<script language=\"javascript\">alert(\"" + strMsg + "\");");
            if (bBack) sbOut.Append("history.back();");
            if (strJumpUrl.Length != 0) sbOut.Append("location.href=\"" + strJumpUrl + "\";");
            sbOut.Append("</script>");
            HttpContext.Current.Response.Write(sbOut.ToString());
            HttpContext.Current.Response.End();
        }
        public static void MsgBox( String strMsg, bool bBack, String strJumpUrl, bool bIsClose ) {
            StringBuilder sbOut = new StringBuilder();
            sbOut.Append("<script language=\"javascript\">alert(\"" + strMsg + "\");");
            if (bBack) sbOut.Append("history.back();");
            if (strJumpUrl.Length != 0) sbOut.Append("location.href=\"" + strJumpUrl + "\";");
            if (bIsClose) sbOut.Append("window.close();");

            sbOut.Append("</script>");

            HttpContext.Current.Response.Write(sbOut.ToString());
            HttpContext.Current.Response.End();
        }

        #region  字符串验证
        /*
         "^\\d+$"　　//非负整数（正整数 + 0） 
        "^[0-9]*[1-9][0-9]*$"　　//正整数 
        "^((-\\d+)|(0+))$"　　//非正整数（负整数 + 0） 
        "^-[0-9]*[1-9][0-9]*$"　　//负整数 
        "^-?\\d+$"　　　　//整数 
        "^\\d+(\\.\\d+)?$"　　//非负浮点数（正浮点数 + 0） 
        "^(([0-9]+\\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\\.[0-9]+)|([0-9]*[1-9][0-9]*))$"　　//正浮点数 
        "^((-\\d+(\\.\\d+)?)|(0+(\\.0+)?))$"　　//非正浮点数（负浮点数 + 0） 
        "^(-(([0-9]+\\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\\.[0-9]+)|([0-9]*[1-9][0-9]*)))$"　　//负浮点数 
        "^(-?\\d+)(\\.\\d+)?$"　　//浮点数 
        "^[A-Za-z]+$"　　//由26个英文字母组成的字符串 
        "^[A-Z]+$"　　//由26个英文字母的大写组成的字符串 
        "^[a-z]+$"　　//由26个英文字母的小写组成的字符串 
        "^[A-Za-z0-9]+$"　　//由数字和26个英文字母组成的字符串 
        "^\\w+$"　　//由数字、26个英文字母或者下划线组成的字符串 
        "^[\\w-]+(\\.[\\w-]+)*@[\\w-]+(\\.[\\w-]+)+$"　　　　//email地址 
        "^[a-zA-z]+://(\\w+(-\\w+)*)(\\.(\\w+(-\\w+)*))*(\\?\\S*)?$"　　//url
         */


        /// <summary>
        /// 检查一个字符串是否可以转化为日期，一般用于验证用户输入日期的合法性。
        /// </summary>
        /// <param name="_value">需验证的字符串。</param>
        /// <returns>是否可以转化为日期的bool值。</returns>

        public static bool IsStringDate( string date ) {
            DateTime dt;
            try {
                dt = DateTime.Parse(date);
            } catch (FormatException e) {
                //日期格式不正确时
                e.ToString();
                return false;
            }
            return true;
        }

        /// <summary>
        /// 检查一个字符串是否是纯数字构成的，一般用于查询字符串参数的有效性验证。
        /// </summary>
        /// <param name="_value">需验证的字符串。。</param>
        /// <returns>是否合法的bool值。</returns>
        public static bool IsNumberId( string _value ) {
            return QuickValidate("^[1-9]*[0-9]*$", _value);
        }

        /// <summary>
        /// 检查一个字符串是否是纯字母和数字构成的，一般用于查询字符串参数的有效性验证。
        /// </summary>
        /// <param name="_value">需验证的字符串。</param>
        /// <returns>是否合法的bool值。</returns>
        public static bool IsLetterOrNumber( string _value ) {
            return QuickValidate("^[a-zA-Z0-9_]*$", _value);
        }


        /// <summary>
        /// 判断是否是数字，包括小数和整数。
        /// </summary>
        /// <param name="_value">需验证的字符串。</param>
        /// <returns>是否合法的bool值。</returns>
        public static bool IsNumber( string _value ) {
            return QuickValidate("^(0|([1-9]+[0-9]*))(.[0-9]+)?$", _value);
        }

        /// <summary>
        /// 快速验证一个字符串是否符合指定的正则表达式。
        /// </summary>
        /// <param name="_express">正则表达式的内容。</param>
        /// <param name="_value">需验证的字符串。</param>
        /// <returns>是否合法的bool值。</returns>
        public static bool QuickValidate( string _express, string _value ) {
            System.Text.RegularExpressions.Regex myRegex = new System.Text.RegularExpressions.Regex(_express);
            if (_value.Length == 0) {
                return false;
            }
            return myRegex.IsMatch(_value);
        }


        #endregion
        
        /// <summary>
        /// Outs the CSV file.
        /// </summary>
        /// <param name="strContent">Content of the STR.</param>
        /// <param name="strType">Type: txt ; csv </param>
        public static void OutFile( String Content, String fileName, String Type ) {
            String strHeader = string.Format("attachment;filename={0}", fileName + "." + Type);
            HttpContext.Current.Response.ClearHeaders();
            String strEncode = Res.GetProductEncode().ToUpper();
            if (string.IsNullOrEmpty(strEncode) || strEncode == "UTF8") {
                HttpContext.Current.Response.HeaderEncoding = System.Text.Encoding.UTF8;
            } else {
                HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding(strEncode);
            }

            HttpContext.Current.Response.ContentType = "application/x-octet-stream";
            HttpContext.Current.Response.AppendHeader("Content-Disposition", strHeader);
            HttpContext.Current.Response.Write(Content);
            HttpContext.Current.Response.End();
        }

        public static Int32 CompareDate( DateTime dtOne, DateTime dtTwo ) {
            TimeSpan tspan = dtOne.Subtract(dtTwo);
            tspan = tspan.Duration();//正负呢 ？
            return (int)tspan.TotalMinutes; 
        }



    }
}
