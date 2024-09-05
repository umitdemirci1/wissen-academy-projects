using JQuerryAJAX.Models;
using Microsoft.AspNetCore.Mvc;

namespace JQuerryAJAX.Controllers
{
    public class StudentController : Controller
    {
        List<Student> students = new List<Student>()
        {
            new Student(){StudentID=1, FirstName="Ali", LastName="Veli", StudentNumber="123", StudentClass=1},
            new Student(){StudentID=2, FirstName="Ayşe", LastName="Fatma", StudentNumber="456", StudentClass =2},
            new Student(){StudentID=3, FirstName="Mehmet", LastName="Ahmet", StudentNumber="789", StudentClass=3},
            new Student(){StudentID=4, FirstName="Zeynep", LastName="Kaya", StudentNumber="101", StudentClass=2},
            new Student(){StudentID=5, FirstName="Kemal", LastName="Kaya", StudentNumber="112", StudentClass=4}
        };
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetStudent(int id)
        {
            Student student = students.FirstOrDefault(x => x.StudentID == id);
            return Json(student);
        }


        public IActionResult GetStudents()
        {
            return View();
        }

        public JsonResult GetAllStudents()
        {
            return Json(students);
        }
    }
}
