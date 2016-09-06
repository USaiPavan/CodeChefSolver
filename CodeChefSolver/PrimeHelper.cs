//using System;
//using System.Collections.Generic;

//namespace CodeChefSolver
//{
//    public static class PrimeHelper
//    {
//        public static bool IsPrime(int candidate)
//        {
//            if ((candidate & 1) != 0)
//            {
//                var limit = (int)Math.Sqrt(candidate);
//                for (var divisor = 3; divisor <= limit; divisor += 2)
//                {
//                    if ((candidate % divisor) == 0)
//                        return false;
//                }
//                return true;
//            }
//            return (candidate == 2);
//        }
//    }
//}