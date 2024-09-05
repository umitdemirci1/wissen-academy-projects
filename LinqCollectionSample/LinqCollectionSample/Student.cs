using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqCollectionSample
{
    public class Student
    {
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public IList<Student> GetStudentList()
        {
            IList<Student> students = new List<Student>()
            {
                new Student()
                {
                   StudentID = 1,
                   FirstName = "Zed",
                    LastName = "Doe",
                    Age = 23
                },
                new Student()
                {
                   StudentID = 2,
                   FirstName = "Jane",
                    LastName = "Doe",
                    Age = 27
                },
                new Student()
                {
                   StudentID = 3,
                   FirstName = "Markus",
                    LastName = "Doe",
                    Age = 21
                },
                new Student()
                {
                   StudentID = 4,
                   FirstName = "Sarah",
                    LastName = "Jackson",
                    Age = 23
                }
            };
            return students;
        }
    }
}
