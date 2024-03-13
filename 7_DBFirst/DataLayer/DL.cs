using _7_DBFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_DBFirst.DataLayer
{
    public static class DL
    {
        public static CustomerModel ByID(int sd)
        {
            using (var db=new P_11_CompanyEntities())
            {
                CustomerModel client = new CustomerModel();
                var client_res = db.stp_CustomerALL().First();
                client.id = client_res.id;
                client.FirstName = client_res.FirstName;
                client.LastName = client_res.LastName;
                client.Birthdate = (DateTime)client_res.DateOfBirth;
                return client;
            }
        }

        public static IEnumerable <CustomerModel> All()
        {
            using( var db=new P_11_CompanyEntities())
            {
                List<CustomerModel> customers = new List<CustomerModel>(); 
                var result=db.stp_CustomerALL().ToList();
                foreach (var customer in result)
                {
                    CustomerModel c = new CustomerModel();
                    c.id = customer.id; 
                    c.FirstName = customer.FirstName; 
                    c.LastName = customer.LastName;
                    c.Birthdate = (DateTime)customer.DateOfBirth;
                    customers.Add(c);
                }
                return customers;
            }        }

        public static EmployeeModel ByIDEmployee(int EmployeeID)
        {
            using (var db = new P_11_CompanyEntities())
            {
                EmployeeModel employee = new EmployeeModel();
                var employee_res = db.stp_EmployeeALL().First();
                employee.EmployeeID = employee_res.EmployeeID;
                employee.FirstName = employee_res.FirstName;
                employee.LastName = employee_res.LastName;
                employee.Birthdate = (DateTime)employee_res.BirthDate;
                employee.PositionID = (int)employee_res.PositionID;
                employee.Salary = (int)employee_res.Salary;
                return employee;
            }
        }

        public static IEnumerable<EmployeeModel> All_Employee()
        {
            using (var db = new P_11_CompanyEntities())
            {
                List<EmployeeModel> employees = new List<EmployeeModel>();
                var result = db.stp_EmployeeALL().ToList();
                foreach (var employee in result)
                {
                    EmployeeModel c = new EmployeeModel();
                    c.EmployeeID = employee.EmployeeID;
                    c.FirstName = employee.FirstName;
                    c.LastName = employee.LastName;
                    c.Birthdate = (DateTime)employee.BirthDate;
                    employees.Add(c);
                }
                return employees;
            }
        }


    }
}
