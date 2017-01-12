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

namespace MOD.WebTd
{
    public partial class ProgramInfo : MOD.WebUtility.UI.Page
    {
        public Int32 nPid = 0;
        public Int32 nPClass = 0;
        public Int32 nPMask = 0;
        public Int32 nPpoint = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            nPid = this.GetIntParam("pid", 0);

            if (!Page.IsPostBack)
            {
                
                if (nPid == 0) {
                    Response.Redirect("Default.aspx"); 
                }
                ProgramData prmdata = (new Program()).GetDetail(nPid);
                if (prmdata == null)
                    Response.Redirect("Default.aspx");

                nPClass = prmdata.PClass;
                nPMask = prmdata.PGroupMask;
                nPpoint = prmdata.PPoint;

                // check user is can view this program
                
              
               
                if(this.GroupClass < nPClass || (this.GroupMask & nPMask) < 0)
                    Response.Redirect("Default.aspx");


                lbPosi.Text = String.Format(Helper.PositionBar,prmdata.PName);

                ltrImg.Text = "<img src=\""+ProgramHelper.GetProgramImage(prmdata.PImageId)+"\" "
                    +ProgramHelper.OutImageWidthHeight(160,160,prmdata.PImageId)+" />";
                if ((new Permit()).CanPlay()) {
                    ltrPlay.Text = "<img src=\"Images/depend/btn_play_big.gif\" class=\"hand\" onclick=\"OpenPlay('" + WebHelper.EncryptPid(nPid) + "',0,"+prmdata.PMediaKind+");\" alt=\"\">";
                }
             
                if ((new Permit()).CanDownMedia()) {
                    ltrDown.Text = "<img src=\"Images/depend/btn_down_big.gif\" class=\"hand\" onclick=\"OpenDown('" + WebHelper.EncryptPid(nPid) + "',0);\" alt=\"\">";
                }
                ltrActor.Text = prmdata.PActor;
                ltrDirector.Text = prmdata.PDirector;
                ltrAddtime.Text = prmdata.PAddTime.ToShortDateString() + " " + prmdata.PAddTime.ToLongTimeString();
                ltrClass.Text = prmdata.PClass.ToString();
                if (prmdata.PInfo == string.Empty)
                {
                    pnlPrmIntro.Visible = false;
                }
                else
                {
                    ltrIntro.Text = prmdata.PInfo;
                }
                ltrKbps.Text = prmdata.nKbps + " Kbps";
                ltrName.Text = prmdata.PName;
                ltrReadCount.Text = prmdata.PReadCount.ToString();
                ltrTime.Text = prmdata.nTime;
                ltrPoint.Text = prmdata.PPoint.ToString();
                this.Page.Title = prmdata.PName;


               

               
            }
        }


       


     

        

    }
}