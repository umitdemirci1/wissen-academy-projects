

using LinqApp;
#region Personel
string[] dersler = { "Matematik", "Türkçe", "Fen Bilgisi", "Beden Eğitimi", "Müzik", "Tarih" };
//var derslerList = from ders in dersler
//                  select ders;

//Console.WriteLine(string.Join('-', derslerList));

//var dersList2 = from d in dersler
//                where d.Contains("çe")
//                select d;
//Console.WriteLine(string.Join(',', dersList2));

//var dersList3 = from ders in dersler
//                orderby ders descending
//                select ders;

//foreach (var d in dersList3) Console.WriteLine(d);

//var dersList4 = dersler.Take(3);

//var dersList = dersler.TakeLast(3);

List<Personel> personelList = new List<Personel>()
{
    new Personel
    {
        ID = 1,
        FirstName = "John",
        LastName = "Doe",
        Salary = 25000
    },
    new Personel
    {
        ID = 2,
        FirstName = "Jeyn",
        LastName = "Doe",
        Salary = 30000
    },
    new Personel
    {
        ID = 3,
        FirstName = "Tom",
        LastName = "Doe",
        Salary = 28000
    },
    new Personel
    {
        ID = 4,
        FirstName = "Philip",
        LastName = "Doe",
        Salary = 18000
    },
    new Personel
    {
        ID = 5,
        FirstName = "Hans",
        LastName = "Doe",
        Salary = 60000
    }
};

//var personeller = from p in personelList
//                  where p.Salary >= 30000
//                  orderby p.Salary descending
//                  select p;

//foreach (var p in personeller) Console.WriteLine(p.Salary);

//var personeller = personelList.Where(x => x.Salary >= 30000).OrderByDescending(x => x.Salary);

//Adı ve Soyadında o harfi geçen personeller

//var personeller = personelList.Where(x => x.FirstName.Contains('o') || x.LastName.Contains('o')).OrderByDescending(x=>x.Salary);

////var personeller = from p in personelList
////                  where p.FirstName.Contains('h') || p.LastName.Contains('h')
////                  orderby p.Salary descending
////                  select p;

//foreach (var p in personeller)
//{
//    Console.WriteLine(
//        $"PersonelID : {p.ID}\n" +
//        $"Personel Adı : {p.FirstName} {p.LastName}\n" +
//        $"Personel Maaş : {p.Salary}\n"
//    );
//    Console.WriteLine(new string('*', 100));
//}
#endregion

IList<Student> studentsList = new List<Student>()
{
    new Student { StudentID = 1, Name = "John Doe", Age = 22 },
    new Student { StudentID = 2, Name = "Jeyn Doe", Age = 25 },
    new Student { StudentID = 3, Name = "Tom Doe", Age = 20 },
    new Student { StudentID = 4, Name = "Bill Doe", Age = 18 },
    new Student { StudentID = 5, Name = "Bob Doe", Age = 27 },
};

//Tüm öğrenciler
//Query Syntax
//var students = from student in studentsList
//               select student;
//foreach (var student in students) Console.WriteLine($"Student ID : {student.StudentID} - Name : {student.Name} - Age : {student.Age}");

////Method Syntax
//var students2 = studentsList.ToList();

////Belirli property - kolonları almak için. StudentID ve Name alanları listelensin
////Query Syntax
//var students3 = from student in studentsList
//                select new
//                {
//                    student.StudentID,
//                    student.Name,
//                };

//Method Syntax
//var students4 = studentsList.Select(x => new { x.StudentID, x.Name });
//foreach (var student in students4) Console.WriteLine($"Student ID : {student.StudentID} - Name : {student.Name}");
