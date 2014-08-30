using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using br.com.lassal.Kata.Kata02;

namespace Test.br.com.lassal.Kata
{
    /// <summary>
    /// Summary description for K02_BinarySearch_TestFixture
    /// </summary>
    [TestClass]
    public class K02_BinarySearch_TestFixture
    {
        public K02_BinarySearch_TestFixture()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        private IBinarySearch BinarySearch
        {
            get
            {
                return new BinarySearchStats(new BinarySearchFirstImpl());
                    //SequentialSearch_SecImpl();
            }
        }

        [TestMethod]
        public void TestBinarySearch()
        {
            IBinarySearch s = this.BinarySearch;

            int[] emptySet = null;
            int[] oneSet = {1};
            int[] threeSet = {1,3,5};
            int[] fourSet = {1, 3, 5, 7};

            Assert.AreEqual(-1, s.Chop(3, emptySet));
            Assert.AreEqual(-1, s.Chop(3, oneSet));
            Assert.AreEqual(0, s.Chop(1, oneSet));
  
            Assert.AreEqual(0, s.Chop(1, threeSet));
            Assert.AreEqual(1, s.Chop(3, threeSet));
            Assert.AreEqual(2, s.Chop(5, threeSet));
            Assert.AreEqual(-1, s.Chop(0, threeSet));
            Assert.AreEqual(-1, s.Chop(2, threeSet));
            Assert.AreEqual(-1, s.Chop(4, threeSet));
            Assert.AreEqual(-1, s.Chop(6, threeSet));
  
            Assert.AreEqual(0, s.Chop(1, fourSet));
            Assert.AreEqual(1, s.Chop(3, fourSet));
            Assert.AreEqual(2, s.Chop(5, fourSet));
            Assert.AreEqual(3, s.Chop(7, fourSet));
            Assert.AreEqual(-1, s.Chop(0, fourSet));

            Assert.AreEqual(-1, s.Chop(2, fourSet));
            Assert.AreEqual(-1, s.Chop(4, fourSet));
            Assert.AreEqual(-1, s.Chop(6, fourSet));
            Assert.AreEqual(-1, s.Chop(8, fourSet));

            BinarySearchStats stats = (BinarySearchStats)s;

            Console.WriteLine("Tempo medio de busca: {0}, num de buscas {1}", stats.AverageSearchTime, stats.NumberOfSearchs);
        }

        [TestMethod]
        public void TestBinarySearchLargeSets()
        {
            int[] testSet = new int[100000];

            for (int i = 0; i < 100000; i++)
            {
                testSet[i] = i+1;
            }

            IBinarySearch s = this.BinarySearch;

            Assert.AreEqual(99998, s.Chop(99999, testSet));
            Assert.AreEqual(8, s.Chop(9, testSet));

            BinarySearchStats stats = (BinarySearchStats)s;
            Console.WriteLine("Tempo medio de busca: {0}, num de buscas {1}", stats.AverageSearchTime, stats.NumberOfSearchs);
        }
    }
}
