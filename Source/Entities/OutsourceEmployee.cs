using System.Globalization;

namespace Source.Entities
{
    class OutsourceEmployee : Employee
    {
        public double AdditionalCharge { get; set; }

        public OutsourceEmployee() { }

        public OutsourceEmployee(string name, int hours, double valuePerHour, double additionalCharge) : base(name, hours, valuePerHour)
        {
            AdditionalCharge = additionalCharge;
        }

        public override double Payment()
        {
            double payment = base.Payment();
            return payment += (AdditionalCharge*1.10);
        }

        public override string ToString()
        {
            return (Name + " - $" + Payment().ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}
