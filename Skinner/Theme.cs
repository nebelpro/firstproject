using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml;
using MOD.WebUtility;

namespace MOD.UI.SkinFactory {
    public class Skin {
        protected XmlDocument xdoc = new XmlDocument();
        public XmlElement root;
        public String ViewPath;
        private readonly bool enableCaching = bool.Parse(ConfigurationManager.AppSettings["EnableCaching"]);
        public Skin( String strTheme ) {
            this.ViewPath = this.GetThemeConfig(strTheme);
            xdoc.Load(this.ViewPath);
            root = xdoc.DocumentElement;
        }

        public string GetThemeConfig( String strTheme ) {
            string strRoot="";
            if (strRoot.LastIndexOf("\\") != -1) {
                strRoot = HttpContext.Current.Server.MapPath(".") + "\\Theme\\" + strTheme + "\\View.xml";
            } else {
                strRoot = HttpContext.Current.Server.MapPath(".") + "/Theme/" + strTheme + "/View.xml";
            }           
            return strRoot;
        }

        public String GetValue( String strKey ) {
            XmlNode node = root.SelectSingleNode(strKey);
            if (node != null) return node.InnerText;
            return String.Empty;
        }

        public String GetPath() {
            String strKey = "descendant::path";
            return GetValue(strKey);
        }

        public XmlNode GetViewNode( string strName ) {
            string strKey = "descendant::views/view[@name='" + strName + "']";
            XmlNode xnView = root.SelectSingleNode(strKey);
            return xnView;
        }

        public View GetView( String strName ) {

            if (!enableCaching) {
                return new View(GetViewNode(strName));
            }

            View vw = (View)HttpRuntime.Cache[strName];
            if (vw == null) {

                System.Web.Caching.CacheDependency dep1 = new System.Web.Caching.CacheDependency(Res.GetResourcePath());
                System.Web.Caching.CacheDependency dep2 = new System.Web.Caching.CacheDependency(ViewPath);
                System.Web.Caching.AggregateCacheDependency aggDep = new System.Web.Caching.AggregateCacheDependency();
                aggDep.Add(dep1);
                aggDep.Add(dep2);

                vw = new View(GetViewNode(strName));
                HttpRuntime.Cache.Insert(strName, vw, aggDep);
            }

            return vw;
        }

        public String[] GetMaster( String strName ) {
            String strArray="";
            string strKey = "descendant::master[@name='" + strName + "']";
            XmlNode xnMaster = root.SelectSingleNode(strKey);
            if (xnMaster != null) strArray = xnMaster.InnerText;
            return strArray.Split(",".ToCharArray());
        }

        public String[] GetPage( String strName ) {
            String strArray = "";
            string strKey = "descendant::page[@name='" + strName + "']";
            XmlNode xnPage = root.SelectSingleNode(strKey);
            if (xnPage != null) strArray = xnPage.InnerText;
            return strArray.Split(",".ToCharArray());
        }

        public String[] GetControl( String strName ) {
            String strArray = "";
            string strKey = "descendant::control[@name='" + strName + "']";
            XmlNode xnPage = root.SelectSingleNode(strKey);
            if (xnPage != null) strArray = xnPage.InnerText;
            return strArray.Split(",".ToCharArray());
        }

       
    }
    public class View {
        Hashtable hsView = new Hashtable();
        public String Name {
            get {return GetString("name"); }
        }

        public String File {
            get { return GetString("file"); }
        }

        public View( XmlNode xn ) {
            if (xn != null) {
                for (int i = 0; i < xn.Attributes.Count; i++) {
                    XmlAttribute xa = xn.Attributes[i];
                    hsView.Add(xa.Name, xa.Value);
                }
            }
        }

        public String GetString( String Name ) {
            String str="";
            if (hsView.Contains(Name)) {
                str = hsView[Name].ToString();
            }
            return str;
        }

        public Int32 GetInt32( String Name ) {
            Int32 nRet = 0;
            if (hsView.Contains(Name)) {
                String str = hsView[Name].ToString();
                nRet = Int32.Parse(str);
            }
            return nRet;
        }

    }


}
