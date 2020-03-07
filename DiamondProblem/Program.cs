using System;
using DiamondProblem.Devices;

namespace DiamondProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            Printer p1 = new Printer() { SerialNumber = "1080" };
            p1.ProcessDoc("DOC 1");
            p1.Print("My letter");

            Scanner s1 = new Scanner() { SerialNumber = "3028" };
            s1.ProcessDoc("TESTE3");
            Console.WriteLine(s1.Scan());

            ComboDevice cb = new ComboDevice();

            cb.ProcessDoc("CB TESTE");
            cb.Print("cb print");
            Console.WriteLine(cb.Scan()); 
        }
    }
}
