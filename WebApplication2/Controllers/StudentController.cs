using Microsoft.AspNetCore.Mvc;
using University.BLogic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FirstWebApplication.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private string connectionString;
        private readonly IConfiguration _configuration;
        StudentManager studentManager = new StudentManager();

        public StudentController(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("SqlDbConnectionString");
        }

        // GET Students
        [HttpGet]
        public string Get()
        {
            return studentManager.GetStudents(connectionString);
        }

        // ADD new Student
        [HttpPost]
        public void Post(int Id, string FullName, DateTime DateOfBirth, int FacultyId, decimal Tuiton, decimal AvgGrades)
        {
            studentManager.AddStudent(connectionString, Id, FullName, DateOfBirth, FacultyId, Tuiton, AvgGrades);
        }

        // UPDATE Student (tuition, avg)
        [HttpPut]
        public void Put(string nome, decimal tuition, decimal avg)
        {
            studentManager.UpdateStudent(connectionString, nome, tuition, avg);
        }

        // DELETE Student with Id
        [HttpDelete]
        public void Delete(int Id)
        {
            studentManager.DeleteStudent(connectionString, Id);
        }
    }
}


