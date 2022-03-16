using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace QueryDuplicateFilesUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            QueryDuplicateFiles.QueryDuplicateFiles.QueryDuplicatesByFileName();
        }
    }
}
