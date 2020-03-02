using System;
using System.Collections.Generic;
using System.Text;

namespace ContractsEx.Services
{
    interface IPaymentService
    {
        public double Tax(double amount, int months);
        public double Interest(double amount);
    }
}
