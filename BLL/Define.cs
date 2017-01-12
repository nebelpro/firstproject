using System;
using System.Collections.Generic;
using System.Text;

namespace MOD.BLL {




    public class PERMIT_TYPE {


        #region 权限设置常量
        //User Permit

        public const int per_u_login = 0x1;                   // 1
        public const int per_u_changepwd = 0x2;			    //01

        //Group Permit int value
        public const int per_g_login                =   0x1;			        //01
        public const int per_g_private_folder       =   0x2;			//10
        public const int per_g_mng_privatefolder    =   0x4;       //100
        public const int per_g_mycourse             =   0x8;	            //1000

        public const int per_g_find                 =   0x10;                   //节目查找 10 000
        public const int per_g_subtocheck           =   0x20;             //100 000
        public const int per_g_media_down           =   0x40;		        //1 000 000

        public const int per_g_play                 =   0x100;			        //100 000 000
        public const int per_g_mngprogram           =   0x200;	        //1 000 000 000
        public const int per_g_free_audit           =   0x400;           //免审核 //10 000 000 000
        public const int per_g_auditing             =   0x800;             //100 000 000 000

        

        //int per_g_broadcast_play = 262144;
        //int per_g_livecast_play = 262144;
        public const int per_g_set_channel          =   0x10000;	        //10 000 000 000 000 000
        public const int per_g_channel_play         =   0x20000;       //100 000 000 000 000 000
        public const int per_g_channel_recive       =   0x40000;     //1 000 000 000 000 000 000

        public const int per_g_live_record          =   0x100000;       //100 000 000 000 000 000 000
        public const int per_g_player_record        =   0x200000;     //1 000 000 000 000 000 000 000
        

        //int per_g_rebroadcast_play = 262144
        
        public const int per_g_sys_montior          =   0x1000000;      //1 000 000 000 000 000 000 000 000
        public const int per_g_sys_user_mng         =   0x2000000;     //10 000 000 000 000 000 000 000 000
        public const int per_g_bulletin_mng         =   0x4000000;     //100 000 000 000 000 000 000 000 000
        public const int per_g_sys_catalog_mng      =   0x8000000; //1 000 000 000 000 000 000 000 000 000

        public const int per_g_sys_rate_mng         =   0x10000000;    //10 000 000 000 000 000 000 000 000 000
        public const int per_g_export_info          =   0x20000000;     //100 000 000 000 000 000 000 000 000 000

        //微格权限  2007-07-06
        public const int per_g_weige                =   0x40000000;
        
        


        public const int showbill = 0x40;                     //在 resource ;

        #endregion
    }

    public class SETTING_TYPE {

        public const String KEY_FREETIME = "maxfreetime";
        public const String KEY_DEFAULTUSER = "defaultuser";

        //2006-11-14

        public const String KEY_EDITION_MASK = "edition_mask";
        public const String KEY_VIEWMODEL = "ViewModel";
        public const String KEY_B_SHOW_LOGIN = "b_show_login";
        public const String KEY_B_ALLOW_REG = "b_allow_reg";
        public const String KEY_B_COMMEND = "b_commend";

        public const String KEY_DEFAULT_SORT = "default_sort";
        public const String KEY_DEFAULTSORT = "DefaultSort";  //节目排序

        public const String KEY_EXTFUNC_1_ICON = "extfunc_1_icon";
        public const String KEY_EXTFUNC_1_NAME = "extfunc_1_name";
        public const String KEY_EXTFUNC_1_LINK = "extfunc_1_link";

        public const String KEY_EXTFUNC_2_ICON = "extfunc_2_icon";
        public const String KEY_EXTFUNC_2_NAME = "extfunc_2_name";
        public const String KEY_EXTFUNC_2_LINK = "extfunc_2_link";

        public const String KEY_EXTFUNC_3_ICON = "extfunc_3_icon";
        public const String KEY_EXTFUNC_3_NAME = "extfunc_3_name";
        public const String KEY_EXTFUNC_3_LINK = "extfunc_3_link";
        //新增
        public const String KEY_DEFAULT_CATALOG = "default_catalog";
        public const String KEY_WEIGE_VIEW = "weige_view";
        public const String KEY_WEIGE_SORT = "weige_sort";

        public const String KEY_ALLOW_REMARK = "allow_remark";

    }

    public class Define {

        //Program property
        public enum ENUM_PROGRAM_PROPERTY {
            p_check_pass = 1,
            p_private = 2,
            p_uncheck = 0
        }

        // 节目排序定义
        public enum ENUM_PROGRAM_SORT {
            ADDTIME_DESC = 0,
            ADDTIME_ASC = 1,
            PLAYCOUNT_DESC = 2,
            PLAYCOUNT_ASC = 3,
            LONG_DESC = 4,
            LONG_ASC = 5,
            NAME_DESC = 6,
            NAME_ASC = 7
        };

        //节目搜索类型
        public enum ENUM_PROGRAM_SEARCH {
            // 0 标题 1 简介 2 主演 3 导演 4 出版单位 5 发布者 6 All
            TITLE = 0,
            INFO = 1,
            ACTOR = 2,
            DIRECTOR = 3,
            PUBLISH = 4,
            ADDER = 5,
            ALL = 6
        };

        // 节目类型
        public enum ENUM_PROGRAM_TYPE {
            t_unknown = 0,
            t_mp3 = 1,
            t_mpv = 2,
            t_mpeg1 = 3,
            t_mpeg2 = 4,
            t_avi = 5,
            t_real = 6,
            t_asfwmv = 7,
            t_wave = 8,
            t_rtp = 9,
            t_course = 258
        };

        public enum CHANNEL_SHOW {
            ALL = -1,
            LIVE = 0,
            BROAD = 1,
            REBROAD = 2,
            MIXC = 3,
            IPTV = 4
            
        }

        public enum CHANNEL_STATE {
            MIXCHANNEL = -1,
            NOACTIVE = 0,
            STOP = 1,
            NORMARL = 2,
            PAUSE = 3
        }

        public enum MEDIASEVER_STATE {
            NORMAL = 1,
            PAUSE = 2,
            UNREGISTER = 3
        }
        /*
        CHANNEL_DIRECT	= 0x00,
        CHANNEL_BROAD	= 0x01,
        CHANNEL_REBROAD = 0x02,
        CHANNEL_MULTI	= 0x03,
        CHANNEL_IPTV	= 0x04
        */
        public enum CHANNEL_TYPE {
            LIVE = 0,
            BROADCAST = 1,
            REBROAD = 2,//2007版去除转播
            MIXC = 3,
            IPTV = 4
           
        }
        public enum CHANNEL_ADDRESS_TYPE {
            INVALID = 0,
            UDP = 1,
            TCP = 2,
            MASTER = 3,
            BROAD = 4,
            NAT = 5,
            MS = 6,
            WMS = 7  // windows media Server
        }

    }
}
