using System;
using System.IO;
using CsvParser.Helpers;
using CsvParser.Windsor;

namespace CsvParser
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length != 3)
            {
                Console.WriteLine("Three arguments are required");
                return;
            }

            var filePath = args[0];

            if (!File.Exists(filePath))
            {
                Console.WriteLine($"The path specified for the file '{filePath}' is not valid");
                return;
            }

            if (!int.TryParse(args[1], out var columnToSearch) || columnToSearch < 0 || columnToSearch > 3)
            {
                Console.WriteLine("The column number must be an integer between 0 and 3");
                return;
            }

            var keyword = args[2];

            var container = new DependecyResolver().GetContainer();
            var myCsvHelper = container.Resolve<IMyCsvHelper>();

            var records = myCsvHelper.Read(filePath);
            var record = myCsvHelper.Filter(records, columnToSearch, keyword);

            if (record == null)
            {
                Console.WriteLine("No item found");
                return;
            }

            var output = string.Join(",", record.ItemArray);

            Console.WriteLine(output);
        }
    }
}
