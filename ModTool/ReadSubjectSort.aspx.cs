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

using System.Data.OleDb;



using MOD.BLL;
using MOD.Model;
using MOD.WebUtility;

namespace MODTool {
    public partial class ReadSubjectSort : System.Web.UI.Page {
        protected void Page_Load( object sender, EventArgs e ) {
            HttpContext.Current.Session["SQLServer"]="192.168.0.113";
            HttpContext.Current.Session["SQLUid"]="sa";
            HttpContext.Current.Session["SQLPwd"]="11111";


            ReadSubject();
        }

        public void ReadSubject() {

            Catalog cataBll = new Catalog();

         
            Stack skNo = new Stack();   //上次的skNo
            Hashtable hst = new Hashtable();
            
            Int32 nParentId = this.Insert(0, "国标学科分类").CId;
            
            Int32 TopParentId = nParentId;
            string FilePath = @Server.MapPath(".") + "\\xls\\subject.xls";
            OleDbConnection Conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + FilePath + ";Extended Properties=Excel 8.0");

            hst.Add("A", this.Insert(nParentId, "自然科学").CId);
            hst.Add("B", this.Insert(nParentId, "农业科学").CId);
            hst.Add("C", this.Insert(nParentId, "医药科学").CId);
            hst.Add("D", this.Insert(nParentId, "工程与技术科学").CId);
            hst.Add("E", this.Insert(nParentId, "人文与社会科学").CId);

            CatalogData cda=new CatalogData();//上一次插入的对象
            using (OleDbDataReader dr = GetXls(Conn)) {
                while (dr.Read()) {
                    string strNo = dr[0].ToString();
                    string strName = dr[1].ToString();

                    if (strNo.Length == 3) {
                        if (strNo.IndexOf("1") == 0) {

                            nParentId = Convert.ToInt32(hst["A"]);
                        } else if (strNo.IndexOf("2") == 0) {
                            nParentId = Convert.ToInt32(hst["B"]);

                        } else if (strNo.IndexOf("3") == 0) {
                            nParentId = Convert.ToInt32(hst["C"]);
                        } else if (strNo.IndexOf("4") == 0 || strNo.IndexOf("5") == 0 || strNo.IndexOf("6") == 0) {
                            nParentId = Convert.ToInt32(hst["D"]);
                        } else if (strNo.IndexOf("7") == 0 || strNo.IndexOf("8") == 0 || strNo.IndexOf("9") == 0) {
                            nParentId = Convert.ToInt32(hst["E"]);
                        }
                        cda = Insert(nParentId, strName);
                        skNo.Push(strNo);
                        hst.Add(strNo, cda.CId);
                    } else {
                        //   1
                        if (skNo.Count == 0) { //第一次添加数据
                            cda = Insert(nParentId, strName);
                            skNo.Push(strNo);
                            hst.Add(strNo, cda.CId);
                        } else if (strNo.IndexOf(skNo.Peek().ToString()) == 0) {//表示该no是上一个no的子类
                            nParentId = cda.CId;
                            cda = Insert(nParentId, strName);
                            skNo.Push(strNo);
                            hst.Add(strNo, cda.CId);
                        } else {//否则不是,表示这个对象是一个新的对象,它可能属于 父父类

                            while (skNo.Count > 0) {


                                if (strNo.IndexOf(skNo.Peek().ToString()) == 0) {
                                    break;
                                }
                                skNo.Pop();
                            }//当跳出循环时就找到了当前的父类

                            if (skNo.Count > 0) {
                                nParentId = Convert.ToInt32(hst[skNo.Peek()]);
                            } else {
                                nParentId = TopParentId;
                            }
                            cda = Insert(nParentId, strName);
                            skNo.Push(strNo);
                            hst.Add(strNo, cda.CId);
                        }

                    }

                }
                Conn.Close();
                Conn.Dispose();
            }

        }




        public CatalogData Insert( Int32 nParent, string strName ) {
            Catalog cataBll = new Catalog();
            CatalogData ctda=null ;
            foreach (CatalogData cda in cataBll.GetList(nParent, 0)) {
                if (cda.CName == strName) {
                    ctda = cda;
                    break;
                } 
            }
            if (ctda == null) {
                cataBll.AddCatalog(nParent, strName);
                return Insert(nParent, strName);
            } else {
                return ctda;
            }

        }



        public OleDbDataReader GetXls(OleDbConnection Conn) {
            
            Conn.Open();
            string Sql = "select * from [mySheet$]";
            OleDbCommand Command = new OleDbCommand(Sql, Conn);
            OleDbDataReader Reader = Command.ExecuteReader(); 
            
            Command.Dispose();

            OleDbDataAdapter adapter = new OleDbDataAdapter(Sql, Conn);

            DataTable customers = new DataTable();
            adapter.Fill(customers);
            return Reader;
        }
    }
}
