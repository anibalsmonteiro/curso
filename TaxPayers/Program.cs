using System;
using System.Globalization;
using System.Collections.Generic;
using TaxPayers.Entities;

namespace TaxPayers
{
    class Program
    {

        static void Main(string[] args)
        {

            List<Person> persons = new List<Person>();
            
            Console.Write("Enter the number of tax payers: ");
            int qtyTaxPayers = int.Parse(Console.ReadLine());

            for (int i = 1; i <= qtyTaxPayers; i++)
            {
                Console.WriteLine($"Tax payer #{i} data: ");

                Console.Write("Individual or Company (i/c)? ");
                char ch = char.Parse(Console.ReadLine());

                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("Annual income: ");
                double annualIncome = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                if (ch == 'i')
                {
                    Console.Write("Health expenses: ");
                    double healthExpenses = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                    persons.Add(new Individual(name, annualIncome, healthExpenses));
                }
                else
                {
                    Console.Write("Number of employees: ");
                    int employees = int.Parse(Console.ReadLine());
                    
                    persons.Add(new Company(name, annualIncome, employees));
                }
            }

            Console.WriteLine();
            Console.WriteLine("TAXES PAID: ");
            
            double totalTaxes = 0;
            
            foreach (Person person in persons)
            {
                Console.WriteLine(person);
                totalTaxes += person.CalculateTax();
            }

            Console.WriteLine();
            Console.Write("TOTAL TAXES: " + totalTaxes.ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}
