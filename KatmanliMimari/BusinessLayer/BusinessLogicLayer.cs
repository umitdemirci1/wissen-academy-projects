using BusinessLayer.Models;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BusinessLogicLayer
    {
        public List<Customer> GetAllCustomers()
        {
            string query = "Select * From Customers";
            List<Customer> customers = new();

            DataAccessLayer dataLayer = new();

            SqlCommand cmd = dataLayer.ExecuteCommand(query);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Customer customer = new();
                customer.CustomerID = reader["CustomerID"].ToString();
                customer.CompanyName = reader["CompanyName"].ToString();
                customer.ContactTitle = reader["ContactTitle"].ToString();
                customer.ContactName = reader["ContactName"].ToString();
                customer.Address = reader["Address"].ToString();
                customer.City = reader["City"].ToString();
                customer.PostalCode = reader["PostalCode"].ToString();
                customer.Country = reader["Country"].ToString();
                customer.Region = reader["Region"].ToString();
                customer.Phone = reader["Phone"].ToString();
                customer.Fax = reader["Fax"].ToString();

                if (!customers.Contains(customer))
                {
                    customers.Add(customer);
                }
            }
            dataLayer.CloseConnection(cmd.Connection);

            return customers;
        }
    }
}
