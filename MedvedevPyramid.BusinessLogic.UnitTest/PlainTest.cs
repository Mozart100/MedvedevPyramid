using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MedvedevPyramid.BusinessLogic;
using System.Linq;

namespace MedvedevPyramid.BusinessLogic.UnitTest
{
    [TestClass]
    public class PlainTest
    {
        [TestMethod]
        public void PlainItem__CreateFirstElement()
        {
            const int expected = 10;
            var plain = new Plain();

            plain.Store(expected);

            var root = plain.Root;

            Assert.AreEqual(expected, root.Item);
            Assert.IsNull(root.Right);
            Assert.IsNull(root.Left);

        }


        [TestMethod]
        public void PlainItem__CreateSecondAndThirdElement()
        {
            var expected = new int[] { 10, 23, 4 };
            var plain = new Plain();


            plain.Store(expected);
            var root = plain.Root;

            Assert.AreEqual(expected[0], root.Item);
            Assert.AreEqual(expected[1], root.Left.Item);
            Assert.AreEqual(expected[2], root.Right.Item);

        }

        [TestMethod]
        public void PlainItem__CreatePyramidOfElements()
        {
            var expected = new int[] { 55, 94, 48, 95, 30, 28, 77, 71, 26, 28 };
            var plain = new Plain();


            plain.Store(expected);
            var root = plain.Root;

            Assert.AreEqual(expected[0], root.Item);
            Assert.AreEqual(expected[1], root.Left.Item);
            Assert.AreEqual(expected[2], root.Right.Item);
            Assert.AreEqual(expected[3], root.Left.Left.Item);
            Assert.AreEqual(expected[4], root.Left.Right.Item);
            Assert.AreEqual(expected[5], root.Right.Right.Item);

            Assert.AreEqual(expected[6], root.Left.Left.Left.Item);
            Assert.AreEqual(expected[7], root.Left.Left.Right.Item);
            Assert.AreEqual(expected[7], root.Right.Left.Left.Item);
            Assert.AreEqual(expected[8], root.Left.Right.Right.Item);
            Assert.AreEqual(expected[8], root.Right.Right.Left.Item);
            Assert.AreEqual(expected[9], root.Right.Right.Right.Item);

            var occurenceCounter = new OccurenceCounter();

            var reports = occurenceCounter.CountOccurences(root);

            var report = reports.First();
            Assert.AreEqual(report.Frequence, 2);
            Assert.AreEqual(report.Sum, 159);



        }



    }
}
