using System;
using System.Collections.Generic;
using System.Text;

using MOD.BLL;

namespace MOD.BLL {
    public class Product {

        public class Support_Type {            
            public const Int32 FUNC_DV                  = 1;    //0x0001
            public const Int32 FUNC_SCREEN              = 2;    //0x0002
            public const Int32 FUNC_MPEG4_CARD          = 4;    //0x0004
            public const Int32 FUNC_SATELLITE           = 8;    //0x0008 no support
            public const Int32 FUNC_NETCHARD_ADAPTER    = 16;   //0x0010
            public const Int32 FUNC_NAT                 = 32;   //0x0020
            public const Int32 FUNC_BILLING             = 64;   //0x0040
            public const Int32 FUNC_MULTI_LIVECAST      = 128;  //0x0080 no support
        }

        /// <summary>
        /// 点播:广播:直播:媒体服务器:IPTV:录播:代理端:77
        /// 点播:广播:直播:媒体服务器:iptv:77
        /// </summary>
        /// <param name="nIndex"></param>
        /// <returns></returns>
        public Int32 GetMaskValue( int nIndex ) {

            if (nIndex > -1 && System.Web.HttpContext.Current.Session["edition_mask"] != null && System.Web.HttpContext.Current.Session["edition_mask"].ToString() != string.Empty) {
                string EditonMask = System.Web.HttpContext.Current.Session["edition_mask"].ToString();
                string[] gmvArr = EditonMask.Split(new Char[] { ':' });// 老加密狗 6,新加密狗 8

                if (gmvArr.Length == 8) {       //=========新加密狗 8
                    if (nIndex < gmvArr.Length) {
                        try {
                            if (nIndex == 7) {
                                return Convert.ToInt32(gmvArr[nIndex],16);
                            } else {
                                return Convert.ToInt32(gmvArr[nIndex]);
                            }
                        } catch { return 0; }
                    } else {
                        return 0;
                    }
                } else if (gmvArr.Length == 6) {//=========老加密狗 6
                    if (nIndex == 5) {
                        return -1;
                    } else if (nIndex == 6) {
                        return -1;
                    } else if (nIndex == 7) {
                        return Convert.ToInt32(gmvArr[5], 16);
                    } else {
                        try { return Int32.Parse(gmvArr[nIndex]); } catch { return 0; }
                    }
                } else {
                    return 0;
                }
            } else {
                return 0;
            }
            
        }


        #region ========授权信息
        public Int32 Support_Program {
            get { return this.GetMaskValue(0); }
        }
        public Int32 Support_BroadCast {
            get { return this.GetMaskValue(1); }
        }
        public Int32 Support_LiveCast {
            get { return this.GetMaskValue(2); }
        }       
        public Int32 Support_MediaServer {
            get { return this.GetMaskValue(3); }
        }
        public Int32 Support_Iptv {
            get { return this.GetMaskValue(4); }
        }
        public Int32 Support_Recorder {
            get { 
                return this.GetMaskValue(5); 
            }
        }
        public Int32 Support_Proxy {
            get { return this.GetMaskValue(6); }
        }


        public bool Support_DV {
            get {
                if ((this.GetMaskValue(7) & Support_Type.FUNC_DV) != 0) {
                    return true;
                } else {
                    return false;
                }
            }

        }
        public bool Support_SCREEN {
            get {
                if ((this.GetMaskValue(7) & Support_Type.FUNC_SCREEN) != 0) {
                    return true;
                } else {
                    return false;
                }
            }
        }
        public bool Support_MPEG4_CARD {
            get {
                if ((this.GetMaskValue(7) & Support_Type.FUNC_MPEG4_CARD) != 0) {
                    return true;
                } else {
                    return false;
                }
            }    
        }
        public bool Support_SATELLITE {
            get {
                if ((this.GetMaskValue(7) & Support_Type.FUNC_SATELLITE) != 0) {
                    return true;
                } else {
                    return false;
                }
            }
        }
        public bool Support_NETCHARD_ADAPTER {
            get {
                if ((this.GetMaskValue(7) & Support_Type.FUNC_NETCHARD_ADAPTER) != 0) {
                    return true;
                } else {
                    return false;
                }
            }
        }
        public bool Support_NAT {
            get {
                if ((this.GetMaskValue(7) & Support_Type.FUNC_NAT) != 0) {
                    return true;
                } else {
                    return false;
                }
            }
        }
        public bool Support_BILLING {
            get {
                if ((this.GetMaskValue(7) & Support_Type.FUNC_BILLING) != 0) {
                    return true;
                } else {
                    return false;
                }
            }
        }
        public bool Support_MULTI_LIVECAST {
            get {
                if ((this.GetMaskValue(7) & Support_Type.FUNC_MULTI_LIVECAST) != 0) {
                    return true;
                } else {
                    return false;
                }
            }
        }
        #endregion 

        #region  ========模块信息
        public bool Module_Program {
            get {
                if (this.GetMaskValue(0) > 0) {
                    return true;
                } else {
                    return false;
                }            
            }
        }
        public bool Module_Iptv {
            get {
                if (this.GetMaskValue(4) > 0) {
                    return true;
                } else {
                    return false;
                }
            }
        }
        public bool Module_Recorder {
            get {
                if (this.GetMaskValue(5) > 0) {
                    return true;
                } else if (this.GetMaskValue(5) < 0) {//-1
                    if (this.GetMaskValue(3) > 0) {
                        return true;
                    } else {
                        return false;
                    }

                } else {
                    return false;
                }
            }
        }

        public bool Module_Weige {
            get {
                return new Permit().CanWeigeReceive();            
            }
        }
        #endregion 



    }
}
