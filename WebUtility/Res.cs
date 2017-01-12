using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Web;
using NLog;

namespace MOD.WebUtility {
    public class Res {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static String strResPath = GetResourcePath();

        public static String GetResourcePath() {
            String strRoot = HttpContext.Current.Server.MapPath(".");
            if (strRoot.LastIndexOf("\\") != -1) {
                return HttpContext.Current.Server.MapPath(".") + "\\Resource\\ModRes.xml";
            } else {
                return HttpContext.Current.Server.MapPath(".") + "/Resource/ModRes.xml";
            }
        }

        public static String GetValueByKey( String strKey ) {           
            XmlDocument xml = new XmlDocument();
            xml.Load(strResPath);
            if (xml != null) {
                XmlNode node = xml.DocumentElement.SelectSingleNode(strKey);
                if (node != null) return node.InnerText;
                else logger.Trace("resource xml lack of ==>"+strKey);
            } else {
                logger.Trace("resource xml is not exist!");
            }

            return String.Empty;
        }

        public static String GetValue(String strKey) {
            strKey = "descendant::Server/key[@name='" + strKey + "']";
            return GetValueByKey(strKey);
        }

        public static String GetProductName() {
            string strKey = "descendant::product/name";
            return GetValueByKey(strKey);
        }

        public static String GetProductEncode() {
            string strKey = "descendant::encode";
            return GetValueByKey(strKey);
        }

        public static String GetProductTheme() {
            String strKey = "descendant::theme";
            return GetValueByKey(strKey);
        }

        public static String GetProductVersion() {
            string strKey = "descendant::product/version";
            return GetValueByKey(strKey);            
        }

        public static String GetCompanyName() {
            String strKey = "descendant::company/name";
            return GetValueByKey(strKey);
        }

        public static String GetCompanyWebSite() {
            String strKey = "descendant::company/website";
            return GetValueByKey(strKey);            
        }
    }
}
