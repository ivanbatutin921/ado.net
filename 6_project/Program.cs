using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Configuration;
using _6_project.Entities;

namespace _6_project
{
    /*
    Link to Object - RAM
    Link to SQL - DB
    Link to  XML - XML file
    IEnumerable
    IQueryable
     */

    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionstring = ConfigurationManager.ConnectionStrings["Company"].ConnectionString;
            DataContext db = new DataContext(connectionstring);
            Table<Customer> customers=db.GetTable<Customer>();
            Table<Employee> employes=db.GetTable<Employee>();
            //1 вариант
            //с id
            //foreach (Customer customer in customers)
            //{
            //    Console.WriteLine(customer);
            //}
            //Console.ReadKey();


            //where
            //var query = from c in customers 
            //            where c.id <= 3 && c.id >= 1
            //            select c;
            //foreach ( Customer customer in query )
            //{
            //    Console.WriteLine(customer);
            //}


            //order by
            //var query = from c in customers
            //            //where c.id == 3 && c.id == 2
            //            orderby c.DateOfBirth
            //            select c;
            //foreach (Customer customer in query)
            //{
            //    Console.WriteLine(customer);
            //}
            //Console.ReadKey();


            //firstname = I
            //var query = from c in customers
            //            where c.FirstName.StartsWith("I")
            //            orderby c.DateOfBirth
            //            select c;
            //foreach (Customer customer in query)
            //{
            //    Console.WriteLine(customer);
            //}
            //Console.ReadKey();

            //2 вариант
            //1
            //var res = customers.Where(c => c.id == 3);
            //foreach(Customer customer in res)
            //{
            //    Console.WriteLine(customer);
            //}

            //2
            //var res = customers.Where<Customer>(c => c.FirstName.StartsWith("I")).ToList();
            //foreach ( Customer customer in res )
            //{
            //    Console.WriteLine(customer);
            //}

            //3 только один
            //Customer res = customers.First();
            //Console.WriteLine(res);

            //4 топ 3
            //List<Customer> customers1=customers.Take(3).ToList();
            //foreach (Customer customer in customers1)
            //{
            //    Console.WriteLine(customer);
            //}

            //5

            //Customer c_edit = customers.Where(c => c.id == 2).First();
            //c_edit.FirstName = "Johan"+"_edit";
            //Console.WriteLine(c_edit);
            //db.SubmitChanges();

            //6 add
            //Customer newcust = new Customer
            //{
            //    FirstName = "firstname",
            //    LastName = "lastname",
            //    DateOfBirth = new DateTime(2020, 10, 10)
            //};
            //customers.InsertOnSubmit(newcust);
            //db.SubmitChanges();
            //foreach (Customer customer in customers)
            //{
            //    Console.WriteLine(customer);
            //}
            //Console.ReadKey();

            // del

            //var customerToDelete = customers.SingleOrDefault(c => c.LastName == "Ivanova");
            //if (customerToDelete != null)
            //{
            //    customers.DeleteOnSubmit(customerToDelete);
            //    db.SubmitChanges();
            //}

            //7 add
            List<Employee> employees = new List<Employee>()
            {
                new Employee{ FirstName = "firstname1", LastName="lastname1",BirthDate=new DateTime(2023,12,12)},
                new Employee{ FirstName = "firstname2", LastName="lastname2",BirthDate=new DateTime(2023,11,11)},
                new Employee{ FirstName = "firstname3", LastName="lastname3",BirthDate=new DateTime(2023,10,10)}

            };
            employes.InsertAllOnSubmit(employees);
            db.SubmitChanges();

            foreach (Employee employee in employes)
            {
                Console.WriteLine(employee);
            }
            Console.ReadKey();

        }
    }
}
