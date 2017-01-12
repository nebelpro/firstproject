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

namespace mentougou {
    public partial class ProgramPlay : MOD.WebUtility.UI.Page {
        public string strPlayUrl = "";

        /// <summary>
        ///  节目点播
        /// </summary>
        protected void Page_Load( object sender, EventArgs e ) {

            if (this.UserID == 0) WebHelper.MsgBox(this.GetRes("WARING_NOLOGIN"), false, "", true);
            else {

                Int32 nId = 0;
                if (WebHelper.GetRequest("id") != String.Empty) nId = WebHelper.DecryptPid(WebHelper.GetRequest("id"));
                if (nId == 0) WebHelper.MsgBox(this.GetRes("ERR_PARAMS"), false, "", true);
                Int32 nPcIndex = this.GetIntParam("index", 0);
                Int32 nMsId = this.GetIntParam("msid", 0);
                string CardValid = this.GetSession(UserHelper.SESSION_TYPE.CardValid);
                DateTime dtValid = WebHelper.FormatDateTime(Convert.ToDateTime(CardValid), 1);


                Consume consume = new Consume(this.UserID, nId, dtValid, nPcIndex, nMsId);               
                if (consume.PrepareCharge() >= 0) { //实际扣点，并添加相应的消费记录
                    UserHelper.SetUserPointSession(this.UserID);
                    strPlayUrl = consume.Play();
                } else {
                    Response.Write("<script>parent.returnValue = 1;self.close();</script>");
                    Response.End();
                }
                
            }
        }


       
      

    }
}