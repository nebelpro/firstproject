using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using MOD.BLL;
using MOD.Model;

namespace MOD.WebUtility {
    public class ProgramHelper {        

        public static String GetProgramImage( Int32 nImgId ) {
            return GetProgramImage(nImgId, "program_defult.gif");                      
        }

        public static String GetProgramImage( Int32 nImgId, String defaultImg ) {
            return nImgId == 11 ? ("Images/nodepend/" + defaultImg) : ("ShowImage.aspx?imgid=" + nImgId);            
        }


        /// <summary>
        /// MakeUrl ����˵��(���š����ء��μ�ʹ��)
        /// pid ���ܺ�Ľ�ĿID�ִ�,msid ý�������IDĬ��Ϊ0,indexƬ������Ĭ��Ϊ0, mtý������
        /// t �������� �μ������� ENMU_PLAY_TYPE,flag ��Ǵ�Щ����Ƿ����Ĭ��0��ʾ����        
        /// �㲥��ַ
        /// </summary>
        public static String GetPlayUrl( Int32 nPid, Int32 nMsid, Int32 nPcindex ) {
            StringBuilder sbOut = new StringBuilder();
            Int32 nUserId = WebHelper.GetSession("UserId", 0);

            String strUserValid = HttpContext.Current.Session["CardValid"].ToString();
            DateTime dtValid = DateTime.Parse(strUserValid);

            Consume myConsume = new Consume(nUserId, nPid, dtValid, nPcindex, nMsid);
            Int32 nConsumePoint = myConsume.PrepareCharge();
            if (nConsumePoint >= 0) {
                String strPid = WebHelper.EncryptPid(nPid);
                String strPlayMode = "openwndex('ProgramPlay.aspx?id=" + strPid + "&msid=" + nMsid.ToString()
                    + "&index=" + nPcindex.ToString() + "','" + Res.GetValue("INFO_POP_PLAY") + "',2,20)";
                strPlayMode = "if(IsPlay(" + myConsume.consumePoint.ToString() + ")){" + strPlayMode + "}";

                sbOut.Append(strPlayMode);
            } else if (nConsumePoint == (Int32)Consume.RET.NoLogin) {
                sbOut.Append("alert('" + Res.GetValue("WARN_NOLOGIN") + "')");
            } else if (nConsumePoint == (Int32)Consume.RET.ErrGroupMask) {
                sbOut.Append("alert('" + Res.GetValue("WARN_NOPLAYPMERIT") + "')");
            } else if (nConsumePoint == (Int32)Consume.RET.ErrPermit) {
                sbOut.Append("alert('" + Res.GetValue("WARN_NOPERMIT") + "')");
            } else if (nConsumePoint == (Int32)Consume.RET.NoPoint) {
                sbOut.Append("alert('" + Res.GetValue("WARN_NOPOINT") + "')");
            }
            return sbOut.ToString();
        }


        /// <summary>
        /// �������ص�Url
        /// </summary>
        /// <param name="nPid"></param>
        /// <param name="nMsid"></param>
        /// <param name="nPcindex">������Ϊindex����Ŀ����ΪƬ��ID</param>
        /// <param name=""></param>
        /// <param name="strType"></param>
        /// <returns></returns>
        public static String Download( Int32 nPid, Int32 nMsid, Int32 nPcindex ) {
            Int32 nUserId = WebHelper.GetSession("UserId", 0);
            string strDownUrl =(new Consume(nUserId, nPid, nPcindex, nMsid)).Download();
            if (strDownUrl != "") {
                return "<a href=\"javascript://\" onclick=\"openwndex('Download.aspx?&url=" + strDownUrl
                     + "&id=" + WebHelper.EncryptPid(nPid) + "','',2,20);\">" + Res.GetValue("Oper_Download") + "</a>";
            } else {
                return "";
            }
        }

        /// <summary>
        /// ԭʼͼƬ����,�����ַ��� height="XX" width="XX"
        /// </summary>
        /// <param name="nNewWidth">�¿��</param>
        /// <returns></returns>
        public static String OutImageWidthHeight( Int32 nNewWidth, Int32 nNewHeight, Int32 nImageId ) {
            ImageData ida = (new BLL.Program()).GetImage(nImageId);
            if (ida != null) {         
                Int32 nTmpHeight = nNewWidth * ida.Height / ida.Width;
                Int32 nTmpWidth = nNewWidth;
                if (nTmpHeight > nNewHeight) {
                    nTmpHeight = nNewHeight;
                    nTmpWidth = nTmpHeight * ida.Width / ida.Height;
                    if (nTmpWidth > nNewWidth)  nTmpWidth = nNewWidth;
                }
                return "width=\"" + nTmpWidth + "\" height=\"" + nTmpHeight + "\"";
            }
            return "width=\"" + nNewWidth + "\" height=\"" + nNewHeight + "\"";
        }

        public static String GetChapterName( String strChapterFileName ) {
            if (strChapterFileName.Length != 0) {
                Int32 nPos = strChapterFileName.LastIndexOf(".");
                String strSuffix = strChapterFileName.Substring(nPos);
                strChapterFileName = strChapterFileName.Replace(strSuffix, "");
                nPos = strChapterFileName.LastIndexOf(".");

                if (nPos != -1) {
                    strChapterFileName = strChapterFileName.Substring(0, nPos);
                }
                return strChapterFileName + strSuffix;
            }
            return "";
        }

        /// <summary>
        /// INFO_REMARK_STATE0:δ���
        /// INFO_REMARK_STATE1:�����
        /// </summary>
        /// <param name="nState"></param>
        /// <returns></returns>
        public static String GetRemarkState( Int32 nState ) {
            if (nState == 0) {
                return "<span style=\"color:green;\">" + Res.GetValue("INFO_REMARK_STATE0") + "</span>";
            } else {
                return "<span style=\"color:red;\">" + Res.GetValue("INFO_REMARK_STATE1") + "</span>";
            }
        }

        public static int GetProgramCountByCatalogId( Int32 nCatalogId ) {
            int nGroupMask = WebHelper.GetSession("GroupMask", 0);
            int nGroupClass = WebHelper.GetSession("GroupClass", 0);
            return (new Program()).GetCount(nCatalogId, (int)Define.ENUM_PROGRAM_PROPERTY.p_check_pass, nGroupClass, nGroupMask);
        }

        #region =============Admin Manager
       


        // <a href="#" onclick="program.GetListByCatalog(1,{0}");">{1} "</a>

        /// <summary>
        /// ��Ŀ�������Ľ�Ŀ����
        /// </summary>
        /// <param name="pid">The pid.</param>
        /// <param name="strFormat">The STR format.</param>
        /// <returns></returns>
        public static String GetCatalogStepByProgramId( int pid, string strFormat, Int32 TopParentId )  //Ҳ���û�˽��Ŀ¼��Ŀ¼��ȡ
        {
            // A/B/C/D/E
            Catalog cataBll = new Catalog();
            String strRet = "";
            Int32 nParentId = (new Program()).GetCatalogByProgramId(pid);


            while (nParentId > TopParentId) {
                CatalogData cda = cataBll.GetDetail(nParentId);
                string temp = string.Format(strFormat, cda.CId, cda.CName);
                strRet = " / " + temp + strRet;

                nParentId = cataBll.GetParentByCId(nParentId);
            }

            return strRet;

        }


        public static String GetCatalogStepByCId( int CId, string strFormat ) {
            CatalogData catalogDta = (new Catalog()).GetDetail(CId);
            String strName = catalogDta.CName;
            String strSerial = catalogDta.CSerial;
            String strNavList = "";
            Int32 nLevel = strSerial.Length / 4;
            if (nLevel > 2) {
                Catalog c = new Catalog();
                for (Int32 i = 2; i <= nLevel; i++) {
                    String strCurSerial = strSerial.Substring(0, i * 4);
                    CatalogData cdNavCur = c.GetDetailBySerial(strCurSerial);
                    if (cdNavCur != null) {
                        if (cdNavCur.CSerial != strSerial)
                            strNavList += string.Format(strFormat, cdNavCur.CId, cdNavCur.CName) + " - ";
                        else {
                            strNavList += "<span>" + cdNavCur.CName + "</span>";
                        }
                    }
                }
            } else {
                strNavList += "<span>" + strName + "</span>";
            }

            return strNavList;
        }
        /// <summary>
        /// ���༶��
        /// Info_CatalogView:�������
        /// </summary>
        /// <param name="CId">The C id.</param>
        /// <param name="strFormat">[a href="ViewByClass.aspx?cid={0}"]{1}[/a]</param>
        /// <param name="TopParentId">The top parent id.</param>
        /// <returns></returns>
        public static String GetCatalogStepByCId( int CId, string strFormat, Int32 TopParentId )  //Ҳ���û�˽��Ŀ¼��Ŀ¼��ȡ
        {
            // A/B/C/D/E
            Catalog cataBll = new Catalog();
            String strRet = "";
            Int32 nParentId = CId;

            while (nParentId >= TopParentId) {
                if (nParentId != 0) {
                    CatalogData cda = cataBll.GetDetail(nParentId);
                    string temp = string.Format(strFormat, cda.CId, cda.CName);
                    strRet = " / " + temp + strRet;

                    nParentId = cataBll.GetParentByCId(nParentId);
                } else {
                    strRet = "/" + string.Format(strFormat, 0, Res.GetValue("Info_CatalogView")) + strRet;
                    nParentId = -1;
                }
            }

            return strRet;

        }


        #endregion

    }
}
