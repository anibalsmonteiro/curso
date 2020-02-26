using System;

namespace Source.Test
{
    class Aluno
    {
        public string Nome;
        public double Nota1;
        public double Nota2;
        public double Nota3;

        public double CalcularNotaFinal()
        {
            return (Nota1 + Nota2 + Nota3);
        }

        public void VerificarAprovacao()
        {
            double notaFinal = CalcularNotaFinal();
            string resultado;

            Console.WriteLine("Nota Final: " + notaFinal);

            if (notaFinal >= 60.00)
            {
                resultado = "APROVADO";
            }
            else
            {
                resultado = ("REPROVADO! FALTARAM " + (60 - notaFinal) + " PONTOS");
            }

            Console.WriteLine(resultado);
        }
    }
}
