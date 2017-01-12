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

        #region  xml������




        //ȡ������Ϊname�Ľ���ֵ
        public string GetNodeValue( string name ) {
            XmlNode xn = FindNodeByName(root.ChildNodes, name);
            if (xn == null) return null;
            return xn.InnerText;
        }

        //�ҵ�ָ���������Ե�ֵ
        protected string GetAttrValue( XmlAttributeCollection xac, string strName ) {
            for (int i = 0; i < xac.Count; i++) {
                if (xac.Item(i).LocalName == strName) return xac.Item(i).Value;
            }
            return null;
        }

        //�ҵ�ָ���������Ե�ֵ
        protected string GetNodeValue( XmlNodeList xnl, string strName ) {
            for (int i = 0; i < xnl.Count; i++) {
                if (xnl.Item(i).LocalName == strName) return xnl.Item(i).InnerText;
            }
            return null;
        }

        //Ѱ�Ҿ���ָ�����ƺ�����/ֵ��ϵĽڵ�
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
        //ͨ���ڵ������ҵ�ָ���Ľڵ�
        protected XmlNode FindNodeByName( XmlNodeList xnl, string strName ) {
            for (int i = 0; i < xnl.Count; i++) {
                if (xnl.Item(i).LocalName == strName) return xnl.Item(i);
            }
            return null;
        }

        #endregion


        #region  xmlд����
        //����һ������version��ָ�����ڵ��XmlDocument
        public void CreateRoot( string rootName ) {
            XmlElement xe = xdoc.CreateElement(rootName);
            xdoc.AppendChild(xe);
            root = xe;
        }


        //����һ���ӽ��
        public XmlElement AppendChild( string name, string _value ) {
            return AddChild((XmlElement)root, name, _value);
        }
        //Ϊһ��XmlElement����ӽڵ㣬��������ӵ��ӽڵ�����
        public XmlElement AddChild( XmlElement xe, string sField, string sValue ) {
            XmlElement xeTemp = xdoc.CreateElement(sField);
            xeTemp.InnerText = sValue;
            xe.AppendChild(xeTemp);
            return xeTemp;
        }

        //Ϊһ��XmlElement����ӽڵ㣬��������ӵ��ӽڵ�����
        protected XmlElement AddChild( XmlElement xe, XmlDocument xd, string sField ) {
            XmlElement xeTemp = xd.CreateElement(sField);
            xe.AppendChild(xeTemp);
            return xeTemp;
        }

        //Ϊһ���ڵ��������
        public void AddAttribute( XmlElement xe, string strName, string strValue ) {
            //�ж������Ƿ����
            string s = GetAttrValue(xe.Attributes, strName);
            //�����Ѿ�����
            if (s != null) {
                throw new System.Exception("attribute exists");
            }
            XmlAttribute xa = xdoc.CreateAttribute(strName);
            xa.Value = strValue;
            xe.Attributes.Append(xa);
        }

        //Ϊһ���ڵ�������ԣ�����ϵͳ��
        protected void AddAttribute( XmlDocument xdoc, XmlElement xe, string strName, string strValue ) {
            //�ж������Ƿ����
            string s = GetAttrValue(xe.Attributes, strName);
            //�����Ѿ�����
            if (s != null) {
                throw new Exception("Error:The attribute '" + strName + "' has been existed!");
            }
            XmlAttribute xa = xdoc.CreateAttribute(strName);
            xa.Value = strValue;
            xe.Attributes.Append(xa);
        }

        //Ϊһ���ڵ�ָ��ֵ
        protected void SetNodeValue( XmlNodeList xnl, string strName, string strValue ) {
            for (int i = 0; i < xnl.Count; i++) {
                if (xnl.Item(i).LocalName == strName) {
                    xnl.Item(i).InnerText = strValue;
                    return;
                }
            }
            return;
        }

        //Ϊһ������ָ��ֵ
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
            //���Ҕ���������һ��DataView
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
        /// ��������ϣ�������xml�����ÿ�
        /// </summary>
        public void Save() {
            //�����ęn��
            try {
                xdoc.Save(path);
            } catch (Exception ex) {
                throw ex;
            }
            xdoc = null;
        }
        /// <summary>
        /// ��������������xml���󻹴���
        /// </summary>
        /// <param name="strPath"></param>
        public void Save(String strPath) {
            //�����ęn��
            try {
                xdoc.Save(strPath);
            } catch (Exception ex) {
                throw ex;
            }           
        }



    }

}
