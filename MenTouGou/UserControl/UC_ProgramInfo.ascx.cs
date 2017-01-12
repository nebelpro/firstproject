using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using MOD.Model;
using MOD.BLL;
using MOD.WebUtility;

namespace mentougou.UserControl {
    public partial class UC_ProgramInfo : MOD.WebUtility.UI.UserControl {
        protected void Page_Load( object sender, EventArgs e ) {
            if (!Page.IsPostBack) {
                BindProgramInfo();
            }
        }

        public void BindProgramInfo() {
            
            Int32 nPid = this.GetIntParam("pid", 0);            
            #region  绑定节目信息
            Permit permit = new Permit();
            ProgramData pda = (new Program()).GetDetail(nPid);
            if (pda != null) {
                ltrImg.Text = "<img  src=\"" +
                                ProgramHelper.GetProgramImage(pda.PImageId, "program_default.gif") + "\" "
                                + ProgramHelper.OutImageWidthHeight(150,180, pda.PImageId) + "  class=\"image\" alt=\"" + pda.PName + "\"/>";
                ltrName.Text = "<img src=\"Images/mediatype/"+WebHelper.GetMediaType(pda.PMediaKind)+"\" alt=\"\" /> "+pda.PName;
               
                ltrDirector.Text = pda.PDirector;
                ltrClass.Text = pda.PClass.ToString();
                ltrActor.Text = pda.PActor;
                ltrPublish.Text = pda.PPublish;
                ltrTime.Text = pda.nTime;
                ltrKbps.Text = pda.nKbps + "kbps";
                ltrReadCount.Text = pda.PReadCount.ToString();
                ltrAddTime.Text = pda.PAddTime.ToString();
                ltrAddUser.Text = pda.PAddUser;
                ltrPoint.Text = pda.PPoint.ToString();
                ltrInfo.Text = (pda.PInfo == "" ? "" : ("<li class=\"infoLi\">" + this.TextIn(pda.PInfo) + "</li>"));
                ltrPlay.Text = "<a href=\"#\" onclick=\"javascript:" + ProgramHelper.GetPlayUrl(pda.PId, 0, 0) + "\"><img src=\"Images/depend/btn_play.gif\" alt=\"\"/></a>";
            
            #endregion
            }
        }


    }

    


}