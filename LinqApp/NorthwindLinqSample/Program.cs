using NorthwindLinqSample.Models;
using NorthwindLinqSample.NorthwindDTO;

NorthwindContext context = new NorthwindContext();

//Method Syntax
var customers = context.Customers.ToList();

//Query Syntax
var customers2 = from customer in context.Customers
                 select customer;

//Country UK veya USA olan müşteriler
var customers3 = from customer in context.Customers
                 where customer.Country == "UK" || customer.Country == "USA"
                 select customer;

////Method Syntax
//var customers4 = context.Customers.Where(x => x.Country == "UK" || x.Country == "USA");

//foreach (var customer in customers4)
//{
//    Console.WriteLine($"Customer ID : {customer.CustomerId} - Company Name : {customer.CompanyName} - Country : {customer.Country}");
//}

//Country UK veya USA olup Country e göre artan Region a göre azalan sıralama
//var customers5 = from customer in customers
//                 where customer.Country == "UK" || customer.Country == "USA" || customer.Country == "France" || customer.Country == "Mexico"
//                 orderby customer.Country, customer.Region descending
//                 select customer;

//var customers6 = context.Customers.Where(x => x.Country == "UK" || x.Country == "USA" || x.Country == "France" || x.Country == "Mexico").OrderBy(x => x.Country).ThenByDescending(x => x.Region);

//foreach (var customer in customers6)
//{
//    Console.WriteLine($"Customer ID : {customer.CustomerId} - Company Name : {customer.CompanyName} - Country : {customer.Country} " +
//        $"Region : {customer.Region}");
//}

//Country UK, USA, Mexico ve France olup Country e göre artan Region a göre azalan sıralama. Dönüş tipinde sadece CustomerID, CompanyName, Country ve Region olacak.
//Query Syntax
//var customers7 = from customer in customers
//                 where customer.Country == "UK" || customer.Country == "USA" || customer.Country == "France" || customer.Country == "Mexico"
//                 orderby customer.Country, customer.Region descending
//                 select new CustomerDTO
//                 {
//                     CustomerID = customer.CustomerId,
//                     CustomerName = customer.CompanyName,
//                     Country = customer.Country,
//                     Region = customer.Region
//                 };

//Method Syntax
//var customers8 = context.Customers.
//    Where(customer => customer.Country == "UK" || customer.Country == "USA" || customer.Country == "France" || customer.Country == "Mexico").
//    OrderBy(customer => customer.Country).
//    ThenByDescending(customer => customer.Region).
//    Select(x => new CustomerDTO
//    {
//        CustomerID = x.CustomerId,
//        CustomerName = x.ContactName,
//        Country = x.Country,
//        Region = x.Region
//    });
//foreach (var customer in customers8)
//{
//    Console.WriteLine($"Customer ID : {customer.CustomerID} - Company Name : {customer.CustomerName} - Country : {customer.Country} " +
//        $"Region : {customer.Region}");
//}
//*********************************************
//Country UK, USA, Mexico ve France olup Country e göre artan Region a göre azalan sıralama. Dönüş tipinde sadece CustomerID, CompanyName, Country ve Region olacak.
//Query Syntax
//var customers9 = from customer in customers
//                 where customer.Country == "UK" || customer.Country == "USA" || customer.Country == "France" || customer.Country == "Mexico"
//                 orderby customer.Country, customer.Region descending
//                 select new 
//                 {
//                     CustomerID = customer.CustomerId,
//                     CustomerName = customer.CompanyName,
//                     Country = customer.Country,
//                     Region = customer.Region
//                 };

////Method Syntax
//var customers8 = context.Customers.
//    Where(customer => customer.Country == "UK" || customer.Country == "USA" || customer.Country == "France" || customer.Country == "Mexico").
//    OrderBy(customer => customer.Country).
//    ThenByDescending(customer => customer.Region).
//    Select(x => new
//    {
//        CustomerID = x.CustomerId,
//        CustomerName = x.ContactName,
//        Country = x.Country,
//        Region = x.Region
//    });

//foreach (var customer in customers9)
//{
//    Console.WriteLine($"Customer ID : {customer.CustomerID} - Company Name : {customer.CustomerName} - Country : {customer.Country} " +
//        $"Region : {customer.Region}");
//}
//******************************************************
//Tekrar etmeyen - Distinct Contact Title bilgilerni alalım.
//var contactTitle = (from customer in context.Customers
//                  select customer.ContactTitle).Distinct();

//var contactTitles = context.Customers.Select(x=>x.ContactTitle).Distinct();
//foreach (var contact in contactTitles) Console.WriteLine($"Contact Title : {contact}");

//******************************************************
//Müşteri isminde A geçen müşterilerin şirket bilgisi ve sipariş bilgilerini ekrana yazalım.
//var customerOrders = from customer in context.Customers
//                     where customer.CompanyName.Contains("A")
//                     select new
//                     {
//                         CustomerID = customer.CustomerId,
//                         CompanyName = customer.CompanyName,
//                         Orders = customer.Orders,
//                     };

//var customerOrdersMethodSyntax = context.Customers.
//    Where(x => x.CompanyName.Contains("A")).
//    Select(x => new
//    {
//        CustomerID = x.CustomerId,
//        CompanyName = x.CompanyName,
//        Orders = x.Orders,
//    });

//foreach (var customer in customerOrdersMethodSyntax)
//{
//    Console.WriteLine($"CustomerID : {customer.CustomerID} - Company Name : {customer.CompanyName}");
//    Console.WriteLine("Customer Orders");
//    foreach (var orderItem in customer.Orders)
//    {
//        Console.WriteLine($"Order ID : {orderItem.OrderId} - OrderDate : {orderItem.OrderDate}");
//    }
//    Console.WriteLine(new string('-', 100));
//}
//********************************************************
//var orderQuantity = (from order in context.OrderDetails
//                     where order.ProductId == 30
//                     select order).Count();

//Console.WriteLine(orderQuantity);

//var orderProductCountAverage = (from order in context.OrderDetails
//                                where order.ProductId == 30
//                                select order).Average(x => x.Quantity);

//var orderProductCountAverage2 = (from order in context.OrderDetails
//                                 where order.Product.ProductName == "Konbu"
//                                 select (order.UnitPrice * order.Quantity)).Average();
//Console.WriteLine(orderProductCountAverage2);

//var productListByCategory = from product in context.Products
//                            where product.Category.CategoryName == "Seafood"
//                            select product;

//foreach (var product in productListByCategory)
//{
//    Console.WriteLine($"Product ID : {product.ProductId} - Product Name : {product.ProductName} - Stok : {product.UnitsInStock}");
//}

//var orderProductCountAverage3 = context.OrderDetails.Where(x => x.ProductId == 30).Average(x => x.Quantity);

////10 adetten fazla siparişi olan müşteri adı
//var customers = from customer in context.Customers
//                where customer.Orders.Count() >= 10
//                select new
//                {
//                    CustomerName = customer.CompanyName
//                };

//foreach (var customer in customers)
//{
//    Console.WriteLine(customer.CustomerName);
//}

//****************************************************************************

//var customerTotal = (from orderTotal in context.OrderDetails
//                     where orderTotal.Order.Customer.CompanyName == "Eastern Connection"
//                     select orderTotal.Quantity * orderTotal.UnitPrice).Sum();

//Console.WriteLine(customerTotal);

//****************************************************************************

//Query Syntax
//var productsByCategory = from product in context.Products
//                         join category in context.Categories
//                         on product.CategoryId equals category.CategoryId
//                         orderby category.CategoryId ascending, product.ProductId ascending
//                         select new
//                         {
//                             CategoryID = category.CategoryId,
//                             CategoryName = category.CategoryName,
//                             ProductID = product.ProductId,
//                             ProductName = product.ProductName,
//                         };

var productsByCategory = context.Products.
    Join(context.Categories,
    product => product.CategoryId,
    category => category.CategoryId,
    (product, category) => new
    {
        CategoryID = category.CategoryId,
        CategoryName = category.CategoryName,
        ProductID = product.ProductId,
        ProductName = product.ProductName,
    }).
    OrderBy(x => x.CategoryID).ThenBy(x => x.ProductID);

foreach (var product in productsByCategory)
{
    Console.WriteLine($"CategoryID : {product.CategoryID} - CategoryName : {product.CategoryName} - ProductID : {product.ProductID} - ProductName : {product.ProductName}");
}