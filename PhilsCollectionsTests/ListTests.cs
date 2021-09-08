using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhilsCollections;

namespace PhilsCollectionsTests
{
    [TestClass]
    public class ListTests
    {
        [TestMethod]
        public void AddTest1()
        {
            PhilsList list = new PhilsList();
            list.Add("Bob");
            Assert.AreEqual(1, list.Count, " !! Count is wrong.");
        }

        [TestMethod]
        public void RemoveTest1()
        {
            PhilsList list = new PhilsList();
            list.Add("Bob");
            list.Remove("Bob");
            Assert.AreEqual(0, list.Count, " !! Count is wrong.");
        }
    }
}
