using System;
using EntityFrameworkDemo01.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EntityFrameworkDemo01Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod01()
        {
            var memberName = Common.Helpers.Reflection.ObjectMembers.GetMemberName((Condominium cm) => cm.Id);
            Assert.AreEqual("Id", memberName);
        }
    }
}
