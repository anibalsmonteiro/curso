using System;
using DelegateEx.Services;

namespace DelegateEx
{
    delegate double BinaryNumericOperation(double n1, double n2);
    
    //Multicast Delegate
    delegate void BinaryNumericOperation_2(double n1, double n2);
    class Program
    {
        static void Main(string[] args)
        {
            double a = 10;
            double b = 12;

            BinaryNumericOperation op = CalculationService.Sum;
            //BinaryNumericOperation op = new BinaryNumericOperation(CalculationService.Sum);

            double result2 = CalculationService.Square(a);
            Console.WriteLine(result2);

//            double result = op(a, b);
            double result = op.Invoke(a, b);
            Console.WriteLine(result);


            //Multicast Delegate
            BinaryNumericOperation_2 op2 = CalculationService.ShowSum;
            op2 += CalculationService.ShowMax;

            op2(a, b);
        }
    }
}
