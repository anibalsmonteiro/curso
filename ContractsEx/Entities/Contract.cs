using System;
using System.Collections.Generic;
using System.Text;
using ContractsEx.Entities;

namespace ContractsEx.Entities
{
    class Contract
    {
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public double TotalValue { get; set; }
        public List<Installment> Installments { get; set; }

        public Contract(string number, DateTime date, double totalValue)
        {
            Number = number;
            Date = date;
            TotalValue = totalValue;
            Installments = new List<Installment>();
        }

        public void AddInstallment(Installment installment)
        {
            Installments.Add(installment);
        }
        public void RemoveInstallment(Installment installment)
        {
            Installments.Remove(installment);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Installment installment in Installments)
            {
                sb.AppendLine(installment.ToString());
            }

            return "INSTALLMENTS: \n" + sb.ToString();
        }
    }
}
