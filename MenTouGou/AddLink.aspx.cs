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

using MOD.BLL;
using MOD.WebUtility;
using MOD.Model;
namespace mentougou {
    public partial class AddLink : MOD.WebUtility.UI.Page {
        protected void Page_Load( object sender, EventArgs e ) {
            if (!(new Permit()).CanMngProgram()) {
                Response.Write("<script>self.close();</script>");
            }
            if (!Page.IsPostBack) {
                int nCid = this.GetIntParam("cid", 0);
                if (nCid != 0) {
                    ibtnAdd.ImageUrl = "Images/depend/m_button_edit.gif";
                    ChannelData chda = (new Channel()).GetChannelInfoById(nCid);
                    tbInfo.Text = this.TextOut(chda.CInfo);
                    tbName.Text = this.TextOut(chda.CName);
                } else {
                    ibtnAdd.ImageUrl = "Images/depend/btn_ok.gif";
                }
            }

        }
        protected void ibtnAdd_Click( object sender, ImageClickEventArgs e ) {
            if (WebHelper.GetStringLength(tbName.Text) == 0) {
                lblError.Text = "*" + this.GetRes("Warn_LinkNameNoTitle");
                return;
            }
            if (WebHelper.GetStringLength(tbName.Text) > 30) {
                lblError.Text = "*" + this.GetRes("Warn_LinkNameTitleOutLength");
                return;
            }
            if (WebHelper.GetStringLength(tbInfo.Text) == 0) {
                lblError.Text = "*" + this.GetRes("Warn_LinkHrefNoContent");
                return;
            }
            if (WebHelper.GetStringLength(tbInfo.Text) > 512) {
                lblError.Text = "*" + this.GetRes("Warn_LinkHrefContentOutLenght");
                return;
            }
            lblError.Text = "";
            string strInfo = this.TextIn(tbInfo.Text);
            string strName = this.TextIn(tbName.Text);
            int nCid = this.GetIntParam("cid", 0);

            if (nCid != 0) {
                 ChannelData chda = new ChannelData();
                 chda.CId = nCid;
                chda.CName = strName;
                chda.CInfo = strInfo;
                chda.CCreateTime = DateTime.Now;
                chda.CUserId = this.UserID;
                Int32 nRet=(new Channel()).Update(chda);
                if (nRet == -1) {
                    lblError.Text = "*" + this.GetRes("Warn_LinkNameExist");
                    return;
                } else {
                    Response.Write("<script>parent.returnValue = 1;parent.window.close()</script>");
                }
            } else {
                ChannelData chda = new ChannelData();
                chda.CId = 0;
                chda.CName = strName;
                chda.CInfo = strInfo;
                chda.CType = 5;//Temp Type
                chda.CCreateTime = DateTime.Now;
                chda.CUserId = this.UserID;
                Int32 nRet = (new Channel()).Insert(chda);
                if (nRet == -1) {
                    lblError.Text = "*" + this.GetRes("Warn_LinkNameExist");
                    return;
                } else {
                    Response.Write("<script>parent.returnValue = 1;parent.window.close()</script>");
                }
            }
        }
    }
}
