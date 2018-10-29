using Microsoft.VisualStudio.TestTools.UnitTesting;
using CheckBrackets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckBrackets.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void GetFirstCharSubStringTest()
        {
            // Arrange
            string inputText = "123456789";
            
            // Act
            // For the input string get the substring around the first character
            string substring = Program.GetSubString(inputText, 0);
            
            // Assert
            // Expected result should contain only the numbers on the right side of the first character
            Assert.AreEqual("1234", substring);
        }

        [TestMethod]
        public void GetMiddleCharSubStringTest()
        {
            // Arrange
            string inputText = "123456789";

            // Act
            // For the input string get the substring around the character in the middle
            string substring = Program.GetSubString(inputText, 4);

            // Assert
            // Expected result should contain only the numbers on the left side and right side of the middle character
            Assert.AreEqual("2345678", substring);
        }

        [TestMethod]
        public void GetLastCharSubStringTest()
        {
            // Arrange
            string inputText = "123456789";

            // Act
            // For the input string get the substring around the first character
            string substring = Program.GetSubString(inputText, 8);

            // Assert
            // Expected result should contain only the numbers on the right side of the first character
            Assert.AreEqual("6789", substring);
        }

        [TestMethod]
        public void NoErrorOccuredInBracketsChecking()
        {
            // Arrange
            string inputText = "()()()()";

            // Act
            string errors = Program.CheckBracketsOnString(inputText);

            // Assert
            Assert.AreEqual(string.Empty, errors);
        }

        [TestMethod]
        public void ErrorsInBracketsChecking()
        {
            // Arrange
            string inputText = "this ( text () has incorrect brackets";

            // Act
            string errors = Program.CheckBracketsOnString(inputText);
            string expected = "is.(.te" + Environment.NewLine;
            // Assert
            Assert.AreEqual(expected, errors);
        }
    }
}