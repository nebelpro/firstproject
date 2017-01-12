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
    public partial class AddBulletin : MOD.WebUtility.UI.Page {
        protected void Page_Load( object sender, EventArgs e ) {
            if (!Page.IsPostBack) { 
                if (!(new Permit()).CanBulletinMng()) {
                    Response.Write("<script>self.close();</script>");
                }              

                int nBid = this.GetIntParam("bid",0);
                if (nBid != 0) {
                    ibtnAdd.ImageUrl = "Images/depend/m_button_edit.gif";
                    BulletinData bda = (new Bulletin()).GetBulletinByBid(nBid);
                    tbInfo.Text = this.TextOut(bda.BInfo);
                    tbName.Text = this.TextOut(bda.BName);                    
                } else {
                    ibtnAdd.ImageUrl = "Images/depend/m_button_newbulletin.gif";
                }
            }
        }

        protected void ibtnAdd_Click( object sender, ImageClickEventArgs e ) {
            if (WebHelper.GetStringLength(tbName.Text) == 0 ){
                lblError.Text = "*"+this.GetRes("Warn_BulletinNoTitle");
                return;
            }
            if ( WebHelper.GetStringLength(tbName.Text) > 32) {
                lblError.Text = "*" + this.GetRes("Warn_BulletinTitleOutLength");
                return;
            }
            if (WebHelper.GetStringLength(tbInfo.Text) == 0){
                lblError.Text = "*" + this.GetRes("Warn_BulletinNoContent");
                return;
            }
            if (WebHelper.GetStringLength(tbInfo.Text) > 512) {
                lblError.Text = "*" + this.GetRes("Warn_BulletinContentOutLenght");
                return;
            }
            lblError.Text = "";
            string strInfo = this.TextIn(tbInfo.Text);
            string strName = this.TextIn(tbName.Text);
            int nBid = this.GetIntParam("bid",0);           

            if (nBid != 0) {
                (new Bulletin()).Update(new BulletinData(nBid,strName,strInfo,DateTime.Now,this.UserID,this.UserName));
                Response.Write("<script>parent.returnValue = 1;parent.window.close()</script>");
            } else {
                (new Bulletin()).Insert(new BulletinData(0, strName, strInfo, DateTime.Now, this.UserID, this.UserName));
                Response.Write("<script>parent.returnValue = 1;parent.window.close()</script>");
            }
        }
    }
}
