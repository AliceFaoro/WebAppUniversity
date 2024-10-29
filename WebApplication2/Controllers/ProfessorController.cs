using Microsoft.AspNetCore.Mvc;
using University.BLogic;
using University.DataModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FirstWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private string connectionString;
        private readonly IConfiguration _configuration;
        ProfessorManager professorManager = new();

        public ProfessorController(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("SqlDbConnectionString");
        }

        // GET Professors
        [HttpGet]
        public string Get()
        {
            return professorManager.GetProfessors(connectionString);
        }

        // ADD new Professor
        [HttpPost]
        public void Post(int id, string name, DateTime date, int facultyId, decimal pay)
        {
            professorManager.AddProfessor(connectionString, id, name, date, facultyId, pay);
        }

        // UPDATE Professor (faculty, pay)
        [HttpPut]
        public void Put(string nome, int facultyId, decimal pay)
        {
            professorManager.UpdateProfessor(connectionString, nome, facultyId, pay );
        }

        // DELETE Professor with Id
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            professorManager.DeleteProfessor(connectionString, id);
        }
    }
}
