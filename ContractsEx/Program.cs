using System;
using System.Globalization;
using ContractsEx.Entities;
using ContractsEx.Services;

namespace ContractsEx
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter contract data: ");
            Console.Write("Number: ");
            string number = Console.ReadLine();

            Console.Write("Date (dd/MM/yyyy): ");
            DateTime dueDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Contract value: ");
            double totalValue = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.Write("Enter number of installments: ");
            int qtyInstallments = int.Parse(Console.ReadLine());

            Contract contract = new Contract(number, dueDate, totalValue);
            ProcessService processService = new ProcessService(new PaypalService());
            processService.ProcessContracts(contract, qtyInstallments);

            Console.WriteLine(contract);
        }
    }
}
