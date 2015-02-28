using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Numbers;

namespace NumbersTest
{
    [TestClass]
    public class TestNumbers
    {
        [TestMethod]
        public void WhenOnlyOneAndTwoIsPresentInGroupLines_ExtractNumbersFromGroupBatchReturnsCorrectly()
        {
            var numbersBatch = new List<List<string>>
                {
                    new List<string>() {"|", " ", "-", "-", "-"},
                    new List<string>() {"|", " ", " ", "_", "|"},
                    new List<string>() {"|", " ", "|", " ", " "},
                    new List<string>() {"|", " ", "-", "-", "-"}
                };

            List<Number> extractedNumbers = NumbersProcessor.ExtractNumbersFromGroupBatch(numbersBatch);

            Assert.AreEqual(2, extractedNumbers.Count);
            Assert.IsTrue(extractedNumbers.Contains(NumbersFactory.CreateOne()));
            Assert.IsTrue(extractedNumbers.Contains(NumbersFactory.CreateTwo()));
        }

        [TestMethod]
        public void WhenTwoNumberGroupsLinesArePassed_ExtractNumbersFromFileContentReturnsCorrectly()
        {
            var lines = new List<String>()
                {
                    "| ---",
                    "|  _|",
                    "| |  ",
                    "| ---",
                    "---",
                    " / ",
                    " \\ ",
                    "-- "
                };

            List<Number> extractedNumbers = NumbersProcessor.ExtractNumbersFromFileContent(lines);
            Assert.AreEqual(3, extractedNumbers.Count);
            Assert.IsTrue(extractedNumbers.Contains(NumbersFactory.CreateOne()));
            Assert.IsTrue(extractedNumbers.Contains(NumbersFactory.CreateTwo()));
            Assert.IsTrue(extractedNumbers.Contains(NumbersFactory.CreateThree()));
        }
    }
}
