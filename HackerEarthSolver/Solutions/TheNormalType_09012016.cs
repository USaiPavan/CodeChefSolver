using System;
using System.Collections.Generic;

namespace HackerEarthSolver.Solutions
{
    public static class TheNormalType_09012016
    {
        public static void Execute()
        {
            var totalInputCount = Console.ReadLine();
            var inputArray = Console.ReadLine();

            RunProgram(totalInputCount, inputArray);
        }

        public static void RunProgram(string totalInputCount, string inputValues)
        {
            var inputArray = inputValues.Split(' ');
            var input = new Dictionary<int, int>();
            var currentIndex = 0;
            foreach (var element in inputArray)
            {
                var requiredNumber = 0;
                for (var i = 0; i < element.Length; i++)
                    requiredNumber = requiredNumber * 10 + (element[i] - '0');
                input.Add(currentIndex, requiredNumber);
                currentIndex++;
            }
            
            var fullWindow = CountDistinct(input, input.Count);
            var fullWindowDistinctCount = fullWindow[0];
            var totalWindowMatch = 0;

            for (var index = 2; index <= input.Count - 1; index++)
            {
                totalWindowMatch += CountDistinct(input, index, fullWindowDistinctCount);
            }

            totalWindowMatch++;
            Console.WriteLine(totalWindowMatch);
        }

        static List<int> CountDistinct(Dictionary<int, int> inputArray, int windowSize)
        {
            var window = new Dictionary<int, int>();
            var returnSet = new List<int>();
            var distinctCount = 0;

            for (var index = 0; index < windowSize; index++)
            {
                if (!window.ContainsKey(inputArray[index]))
                {
                    window.Add(inputArray[index], 1);
                    distinctCount++;
                }
                else
                {
                    window[inputArray[index]]++;
                }
            }

            returnSet.Add(distinctCount);

            for (var index = windowSize; index < inputArray.Count; index++)
            {
                var firstValue = inputArray[index - windowSize];
                if (window[firstValue] == 1)
                {
                    window.Remove(firstValue);
                    distinctCount--;
                }
                else
                {
                    window[firstValue]--;
                }


                var currentValue = inputArray[index];
                if (!window.ContainsKey(currentValue))
                {
                    window.Add(inputArray[index], 1);
                    distinctCount++;
                }
                else
                {
                    window[currentValue]++;
                }
                returnSet.Add(distinctCount);
            }

            return returnSet;
        }



        static int CountDistinct(Dictionary<int, int> inputArray, int windowSize, int compareValue)
        {
            var window = new Dictionary<int, int>();
            var returnValue = 0;
            var distinctCount = 0;

            for (var index = 0; index < windowSize; index++)
            {
                if (!window.ContainsKey(inputArray[index]))
                {
                    window.Add(inputArray[index], 1);
                    distinctCount++;
                }
                else
                {
                    window[inputArray[index]]++;
                }
            }

            if (distinctCount == compareValue)
            {
                returnValue++;
            }

            for (var index = windowSize; index < inputArray.Count; index++)
            {
                var firstValue = inputArray[index - windowSize];
                if (window[firstValue] == 1)
                {
                    window.Remove(firstValue);
                    distinctCount--;
                }
                else
                {
                    window[firstValue]--;
                }

                var currentValue = inputArray[index];
                if (!window.ContainsKey(currentValue))
                {
                    window.Add(currentValue, 1);
                    distinctCount++;
                }
                else
                {
                    window[currentValue]++;
                }
                if (distinctCount == compareValue)
                {
                    returnValue++;
                }
            }

            return returnValue;
        }
    }
}