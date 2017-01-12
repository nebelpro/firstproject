using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using System.Xml;


namespace MOD.WebUtility {
    public class XmlTool {

        protected XmlDocument xdoc = new XmlDocument();
        public XmlElement root;
        public String path;
        public XmlTool() {

        }

        public XmlTool( XmlDocument xdoc ) {
            this.xdoc = xdoc;
        }
        public XmlTool( string xmlPath ) {            
            this.LoadXml(xmlPath);
        }

        public void LoadXml( string xmlPath ) {
            this.path = xmlPath;
            xdoc.LoadXml(xmlPath);
            root = (XmlElement)xdoc.FirstChild;
        }

        #region  xml读操作




        //取得名称为name的结点的值
        public string GetNodeValue( string name ) {
            XmlNode xn = FindNodeByName(root.ChildNodes, name);
            if (xn == null) return null;
            return xn.InnerText;
        }

        //找到指定名称属性的值
        protected string GetAttrValue( XmlAttributeCollection xac, string strName ) {
            for (int i = 0; i < xac.Count; i++) {
                if (xac.Item(i).LocalName == strName) return xac.Item(i).Value;
            }
            return null;
        }

        //找到指定名称属性的值
        protected string GetNodeValue( XmlNodeList xnl, string strName ) {
            for (int i = 0; i < xnl.Count; i++) {
                if (xnl.Item(i).LocalName == strName) return xnl.Item(i).InnerText;
            }
            return null;
        }

        //寻找具有指定名称和属性/值组合的节点
        protected XmlNode FindNodeByAttr( XmlNodeList xnl, string strXaName, string strXaValue ) {
            string xa;
            for (int i = 0; i < xnl.Count; i++) {
                xa = GetAttrValue(xnl.Item(i).Attributes, strXaName);
                if (xa != null) {
                    if (xa == strXaValue) return xnl.Item(i);
                }
            }
            return null;
        }
        //通过节点名称找到指定的节点
        protected XmlNode FindNodeByName( XmlNodeList xnl, string strName ) {
            for (int i = 0; i < xnl.Count; i++) {
                if (xnl.Item(i).LocalName == strName) return xnl.Item(i);
            }
            return null;
        }

        #endregion


        #region  xml写操作
        //创建一个包含version和指定根节点的XmlDocument
        public void CreateRoot( string rootName ) {
            XmlElement xe = xdoc.CreateElement(rootName);
            xdoc.AppendChild(xe);
            root = xe;
        }


        //增加一个子结点
        public XmlElement AppendChild( string name, string _value ) {
            return AddChild((XmlElement)root, name, _value);
        }
        //为一个XmlElement添加子节点，并返回添加的子节点引用
        public XmlElement AddChild( XmlElement xe, string sField, string sValue ) {
            XmlElement xeTemp = xdoc.CreateElement(sField);
            xeTemp.InnerText = sValue;
            xe.AppendChild(xeTemp);
            return xeTemp;
        }

        //为一个XmlElement添加子节点，并返回添加的子节点引用
        protected XmlElement AddChild( XmlElement xe, XmlDocument xd, string sField ) {
            XmlElement xeTemp = xd.CreateElement(sField);
            xe.AppendChild(xeTemp);
            return xeTemp;
        }

        //为一个节点添加属性
        public void AddAttribute( XmlElement xe, string strName, string strValue ) {
            //判断属性是否存在
            string s = GetAttrValue(xe.Attributes, strName);
            //属性已经存在
            if (s != null) {
                throw new System.Exception("attribute exists");
            }
            XmlAttribute xa = xdoc.CreateAttribute(strName);
            xa.Value = strValue;
            xe.Attributes.Append(xa);
        }

        //为一个节点添加属性，不是系统表
        protected void AddAttribute( XmlDocument xdoc, XmlElement xe, string strName, string strValue ) {
            //判断属性是否存在
            string s = GetAttrValue(xe.Attributes, strName);
            //属性已经存在
            if (s != null) {
                throw new Exception("Error:The attribute '" + strName + "' has been existed!");
            }
            XmlAttribute xa = xdoc.CreateAttribute(strName);
            xa.Value = strValue;
            xe.Attributes.Append(xa);
        }

        //为一个节点指定值
        protected void SetNodeValue( XmlNodeList xnl, string strName, string strValue ) {
            for (int i = 0; i < xnl.Count; i++) {
                if (xnl.Item(i).LocalName == strName) {
                    xnl.Item(i).InnerText = strValue;
                    return;
                }
            }
            return;
        }

        //为一个属性指定值
        protected void SetAttrValue( XmlAttributeCollection xac, string strName, string strValue ) {
            for (int i = 0; i < xac.Count; i++) {
                if (xac.Item(i).LocalName == strName) {
                    xac.Item(i).Value = strValue;
                    return;
                }
            }
            return;
        }
        #endregion


        #region
        public DataView GetData( string XmlPathNode ) {
            //查找數據。返回一個DataView
            DataSet ds = new DataSet();
            StringReader read = new StringReader(xdoc.SelectSingleNode(XmlPathNode).OuterXml);
            ds.ReadXml(read);
            return ds.Tables[0].DefaultView;
        }

        #endregion




        public override string ToString() {
            return xdoc.OuterXml;
        }
        /// <summary>
        /// （操作完毕）保存後xml对象置空
        /// </summary>
        public void Save() {
            //保存文檔。
            try {
                xdoc.Save(path);
            } catch (Exception ex) {
                throw ex;
            }
            xdoc = null;
        }
        /// <summary>
        /// （拷贝）保存後xml对象还存在
        /// </summary>
        /// <param name="strPath"></param>
        public void Save(String strPath) {
            //保存文檔。
            try {
                xdoc.Save(strPath);
            } catch (Exception ex) {
                throw ex;
            }           
        }



    }

}
