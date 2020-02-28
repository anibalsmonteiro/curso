namespace TaxPayers.Entities
{
    class Company : Person
    {
        public int Employees { get; set; }

        public Company() { }

        public Company(string name, double annualIncome, int employees) : base(name, annualIncome)
        {
            Employees = employees;
        }

        public override double CalculateTax()
        {
            double tax = Employees > 10 ? 0.14 : 0.16;

            return AnnualIncome * tax;
        }
    }
}
