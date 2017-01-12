using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Web;
using System.Xml;
using System.IO;


namespace MOD.WebUtility {
    public class WebConfig {
        
        public IniStructure IniOper;

        private const String SEC_SQL = "SQLServer";
        private const String SEC_SQL_INTERNET = "SQLServer_internet";
        private const String SEC_HOMESERVER = "HomeServer";
        private const String SEC_HOMESERVER_INTERNET = "HomeServer_internet";
        private const String KEY_SQL_UID = "UID";
        private const String KEY_SQL_PWD = "PWD";
        private const String KEY_SQL_SERVER = "Server";
        private const String KEY_HS_SERVER = "Server";
        private const String KEY_HS_PORT = "Port";


        public const String SESSION_SQLSERVER = "SQLServer";
        public const String SESSION_UID = "SQLUid";
        public const String SESSION_PWD = "SQLPwd";
        public const String SESSION_HS_SERVER = "HSServer";
        public const String SESSION_HS_PORT = "HSPort";

        public WebConfig() {
            IniOper = IniStructure.ReadIni(this.GetConfigPath());
        }    

        private String GetConfigPath() {
            String strRoot = HttpContext.Current.Server.MapPath(".");
            Int32 nPos = strRoot.LastIndexOf("\\");
            if (nPos != -1) {
                return strRoot.Substring(0, nPos) + "\\Database\\WebConfig.ini";
            } else {
                strRoot = strRoot.Substring(0, strRoot.Length - 1);
                nPos = strRoot.LastIndexOf("/");
                return strRoot.Substring(0, nPos) + "/Database/WebConfig.ini";
            }
        }

        public void InitDbSetting() {
            String strUrl = HttpContext.Current.Request.RawUrl.ToLower();
            String strSecSql, strSecHs;
            if (strUrl.IndexOf("_internet") == -1) {
                strSecSql = SEC_SQL;
                strSecHs = SEC_HOMESERVER;
            } else {
                strSecSql = SEC_SQL_INTERNET;
                strSecHs = SEC_HOMESERVER_INTERNET;
            }
            HttpContext.Current.Session["SQLServer"] = IniOper.GetValue(strSecSql, KEY_SQL_SERVER); 
            HttpContext.Current.Session["SQLUid"] = IniOper.GetValue(strSecSql, KEY_SQL_UID);
            HttpContext.Current.Session["SQLPwd"] = IniOper.GetValue(strSecSql, KEY_SQL_PWD);
            HttpContext.Current.Session["HSServer"] = IniOper.GetValue(strSecHs, KEY_HS_SERVER);
            HttpContext.Current.Session["HSPort"] = IniOper.GetValue(strSecHs, KEY_HS_PORT);

            //服务器的软件版本
            HttpContext.Current.Session["MPVer"] = IniOper.GetValue("version", "MediaPlayer");
            HttpContext.Current.Session["MNVer"] = IniOper.GetValue("version", "Manager");
        }
    }


   

}
