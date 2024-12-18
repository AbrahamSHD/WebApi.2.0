using OfficeOpenXml;
using SchoolsWebApi.Models;
using System.IO;
using System.Linq;

namespace SchoolsWebApi.Data
{
    public class ExcelDataReader
    {
        private readonly string _filePath;

        public ExcelDataReader(string filePath)
        {
            _filePath = filePath;
        }

        public List<School> ReadSchools()
        {
            var schools = new List<School>();

            using var package = new ExcelPackage(new FileInfo(_filePath));
            var worksheet = package.Workbook.Worksheets[0];

            // Iterar sobre las filas del Excel
            for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
            {
                var schoolName = worksheet.Cells[row, 1].Text.Trim();
                var studentAdvisor = worksheet.Cells[row, 2].Text.Trim();
                var meetingDate = worksheet.Cells[row, 3].Text.Trim();

                // Validar que schoolName no sea nulo ni vacío
                if (string.IsNullOrWhiteSpace(schoolName))
                {
                    // Si el nombre de la escuela es vacío o nulo, continuar con la siguiente fila
                    continue;
                }

                // Buscar si el plantel ya existe
                var school = schools.FirstOrDefault(s => s.Name == schoolName);
                if (school == null)
                {
                    // Crear un nuevo objeto School solo si schoolName es válido
                    school = new School { Name = schoolName };
                    schools.Add(school);
                }

                // Agregar alumno consejero si existe
                if (!string.IsNullOrWhiteSpace(studentAdvisor))
                {
                    school.StudentAdvisors.Add(new StudentAdvisor { Name = studentAdvisor });
                }

                // Agregar reunión si la fecha es válida
                if (DateTime.TryParse(meetingDate, out var date))
                {
                    school.Meetings.Add(new Meeting { Date = date });
                }
            }

            return schools;
        }
    }
}
