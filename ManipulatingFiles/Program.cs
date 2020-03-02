using System;
using System.IO;
using System.Collections.Generic;
using ManipulatingFiles.Entities;
using System.Globalization;

namespace ManipulatingFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"c:\temp\sales.csv";
            string OutPath = Path.GetDirectoryName(path) + @"\out\";
            List<Product> products = new List<Product>();

            try
            {
                using StreamReader sr = File.OpenText(path);
                while (!sr.EndOfStream)
                {
                    string[] lineParts = sr.ReadLine().Split(';');

                    string name = lineParts[0];
                    double price = double.Parse(lineParts[1], CultureInfo.InvariantCulture);
                    int quantity = int.Parse(lineParts[2]);

                    products.Add(new Product(name, price, quantity));
                }

                //Criando a pasta de saída
                Directory.CreateDirectory(OutPath);

                using StreamWriter sw = File.AppendText(OutPath + "summary.csv");

                foreach (Product product in products)
                {
                    sw.Write(product.Name);
                    sw.Write(';');
                    sw.WriteLine(product.Subtotal().ToString("F2", CultureInfo.InvariantCulture));
                }

            }
            catch (IOException e)   
            {
                Console.WriteLine("An error occurred!");
                Console.WriteLine(e.Message);
            }
        }

        static void Ex()
        {
            Console.Write("Enter file full path: ");
            string sourceFilePath = Console.ReadLine();

            try
            {
                string[] lines = File.ReadAllLines(sourceFilePath);

                string sourceFolderPath = Path.GetDirectoryName(sourceFilePath);
                string targetFolderPath = sourceFolderPath + @"\out";
                string targetFilePath = targetFolderPath + @"\summary.csv";

                Directory.CreateDirectory(targetFolderPath);

                using (StreamWriter sw = File.AppendText(targetFilePath))
                {
                    foreach (string line in lines)
                    {

                        string[] fields = line.Split(',');
                        string name = fields[0];
                        double price = double.Parse(fields[1], CultureInfo.InvariantCulture);
                        int quantity = int.Parse(fields[2]);

                        Product prod = new Product(name, price, quantity);

                        sw.WriteLine(prod.Name + "," + prod.Subtotal().ToString("F2", CultureInfo.InvariantCulture));
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred");
                Console.WriteLine(e.Message);
            }
        }

        static void DirectoryAndDirectoryInfoTest()
        {
            string sourcePath = @"C:\temp";
            string path = @"C:\temp\file1.txt";

            DirectoryInfo directoryInfo = new DirectoryInfo(sourcePath);

            try
            {
                //Usando tipagem de variável
                IEnumerable<DirectoryInfo> folders2 = directoryInfo.EnumerateDirectories("*.*", SearchOption.AllDirectories);
                Console.WriteLine("FOLDERS:");

                foreach (DirectoryInfo item in folders2)
                {
                    Console.WriteLine(item);
                }

                //usando var
                var files = Directory.EnumerateFiles(sourcePath, "*.*", SearchOption.AllDirectories);
                Console.WriteLine("FILES:");

                foreach (string item in files)
                {
                    Console.WriteLine(item);
                }

                //Directory.CreateDirectory(sourcePath + @"\newforder4");


                Console.WriteLine("GetFileName: " + Path.GetFileName(path));
                Console.WriteLine("GetExtension: " + Path.GetExtension(path));
                Console.WriteLine("GetFileNameWithoutExtension: " + Path.GetFileNameWithoutExtension(path));
                Console.WriteLine("GetFullPath: " + Path.GetFullPath(path));
                Console.WriteLine("GetTempPath: " + Path.GetTempPath());
                Console.WriteLine("GetTempFileName: " + Path.GetTempFileName());
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred!");
                Console.WriteLine(e.Message);

            }
        }

        static void FileWriterTest()
        {
            string sourcePath = @"C:\temp\file1.txt";
            string targetPath = @"C:\temp\file2.txt";

            try
            {
                string[] lines = File.ReadAllLines(sourcePath);

                using StreamWriter sw = File.AppendText(targetPath);
                foreach (var item in lines)
                {
                    sw.WriteLine(item.ToUpper());
                }

                Console.WriteLine("Copy ok!");
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred!");
                Console.WriteLine(e.Message);

            }
        }

        static void ResumedFileStreamAndStreamReaderTest()
        {
            string sourcePath = @"C:\temp\file1.txt";

            try
            {
                using StreamReader sr = File.OpenText(sourcePath);
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    Console.WriteLine(line);

                }
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred!");
                Console.WriteLine(e.Message);
            }
        }

        static void FileStreamAndStreamReaderTest()
        {
            string sourcePath = @"C:\temp\file1.txt";
            FileStream fs = null;
            StreamReader sr = null;

            try
            {
                //fs = new FileStream(sourcePath, FileMode.Open);
                //sr = new StreamReader(fs);

                sr = File.OpenText(sourcePath);
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    Console.WriteLine(line);

                }
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred!");
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (sr != null) sr.Close();
                if (fs != null) fs.Close();
            }
        }

        static void FileAndFileInfoTest()
        {
            string sourcePath = @"C:\temp\file1.txt";
            string targetPath = @"C:\temp\file2.txt";

            try
            {
                FileInfo fileInfo = new FileInfo(sourcePath);
                fileInfo.CopyTo(targetPath);

                string[] lines = File.ReadAllLines(sourcePath);
                foreach (var item in lines)
                {
                    Console.WriteLine(item);
                }


                Console.WriteLine("Copy ok!");

            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred!");
                Console.WriteLine(e.Message);

            }
        }
    }
}
