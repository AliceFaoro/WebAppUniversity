using Microsoft.AspNetCore.Mvc;
using University.BLogic;

namespace FirstWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private string connectionString;
        private readonly IConfiguration _configuration;
        CourseManager courseManager = new();

        public CourseController(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("SqlDbConnectionString");
        }

        // GET Courses
        [HttpGet]
        public string Get()
        {
            return courseManager.GetCourses(connectionString);
        }

        // ADD new Course
        [HttpPost]
        public void Post(int id, string name, int fId, int pId)
        {
            courseManager.AddCourse(connectionString, id, name, fId, pId);
        }

        // UPDATE Course (professor)
        [HttpPut]
        public void Put(string name, string professorId)
        {
            courseManager.UpdateCourse(connectionString, name, professorId);
        }

        // DELETE Corse with Id
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            courseManager.DeleteCourse(connectionString, id);
        }
    }
}
