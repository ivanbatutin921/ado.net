using _3._1_project.Data;
using _3._1_project.Model;
using System;
using System.Collections.Generic;
using static _3._1_project.Data.ClassDataLayer;

namespace _3._1_project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //CustomerModel cl = Customer.ById(1);
            //Console.WriteLine(cl);


            //Customer.DeleteById(6);

            Customer.All();
            Console.WriteLine(Customer.Insert(new CustomerModel(0,"firstname", "lastname", new DateTime(2020, 10, 10))));
            Customer.All();

            Console.ReadKey();
            //удаление
            int id = Int32.Parse(Console.ReadLine());
            if (Customer.DeleteById(id))
                Console.WriteLine($"Клиент с ID = {id} удален");
            else
                Console.WriteLine("Error");

            //добавление
            int id1 = Customer.Insert(new CustomerModel(0, "firstname", "lastname", new DateTime(2020, 10, 10)));
            if (id1>0)
                Console.WriteLine($"Клиент добавлен");
            else
                Console.WriteLine("Error");

        }
    }
}
