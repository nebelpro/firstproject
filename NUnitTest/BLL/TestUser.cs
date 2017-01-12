using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using NUnit.Core;
using MOD.BLL;
using MOD.WebUtility;



namespace MOD.Test.BLL
{
    [TestFixture]
    public class TestUser
    {
        [Test]
        public void GetIndexTestNull()
        {
            //Assert.AreEqual(1, BLLHelper.GetIndex(null));
            Assert.AreEqual(1, BLLHelper.GetIndex(new int[] { }));

        }
        [Test]
        public void GetIndexTestOne()
        {
            Assert.AreEqual(2, BLLHelper.GetIndex(new int[] { 1 }));
            Assert.AreEqual(1, BLLHelper.GetIndex(new int[] { 2 }));
            Assert.AreEqual(1, BLLHelper.GetIndex(new int[] { 3 }));
        }
        [Test]
        public void GetIndexTestTwo()
        {
            Assert.AreEqual(1, BLLHelper.GetIndex(new int[] { 2, 3 }));
            Assert.AreEqual(2, BLLHelper.GetIndex(new int[] { 1, 3 }));
            Assert.AreEqual(3, BLLHelper.GetIndex(new int[] { 1, 2 }));
            Assert.AreEqual(1, BLLHelper.GetIndex(new int[] { 4, 6 }));
        }

        [Test]
        public void PageListTest()
        {
            Assert.AreEqual("dsafasf", WebHelper.PageList("sdafsdafdasfsaf", 15, 2, 3));
        }


    }
}
