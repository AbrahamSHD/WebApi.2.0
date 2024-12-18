using SchoolsWebApi.Models;
using SchoolsWebApi.Repositories;

namespace SchoolsWebApi.Services
{
    public class SchoolService
    {
        private readonly SchoolRepository _repository;

        public SchoolService(SchoolRepository repository)
        {
            _repository = repository;
        }

        public List<School> GetSchools() => _repository.GetAll();

        public School GetSchoolByName(string name) => _repository.GetByName(name);
    }
}
