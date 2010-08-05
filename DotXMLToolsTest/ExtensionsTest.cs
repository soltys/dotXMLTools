using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyExtensions;

namespace ExtensionsTest
{
    [TestClass]
    public class ExtensionsTest
    {
        [TestMethod]
        public void DeleteLastCharacterTest()
        {
            string input = "abc";
            string expected = "ab";
            string output;
            output = input.DeleteLastCharacter();
            Assert.AreEqual(output, expected);
        }
    }
}