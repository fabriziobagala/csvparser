using CsvHelper.Configuration;
using CsvParser.Models;

namespace CsvParser.Mapping
{
    public sealed class PersonalDetailsMap : ClassMap<PersonalDetails>
    {
        public PersonalDetailsMap()
        {
            Map(m => m.Id).Index(0);
            Map(m => m.Name).Index(1);
            Map(m => m.Surname).Index(2);
            Map(m => m.BirthDate).Index(3);
        }
    }
}
