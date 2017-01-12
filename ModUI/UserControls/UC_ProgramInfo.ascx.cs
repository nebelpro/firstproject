using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using MOD.BLL;
using MOD.Model;
using MOD.WebUtility;

namespace MOD.UI.UserControls {
    public partial class UC_ProgramInfo : MOD.WebUtility.UI.UserControl {       
        public Int32 nPoint = 0;
        public Int32 nPClass = 0;
        public Int32 nPGroupMask = 0;

        protected void Page_Load( object sender, EventArgs e ) {
            BindProgramIntro();
            BindMediaServer();

            if (this.GetSession(SETTING_TYPE.KEY_ALLOW_REMARK, 0) != 0) {
                tabPage2.Visible = true;
            } else {
                tabPage2.Visible = false;
            }
        }
        
        /// <summary>
        /// °ó¶¨½ÚÄ¿½éÉÜ
        /// </summary>
        public void BindProgramIntro() {
            int nProgramId = this.GetIntParam("pid", 0);
            ProgramData prmdata = (new Program()).GetDetail(nProgramId);
            ltrDirector.Text = prmdata.PDirector;
            ltrActor.Text = prmdata.PActor;
            ltrAddtime.Text = prmdata.PAddTime.ToShortDateString() + " " + prmdata.PAddTime.ToLongTimeString();
            ltrClass.Text = prmdata.PClass.ToString();
            ltrIntro.Text = (prmdata.PInfo == "" ? this.GetRes("INFO_PROGRAM_NOINTRO") : this.TextIn(prmdata.PInfo));
            ltrKbps.Text = prmdata.nKbps+" Kbps";
            ltrName.Text = prmdata.PName;
            ltrReadCount.Text = prmdata.PReadCount.ToString();
            ltrTime.Text = prmdata.nTime;
            ltrPoint.Text = prmdata.PPoint.ToString();
            nPoint = prmdata.PPoint;
            nPClass = prmdata.PClass;
            nPGroupMask = prmdata.PGroupMask;

            ltrImg.Text = "<img src=\"" + ProgramHelper.GetProgramImage(prmdata.PImageId) + "\"  "
                                + ProgramHelper.OutImageWidthHeight(240, 200, prmdata.PImageId) + " class=\"image\" alt=\"" + prmdata.PName + "\"/>";

            if ((new Permit()).CanPlay()) {
                int maxfreetime = SettingHelper.GetFreeTime();                
                string strFirstPlayTime = (new PointCard()).GetFirstPlayTimeByProgramId(nProgramId, this.UserID);

                String strCardValid = this.GetSession("CardValid");
                Boolean bUseMonthCard = false;
                if (strCardValid.Length != 0) {
                    DateTime dt = DateTime.Parse(strCardValid);
                    if (WebHelper.FormatDateTime(dt, 1) >= DateTime.Now)
                        bUseMonthCard = true;
                }

                if (prmdata.PPoint != 0 && maxfreetime != 0 && !bUseMonthCard) {
                    if (BLLHelper.BoolFreeTime(DateTime.Now, strFirstPlayTime)) {
                        DateTime dtbefore = (DateTime.Parse(strFirstPlayTime)).AddMinutes(maxfreetime);
                        ltrTimeLeft.Text = " <span style=\"color:red\">(" + string.Format(this.GetRes("Info_Program_FreeTime"), dtbefore.ToString())+")</span>";
                    }
                }
            }
            ltrPlay.Text = "<img src=\"images/depend/btn_play.gif\" onclick=\"javascript:" + ProgramHelper.GetPlayUrl(prmdata.PId, 0, 0) + "\" alt=\"\" />";
            this.Page.Title = ltrName.Text;
        }


        public String BindUrl( Int32 nRegister, Int32 nPId, Int32 nMsId, Int32 nIndex ) {
            if (nRegister != 1) {
                return "--";
            } else {
                return "<a onclick=\"" + ProgramHelper.GetPlayUrl(nPId, nMsId, nIndex) + "\" href=\"javascript://\">" + this.GetRes("Oper_Play") + "</a>";
            }
        }

        public String BindDownload(Int32 nRegister,Int32 nPId,Int32 nMsId,Int32 nIndex) {
            string strUrl=ProgramHelper.Download(nPId, nMsId, nIndex);
            if (nRegister != 1||strUrl=="") {
                return "--";
            } else {
                return strUrl;
            }
        }



        protected void BindMediaServer() {
            
            Int32 nPId = this.GetIntParam("pid", 0);
            IList<MediaServerData> MsList = (new Program()).GetMediaServer(nPId);
            if (MsList.Count > 1) {
                tabPage4.Visible = true;
                rptMediaServer.DataSource = MsList;
                rptMediaServer.DataBind();

            } else {
                tabPage4.Visible = false;
            }

        }
    }
}