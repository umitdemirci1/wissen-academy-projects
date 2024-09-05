


#region LINQ SORT
#region Order By kullanımı

using LinqCollectionSample;
//using System.Text;

//Student student = new Student();
//var students = student.GetStudentList();

//Query Syntax
//var result = from _student in students
//             orderby _student.FirstName, _student.Age descending
//             select _student;

////Method Syntax
//var result2 = students.OrderBy(x => x.FirstName).ThenByDescending(y => y.Age);

//foreach (var item in result2)
//{
//    Console.WriteLine($"Ad : {item.FirstName} - Soyad : {item.LastName} - Yaş: {item.Age}");
//}
#endregion

#region Then By kullanımı
//string[] sehirler = new string[] { "Ankara", "İzmir", "Bursa", "Mardin", "Hatay", "Edirne" };

////Method Syntax
//var result = sehirler.OrderBy(x => x.Length).ThenBy(x => x);

////Query Syntax
//var result2 = from _sehir in sehirler
//              orderby _sehir.Length, _sehir
//              select _sehir;

//foreach (var item in result2)
//{
//    Console.WriteLine(item);
//}
#endregion

#region OrderByDescending
//int[] numbers = [1, 5, 2, 9, 12, 6, 7, 10, 3];

////Method Syntax
//var result = numbers.OrderByDescending(x => x);

////Query Syntax
//var result2 = from num in numbers
//              orderby num descending
//              select num;
//foreach (int x in result2)
//{
//    Console.WriteLine(x);
//}
#endregion

#region ThenByDesc
//string[] sehirler = { "İstanbul", "Ankara", "İzmir", "Bursa", "Mardin", "Hatay", "Edirne" };

////Method Syntax
//var result = sehirler.OrderBy(x => x.Length).ThenByDescending(x => x);

////Query Syntax
//var result2 = from sehir in sehirler
//              orderby sehir.Length, sehir descending
//              select sehir;

//foreach (var item in result2)
//{
//    Console.WriteLine(item);
//}
#endregion

#region Reverse kullanımı
//int[] numbers = [1, 5, 2, 9, 12, 6, 7, 10, 3];

//var result = numbers.Reverse();

//foreach (var number in result)
//{
//    Console.WriteLine(number);
//}
#endregion
#endregion

#region Quantifiers
#region Contains
//int[] numbers = [1, 5, 2, 9, 12, 6, 7, 10, 3];

//var result1 = numbers.Contains(12);
//var result2 = numbers.Contains(13);
#endregion

#region Any
//int[] numbers = [1, 5, 2, 9, 12, 6, 7, 10, 3];

//var result1 = numbers.Any();
//var result2 = numbers.Any(x => x == 9);
//var result3 = numbers.Any(x => x == 7 && x == 3);

//Console.WriteLine(result1);
//Console.WriteLine(result2);
//Console.WriteLine(result3);
#endregion

#region All
//string[] languages = { "French", "English", "Russian", "Chinese" };

//var result1 = languages.All(x => x == "French");
//var result2 = languages.All(x => x.StartsWith("R"));
//var result3 = languages.All(x => x.Contains("n"));

//Console.WriteLine(result1);
//Console.WriteLine(result2);
//Console.WriteLine(result3);
#endregion
#endregion

#region Aggregations
#region Count(dönüş tipi int), LongCount(Dönüş tipi int64-long)
//var monthList = new List<string>
//{
//    "Ocak", "Şubat", "Mart", "Nisan", "Mayıs", "Haziran", "Temmuz", "Ağustos", "Eylül", "Ekim", "Kasım", "Aralık"
//};

//var result = monthList.Count();
//var result2 = monthList.LongCount();

//Console.WriteLine($"{result} - {result.GetType()}");
//Console.WriteLine($"{result2} - {result2.GetType()}");
#endregion

#region Sum
//using LinqCollectionSample;

//int[] numbers = { 1, 5, 6, 8, 10 };

//var result1 = numbers.Sum(x => x);
//var result2 = numbers.Sum();

//Console.WriteLine(result2);
//Console.WriteLine(result1);

//Student student = new Student();
//var students = student.GetStudentList();

//var result1 = students.Where(x => x.LastName == "Doe").Sum(x => x.Age);
//var result2 = students.Sum(x => x.Age);

//Console.WriteLine(result1);
//Console.WriteLine(result2);
#endregion

#region Max, Min, Average

//int[] numbers = { 1, 5, 8, 9, 10, 45, 100, 34 };

//var result1 = numbers.Max();
//var result2 = numbers.Min();
//var result3 = numbers.Average();

//var result4 = numbers.Where(x=>x >=8).Max();
//var result5 = numbers.Where(x => x >= 30).Min();

//var result6 = numbers.Max(x => x >= 8);
//var result7 = numbers.Min(x => x >= 30);

//Console.WriteLine(result1);
//Console.WriteLine(result2);
//Console.WriteLine(result3);
//Console.WriteLine(result4);
//Console.WriteLine(result5);
//Console.WriteLine(result6);
//Console.WriteLine(result7);
#endregion
#endregion

#region Filters

#region Where kullanımı
//Product product = new Product();
//var products = product.GetAllProducts();

////Query Syntax
////var result1 = from _product in products
////              where _product.CategoryName == "Meyve"
////              select _product;

////var result1 = from _product in products
////              where _product.CategoryName == "Meyve" && _product.Price > 50
////              select _product;

////Method Syntax
//var result = products.Where(x => x.CategoryName == "Meyve" && x.Price > 50);

//foreach (var item in result)
//{
//    Console.WriteLine($"Ürün Adı : {item.ProductName} - Ürün Fiyatı : {item.Price}");
//}
#endregion

#region OffType
//object[] values = { "Ankara", "Bursa", 5, 7, "Çankırı", 4.80, true, 2, false, DateTime.Now };

//var resultInt = values.OfType<int>();
//foreach (var item in resultInt) Console.WriteLine($"{item} * {item.GetType}");
//Console.WriteLine(new string('-', 100));
//var resultString = values.OfType<string>();
//foreach (var item in resultString) Console.WriteLine($"{item} * {item.GetType}");
//Console.WriteLine(new string('-', 100));
//var resultBoolean = values.OfType<bool>();
//foreach (var item in resultBoolean) Console.WriteLine($"{item} * {item.GetType}");
//Console.WriteLine(new string('-', 100));
//var resultDouble = values.OfType<double>();
//foreach (var item in resultDouble) Console.WriteLine($"{item} * {item.GetType}");
//Console.WriteLine(new string('-', 100));
//var resultDateTime = values.OfType<DateTime>();
//foreach (var item in resultDateTime) Console.WriteLine($"{item} * {item.GetType}");
#endregion
#endregion

#region Grouping
#region GroupBy
//int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
//var result = numbers.GroupBy(x => x % 2 == 0);

//foreach (var item in result)
//{
//    Console.WriteLine(string.Join("-", item));
//}
#endregion

#region LookUp
//var monthList = new List<string>()
//{ "Ocak", "Şubat", "Mart", "Nisan", "Mayıs", "Haziran", "Temmuz", "Ağustos", "Eylül", "Ekim", "Kasım", "Aralık" };

////aynı karakter sayısındaki değerleri grupluyor.
//var result = monthList.ToLookup(x => x.Length);
//foreach (var item in result) Console.WriteLine(string.Join("-", item));
#endregion
#endregion

#region Get Elements

#region First ve Last, ElementAt

////Herhangi bir item yok ise First ve Last metotları hata üretip programın çalışmasını durdurur.
//string[] names = { "John", "Jeyn", "Tom", "Paul", "David" };
//var resultFirst = names.First();
//var resultLast = names.Last();

////out of exception hatası verebilir, dikkat edilmeli.
//var resultElementAt = names.ElementAt(3);

//Console.WriteLine(resultFirst);
//Console.WriteLine(resultLast);
//Console.WriteLine(resultElementAt);
#endregion

#region FirstOrDefault, LastOrDefault
//string[] countries = { "Turkey", "India", "England", "USA" };
//string[] emptyCollection = { };

//var result1 = countries.FirstOrDefault();
//var result2 = countries.LastOrDefault();

////veritipinin default boş tipini döndürür
//var result3 = emptyCollection.FirstOrDefault();
//var result4 = emptyCollection.LastOrDefault();

//Console.WriteLine(result1);
//Console.WriteLine(result2);
//Console.WriteLine(result3);
//Console.WriteLine(result4);
#endregion

#region Single, SingleOrDefault
////Tek bir kayıt olduğundan emin olunması gerek, aksi halde hata döndürür
//int[] numbers = { 3, 6, 9, 12, 6 };
////var result = numbers.Single(x => x == 6);
////var result2 = numbers.SingleOrDefault(x => x == 6);

////Bir şey bulamadığı için default değeri döndürdü.
//var result3 = numbers.SingleOrDefault(x => x == 30);
//var result4 = numbers.Single(x => x == 30);

//var result5 = numbers.Where(x => x == 6).SingleOrDefault();
#endregion

#endregion

#region Sub Sets
#region Select
//int[] numbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
////var result1 = numbers.Select(x => x * 5);
//var result2 = numbers.Select(x => x > 5);

//var result3 = numbers.Where(x => x > 6).Select(x => x* 3);

//foreach (var i in result2) Console.WriteLine(i);
//Console.WriteLine("--------");
//foreach (var i in result3) Console.WriteLine(i);
#endregion

#region SelectMany
//Crossjoin in C# karşılığı
//string[] countries = { "Turkey", "USA", "UK", "Chinese" };
//int[] indexes = { 1, 2, 3, 4 };

//var result = countries.SelectMany
//    (x => indexes,
//    (x, i) => new { ulke = x, index = i });

//foreach (var item in result)
//{
//    Console.WriteLine($"Ülke : {item.ulke} - Index : {item.index}");
//}
#endregion
#endregion

#region Sets
#region Distinct
//string[] days = { "Pazartesi", "Salı", "Çarşamba", "Perşembe", "Salı", "Cuma", "Cumartesi", "Çarşamba", "Salı", "Pazar" };
//var result1 = days.Distinct();

//foreach (var day in result1) Console.WriteLine(day);

#endregion

#region Union
//string[] days1 = { "Pazartesi", "Perşembe", "Cumartesi", "Pazartesi" };
//string[] days2 = { "Salı", "Çarşamba", "Pazartesi", "Cuma", "Pazar", "Pazar" };

//var result = days1.Union(days2);
//foreach (var day in result) Console.WriteLine(day);
#endregion

#region Intersect
//int[] numbers = { 5, 10, 15, 20 };
//int[] numbers2 = { 15, 20, 25, 30 };

//var result = numbers.Intersect(numbers2);
//foreach (var number in result) Console.WriteLine(number);
#endregion

#region Except
//string[] values1 = { "a", "b", "c", "d" };
//string[] values2 = { "c", "d", "e", "f" };

//var result = values1.Except(values2);
//foreach (var value in result) Console.WriteLine(value);
#endregion
#endregion

#region Partitioning

#region Take, TakeWhile
int[] numbers = { 1, 5, 8, 4, 56, 47, 3, 8 };
var result = numbers.Take(5);
foreach (var number in result) Console.WriteLine(number);

//Console.WriteLine("TakeLast");
//var result4 = numbers.TakeLast(5);
//foreach (var number in result4) Console.WriteLine(number);

//int[] numbers2 = { 1, 2, 3, 4, 5, -1, -2 };
////Yalnızca doğal sayıları alıyor.
////var result2 = numbers2.TakeWhile(x => x <= 3);
////foreach (var number in result2) Console.WriteLine(number);

////Tamsayı değerlerini alır.
//var result3 = numbers2.Where(x => x <= 3);
//foreach (var number in result3) Console.WriteLine(number);
#endregion
#endregion