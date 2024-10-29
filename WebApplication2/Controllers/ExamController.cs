using Microsoft.AspNetCore.Mvc;
using University.BLogic;

namespace FirstWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private string connectionString;
        private readonly IConfiguration _configuration;
        ExamManager examManager = new();

        public ExamController(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("SqlDbConnectionString");
        }

        //GET Exams
        [HttpGet]
        public string Get()
        {
            return examManager.GetExams(connectionString);
        }


        // ADD new Exam
        [HttpPost]
        public void Post(int id, int facultyId, int courseId, int professorId, DateTime date)
        {
            examManager.AddExam(connectionString, id, facultyId, courseId, professorId, date);
        }

        // UPDATE Exam (professor and date)
        [HttpPut]
        public void Put(int examId, int  professorId, DateTime date)
        {
            examManager.UpdateExam(connectionString, examId, professorId, date);
        }

        // DELETE Exam with Id 
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            examManager.DeleteExam(connectionString, id);
        }
    }
}
