using Microsoft.AspNetCore.Mvc;
using University.BLogic;
using University.DataModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FirstWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultyController : ControllerBase
    {
        private string connectionString;
        private readonly IConfiguration _configuration;
        FacultyManager facultyManager = new();

        public FacultyController(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("SqlDbConnectionString");
        }

        // GET Faculties
        [HttpGet]
        public string Get()
        {
           return facultyManager.GetFaculties(connectionString);
        }

        // ADD new Faculty
        [HttpPost]
        public void Post(int Id, string FullName)
        {
            facultyManager.AddFaculty(connectionString ,Id, FullName);
        }

        // UPDATE Faculty (name)
        [HttpPut]
        public void Put(string name, string newName)
        {
            facultyManager.UpdateFaculty(connectionString, name, newName);
        }

        // DELETE Faculty with Id
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            facultyManager.DeleteFaculty(connectionString, id);
        }
    }
}
