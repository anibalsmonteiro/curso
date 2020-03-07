using System;

namespace DiamondProblem.Devices
{
    class Printer : Device, IPrinter
    {
        public void Print(string doc)
        {
            Console.WriteLine(doc);
        }

        public override void ProcessDoc(string doc)
        {
            Console.WriteLine("Processing printer: "+ doc);
        }
    }
}
