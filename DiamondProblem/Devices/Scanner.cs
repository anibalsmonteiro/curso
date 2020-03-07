using System;
using System.Collections.Generic;
using System.Text;

namespace DiamondProblem.Devices
{
    class Scanner : Device, IScanner
    {
        public string Scan() {
            return "Scanner DOC";
        }

        public override void ProcessDoc(string doc)
        {
            Console.WriteLine("Processing doc Scanner: " + doc);
        }
    }
}
