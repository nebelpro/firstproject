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
using MOD.Model;
using MOD.WebUtility;

namespace MOD.UI.UserControls {
    public partial class UC_GuestBookAdd : MOD.WebUtility.UI.UserControl {
        protected void Page_Load( object sender, EventArgs e ) {            
        }

        protected void Add_Click(object sender, EventArgs e) {
            lblTips.Text = "";
            /* ChkSubject:function(){
        
        if(sSubject.length == 0){
            alert(this.tips.nonull);
            $("txtSubject").focus();
            return false;
        }else if(sSubject.length > 32){
            alert(this.tips.reg_outlen);
            $("txtSubject").focus();
            return false;
        }else{
            this.subject=sSubject;
            return true;
        }    
    },
    ChkInfo:function(){
        var sInfo = $("txtInfo").value.strip();      
        if(sInfo.len() == 0){
            alert(this.tips.nonull);
            $("txtInfo").focus();
            return false;
        }else if(sInfo.len() > 2048){
            alert(this.tips.gboutrange);
            $("txtInfo").focus();
            return false;
        }else{	    
            this.info = sInfo;	      
            return true;
        }    
    },*/


            String strSubject = this.txtSubject.Value.Trim();
            String strInfo = this.txtInfo.Value.Trim();
            Int32 nType = this.gbType0.Checked ? 0 : 1;
            if (strSubject == "" || strInfo == "" ) {
                lblTips.Text = "* " + this.GetRes("Warn_GuestBookNotEmpty");
            }else if (WebHelper.GetStringLength(strSubject)> 32) {
                lblTips.Text = "* " + this.GetRes("Warn_GuestBookSubjectLength");
            }else if(WebHelper.GetStringLength(strInfo)>2048){
                lblTips.Text = "* " + this.GetRes("Warn_GuestBookInfoLength");
            }else {
                GuestBookData gb = new GuestBookData();
                gb.GbDate = DateTime.Now;
                gb.GbInfo = WebHelper.TextIn(strInfo);
                gb.GbSubject = WebHelper.TextIn(strSubject);
                gb.GbType = nType;
                gb.GbUser = this.UserMask;
                (new BLL.GuestBook()).Insert(gb);
                Response.Redirect("GuestBook.aspx");

            }

        }
    }
}