using System.Collections.Generic;
using System.Data;

namespace CsvParser.Helpers
{
    public interface IMyCsvHelper
    {
        IEnumerable<DataRow> Read(string filePath);
        DataRow Filter(IEnumerable<DataRow> records, int columnToSearch, string keyword);
    }
}
