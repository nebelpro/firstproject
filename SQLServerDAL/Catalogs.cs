using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using MOD.IDAL;
using MOD.Model;

namespace MOD.SQLServerDAL {
    public class Catalogs : ICatalog {

        public Int32 Delete(Int32 nCatalogId) {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = DbHelper.MakeParameter("@CID", SqlDbType.Int, nCatalogId);
            return DbHelper.ExecNonQuery("m3_catalog_delete", param);
        }

        public IList<CatalogData> GetCatalogByParentId(Int32 parentid, Int32 topcount) {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = DbHelper.MakeParameter("@CID", SqlDbType.Int, parentid);
            param[1] = DbHelper.MakeParameter("@TOPCOUNT", SqlDbType.Int, topcount);
            IDataReader dr = DbHelper.ExecQuery("m3_catalog_getlist", param);
            IList<CatalogData> cdList = new List<CatalogData>();
            while (dr.Read()) {
                CatalogData cd = new CatalogData();
                cd.CId = (Int32)dr["c_id"];
                cd.CName = (String)dr["c_name"];
                cd.CParentId = (Int32)dr["c_parent_id"];
                cd.CSerial = (String)dr["c_serial"];
                cd.CSerialIndex = (Int32)dr["c_serial_index"];
                cdList.Add(cd);
            }
            dr.Close();
            return cdList;
        }

        public Int32 GetParentByCId(Int32 nCatalogId) {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = DbHelper.MakeParameter("@CID", SqlDbType.Int, nCatalogId);
            return DbHelper.ReaderInt32("m3_catalog_getparentid", param);
        }

        public CatalogData GetDetail(Int32 nCatalogId) {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = DbHelper.MakeParameter("@CID", SqlDbType.Int, nCatalogId);
            IDataReader dr = DbHelper.ExecQuery("m3_catalog_getdetail", param);
            if (dr.Read()) {
                CatalogData cd = new CatalogData();
                cd.CId = (Int32)dr["c_id"];
                cd.CName = (String)dr["c_name"];
                cd.CParentId = (Int32)dr["c_parent_id"];
                cd.CSerial = (String)dr["c_serial"];
                cd.CSerialIndex = (Int32)dr["c_serial_index"];
                cd.CIsDefault = (Int32)dr["c_isdefault"];
                dr.Close();
                return cd;
            }
            return null;
        }


        public Int32 InsertCatalog(CatalogData catadata) {
            SqlParameter[] param = new SqlParameter[7];
            param[0] = DbHelper.MakeParameter("@NAME", SqlDbType.VarChar, catadata.CName);
            param[1] = DbHelper.MakeParameter("@SERIAL", SqlDbType.VarChar, catadata.CSerial);
            param[2] = DbHelper.MakeParameter("@INDEX", SqlDbType.Int, catadata.CSerialIndex);
            param[3] = DbHelper.MakeParameter("@PARENTID", SqlDbType.Int, catadata.CParentId);
            param[4] = DbHelper.MakeParameter("@ISDEF", SqlDbType.Int, catadata.CIsDefault);
            param[5] = DbHelper.MakeParameter("@DEFCLASS", SqlDbType.Int, catadata.CDefClass);
            param[6] = DbHelper.MakeParameter("@DEFGROUP", SqlDbType.Int, catadata.CDefGroup);
            return DbHelper.ReaderInt32("m3_catalog_insert", param);
        }

        public Int32 UpdateCatalog(CatalogData catadata) {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = DbHelper.MakeParameter("@CID", SqlDbType.Int, catadata.CId);
            param[1] = DbHelper.MakeParameter("@NAME", SqlDbType.VarChar, catadata.CName);
           // param[2] = DbHelper.MakeParameter("@SERIAL", SqlDbType.VarChar, catadata.CSerial);
           // param[3] = DbHelper.MakeParameter("@INDEX", SqlDbType.Int, catadata.CSerialIndex);
           // param[4] = DbHelper.MakeParameter("@PARENTID", SqlDbType.Int, catadata.CParentId);
           // param[5] = DbHelper.MakeParameter("@ISDEF", SqlDbType.Int, catadata.CIsDefault);
           // param[6] = DbHelper.MakeParameter("@DEFCLASS", SqlDbType.Int, catadata.CDefClass);
           // param[7] = DbHelper.MakeParameter("@DEFGROUP", SqlDbType.Int, catadata.CDefGroup);
            return DbHelper.ReaderInt32("m3_catalog_update", param);
        }

        public CatalogData GetDetailBySerial(String strSerial) {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = DbHelper.MakeParameter("@SERIAL", SqlDbType.VarChar, strSerial);
            IDataReader dr =  DbHelper.ExecQuery("m3_catalog_getlistbyserial", param);

            if (dr.Read()) {
                CatalogData cd = new CatalogData();
                cd.CId = (Int32)dr["c_id"];
                cd.CName = dr["c_name"].ToString();
                cd.CSerial = dr["c_serial"].ToString();
                dr.Close();
                return cd;
            }
            return null;
        }
    }
}
