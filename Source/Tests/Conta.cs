
using System.Globalization;

namespace Source.Test
{
    class Conta
    {
        public static double taxaDeSaque = 5.00;

        public string Numero { get; }
        public string NomeTitular { get; private set; }
        public double Saldo { get; private set; }

        public Conta(string numero, string nomeTitular)
        {
            Numero = numero;
            NomeTitular = nomeTitular;
        }

        public Conta(string numero, string nomeTitular, double depositoInicial) : this(numero, nomeTitular)
        {
            Depositar(depositoInicial);
        }

        public void Depositar(double valor)
        {
            Saldo += valor;
        }

        public void Sacar(double valor)
        {
            Saldo -= (valor + taxaDeSaque);
        }

        public override string ToString()
        {
            return "**Dados da conta**\nNumero: " + Numero + " Titular: " + NomeTitular + " Saldo: " + Saldo.ToString("F2", CultureInfo.InvariantCulture);

        }


    }
}

