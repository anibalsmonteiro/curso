using System;
using System.Globalization;

namespace Source
{
    public class Funcionario
    {
        public int Id;
        public String Nome;
        public double SalarioBruto;
        public double Imposto;

        public void AumentarSalario(double porcentagem)
        {
            SalarioBruto *= (1 + (porcentagem/100));
        }

        public double SalarioLiquido()
        {
            return SalarioBruto - Imposto;
        }

        public override string ToString()
        {
            return Nome + " $" + SalarioLiquido().ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
