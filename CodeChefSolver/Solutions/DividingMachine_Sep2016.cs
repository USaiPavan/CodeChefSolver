using System;
using System.Collections.Generic;

namespace CodeChefSolver.Solutions
{
    public static class DividingMachineSep2016
    {

        private static Dictionary<int, int> LeastPrimeDivisorCache = new Dictionary<int, int>();


        public static void JudgeEntry()
        {
            var testCaseCount = int.Parse(Console.ReadLine().Trim());
            var testsToExecute = new List<TestCase>();
            for (var index = 0; index < testCaseCount; index++)
            {
                var inputLineOne = Console.ReadLine().Trim().Split(' ');
                var inputArray = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), int.Parse);
                var operationCount = int.Parse(inputLineOne[1]);
                var operationTestCases = new List<OperationInformation>();

                for (var innerIndex = 0; innerIndex < operationCount; innerIndex++)
                {
                    var operation = new OperationInformation();
                    var input = Console.ReadLine().Trim().Split(' ');
                    operation.Type = int.Parse(input[0]);
                    operation.Left = int.Parse(input[1]);
                    operation.Right = int.Parse(input[2]);

                    operationTestCases.Add(operation);
                }

                var testCase = new TestCase()
                {
                    InputArray = inputArray,
                    Operations = operationTestCases
                };
                testsToExecute.Add(testCase);
            }

            foreach (var testCase in testsToExecute)
            {
                var result = SolveChallenge(testCase.InputArray, testCase.Operations);
                Console.WriteLine(string.Join(" ", result));
            }
            Console.ReadLine();
        }


        public static List<int> SolveChallenge(int[] inputArray, List<OperationInformation> testCases)
        {
            var resultList = new List<int>();
            foreach (var testCase in testCases)
            {
                if (testCase.Type == 0)
                {
                    UpdateOperation(inputArray, testCase.Left, testCase.Right);
                }
                else if (testCase.Type == 1)
                {
                    resultList.Add(GetOperation(inputArray, testCase.Left, testCase.Right));
                }
            }

            return resultList;
        }


        private static void UpdateOperation(int[] inputArray, int left, int right)
        {
            for (var index = left - 1; index <= right - 1; index++)
            {
                var leastPrimeDivisor = GetLeastPrimeDivisor(inputArray[index]);
                inputArray[index] = inputArray[index] / leastPrimeDivisor;
            }
        }


        private static int GetOperation(int[] inputArray, int left, int right)
        {
            var result = 1;
            for (var index = left - 1; index <= right - 1; index++)
            {
                var leastPrimeDivisor = GetLeastPrimeDivisor(inputArray[index]);
                result = GetMaximum(result, leastPrimeDivisor);
            }
            return result;
        }

        private static int GetMaximum(int result, int leastPrimeDivisor)
        {
            if (result > leastPrimeDivisor)
            {
                return result;
            }
            return leastPrimeDivisor;
        }

        private static int GetLeastPrimeDivisor(int input)
        {
            if (LeastPrimeDivisorCache.ContainsKey(input))
            {
                return LeastPrimeDivisorCache[input];
            }


            for (var index = 2; index <= input; index++)
            {
                if (PrimeHelper.IsPrime(index))
                {
                    if (input % index == 0)
                    {
                        LeastPrimeDivisorCache.Add(input, index);
                        return index;
                    }
                }
            }

            LeastPrimeDivisorCache.Add(input, 1);
            return 1;
        }
    }

    public class OperationInformation
    {
        public int Type { get; set; }
        public int Left { get; set; }
        public int Right { get; set; }
    }

    public class TestCase
    {
        public int[] InputArray { get; set; }
        public List<OperationInformation> Operations { get; set; }
    }


    public static class PrimeHelper
    {
        private static Dictionary<int, bool> PrimeNumberCache = new Dictionary<int, bool>();

        public static bool IsPrime(int candidate)
        {
            if (PrimeNumberCache.ContainsKey(candidate))
            {
                return PrimeNumberCache[candidate];
            }


            if ((candidate & 1) != 0)
            {
                var limit = (int)Math.Sqrt(candidate);
                for (var divisor = 3; divisor <= limit; divisor += 2)
                {
                    if ((candidate % divisor) == 0)
                    {
                        PrimeNumberCache.Add(candidate, false);
                        return false;
                    }
                }
                PrimeNumberCache.Add(candidate, true);
                return true;
            }

            return (candidate == 2);
        }
    }
}