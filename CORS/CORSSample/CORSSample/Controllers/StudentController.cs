using CORSSample.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CORSSample.Controllers
{
    [Route("api/[controller]")]
    //[EnableCors("ClientDomains")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        List<Student> studentList = new List<Student>()
        {
            new Student()
            {
                StudentNumber = "10001",
                FirstName = "John",
                LastName="Doe",
                Address = "USA",
                Phone = "1265494984"
            },
            new Student()
            {
                StudentNumber = "10002",
                FirstName = "Jeyn",
                LastName="Doe",
                Address = "USA",
                Phone = "97446456"
            },
            new Student()
            {
                StudentNumber = "10003",
                FirstName = "Tom",
                LastName="Doe",
                Address = "USA",
                Phone = "87984696549"
            },
            new Student()
            {
                StudentNumber = "10004",
                FirstName = "Poul",
                LastName="Doe",
                Address = "USA",
                Phone = "8985556256"
            }
        };

        [HttpGet]
        [Route("GetAllStudents")]
        //[DisableCors]
        public IEnumerable<Student> GetAllStudents()
        {
            return studentList;
        }

        [HttpPost]
        [Route("GetStudentByNumber")]
        public IActionResult GetStudentByQueryParams([FromBody]QueryParams query)
        {
            Student student = studentList.FirstOrDefault(x => x.StudentNumber == query.StudentNumber);
            return Ok(student);

        }
    }
}
