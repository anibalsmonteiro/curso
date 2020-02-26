using System;
using System.Globalization;
using System.Collections.Generic;

namespace Source
{
    class Program
    {
        static void Main(string[] args)
        {
            //1
            //2
            DateTime d1 = new DateTime(2000, 8, 15, 13, 5, 58, DateTimeKind.Local);

            Console.WriteLine("d1: " + d1);
            Console.WriteLine("d1 Kind: " + d1.Kind);
            Console.WriteLine("d1 to local: " + d1.ToLocalTime());
            Console.WriteLine("d1 to utc: " + d1.ToUniversalTime());
        }

        static void ExercicioHashSet()
        {
            HashSet<int> a = new HashSet<int>();
            HashSet<int> b = new HashSet<int>();

            a.Add(1);
            a.Add(3);
            a.Add(5);
            a.Add(7);
            a.Add(9);

            b.Add(2);
            b.Add(4);
            b.Add(6);
            b.Add(8);
            b.Add(9);

            a.Remove(2);

            a.ExceptWith(b);
            a.UnionWith(b);
            a.IntersectWith(b);

            foreach (var item in a)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Enter a value to compare: ");
            int value = int.Parse(Console.ReadLine());

            if (a.Contains(value))
                Console.WriteLine($"The value {value} is contained in group A");
            else
                Console.WriteLine($"The value {value} IS NOT contained in group A");

            if (b.Contains(value))
                Console.WriteLine($"The value {value} is contained in group B");
            else
                Console.WriteLine($"The value {value} IS NOT contained in group B");

        }
        static void Exerciciomatrix()
        {

            Console.WriteLine("Enter the number of rows (Axis X):");
            int m = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the number of columns (Axis Y):");
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[m, n];

            Console.WriteLine("Filling the matrix...");
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = int.Parse(Console.ReadLine());
                }
            }

            Console.WriteLine("Enter the search number: ");
            int searchNumber = int.Parse(Console.ReadLine());

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j] == searchNumber)
                    {
                        Console.WriteLine("Position: " + i + "," + j);
                        if (i > 0) // upper
                        {
                            Console.WriteLine("Upper: " + matrix[i - 1, j]);
                        }

                        if (j > 0) // left
                        {
                            Console.WriteLine("Left: " + matrix[i, j - 1]);
                        }

                        if (j < n - 1) // Right
                        {
                            Console.WriteLine("Right: " + matrix[i, j + 1]);
                        }

                        if (i < m - 1) // Down
                        {
                            Console.WriteLine("Down: " + matrix[i + 1, j]);
                        }

                    }
                }
            }

        }
        static void matrix()
        {
            //double[,] mat2 = new double[2, 3];

            //Console.WriteLine(mat2.Length);
            //Console.WriteLine(mat2.Rank);

            //Console.WriteLine(mat2.GetLength(0));
            //Console.WriteLine(mat2.GetLength(1));

            //Exercício Resolvido

            int n = int.Parse(Console.ReadLine());

            int[,] mat = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                string[] values = Console.ReadLine().Split(' ');

                for (int j = 0; j < n; j++)
                {
                    mat[i, j] = int.Parse(values[j]);
                }
            }

            Console.WriteLine("Main diagonal: ");

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(mat[i, i]);
            }

            int negative = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (mat[i, j] < 0)
                    {
                        negative++;
                    }
                }
            }

            Console.WriteLine("Negative numbers: " + negative);


        }
        static void ExercicioListas()
        {
            List<Employee> emp = new List<Employee>();

            Console.WriteLine("How many employees will be registered? ");
            int QtyEmployee = int.Parse(Console.ReadLine());

            for (int f = 1; f < QtyEmployee; f++)
            {
                Console.WriteLine("\nEmployee #" + f);
                Console.Write("Id: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("Salary: ");
                double salary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                emp.Add(new Employee(id, name, salary));
            }

            Console.WriteLine("\nEnter the employee Id that will have salary increased");
            int searchId = int.Parse(Console.ReadLine());

            if (emp.Exists(x => x.Id == searchId))
            {
                Console.WriteLine("Enter the percentage to increase the salary: ");
                double perc = (double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture));

                emp.Find(x => x.Id == searchId).IncreaseSalary(perc);
            }
            else
            {
                Console.WriteLine("\nThis Id doesn't exist in database!");
            }

            Console.WriteLine("\nUpdated list of employees");
            foreach (Employee e in emp)
            {
                Console.WriteLine(e.ToString());
            }
        }
        static void Listas()
        {
            List<string> nomes = new List<string>();

            nomes.Add("Anibal");
            nomes.Add("José");
            nomes.Add("Pedro");
            nomes.Insert(2, "Anna");

            foreach (string nome in nomes)
            {
                Console.WriteLine(nome);
            }
            Console.WriteLine("List Count: " + nomes.Count);

            string s1 = nomes.Find(x => x[0] == 'A');
            Console.WriteLine(s1);

            string s2 = nomes.FindLast(x => x[0] == 'A');
            Console.WriteLine(s2);

            int pos1 = nomes.FindIndex(x => x[0] == 'A');
            int pos2 = nomes.FindLastIndex(x => x[0] == 'A');

            List<string> list = nomes.FindAll(x => x.Length == 5);
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
        static void TesteParams()
        {
            Console.WriteLine(Calculator.Soma(new double[] { 0, 1, 2, 3 })); //Sem "params" na definição da função
            Console.WriteLine(Calculator.Soma(0, 1, 2, 3)); //Com "params"

            double num = 10;
            Calculator.Triple(ref num); //Com ref
            Console.WriteLine("Triple function with Ref: " + num);

            double a = 20;
            double triple;
            Calculator.Triple(a, out triple);

            Console.WriteLine("Triple function with out: " + triple);

            //Teste Foreach

            string[] arr = new string[] { "anibal", "João", "Carlos" };

            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }
        static void ExercicioVetores()
        {
            Rent[] rents = new Rent[10];

            Console.WriteLine("How many rooms will be rented?");
            int n = int.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("\nRent #" + (i + 1));
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Email: ");
                string email = Console.ReadLine();
                Console.Write("Room: ");
                int room = int.Parse(Console.ReadLine());

                rents[room] = new Rent { TenantName = name, TenantEmail = email };
            }

            Console.WriteLine("\nBusy Rooms: ");
            for (int i = 0; i < rents.Length; i++)
            {
                if (rents[i] != null)
                {
                    Console.WriteLine(i + ": " + rents[i].ToString());
                }

            }

        }
        static void TesteVetoresClasses()
        {


            int n = int.Parse(Console.ReadLine());

            Produto[] vect = new Produto[n];


            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                vect[i] = new Produto(name, price);
            }

            double sum = 0.0;

            for (int i = 0; i < n; i++)
            {
                sum += vect[i].Preco;
            }

            double avg = sum / n;

            Console.WriteLine("AVERAGE PRICE = " + avg.ToString("F2", CultureInfo.InvariantCulture));

        }
        static void TesteVetores()
        {
            int n = int.Parse(Console.ReadLine());

            double[] vect = new double[n];

            for (int i = 0; i < n; i++)
            {
                vect[i] = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            }

            double sum = 0.0;

            for (int i = 0; i < n; i++)
            {
                sum += vect[i];
            }

            double avg = sum / vect.Length;

            Console.WriteLine("AVERAGE HEIGHT = " + avg.ToString("F2", CultureInfo.InvariantCulture));
        }
        static void testeStruct()
        {
            Point p;

            p.X = 10;
            p.Y = 20;

            Console.WriteLine(p);

            Nullable<double> x1 = null;

            Console.WriteLine(x1.GetValueOrDefault());

            double? x = null;
            double? y = 10.0;

            Console.WriteLine(x.GetValueOrDefault());
            Console.WriteLine(y.GetValueOrDefault());

            Console.WriteLine(x.HasValue);
            Console.WriteLine(y.HasValue);

            if (x.HasValue)
                Console.WriteLine(x.Value);
            else
                Console.WriteLine("X is null");

            if (y.HasValue)
                Console.WriteLine(y.Value);
            else
                Console.WriteLine("Y is null");

            //Operador de coalescência nula
            y = x ?? 55.55;

            Console.WriteLine(y);

        }
        static void TesteConta()
        {
            double valor;
            Conta c1;

            Console.WriteLine("Abertura de conta - Insira os dados do correntista: ");
            Console.Write("Número da conta: ");
            string numeroDaConta = Console.ReadLine();
            Console.Write("Nome do titular: ");
            string nomeDoTitular = Console.ReadLine();
            Console.Write("Depósito inicial: ");
            double depositoInicial = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            if (depositoInicial > 0)
            {
                c1 = new Conta(numeroDaConta, nomeDoTitular, depositoInicial);
            }
            else
            {
                c1 = new Conta(numeroDaConta, nomeDoTitular);
            }

            Console.WriteLine(c1.ToString());

            Console.Write("Informe o valor a ser depositado: ");
            valor = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            c1.Depositar(valor);
            Console.WriteLine(c1.ToString());

            Console.Write("Informe o valor a ser sacado: ");
            valor = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            c1.Sacar(valor);
            Console.WriteLine(c1.ToString());
        }
        static void TesteConversorDeMoeda()
        {
            double pTax, dolares, totalEmReais;

            Console.Write("Qual é a cotação do dólar: ");
            pTax = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.Write("Quantos dolares você vai comprar: ");
            dolares = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            totalEmReais = ConversorDeMoeda.Converter(dolares, pTax);

            Console.Write("Valor a ser pago: R$ " + totalEmReais.ToString("F2", CultureInfo.InvariantCulture));
        }
        static void TesteAluno()
        {
            Aluno a1 = new Aluno();

            Console.WriteLine("Insira os dados do Aluno: ");
            Console.Write("Nome: ");
            a1.Nome = Console.ReadLine();

            Console.Write("Nota 1: ");
            a1.Nota1 = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.Write("Nota 2: ");
            a1.Nota2 = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.Write("Nota 3: ");
            a1.Nota3 = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            a1.VerificarAprovacao();
        }
        static void TesteFuncionario()
        {
            Funcionario f = new Funcionario();

            Console.WriteLine("Entre os dados do Funcionário: ");
            Console.Write("Nome: ");
            f.Nome = Console.ReadLine();

            Console.Write("Salário Bruto: ");
            f.SalarioBruto = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.Write("Imposto: ");
            f.Imposto = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine("Dados do Funcionário: " + f);

            Console.WriteLine("Digite a porcentagem para aumentar o salário: ");
            f.AumentarSalario(double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture));

            Console.WriteLine("Dados atualizados: " + f);

        }
        static void TesteProduto()
        {
            Produto p2 = new Produto("Construtor 2", 10.0);

            p2.Nome = "T";

            Console.WriteLine(p2.Nome);
            Console.WriteLine(p2.Preco);

            /*
            string nome;
            double preco;
            int quantidade;

            Console.WriteLine("Entre os dados do produto:");
            Console.Write("Nome: ");
            nome = Console.ReadLine();
            Console.Write("Preço: ");
            preco = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Quantidade no estoque: ");
            quantidade = int.Parse(Console.ReadLine());

            Produto p = new Produto(nome, preco, quantidade);

            Console.WriteLine("Dados do produto: " + p);

            Console.WriteLine();
            Console.Write("Digite o número de produtos a serem adicionados: ");
            p.AdicionarProdutos(int.Parse(Console.ReadLine()));
            Console.WriteLine("\nDados atualizados: " + p);

            Console.WriteLine();
            Console.Write("Digite o número de produtos a serem removidos: ");
            p.RemoverProdutos(int.Parse(Console.ReadLine()));
            Console.WriteLine("\nDados atualizados: " + p);
            */
        }
        static void TesteOO()
        {
            Funcionario f1 = new Funcionario();

            Console.WriteLine("Insira o nome do PRIMEIRO funcionário");
            f1.Nome = Console.ReadLine();
            Console.WriteLine("Insira o salário do PRIMEIRO funcionário");
            f1.SalarioBruto = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Funcionario f2 = new Funcionario();

            Console.WriteLine("Insira o nome do SEGUNDO funcionário");
            f2.Nome = Console.ReadLine();
            Console.WriteLine("Insira o salário do SEGUNDO funcionário");
            f2.SalarioBruto = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine("Dados do primeiro funcionário");
            Console.WriteLine("Nome: " + f1.Nome);
            Console.WriteLine("Salário: " + f1.SalarioBruto);

            Console.WriteLine("Dados do segundo funcionário");
            Console.WriteLine("Nome: " + f2.Nome);
            Console.WriteLine("Salário: " + f2.SalarioBruto);

            Console.WriteLine("Salário médio: " + (f2.SalarioBruto + f1.SalarioBruto) / 2);
        }
        static void Revisao()
        {
            #region Inicio
            //for (int i = 0; i < 10; i++)
            //    if (i % 2 == 0)
            //        Console.WriteLine("Hello World!" + i);
            //Produto produto = new Produto();
            //produto.Codigo = "A100";
            //produto.Descricao = "Arma de Fogo";
            //produto.Vl_unit = 10.2562f;
            //Console.WriteLine(produto.Codigo);
            //Console.WriteLine(produto.Descricao);
            //Console.WriteLine(produto.Vl_unit);
            //SByte x = 100;
            //float n4 = 4.5565f;
            //double n5 = 4.51156;
            //Console.WriteLine(x);
            //Console.WriteLine(n4);
            //Console.WriteLine(n5);
            #endregion
            #region Saida de dados
            //Console.WriteLine(n5.ToString("F2", CultureInfo.InvariantCulture)); //Delimitando o número de casas no Double
            //Console.WriteLine(n4.ToString("F2")); //Delimitando o número de casas no Float

            //Console.WriteLine("O produto {0}-{1} custa {2:F2} reais", produto.Codigo, produto.Descricao, produto.Vl_unit); //place holder
            //Console.WriteLine($"O produto {produto.Codigo}-{produto.Descricao} custa {produto.Vl_unit:F} reais"); //interporlação (v6> do C#)
            //Console.WriteLine("O produto " + produto.Codigo + "-" + produto.Descricao + " custa " + produto.Vl_unit.ToString("F2", CultureInfo.InvariantCulture) + " reais"); //Concatenando


            //double a = 1.0, b = -3.0, c = -4.0;
            //double delta = Math.Pow(b, 2.0) - 4.0 * a * c;
            //double x1 = (-b + Math.Sqrt(delta)) / (2.0 * a);
            //double x2 = (-b - Math.Sqrt(delta)) / (2.0 * a);
            //Console.WriteLine(delta);
            //Console.WriteLine(x1);
            //Console.WriteLine(x2);
            //x++;
            //++x;
            #endregion
            #region EntradaDeDados
            //Console.WriteLine("Insira um valor ai pra teste");
            //string teste = Console.ReadLine();
            //Console.WriteLine($"O valor de teste inserido foi {teste}");
            //Console.WriteLine("Insira três valores separados por virgulas");
            //string[] vet = Console.ReadLine().Split(',');
            //string a1 = vet[0];
            //string a2 = vet[1];
            //string a3 = vet[2];
            //Console.WriteLine($"Os valores inseridos foram: {a1}, {a2} e {a3}");
            #endregion
            #region Entrada De Dados 2
            Console.WriteLine("Entre com seu nome completo");
            string nome = Console.ReadLine();
            Console.WriteLine("Quantos quartos tem na sua casa?");
            int quartos = int.Parse(Console.ReadLine());
            Console.WriteLine("Entre com o preço de um produto");
            double preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Entre seu último nome, idade e altura (mesma linha)");
            String[] dados = Console.ReadLine().Split(' ');
            Console.WriteLine(nome);
            Console.WriteLine(quartos);
            Console.WriteLine(preco.ToString("F2"));
            Console.WriteLine(dados[0]);
            Console.WriteLine(dados[1]);
            Console.WriteLine(dados[2], CultureInfo.InvariantCulture);
            #endregion
        }
    }
}
