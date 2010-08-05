using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotXMLToolsTest
{
    [TestClass]
    public class StringTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            string input = "abcdef";
            int expected = -1;
            int output;

            output = input.IndexOf('[');
            Assert.AreEqual(output,expected);
        }
    }
}
