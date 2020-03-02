using System;
using System.Collections.Generic;
using System.Text;

namespace ContractsEx.Services
{
    class PaypalService : IPaymentService
    {

        private const double FeePercentage = 0.01;
        private const double MonthlyInterest = 0.02;

        public double Tax(double amount, int months)
        {
            return amount * FeePercentage * months;
        }
        public double Interest(double amount)
        {
            return amount * MonthlyInterest;
        }
    }
}
