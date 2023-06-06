using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculatorKata;
using System;

namespace StringCalculatorKataTest
{
    [TestClass]
    public class UnitTest1
    {
        //ARRANGE
        private StringCalculator _calculator = new StringCalculator();
        [TestMethod]
        public void Add_EmptyStringAsParam_ReturnsZero()
        {
            //ACT
            int result = _calculator.Add("");
            //ASSERT
            Assert.AreEqual(0, result);
        }

        [DataTestMethod]
        [DataRow("1", 1)]
        [DataRow("2", 2)]
        public void Add_StringContainingSingleNumber_ReturnsTheNumberItself(string numbers, int result)
        {
            //ACT
            int value = _calculator.Add(numbers);
            //ASSERT
            Assert.AreEqual(result, value);
        }

        [DataTestMethod]
        [DataRow("1,2,3", 6)]
        [DataRow("1,2,3,4", 10)]
        [DataRow("1,2,3,4,5", 15)]
        public void Add_MoreThenThreeNumbersSeparatedByComma_ReturnsTheirSum(string numbers, int result)
        {
            //ACT
            int value = _calculator.Add(numbers);
            //ASSERT
            Assert.AreEqual(result, value);
        }
        
        [DataTestMethod]
        [DataRow("1,2,3, 1000", 1006)]
        [DataRow("1,2,3,1001", 6)]
        public void Add_NumbersOverOneThousand_NotIncluded(string numbers, int result)
        {
            //ACT
            int value = _calculator.Add(numbers);
            //ASSERT
            Assert.AreEqual(result, value);
        }

        [DataTestMethod]
        [DataRow("-1,2", "Negatives not allowed: -1")]
        [DataRow("-1,-2", "Negatives not allowed: -1,-2")]
        public void Add_StringContainingNegativeNumbers_ThrowsException(string numbers, string result)
        {
            //ACT
            Action value = () => _calculator.Add(numbers);
            var negative = Assert.ThrowsException<Exception>(value);
            //ASSERT
            Assert.AreEqual(result, negative.Message);
        }
    }
}
