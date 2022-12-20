using Aula6.Utils;
using System.Formats.Asn1;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;

namespace Aula6
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
            };

            using var reader = new StreamReader(@"C:\Users\paulo\Desktop\entrada.txt");
            using var csv = new CsvParser(reader, config);

            if (!csv.Read())
                return;

            var numColunas = csv.Record.Length;
            var cities = new int[numColunas, numColunas];

            for (int i = 0; i < numColunas; i++)
            {
                var linha = csv.Record;

                for (int j = 0; j < numColunas; j++)
                {
                    cities[i, j] = int.Parse(linha[j]);
                }

                csv.Read();
            }

            PrintMatriz(cities);
        }

        private static void PrintMatriz(int[,] cities)
        {
            var strBuilder = new StringBuilder();

            for (int i = 0; i < cities.GetLength(0); i++)
            {
                for (int j = 0; j < cities.GetLength(0); j++)
                {
                    strBuilder.Append($"{cities[i, j]} ");
                }

                strBuilder.AppendLine();
            }

            Console.WriteLine(strBuilder.ToString());
        }
    }
}