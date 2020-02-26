using System;
using System.Collections.Generic;
using System.Text;

namespace Source
{
    public class ConversorDeMoeda
    {
        public static double IOF = 1.06;

        public static double Converter(double valor, double pTax)
        {
            return valor * (pTax*IOF);
        }
    }
}
