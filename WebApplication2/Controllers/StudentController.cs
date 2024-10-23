using Microsoft.AspNetCore.Mvc;
using University.BLogic;
using University.DataModel;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private string connectionString;
        private readonly IConfiguration _configuration;
        StudentManager studentManager = new StudentManager();

        // Iniezione della configurazione nel costruttore
        public StudentController(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("SqlDbConnectionString");
        }

        // GET: api/<UniversityController>
        [HttpGet]
        public List<Student> Get()
        {
            var students = studentManager.GetStudents(connectionString);
            return students;
        }

        // POST api/<UniversityController>
        [HttpPost]
        public void Post()
        {
            studentManager.AddStudent(connectionString);
        }

        // PUT api/<UniversityController>/5
        [HttpPut]
        public void Put()
        {
            studentManager.UpdateStudent(connectionString);
        }

        // DELETE api/<UniversityController>/5
        [HttpDelete]
        public void Delete()
        {
            studentManager.DeleteStudent(connectionString);
        }
    }
}
