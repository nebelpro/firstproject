using System;
using System.Text;
using System.Collections.Generic;
using MOD.Model;

namespace MOD.BLL {
    public class GuestBook {

        private static readonly MOD.IDAL.IGuestBook dal = MOD.DALFactory.DataAccess.CreateGuestBook();

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <param name="nType">Type(0: Public 1:All)</param>
        /// <param name="nPage">The page.</param>
        /// <param name="nPageSize">Size of the page.</param>
        /// <returns></returns>
        public IList<GuestBookData> GetList( Int32 nType, Int32 nPage, Int32 nPageSize ) {
            return dal.GetList(nType, nPage, nPageSize);
        }

        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <param name="nType">Type(0: Public 1:All)</param>
        /// <returns></returns>
        public Int32 GetCount( Int32 nType ) {
            return dal.GetCount(nType);
        }


        /// <summary>
        /// Gets the detail.
        /// </summary>
        /// <param name="nGuestbookId">The guestbook id.</param>
        /// <returns></returns>
        public GuestBookData GetDetail( Int32 nGuestbookId ) {
            return dal.GetDetail(nGuestbookId);
        }

        /// <summary>
        /// Inserts the guestbookdata.
        /// </summary>
        /// <param name="guestbookdata">The guestbookdata.</param>
        /// <returns></returns>
        public Int32 Insert( GuestBookData guestbookdata ) {
            return dal.Insert(guestbookdata);
        }

        /// <summary>
        /// Deletes the specified guestbook .
        /// </summary>
        /// <param name="nGuestbookId">The n guestbook id.</param>
        public void Delete( Int32 nGuestbookId ) {
            dal.Delete(nGuestbookId);
        }
    }
}
