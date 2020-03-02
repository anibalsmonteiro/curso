using System;
using System.Collections.Generic;
using System.Text;
using ContractsEx.Entities;

namespace ContractsEx.Services
{
    class ProcessService
    {
        private IPaymentService _paymentService;

        public ProcessService(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public void ProcessContracts(Contract contract, int qtyInstallments)
        {

            for (int i = 1; i <= qtyInstallments; i++)
            {
                double installmentAmount = contract.TotalValue / qtyInstallments;
                DateTime date = contract.Date.AddMonths(i);
                installmentAmount += _paymentService.Tax(installmentAmount, i);
                installmentAmount += _paymentService.Interest(installmentAmount);
                contract.AddInstallment(new Installment(date, installmentAmount));
            }

        }

    }
}
