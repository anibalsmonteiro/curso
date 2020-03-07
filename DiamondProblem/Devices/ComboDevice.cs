using System;
using System.Collections.Generic;
using System.Text;

namespace DiamondProblem.Devices
{
    class ComboDevice : Device, IScanner, IPrinter
    {
        public void Print(string doc)
        {
            Console.WriteLine("Combo device print: " + doc);
        }

        public override void ProcessDoc(string doc)
        {
            Console.WriteLine(doc);    
        }

        public string Scan()
        {
            return "Combodevice scan result";
        }
    }
}
