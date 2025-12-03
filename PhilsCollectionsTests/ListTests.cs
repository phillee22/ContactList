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
        public void ClearTest1()    // call clear() on an empty list...
        {
            PhilsList list = new PhilsList();
            Assert.AreEqual(0, list.Count, " !! Count is wrong.");
            list.Clear();
            Assert.AreEqual(0, list.Count, " !! Count is wrong.");
        }

        [TestMethod]
        public void ClearTest2()    // call clear() on a list with elements...
        {
            PhilsList list = new PhilsList();
            list.Add("Bob");
            Assert.AreEqual(1, list.Count, " !! Count is wrong.");

            list.Add(1);
            Assert.AreEqual(2, list.Count, " !! Count is wrong.");

            list.Clear();
            Assert.AreEqual(0, list.Count, " !! Count is wrong.");
        }

        [TestMethod]
        public void ContainsTest1()
        {
            PhilsList list = new PhilsList();
            Assert.IsFalse(list.Contains("Bob"), " !! Wrong answer on empty list.");

            list.Add("bob");
            Assert.IsTrue(list.Contains("bob"), " !! Wrong answer on case-sensitive list.");
            Assert.IsFalse(list.Contains("Bob"), " !! Wrong answer on case-sensitive list."); 
            Assert.IsFalse(list.Contains(123), " !! Wrong answer on int item no in list.");

            list.Add(123);
            Assert.IsTrue(list.Contains(123), " !! Wrong answer on int in the list.");

            list.Remove(123);
            Assert.IsFalse(list.Contains(123), " !! Wrong answer on int removed from the list.");
        }


        [TestMethod]
        public void EnumeratorTest()
        {
            PhilsList list = new PhilsList();

            for (int i = 0; i < 5; i++)
            {
                list.Add(i);
            }
            Assert.AreEqual(5, list.Count, " !! Count is wrong after adding a bunch.");

            int c = 0;
            foreach (object o in list)
            {
                Assert.AreEqual(c, o, " !! c != o.");
                c++;
            }
        }

        [TestMethod]
        public void InsertTest1()
        {
            PhilsList list = new PhilsList();

            // less than 0
            try
            {
                list.Insert(-1, "testobj1");
                Assert.Fail("Insert with index < 0 didn't throw as expected.");
            }
            catch (System.IndexOutOfRangeException) { }

            // greater than count - off the end of the existing list
            try
            {
                list.Insert(1, "testobj2");
                Assert.Fail("Insert with index > count didn't throw as expected.");
            }
            catch (System.IndexOutOfRangeException) { }

            // insert into empty with index 0
            list.Insert(0, "testobj3");
            Assert.AreEqual(1, list.Count, "Count is not correct after insert.");
            Assert.AreEqual("testobj3", list[0].ToString(), "test item 3 is not correct after insert.");

            // try a second time to insert with index 0 - the new item should be the first item in the list...
            list.Insert(0, "testobj4");

            // at this point we have two items in the list - testobj4, testobj3...
            Assert.AreEqual(2, list.Count, "Count is not correct after insert.");
            Assert.AreEqual("testobj4", list[0], "Test item 4 is not the first item in the list");
            Assert.AreEqual("testobj3", list[1], "Test item 3 is not the second item in the list");

            // insert a new item inbetween the two nodes...
            list.Insert(1, "testobj5");

            // at this point we have three items in the list - testobj4, testobj5, testobj3...
            Assert.AreEqual(3, list.Count, "Count is not correct after insert.");
            Assert.AreEqual("testobj4", list[0], "Test item is not the first item in the list");
            Assert.AreEqual("testobj5", list[1], "Test item is not the second item in the list");
            Assert.AreEqual("testobj3", list[2], "Test item is not the second item in the list");

            // insert a new item at the end of the list using Count...
            list.Insert(list.Count, "testobj6");

            // at this point we have four items in the list - testobj4, testobj5, testobj3...
            Assert.AreEqual(4, list.Count, "Count is not correct after insert.");
            Assert.AreEqual("testobj5", list[1], "Test item is not the second item in the list");
            Assert.AreEqual("testobj3", list[2], "Test item is not the third item in the list");
            Assert.AreEqual("testobj6", list[3], "Test item is not the fourth item in the list");

            // Clear the list and attempt to add another where index > Count.
            list.Clear();
            Assert.AreEqual(0, list.Count, "Count is off after Clear()");
            try
            {
                list.Insert(1, "testobj2");
                Assert.Fail("Insert with index > count didn't throw as expected.");
            }
            catch (System.IndexOutOfRangeException) { }
        }

        [TestMethod]
        public void ItemTest1()
        {
            PhilsList list = new PhilsList();
            try
            {
                // Intended to throw when the list is empty...
                list[0].ToString();
                Assert.Fail(" !! Exception not thrown.");
            }
            catch (System.IndexOutOfRangeException) 
            {
            }

            string s = "bob";
            list.Add(s);
            Assert.AreEqual(s, list[0], " !! Wrong answer on case-sensitive list.");
            Assert.AreEqual(s, list[0].ToString(), " !! Wrong answer on case-sensitive list.");
        }


        [TestMethod]
        public void RemoveTest1()
        {
            PhilsList list = new PhilsList();

            // call remove() on empty list...
            list.Remove("xxx");
            Assert.AreEqual(0, list.Count, " !! Count is wrong.");

            // add/remove the first and only item in the list...
            list.Add("Bob");
            list.Remove("Bob");
            Assert.AreEqual(0, list.Count, " !! Count is wrong after add/remove only item.");

            // Add two items and remove the first then the second...
            list.Add("43.amv094");
            float f1 = 383.9339F;
            list.Add(f1);
            Assert.AreEqual(2, list.Count, " !! Count is wrong.");

            list.Remove("43.amv094");
            Assert.AreEqual(1, list.Count, " !! Count is wrong.");

            list.Remove(f1);
            Assert.AreEqual(0, list.Count, " !! Count is wrong.");


            // Add two items and remove the second then the first...
            list.Add("43.bkeo3404");
            f1 = 43.384F;
            list.Add(f1);
            Assert.AreEqual(2, list.Count, " !! Count is wrong.");

            list.Remove(f1);
            Assert.AreEqual(1, list.Count, " !! Count is wrong.");

            list.Remove("43.bkeo3404");
            Assert.AreEqual(0, list.Count, " !! Count is wrong.");


            // add a bunch and remove something in the middle...
            for (int i = 0; i < 5; i++)
            {
                list.Add(i);
            }
            Assert.AreEqual(5, list.Count, " !! Count is wrong after adding a bunch.");
            list.Remove(3);
            Assert.AreEqual(4, list.Count, " !! Count is wrong after removing from the middle.");


            // attempt to remove an item not in the list
            list.Clear();
            list.Add("490sn2408sd");
            list.Add(193);
            Assert.AreEqual(2, list.Count, " !! Count is wrong after adding two.");
            list.Remove("Bob");     // not in the list...
            Assert.AreEqual(2, list.Count, " !! Count is wrong after removing item not in the list");
        }
    }
}
