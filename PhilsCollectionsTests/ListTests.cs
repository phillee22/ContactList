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
            PhilsList plist = new PhilsList();
            plist.Add("Bob");
            Assert.AreEqual(1, plist.Count, " !! Count is wrong.");
        }


        [TestMethod]
        public void AddRangeTest1()    // call clear() on an empty list...
        {
            object[] objarray = ['a', "b", 4, 4.5983];

            // AddRange to an empty list...
            PhilsList addlist = new PhilsList();
            PhilsList baselist = new PhilsList();
            addlist.AddRange(objarray);
            baselist.AddRange(addlist);
            Assert.AreEqual(4, baselist.Count, "AddRangeTest:  Count of item is incorrect.");
            Assert.AreEqual(4.5983, baselist[3], "AddRangeTest:  Item[3] is incorrect.");

            // AddRange to populated list...
            object[] newarray = [4, "er", 3.49, 'b'];
            baselist.AddRange(newarray);
            Assert.AreEqual(8, baselist.Count, "AddRangeTest:  Count of item is incorrect.");
            Assert.AreEqual('a', baselist[0], "AddRangeTest:  Item[0] is incorrect.");
            Assert.AreEqual(4.5983, baselist[3], "AddRangeTest:  Item[3] is incorrect.");
            Assert.AreEqual(4, baselist[4], "AddRangeTest:  Item[7] is incorrect.");
            Assert.AreEqual(3.49, baselist[6], "AddRangeTest:  Item[7] is incorrect.");
            Assert.AreEqual('b', baselist[7], "AddRangeTest:  Item[7] is incorrect.");
        }

        public void AddRangeTest2()    // call clear() on an empty list...
        {
            PhilsList plist = new PhilsList();
            object[] objarray = ['a', "b", 4, 4.5983];
            plist.AddRange(objarray);
            Assert.AreEqual(4, plist.Count, "AddRangeTest:  Count of item is incorrect.");
            Assert.AreEqual(4.5983, plist[3], "AddRangeTest:  Item[3] is incorrect.");
        }

        [TestMethod]
        public void ClearTest1()    // call clear() on an empty list...
        {
            PhilsList plist = new PhilsList();
            Assert.AreEqual(0, plist.Count, " !! Count is wrong.");
            plist.Clear();
            Assert.AreEqual(0, plist.Count, " !! Count is wrong.");
        }

        [TestMethod]
        public void ClearTest2()    // call clear() on a list with elements...
        {
            PhilsList plist = new PhilsList();
            plist.Add("Bob");
            Assert.AreEqual(1, plist.Count, " !! Count is wrong.");

            plist.Add(1);
            Assert.AreEqual(2, plist.Count, " !! Count is wrong.");

            plist.Clear();
            Assert.AreEqual(0, plist.Count, " !! Count is wrong.");
        }

        [TestMethod]
        public void ContainsTest1()
        {
            PhilsList plist = new PhilsList();
            Assert.IsFalse(plist.Contains("Bob"), " !! Wrong answer on empty list.");

            plist.Add("bob");
            Assert.IsTrue(plist.Contains("bob"), " !! Wrong answer on case-sensitive list.");
            Assert.IsFalse(plist.Contains("Bob"), " !! Wrong answer on case-sensitive list."); 
            Assert.IsFalse(plist.Contains(123), " !! Wrong answer on int item no in list.");

            plist.Add(123);
            Assert.IsTrue(plist.Contains(123), " !! Wrong answer on int in the list.");

            plist.Remove(123);
            Assert.IsFalse(plist.Contains(123), " !! Wrong answer on int removed from the list.");
        }


        [TestMethod]
        public void CopyToTest1()
        {
            const string BOB = "bob";
            PhilsList plist = new PhilsList();
            object[] objarray = new object[10];

            // call CopyTo with empty list
            plist.CopyTo(objarray, 0);
            Assert.IsNull(objarray[0], " !! objarray[0] is not null and should be.");
            Assert.IsNull(objarray[1], " !! objarray[1] is not null and should be.");

            // call with valid list, but invalid starting index
            plist.Add(BOB);
            try
            {
                plist.CopyTo(objarray, -1);
                Assert.Fail("Insert with index < 0 didn't throw as expected.");
            }
            catch (System.IndexOutOfRangeException) { }

            // list has one value, copy it correctly
            plist.CopyTo(objarray, 0);
            Assert.AreEqual(BOB, objarray[0],  " !! Wrong answer on case-sensitive list.");

            // add another item and copy it from item 1...
            plist.Add(123);
            plist.CopyTo(objarray, 1);
            // first BOB is still in the array
            Assert.AreEqual(BOB, objarray[0], " !! objarray[0] has the wrong value.");
            // another BOB and 123 are now in the array
            Assert.AreEqual(BOB, objarray[1], " !! objarray[1] has the wrong value.");
            Assert.AreEqual(123, objarray[2], " !! objarray[1] has the wrong value.");

            // add another item (three total) and copy it from item 0...
            plist.Add(4.32817);
            plist.CopyTo(objarray, 0);
            Assert.AreEqual(3, plist.Count, " !! count is wrong.");  // just to be sure...
            Assert.AreEqual(BOB, objarray[0], " !! objarray[0] has the wrong value.");
            Assert.AreEqual(123, objarray[1], " !! objarray[0] has the wrong value.");
            Assert.AreEqual(4.32817, objarray[2], " !! objarray[0] has the wrong value.");

            // throw something at the end of the array - where the list + the offset is longer than the array...
            plist.CopyTo(objarray, 7);

            // previous items are the same...
            Assert.AreEqual(BOB, objarray[0], " !! objarray[0] has the wrong value.");
            Assert.AreEqual(123, objarray[1], " !! objarray[1] has the wrong value.");
            Assert.AreEqual(4.32817, objarray[2], " !! objarray[2] has the wrong value.");
            Assert.IsNull(objarray[3], " !! objarray[3] is not NULL.");

            // new items are new...
            Assert.IsNull(objarray[6], " !! objarray[6] is not NULL.");
            Assert.AreEqual(BOB, objarray[7], " !! objarray[7] has the wrong value.");
            Assert.AreEqual(123, objarray[8], " !! objarray[8] has the wrong value.");
            Assert.AreEqual(4.32817, objarray[9], " !! objarray[9] has the wrong value.");
        }

        [TestMethod]
        public void EnumeratorTest()
        {
            PhilsList plist = new PhilsList();

            for (int i = 0; i < 5; i++)
            {
                plist.Add(i);
            }
            Assert.AreEqual(5, plist.Count, " !! Count is wrong after adding a bunch.");

            int c = 0;
            foreach (object o in plist)
            {
                Assert.AreEqual(c, o, " !! c != o.");
                c++;
            }
        }

        [TestMethod]
        public void InsertTest1()
        {
            PhilsList plist = new PhilsList();

            // less than 0
            try
            {
                plist.Insert(-1, "testobj1");
                Assert.Fail("Insert with index < 0 didn't throw as expected.");
            }
            catch (System.IndexOutOfRangeException) { }

            // greater than count - off the end of the existing list
            try
            {
                plist.Insert(1, "testobj2");
                Assert.Fail("Insert with index > count didn't throw as expected.");
            }
            catch (System.IndexOutOfRangeException) { }

            // insert into empty with index 0
            plist.Insert(0, "testobj3");
            Assert.AreEqual(1, plist.Count, "Count is not correct after insert.");
            Assert.AreEqual("testobj3", plist[0].ToString(), "test item 3 is not correct after insert.");

            // try a second time to insert with index 0 - the new item should be the first item in the list...
            plist.Insert(0, "testobj4");

            // at this point we have two items in the list - testobj4, testobj3...
            Assert.AreEqual(2, plist.Count, "Count is not correct after insert.");
            Assert.AreEqual("testobj4", plist[0], "Test item 4 is not the first item in the list");
            Assert.AreEqual("testobj3", plist[1], "Test item 3 is not the second item in the list");

            // insert a new item inbetween the two nodes...
            plist.Insert(1, "testobj5");

            // at this point we have three items in the list - testobj4, testobj5, testobj3...
            Assert.AreEqual(3, plist.Count, "Count is not correct after insert.");
            Assert.AreEqual("testobj4", plist[0], "Test item is not the first item in the list");
            Assert.AreEqual("testobj5", plist[1], "Test item is not the second item in the list");
            Assert.AreEqual("testobj3", plist[2], "Test item is not the second item in the list");

            // insert a new item at the end of the list using Count...
            plist.Insert(plist.Count, "testobj6");

            // at this point we have four items in the list - testobj4, testobj5, testobj3...
            Assert.AreEqual(4, plist.Count, "Count is not correct after insert.");
            Assert.AreEqual("testobj5", plist[1], "Test item is not the second item in the list");
            Assert.AreEqual("testobj3", plist[2], "Test item is not the third item in the list");
            Assert.AreEqual("testobj6", plist[3], "Test item is not the fourth item in the list");

            // Clear the list and attempt to add another where index > Count.
            plist.Clear();
            Assert.AreEqual(0, plist.Count, "Count is off after Clear()");
            try
            {
                plist.Insert(1, "testobj2");
                Assert.Fail("Insert with index > count didn't throw as expected.");
            }
            catch (System.IndexOutOfRangeException) { }
        }

        [TestMethod]
        public void ItemTest1()
        {
            PhilsList plist = new PhilsList();
            try
            {
                // Intended to throw when the list is empty...
                plist[0].ToString();
                Assert.Fail(" !! Exception not thrown.");
            }
            catch (System.IndexOutOfRangeException) 
            {
            }

            string s = "bob";
            plist.Add(s);
            Assert.AreEqual(s, plist[0], " !! Wrong answer on case-sensitive list.");
            Assert.AreEqual(s, plist[0].ToString(), " !! Wrong answer on case-sensitive list.");
        }


        [TestMethod]
        public void RemoveTest1()
        {
            PhilsList plist = new PhilsList();

            // call remove() on empty list...
            plist.Remove("xxx");
            Assert.AreEqual(0, plist.Count, " !! Count is wrong.");

            // add/remove the first and only item in the list...
            plist.Add("Bob");
            plist.Remove("Bob");
            Assert.AreEqual(0, plist.Count, " !! Count is wrong after add/remove only item.");

            // Add two items and remove the first then the second...
            plist.Add("43.amv094");
            float f1 = 383.9339F;
            plist.Add(f1);
            Assert.AreEqual(2, plist.Count, " !! Count is wrong.");

            plist.Remove("43.amv094");
            Assert.AreEqual(1, plist.Count, " !! Count is wrong.");

            plist.Remove(f1);
            Assert.AreEqual(0, plist.Count, " !! Count is wrong.");


            // Add two items and remove the second then the first...
            plist.Add("43.bkeo3404");
            f1 = 43.384F;
            plist.Add(f1);
            Assert.AreEqual(2, plist.Count, " !! Count is wrong.");

            plist.Remove(f1);
            Assert.AreEqual(1, plist.Count, " !! Count is wrong.");

            plist.Remove("43.bkeo3404");
            Assert.AreEqual(0, plist.Count, " !! Count is wrong.");


            // add a bunch and remove something in the middle...
            for (int i = 0; i < 5; i++)
            {
                plist.Add(i);
            }
            Assert.AreEqual(5, plist.Count, " !! Count is wrong after adding a bunch.");
            plist.Remove(3);
            Assert.AreEqual(4, plist.Count, " !! Count is wrong after removing from the middle.");


            // attempt to remove an item not in the plist
            plist.Clear();
            plist.Add("490sn2408sd");
            plist.Add(193);
            Assert.AreEqual(2, plist.Count, " !! Count is wrong after adding two.");
            plist.Remove("Bob");     // not in the plist...
            Assert.AreEqual(2, plist.Count, " !! Count is wrong after removing item not in the list");
        }
    }
}
