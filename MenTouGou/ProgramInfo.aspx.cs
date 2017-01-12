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
    public partial class ProgramInfo : MOD.WebUtility.UI.Page {
        protected void Page_Load( object sender, EventArgs e ) {
            if (!Page.IsPostBack) {
                Int32 nPid = this.GetIntParam("pid", 0);
                this.Page.Title = this.GetRes("Info_ProgramInfo");




                Int32 nCatalogId = (new Program()).GetCatalogByProgramId(nPid);
                if (nCatalogId <= 21) {  //��Ŀ���Ʒ����� 21����������У� �����21��ǰ�ķ����У����޷���ʾ��Ŀ����ת����ҳ�ˣ�
                    Response.Redirect("Default.aspx");
                }
                String strUrlFormat = "<a href=\"ViewByClass.aspx?cid={0}\">{1}</a>";
                CatalogData cata = (new Catalog()).GetDetail(nCatalogId);
                if (cata.CParentId > 21) {
                    this.Master.CurPath = ProgramHelper.GetCatalogStepByCId(nCatalogId, strUrlFormat, cata.CParentId) + " / " + this.GetRes("Info_ProgramInfo");
                } else {
                    this.Master.CurPath = " / " + string.Format(strUrlFormat, nCatalogId, cata.CName) + " / " + this.GetRes("Info_ProgramInfo");
                }


            }
        }
    }
}
