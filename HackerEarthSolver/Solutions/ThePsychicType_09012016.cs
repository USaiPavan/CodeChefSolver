using System;
using System.Collections.Generic;

namespace HackerEarthSolver.Solutions
{
    public static class ThePsychicType_09012016
    {
        static int[] _input;
        static HashSet<int> _previousPositions = new HashSet<int>();

        public static void JudgeEntry()
        {
            var totalNumbers = Console.ReadLine();
            var inputArray = Console.ReadLine().Trim().Split(' ');
            var teleportationInfo = Console.ReadLine().Trim().Split(' ');
            _input = Array.ConvertAll(inputArray, int.Parse);
            var result = SolveChallenge(teleportationInfo);
            Console.WriteLine(result);
        }


        public static string SolveChallenge(string[] teleportationInfo)
        {
            return TraverseArray(int.Parse(teleportationInfo[0]), int.Parse(teleportationInfo[1])) ? "Yes" : "No";
        }

        static bool TraverseArray(int currentPosition, int requiredPosition)
        {
            if (currentPosition == requiredPosition)
            {
                return true;
            }

            if (_previousPositions.Contains(currentPosition))
            {
                return false;
            }

            if (currentPosition < 1)
            {
                return false;
            }

            _previousPositions.Add(currentPosition);
            return TraverseArray(_input[currentPosition - 1], requiredPosition);
        }
    }
}