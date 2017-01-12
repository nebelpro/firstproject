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

namespace MOD.UI {
    public partial class ShowImage : MOD.WebUtility.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            String strImgId = WebHelper.GetRequest("imgid");
            if (strImgId != "") {
                ImageData img = (new BLL.Program()).GetImage(Int32.Parse(strImgId));
                if (img != null) {
                    Response.ClearContent();
                    Response.ContentType = "Images/jpeg";
                    Response.BinaryWrite(img.Data);
                    Response.End();
                }
            }
        }
    }
}
