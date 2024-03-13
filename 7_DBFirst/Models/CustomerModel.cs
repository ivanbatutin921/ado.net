using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _7_DBFirst.Models
{
    public class CustomerModel
    {
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }

        //public override string ToString()
        //{
        //    return $"{id} {FirstName} {LastName} {DateOfBirth}";
        //}

    }
}
