namespace TaxPayers.Entities
{
    class Individual : Person
    {
        public double HealthExpenses { get; set; }

        public Individual(string name, double annualIncome, double healthExpenses) : base(name, annualIncome)
        {
            HealthExpenses = healthExpenses;
        }

        public override double CalculateTax()
        {
            double tax = (AnnualIncome < 20000.00 ? 0.15 : 0.25);
            double expenseDeduction = HealthExpenses > 0.00 ? HealthExpenses * 0.5 : 0.0;

            return (AnnualIncome * tax) - expenseDeduction;
        }
    }
}
