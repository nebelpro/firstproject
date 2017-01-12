using System;
using System.Web;



namespace MOD.BLL
{
    /// <summary>
    /// Summary description for Permit
    /// </summary>
    public class Permit
    {
        int iUserPermit = 0;
        int iGroupPermit = 0;


        /// <summary>
        /// ���캯������
        /// </summary>
        public Permit()
        {
            iUserPermit = Convert.ToInt32(System.Web.HttpContext.Current.Session["UserPermit"]);
            iGroupPermit = Convert.ToInt32(System.Web.HttpContext.Current.Session["GroupPermit"]);
        }
        /// <summary>
        /// ���캯������
        /// </summary>
        /// <param name="userpermit"></param>
        /// <param name="grouppermit"></param>
        public Permit(int userpermit, int grouppermit)
        {
            iUserPermit = userpermit;
            iGroupPermit = grouppermit;
        }


        // below ,the UserPermit analyze
        #region �û�Ȩ������
        /// <summary>
        /// �û���¼
        /// </summary>
        /// <returns></returns>
        public bool CanLogin()
        {
            bool CanLogin;
            if ((iGroupPermit &  PERMIT_TYPE.per_g_login) != 0)
            {
                if ((iUserPermit & PERMIT_TYPE.per_u_login) != 0)
                {
                    CanLogin = true;
                }
                else
                {
                    CanLogin = false;
                }
            }
            else
            {
                CanLogin = false;
            }
            return CanLogin;
        }
        /// <summary>
        /// �û��޸�����
        /// </summary>
        /// <returns></returns>
        public bool CanChangePwd()
        {
            bool CanChangePwd;
            if ((iUserPermit & PERMIT_TYPE.per_u_changepwd) != 0)
            {
                CanChangePwd = true;
            }
            else
            {
                CanChangePwd = false;
            }
            return CanChangePwd;
        }

        #endregion



        #region  ���Ȩ������
        /// <summary>
        /// ϵͳ�趨
        /// </summary>
        /// <returns></returns>
        public bool CanSysMng()
        {
            bool CanSysMng;

            if (((iGroupPermit & PERMIT_TYPE.per_g_sys_montior) | (iGroupPermit & PERMIT_TYPE.per_g_sys_user_mng)) != 0)   //??????
            {
                CanSysMng = true;
            }
            else
            {
                CanSysMng = false;
            }
            return CanSysMng;
        }
        /// <summary>
        /// ��ʾ����
        /// </summary>
        /// <returns></returns>
        public bool CanShowBill()
        {
            bool CanShowBill;           
            int csbV = Convert.ToInt32( GetMaskValue(7),16); // 5 ��Ϊ 7 ��2007.03.05
            if ((csbV &PERMIT_TYPE.showbill) != 0)
            {
                CanShowBill = true;
            }
            else
            {
                CanShowBill = false;
            }
            return CanShowBill;
        }
        /// <summary>
        /// �鿴˽��Ŀ¼
        /// </summary>
        /// <returns></returns>
        public bool CanViewPrivateFolder()
        {
            bool CanViewPrivateFolder;
            if ((iGroupPermit & PERMIT_TYPE.per_g_private_folder) != 0)
            {
                CanViewPrivateFolder = true;
            }
            else
            {
                CanViewPrivateFolder = false;
            }
            return CanViewPrivateFolder;
        }
        /// <summary>
        /// �γ̹���
        /// </summary>
        /// <returns></returns>
        public bool CanMngCourse()
        {
            bool CanMngCourse = CanHasCourse();

            return CanMngCourse;
        }
        /// <summary>
        /// ӵ�пγ� 
        /// </summary>
        /// <returns></returns>
        public bool CanHasCourse()
        {
            bool CanHasCourse;
            if ((iGroupPermit & PERMIT_TYPE.per_g_mycourse) != 0)
            {
                CanHasCourse = true;
            }
            else
            {
                CanHasCourse = false;
            }
            return CanHasCourse;

        }
        #endregion
        /*
         * program permit ��ĿȨ��
         *  */
        #region ��ĿȨ��
        /// <summary>
        /// ��Ŀ��Ŀ����
        /// </summary>
        /// <returns></returns>
        public bool CanFind()
        {
            bool CanFind;
            if ((iGroupPermit & PERMIT_TYPE.per_g_find) != 0)
            {
                CanFind = true;
            }
            else
            {
                CanFind = false;
            }
            return CanFind;
        }
        /// <summary>
        /// ��Ŀ����
        /// </summary>
        /// <returns></returns>
        public bool CanPlay()
        {
            bool CanPlay;
            if ((iGroupPermit & PERMIT_TYPE.per_g_play) != 0)
            {
                CanPlay = true;
            }
            else
            {
                CanPlay = false;
            }
            return CanPlay;
        }
        /// <summary>
        /// ��Ŀ����
        /// </summary>
        /// <returns></returns>
        public bool CanMngProgram()
        {
            bool CanMngProgram;
            if ((iGroupPermit & PERMIT_TYPE.per_g_mngprogram) != 0)
            {
                CanMngProgram = true;
            }
            else
            {
                CanMngProgram = false;
            }
            return CanMngProgram;
        }
        /// <summary>
        /// �������
        /// </summary>
        /// <returns></returns>
        public bool CanMngCatalog()
        {
            bool CanMngCatalog;
            if ((iGroupPermit & PERMIT_TYPE.per_g_sys_catalog_mng) != 0)
            {
                CanMngCatalog = true;
            }
            else
            {
                CanMngCatalog = false;
            }
            return CanMngCatalog;
        }
        /// <summary>
        /// ˽�н�Ŀ����
        /// </summary>
        /// <returns></returns>
        public bool CanSubPrivateProgram()
        {
            bool CanSubPrivateProgram;
            if ((iGroupPermit & PERMIT_TYPE.per_g_subtocheck) != 0)
            {
                CanSubPrivateProgram = true;
            }
            else
            {
                CanSubPrivateProgram = false;
            }
            return CanSubPrivateProgram;
        }
        /// <summary>
        /// ��Ŀ���
        /// </summary>
        /// <returns></returns>
        public bool CanAuditing()
        {
            bool CanAuditing;
            if ((iGroupPermit & PERMIT_TYPE.per_g_auditing) != 0)
            {
                CanAuditing = true;
            }
            else
            {
                CanAuditing = false;
            }
            return CanAuditing;
        }
        /// <summary>
        /// ��Ŀ����
        /// </summary>
        /// <returns></returns>
        public bool CanDownMedia()
        {
            bool CanDownMedia;
            if ((iGroupPermit & PERMIT_TYPE.per_g_media_down) != 0)
            {
                CanDownMedia = true;
            }
            else
            {
                CanDownMedia = false;
            }
            return CanDownMedia;
        }

        /// <summary>
        /// ��Ŀ�����
        /// </summary>
        /// <returns></returns>
        public bool CanFreeAduit()
        {
            bool CanFreeAduit;
            if ((iGroupPermit & PERMIT_TYPE.per_g_free_audit) != 0)
            {
                CanFreeAduit = true;
            }
            else
            {
                CanFreeAduit = false;
            }
            return CanFreeAduit;
        }

        /// <summary>
        /// ������Ϣ
        /// </summary>
        /// <returns></returns>
        public bool CanExportInfo()
        {
            bool CanExportInfo;
            if ((iGroupPermit & PERMIT_TYPE.per_g_export_info) != 0)
            {
                CanExportInfo = true;
            }
            else
            {
                CanExportInfo = false;
            }
            return CanExportInfo;
        }

        #endregion

        /*
         * Channel Permit
         *  */
        #region  Channel Permit
        /// <summary>
        /// Ƶ������
        /// </summary>
        /// <returns></returns>
        public bool CanSetChannel()
        {
            bool CanSetChannel;
            if ((iGroupPermit & PERMIT_TYPE.per_g_set_channel) != 0)
            {
                CanSetChannel = true;
            }
            else
            {
                CanSetChannel = false;
            }
            return CanSetChannel;
        }
        /// <summary>
        /// Ƶ������
        /// </summary>
        /// <returns></returns>
        public bool CanChannelReceive()
        {
            bool CanChannelReceive;
            if ((iGroupPermit & PERMIT_TYPE.per_g_channel_recive) != 0)
            {
                CanChannelReceive = true;
            }
            else
            {
                CanChannelReceive = false;
            }
            return CanChannelReceive;
        }
        /// <summary>
        /// Ƶ���㲥
        /// </summary>
        /// <returns></returns>
        public bool CanChannelCast()
        {
            bool CanChannelCast;
            if ((iGroupPermit & PERMIT_TYPE.per_g_channel_play) != 0)
            {
                CanChannelCast = true;
            }
            else
            {
                CanChannelCast = false;
            }
            return CanChannelCast;
        }
        /// <summary>
        /// Ƶ��ת��
        /// </summary>
        /// <returns></returns>
        public bool CanBroadCastPaly()
        {
            bool CanBroadCastPaly;
            if ((iGroupPermit & PERMIT_TYPE.per_g_channel_recive) != 0)
            {
                if (CanShowBroadCast())
                    CanBroadCastPaly = true;
                else
                    CanBroadCastPaly = false;
            }
            else
            {
                CanBroadCastPaly = false;
            }
            return CanBroadCastPaly;

        }
        /// <summary>
        /// ��ʾ�㲥��
        /// </summary>
        /// <returns></returns>
        public bool CanShowBroadCast()
        {
            bool CanShowBroadCast;
            int cbcpv = Convert.ToInt32(GetMaskValue(1));
            if (cbcpv == 0)
                CanShowBroadCast = false;
            else
                CanShowBroadCast = true;
            return CanShowBroadCast;
        }
        /// <summary>
        /// ֱ������
        /// </summary>
        /// <returns></returns>
        public bool CanLiveCastPaly()
        {
            bool CanLiveCastPaly;
            if ((iGroupPermit & PERMIT_TYPE.per_g_channel_recive) != 0)
            {
                if (CanShowLiveCast())
                    CanLiveCastPaly = true;
                else
                    CanLiveCastPaly = false;
            }
            else
                CanLiveCastPaly = false;

            return CanLiveCastPaly;
        }
        /// <summary>
        /// ��ʾֱ��
        /// </summary>
        /// <returns></returns>
        public bool CanShowLiveCast()
        {
            bool CanShowLiveCast;
            int clcpV = Convert.ToInt32(GetMaskValue(2));//cint(GetMaskValue(2))
            if (clcpV == 0)
                CanShowLiveCast = false;
            else
                CanShowLiveCast = true;
            return CanShowLiveCast;
        }
        /// <summary>
        /// ת������
        /// </summary>
        /// <returns></returns>
        public bool CanReBroadCastPaly()
        {
            bool CanReBroadCastPaly;
            if ((iGroupPermit & PERMIT_TYPE.per_g_channel_recive) != 0)
            {
                if (CanShowReBroadCast())
                    CanReBroadCastPaly = true;
                else
                    CanReBroadCastPaly = false;
            }
            else
                CanReBroadCastPaly = false;
            return CanReBroadCastPaly;
        }
        /// <summary>
        /// ��ʾת��
        /// </summary>
        /// <returns></returns>
        public bool CanShowReBroadCast()
        {
            bool CanShowReBroadCast;

            int clcpVB = Convert.ToInt32(GetMaskValue(1));// = cint(GetMaskValue(1))
            int clcpVL = Convert.ToInt32(GetMaskValue(2));// = cint(GetMaskValue(2))
            if ((clcpVB == 0) && (clcpVL == 1))
                CanShowReBroadCast = false;
            else
                CanShowReBroadCast = true;

            return CanShowReBroadCast;
        }
        /// <summary>
        /// ���Ŷ�¼��
        /// </summary>
        /// <returns></returns>
        public bool CanPlayerRecord()
        {
            bool CanPlayerRecord;
            if ((iGroupPermit & PERMIT_TYPE.per_g_player_record) != 0)
            {
                CanPlayerRecord = true;
            }
            else
            {
                CanPlayerRecord = false;
            }
            return CanPlayerRecord;
        }
        /// <summary>
        /// ֱ����¼��
        /// </summary>
        /// <returns></returns>
        public bool CanLiveRecord()
        {
            bool CanLiveRecord;
            if ((iGroupPermit & PERMIT_TYPE.per_g_live_record) != 0)
            {
                CanLiveRecord = true;
            }
            else
            {
                CanLiveRecord = false;
            }
            return CanLiveRecord;
        }


        /// <summary>
        /// ΢��Ȩ��
        /// </summary>
        /// <returns></returns>
        public bool CanWeigeReceive() {
            bool CanWeigeReceive;
            if((iGroupPermit&PERMIT_TYPE.per_g_weige)!=0){
                CanWeigeReceive=true;
            }else{
                CanWeigeReceive = false;
            }
            return CanWeigeReceive;
        }


        #endregion

        //  ��������Ȩ��
        #region ��������Ȩ�� 5��
        /// <summary>
        /// �û�����
        /// </summary>
        /// <returns></returns>
        public bool CanMngUser()
        {
            bool CanMngUser;
            if ((iGroupPermit & PERMIT_TYPE.per_g_sys_user_mng) != 0)
            {
                CanMngUser = true;
            }
            else
            {
                CanMngUser = false;
            }
            return CanMngUser;
        }

        /// <summary>
        /// �������
        /// </summary>
        /// <returns></returns>
        public bool CanBulletinMng()
        {
            bool CanBulletinMng;
            if ((iGroupPermit & PERMIT_TYPE.per_g_bulletin_mng) != 0)
            {
                CanBulletinMng = true;
            }
            else
            {
                CanBulletinMng = false;
            }
            return CanBulletinMng;
        }
        /// <summary>
        /// ˽��Ŀ¼
        /// </summary>
        /// <returns></returns>
        public bool CanMngPrivateFolder()
        {
            bool CanMngPrivateFolder;
            if ((iGroupPermit & PERMIT_TYPE.per_g_mng_privatefolder) != 0)
            {
                CanMngPrivateFolder = true;
            }
            else
            {
                CanMngPrivateFolder = false;
            }
            return CanMngPrivateFolder;
        }
        /// <summary>
        /// �Ʒѹ���
        /// </summary>
        /// <returns></returns>
        public bool CanRateMng()
        {
            bool CanRateMng;
            if ((iGroupPermit & PERMIT_TYPE.per_g_sys_rate_mng) != 0)
            {
                CanRateMng = true;
            }
            else
            {
                CanRateMng = false;
            }
            return CanRateMng;
        }

        /// <summary>
        /// ϵͳ���
        /// </summary>
        /// <returns></returns>
        public bool CanMonitor()
        {
            bool CanMonitor;
            if ((iGroupPermit & PERMIT_TYPE.per_g_sys_montior) != 0)
            {
                CanMonitor = true;
            }
            else
            {
                CanMonitor = false;
            }
            return CanMonitor;
        }
        #endregion

       

        public string GetMaskValue(int nIndex)
        {
            string GetMaskValue = string.Empty;

            if (HttpContext.Current.Session["edition_mask"] != null && HttpContext.Current.Session["edition_mask"].ToString() != string.Empty)
            {
                string EditonMask = HttpContext.Current.Session["edition_mask"].ToString();
                string[] gmvArr = EditonMask.Split(new Char[] { ':' });
                if (gmvArr.Length == 8) {
                    if (nIndex < gmvArr.Length) {
                        GetMaskValue = gmvArr[nIndex];
                    } else {
                        GetMaskValue = "0";
                    }
                } else if(gmvArr.Length==6){                  
                    if (nIndex == 7) {
                        GetMaskValue = gmvArr[5];
                    } else {
                        GetMaskValue = gmvArr[nIndex];
                    }

                }
            }
            try
            {
                Int32.Parse(GetMaskValue);
                return GetMaskValue;
            }
            catch
            {
                return "0";
            }

        }

       


        #region  ===ShowPermit()
        /*
        /// <summary>
        /// ȡӵ�е�Ȩ��Stringֵ
        /// </summary>
        /// <returns></returns>
        public string ShowPermit()
        {
            string sp_str = string.Empty;
            int sp_i = 0;
            getSpStr(CanChangePwd(), WebRSC.per_changepwd, ref sp_str, ref sp_i);
            getSpStr(CanViewPrivateFolder(), WebRSC.per_privatefolder, ref sp_str, ref sp_i);
            getSpStr(CanHasCourse(), WebRSC.per_usercourse, ref sp_str, ref sp_i);
            getSpStr(CanFind(), WebRSC.per_find, ref sp_str, ref sp_i);
            getSpStr(CanPlay(), WebRSC.per_paly, ref sp_str, ref sp_i);
            getSpStr(CanMngProgram(), WebRSC.per_mngprogram, ref sp_str, ref sp_i);
            getSpStr(CanMngCatalog(), WebRSC.per_mngcate, ref sp_str, ref sp_i);
            getSpStr(CanSubPrivateProgram(), WebRSC.per_subprogram, ref sp_str, ref sp_i);
            getSpStr(CanAuditing(), WebRSC.per_chkprogram, ref sp_str, ref sp_i);
            getSpStr(CanDownMedia(), WebRSC.per_mediadown, ref sp_str, ref sp_i);
            getSpStr(CanFreeAduit(), WebRSC.per_freeaduit, ref sp_str, ref sp_i);
            getSpStr(CanSetChannel(), WebRSC.per_channel_set, ref sp_str, ref sp_i);
            getSpStr(CanChannelReceive(), WebRSC.per_channel_receive, ref sp_str, ref sp_i);
            getSpStr(CanChannelCast(), WebRSC.per_channel_play, ref sp_str, ref sp_i);
            getSpStr(CanPlayerRecord(), WebRSC.per_rec_live, ref sp_str, ref sp_i);
            getSpStr(CanLiveRecord(), WebRSC.per_rec_player, ref sp_str, ref sp_i);
            getSpStr(CanMngUser(), WebRSC.per_mnguser, ref sp_str, ref sp_i);

            getSpStr((CanBulletinMng() && CanRateMng()), WebRSC.per_mngbulletin, ref sp_str, ref sp_i);

            getSpStr(CanMngPrivateFolder(), WebRSC.per_mngprivatefloder, ref sp_str, ref sp_i);
            getSpStr(CanRateMng(), WebRSC.per_ratemng, ref sp_str, ref sp_i);
            getSpStr(CanMonitor(), WebRSC.per_sysmonitor, ref sp_str, ref sp_i);

            return sp_str;
        }

        /// <summary>
        /// ShowPermit()�ĸ�������
        /// </summary>
        /// <param name="Istrue"></param>
        /// <param name="strper"></param>
        /// <param name="spstr"></param>
        /// <param name="spi"></param>
        public void getSpStr(bool Istrue, string strper, ref string spstr, ref int spi)
        {
            if (Istrue)
            {
                spstr = spstr + strper + " ";
                spi = spi + 1;
                if (((spi % 5) == 0) && (spi != 1))
                {
                    spstr = spstr + "<br>";
                }
            }
        }
        #endregion

        */
       

        #endregion


       
    }
}