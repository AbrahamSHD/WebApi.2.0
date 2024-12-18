using SchoolsWebApi.Data;
using SchoolsWebApi.Models;

namespace SchoolsWebApi.Repositories
{
    public class SchoolRepository
    {
        private readonly List<School> _schools;

        public SchoolRepository(ExcelDataReader excelReader)
        {
            _schools = excelReader.ReadSchools();
        }

        public List<School> GetAll() => _schools;

        public School GetByName(string name) => 
            _schools.FirstOrDefault(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }
}
