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
        // ��̬������


        #region ==========���ܽ���
        /// <summary>
        /// ����Pid
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
        /// �����Ѿ����ܵ�PID
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
        /// ���ü�������
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
        /// ȡ ý������
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
        #region  ��������ַ�����
        /// <summary>
        /// ȡ�ַ����Ӵ�
        /// </summary>
        /// <param name="text">������</param>
        /// <param name="maxLength">��������ַ���󳤶�</param>
        /// <param name="replace">Empty ���ڽ�β�����κζ������ǿ��򸽼�</param>
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
        /// ��ȡ �����ģ��ַ���������ɵ��ַ����� ��������λ���ȣ�����һλ
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
        /// �滻html�е������ַ�
        /// </summary>
        /// <param name="theString">��Ҫ�����滻���ı���</param>
        /// <returns>�滻����ı���</returns>
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
        /// �ָ�html�е������ַ�
        /// </summary>
        /// <param name="theString">��Ҫ�ָ����ı���</param>
        /// <returns>�ָ��õ��ı���</returns>
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
        /// �����ڷǶ������ַ��ļ��飬���û��ʺŵ�����
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

        #region  ��ҳ��
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
        /// Ajax ��ҳ��
        /// </summary>
        /// <param name="strOnClick">this String Like:    getPager({0},"��������"),Ȼ���� Format��ʽ��</param>        
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

        #region ������ȡ��ת����Request, Session��
        public static String GetRequest( String strKey ) {
            if (HttpContext.Current.Request[strKey] != null)
                return HttpContext.Current.Request[strKey].ToString();
            return String.Empty;
        }

        /// <summary>
        /// ��ȡʱ�����
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
        /// ��Request���Ĳ���ת��Ϊ int
        /// </summary>
        /// <param name="strKey">������</param>
        /// <param name="nDefaultNum">������ΪNull,Emptyʱָ�����ص�Ĭ����ֵ</param>
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
        /// ȡWeb.Config Xml �ļ��������õ���ֵ����
        /// </summary>
        /// <param name="strKey">keys</param>
        /// <param name="nCount">���û�иò�����ת������ʱ,ָ����Ĭ����ֵ</param>
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
        /// ȡWeb.Config Xml �ļ��������õ�String����
        /// </summary>
        /// <param name="strKey"></param>
        /// <returns></returns>
        public static string GetAppSetting( string strKey ) {
            return ConfigurationManager.AppSettings[strKey];// null,empty,�ǿ�
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

        //ͨ��Asp.net�ؼ��������Ӧ��HTML�ַ�����ʾ
        public static string GetStringByControl( System.Web.UI.Control c ) {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            System.IO.StringWriter writer = new System.IO.StringWriter(sb);
            System.Web.UI.HtmlTextWriter htw = new System.Web.UI.HtmlTextWriter(writer);
            c.RenderControl(htw);
            return sb.ToString();
        }
        #endregion



        #region  ==========������NBear
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

        #region  �ַ�����֤
        /*
         "^\\d+$"����//�Ǹ������������� + 0�� 
        "^[0-9]*[1-9][0-9]*$"����//������ 
        "^((-\\d+)|(0+))$"����//���������������� + 0�� 
        "^-[0-9]*[1-9][0-9]*$"����//������ 
        "^-?\\d+$"��������//���� 
        "^\\d+(\\.\\d+)?$"����//�Ǹ����������������� + 0�� 
        "^(([0-9]+\\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\\.[0-9]+)|([0-9]*[1-9][0-9]*))$"����//�������� 
        "^((-\\d+(\\.\\d+)?)|(0+(\\.0+)?))$"����//�������������������� + 0�� 
        "^(-(([0-9]+\\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\\.[0-9]+)|([0-9]*[1-9][0-9]*)))$"����//�������� 
        "^(-?\\d+)(\\.\\d+)?$"����//������ 
        "^[A-Za-z]+$"����//��26��Ӣ����ĸ��ɵ��ַ��� 
        "^[A-Z]+$"����//��26��Ӣ����ĸ�Ĵ�д��ɵ��ַ��� 
        "^[a-z]+$"����//��26��Ӣ����ĸ��Сд��ɵ��ַ��� 
        "^[A-Za-z0-9]+$"����//�����ֺ�26��Ӣ����ĸ��ɵ��ַ��� 
        "^\\w+$"����//�����֡�26��Ӣ����ĸ�����»�����ɵ��ַ��� 
        "^[\\w-]+(\\.[\\w-]+)*@[\\w-]+(\\.[\\w-]+)+$"��������//email��ַ 
        "^[a-zA-z]+://(\\w+(-\\w+)*)(\\.(\\w+(-\\w+)*))*(\\?\\S*)?$"����//url
         */


        /// <summary>
        /// ���һ���ַ����Ƿ����ת��Ϊ���ڣ�һ��������֤�û��������ڵĺϷ��ԡ�
        /// </summary>
        /// <param name="_value">����֤���ַ�����</param>
        /// <returns>�Ƿ����ת��Ϊ���ڵ�boolֵ��</returns>

        public static bool IsStringDate( string date ) {
            DateTime dt;
            try {
                dt = DateTime.Parse(date);
            } catch (FormatException e) {
                //���ڸ�ʽ����ȷʱ
                e.ToString();
                return false;
            }
            return true;
        }

        /// <summary>
        /// ���һ���ַ����Ƿ��Ǵ����ֹ��ɵģ�һ�����ڲ�ѯ�ַ�����������Ч����֤��
        /// </summary>
        /// <param name="_value">����֤���ַ�������</param>
        /// <returns>�Ƿ�Ϸ���boolֵ��</returns>
        public static bool IsNumberId( string _value ) {
            return QuickValidate("^[1-9]*[0-9]*$", _value);
        }

        /// <summary>
        /// ���һ���ַ����Ƿ��Ǵ���ĸ�����ֹ��ɵģ�һ�����ڲ�ѯ�ַ�����������Ч����֤��
        /// </summary>
        /// <param name="_value">����֤���ַ�����</param>
        /// <returns>�Ƿ�Ϸ���boolֵ��</returns>
        public static bool IsLetterOrNumber( string _value ) {
            return QuickValidate("^[a-zA-Z0-9_]*$", _value);
        }


        /// <summary>
        /// �ж��Ƿ������֣�����С����������
        /// </summary>
        /// <param name="_value">����֤���ַ�����</param>
        /// <returns>�Ƿ�Ϸ���boolֵ��</returns>
        public static bool IsNumber( string _value ) {
            return QuickValidate("^(0|([1-9]+[0-9]*))(.[0-9]+)?$", _value);
        }

        /// <summary>
        /// ������֤һ���ַ����Ƿ����ָ����������ʽ��
        /// </summary>
        /// <param name="_express">������ʽ�����ݡ�</param>
        /// <param name="_value">����֤���ַ�����</param>
        /// <returns>�Ƿ�Ϸ���boolֵ��</returns>
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
            tspan = tspan.Duration();//������ ��
            return (int)tspan.TotalMinutes; 
        }



    }
}
