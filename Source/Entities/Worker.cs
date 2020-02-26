﻿using Source.Entities.Enums;
using System.Collections.Generic;


namespace Source.Entities
{
    class Worker
    {
        public string Name { get; set; }
        public WorkerLevel Level { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
        public List<HourContract> Contracts { get; set; } = new List<HourContract>();//Garante que a lista não seja Nula


        public Worker()
        {
        }

        public Worker(string name, WorkerLevel level, double baseSalary, Department department)
        {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddContract(HourContract contract)
        {
            Contracts.Add(contract);
        }

        public void RemoveContract(HourContract contract)
        {
            Contracts.Remove(contract);
        }

        public double Income(int year, int month)
        {
            double income = BaseSalary;
            
            foreach (HourContract contract in Contracts)
            {
                if (contract.Date.Month == month && contract.Date.Year == year)
                {
                    income += contract.TotalValue();
                }
            }
            return income;
        }


    }
}
