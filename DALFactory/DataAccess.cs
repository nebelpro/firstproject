using System;
using System.Reflection;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace MOD.DALFactory
{
   public class DataAccess
    {

        private static readonly string path = ConfigurationManager.AppSettings["WebDAL"];

        private DataAccess() { }



        public static MOD.IDAL.IBulletin CreateBulletin()
        {
            string className = path + ".Bulletins";
            return (MOD.IDAL.IBulletin)Assembly.Load(path).CreateInstance(className);
        }

        public static MOD.IDAL.ICatalog CreateCatalog()
        {
            string className = path + ".Catalogs";
            return (MOD.IDAL.ICatalog)Assembly.Load(path).CreateInstance(className);
        }

        public static MOD.IDAL.IChannel CreateChannel()
        {
            string className = path + ".Channels";
            return (MOD.IDAL.IChannel)Assembly.Load(path).CreateInstance(className);
        }

        public static MOD.IDAL.ICourse CreateCourse()
        {
            string className = path + ".Courses";
            return (MOD.IDAL.ICourse)Assembly.Load(path).CreateInstance(className);

        }

        public static MOD.IDAL.IGroup CreateGroup()
        {
            string className = path + ".Groups";
            return (MOD.IDAL.IGroup)Assembly.Load(path).CreateInstance(className);

        }

        public static MOD.IDAL.IGuestBook CreateGuestBook()
        {
            string className = path + ".GuestBooks";
            return (MOD.IDAL.IGuestBook)Assembly.Load(path).CreateInstance(className);
        }

        public static MOD.IDAL.ILogRateex CreateLogRateex()
        {
            string className = path + ".LogRateexs";
            return (MOD.IDAL.ILogRateex)Assembly.Load(path).CreateInstance(className);
        }

        public static MOD.IDAL.IPointCard CreatePointCard()
        {
            string className = path + ".PointCards";
            return (MOD.IDAL.IPointCard)Assembly.Load(path).CreateInstance(className);
        }

        public static MOD.IDAL.IProgram CreateProgram()
        {
            string className = path + ".Programs";
            return (MOD.IDAL.IProgram)Assembly.Load(path).CreateInstance(className);
        }

        public static MOD.IDAL.IRemark CreateRemark()
        {
            string className = path + ".Remarks";
            return (MOD.IDAL.IRemark)Assembly.Load(path).CreateInstance(className);
        }

        public static MOD.IDAL.ISetting CreateSetting()
        {
            string className = path + ".Settings";
            return (MOD.IDAL.ISetting)Assembly.Load(path).CreateInstance(className);
        }

        public static MOD.IDAL.IUser CreateUser()
        {
            string className = path + ".Users";
            return (MOD.IDAL.IUser)Assembly.Load(path).CreateInstance(className);
        }
    }
}
