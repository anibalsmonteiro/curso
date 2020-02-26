using System;
using System.Collections.Generic;
using System.Text;

namespace Source.Test
{
    class Calculator
    {
        public static double Soma (params double [] nums)
        {
            double res= 0.0;
            
            for (int i = 0; i < nums.Length; i++)
            {
                res += nums[i];
            }

            return res;
        }

        public static void Triple(ref double num)
        {
            num *= 3;
        }
        public static void Triple(double origin, out double result)
        {
            result = origin *= 3;
        }
    }
}
