using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeChefSolver.Solutions;
using NUnit.Framework;


namespace ProgrammingChallengeSolver.Tests
{
    [TestFixture]
    public class CodeChefTests
    {



        [SetUp]
        public void SetupSampleData()
        {

        }

        [Test]
        public void DividingMachineSep2016_SolveChallengeWithSampleInput()
        {
            //Arrange
            var inputArray = new int[] { 2, 5, 8, 10, 3, 44 };
            var testCases = new List<OperationInformation>()
            {
                new OperationInformation()
                {
                    Type = 1,
                    Left = 2,
                    Right = 6
                },
                new OperationInformation()
                {
                    Type = 0,
                    Left = 2,
                    Right = 3
                },
                new OperationInformation()
                {
                    Type = 1,
                    Left = 2,
                    Right = 6
                },
                new OperationInformation()
                {
                    Type = 0,
                    Left = 4,
                    Right = 6
                },
                new OperationInformation()
                {
                    Type = 1,
                    Left = 1,
                    Right = 6
                },
                new OperationInformation()
                {
                    Type = 0,
                    Left = 1,
                    Right = 6
                },
                new OperationInformation()
                {
                    Type = 1,
                    Left = 4,
                    Right = 6
                },
            };

            


            //Act
            var result = DividingMachineSep2016.SolveChallenge(inputArray, testCases);

            //Assert
            Assert.AreEqual(4, result.Count);
            Assert.AreEqual(5, result[0]);
            Assert.AreEqual(3, result[1]);
            Assert.AreEqual(5, result[2]);
            Assert.AreEqual(11, result[3]);
        }
    }
}
