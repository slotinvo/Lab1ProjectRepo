using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyLib;

namespace TestProject_task2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1() 
        {
            var matrix1 = new[,]
            {
                { 1, 1, 4},
                { 10, 4, 0 },
                { 8, 5, -1 },
                { 9, 9, 0 }
            };
            var resMatrix1 = new[,]
            {
                { 1, 1, 4},
                { 8, 5, -1 },
                { 10, 4, 0 },
                { 9, 9, 0 }
            };
            var sortMatrix1 = matrix1.SortRows((x, y) => x > y, (x, y) => x + y);
            CollectionAssert.AreEqual(resMatrix1, sortMatrix1);
        }

        [TestMethod]
        public void TestMethod2() 
        {
            var matrix2 = new[,]
            {
                { 9, -5, 6 },
                { 1, 1, 4},
                { 10, 4, 0 },
                { 8, 5, -1 },
                { 9, 9, 0 }
            };
            var resMatrix2 = new[,]
            {
                { 9, 9, 0 },
                { 10, 4, 0 },
                { 8, 5, -1 },
                { 9, -5, 6 },
                { 1, 1, 4}
            };
            var sortMatrix2 = matrix2.SortRows((x, y) => x < y, (x, y) => x + y);
            CollectionAssert.AreEqual(resMatrix2, sortMatrix2);
        }

        [TestMethod]
        public void TestMethod3() 
        {
            var matrix3 = new[,]
            {
                { 9, -5, 6 },
                { 1, 1, 4},
                { 10, 4, 0 },
                { 8, 5, -1 },
                { 9, 11, 0 }
            };
            var resMatrix3 = new[,]
            {
                { 1, 1, 4},
                { 8, 5, -1 },
                { 9, -5, 6 },
                { 10, 4, 0 },
                { 9, 11, 0 }
            };
            var sortMatrix3 = matrix3.SortRows((x, y) => x > y, (x, y) => x > y ? x : y);
            CollectionAssert.AreEqual(resMatrix3, sortMatrix3);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var matrix4 = new[,]
            {
                { 1, 1, 4, 5},
                { 10, 4, 0, 11 },
                { 8, 5, -1, 9 },
                { 9, 9, 0, 15 }
            };
            var resMatrix4 = new[,]
            {
                { 9, 9, 0, 15 },
                { 10, 4, 0, 11 },
                { 8, 5, -1, 9 },
                { 1, 1, 4, 5}
            };
            var sortMatrix4 = matrix4.SortRows((x, y) => x < y, (x, y) => x > y ? x : y);
            CollectionAssert.AreEqual(resMatrix4, sortMatrix4);
        }

        [TestMethod]
        public void TestMethod5()
        {
            var matrix5 = new[,]
            {
                { 9, -5, 6 },
                { 1, 1, 4},
                { 10, 4, 0 },
                { 8, 5, -1 },
                { 9, 9, 2 }
            };
            var resMatrix5 = new[,]
            {
                { 9, -5, 6 },
                { 8, 5, -1 },
                { 10, 4, 0 },
                { 1, 1, 4},
                { 9, 9, 2 }
            };
            var sortMatrix5 = resMatrix5.SortRows((x, y) => x > y, (x, y) => x < y ? x : y);
            CollectionAssert.AreEqual(resMatrix5, sortMatrix5);
        }

        [TestMethod]
        public void TestMethod6()
        {
            var matrix6 = new[,]
            {
                { 1, 1, 4},
                { 10, 4, 0 },
                { 8, 5, -1 },
                { 4, 9, 2 }
            };
            var resMatrix6 = new[,]
            {
                { 4, 9, 2 },
                { 1, 1, 4},
                { 10, 4, 0 },
                { 8, 5, -1 }
            };
            var sortMatrix6 = resMatrix6.SortRows((x, y) => x < y, (x, y) => x < y ? x : y);
            CollectionAssert.AreEqual(resMatrix6, sortMatrix6);
        }
    }
}