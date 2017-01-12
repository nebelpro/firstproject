using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace mentougou.UserControl {
    public class UC_Helper {
        public const Int32 PAGE_BULLETIN_SIZE = 6;
        public const Int32 PAGE_LOG_SIZE = 10;
        public const Int32 PAGE_CARDLIST_SIZE = 10;
        public const Int32 PAGE_CARDUSRLIST_SIZE = 10;
        public const Int32 PAGE_USERLIST_SIZE = 10;
        public const Int32 PAGE_GROUPLIST_SIZE = 10;
        public const Int32 PAGE_CHANNELLIST_SIZE = 10;
        public const Int32 PAGE_PROGRAMLIST_ONE_SIZE = 10;
        public const Int32 PAGE_PROGRAMLIST_TWO_SIZE = 12;
        public const Int32 PAGE_PROGRAMLIST_THREE_SIZE = 15;
        public const Int32 PAGE_PROGRAMREMARKLIST_SIZE = 2;
        public const Int32 PAGE_CATALOGLIST_SIZE = 15;
        public const Int32 PAGE_GUESTBOOKLIST_SIZE = 6;
        public const string ListEmpty = "<div id=\"empty\"></div>";
        public const string ListBar = "<div class=\"ListBar\"><div class=\"left\">{0}</div><div class=\"right\">{1}</div></div>";
    }
}
