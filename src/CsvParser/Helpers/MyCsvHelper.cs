using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvParser.Mapping;

namespace CsvParser.Helpers
{
    public class MyCsvHelper : IMyCsvHelper
    {
        public IEnumerable<DataRow> Read(string filePath)
        {
            try
            {
                var streamReader = new StreamReader(filePath);
                var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture);

                csvReader.Configuration.HasHeaderRecord = false;
                csvReader.Configuration.Delimiter = ",";
                csvReader.Configuration.RegisterClassMap<PersonalDetailsMap>();

                var dataTable = new DataTable();

                dataTable.Columns.Add("Id", typeof(int));
                dataTable.Columns.Add("Surname", typeof(string));
                dataTable.Columns.Add("Name", typeof(string));
                dataTable.Columns.Add("BirthDate", typeof(string));

                while (csvReader.Read())
                {
                    var row = dataTable.NewRow();
                    var i = 0;

                    foreach (DataColumn column in dataTable.Columns)
                    {
                        row[column.ColumnName] = csvReader.GetField(i++);
                    }

                    dataTable.Rows.Add(row);
                }

                return dataTable.Rows.Cast<DataRow>();
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occured: {e.Message}");

                return Enumerable.Empty<DataRow>();
            }
        }

        public DataRow Filter(IEnumerable<DataRow> records, int columnToSearch, string keyword)
        {
            try
            {
                return records?.FirstOrDefault(x => string.Equals(
                    x[columnToSearch].ToString(), keyword, StringComparison.InvariantCultureIgnoreCase));
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occured: {e.Message}");

                return null;
            }
        }
    }
}
