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

namespace MOD.UI.SkinFactory {
    public partial class ShowImage : System.Web.UI.Page {
        private readonly bool enableCaching = bool.Parse(ConfigurationManager.AppSettings["EnableCaching"]);
        protected void Page_Load(object sender, EventArgs e) {
            String strImgId = WebHelper.GetRequest("imgid");
            if (strImgId != "") {

                //ImageData img = (new Program()).GetImage(Int32.Parse(strImgId));

               
                ImageData img;
                if (!enableCaching) {
                     img = (new Program()).GetImage(Int32.Parse(strImgId));
                }

                img = (ImageData)HttpRuntime.Cache["img" + strImgId];

                if (img == null) {
                    img = (new Program()).GetImage(Int32.Parse(strImgId));
                    HttpRuntime.Cache.Insert("img" + strImgId, img,null,
                        DateTime.Now.AddMinutes(60d),System.Web.Caching.Cache.NoSlidingExpiration);//还需设计依赖性
                }


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
