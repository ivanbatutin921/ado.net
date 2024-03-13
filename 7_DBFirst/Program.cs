using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using _7_DBFirst.Models;
using _7_DBFirst.DataLayer;

namespace _7_DBFirst
{
    /*
     OM-группа классов
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            //1 By_ID
            //var db = new P_11_CompanyEntities();
            //var client_res = db.stp_CustomerByID(3).First();
            //Console.WriteLine(client_res);
            //Console.ReadKey();
            //2
            //CustomerModel cm = DL.ByID(2);
            //Console.ReadKey();
            //3
            //IEnumerable<CustomerModel> clients = DL.All();
            //Console.ReadKey();


            //2.1 By_ID_Employee
            //var db = new P_11_CompanyEntities();
            //var employee_res = db.stp_EmployeeID(3).First();
            //Console.WriteLine(employee_res);
            //Console.ReadKey();

            //2 By_ID_Employee
            //EmployeeModel em = DL.ByIDEmployee(6);
            //Console.ReadKey();

            //3 All_Employee
            IEnumerable<EmployeeModel> employees = DL.All_Employee();
            Console.ReadKey();


        }
    }
}
