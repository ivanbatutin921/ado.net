using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_HW.Model
{
    internal class CustomerModel
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirthdate { get; set; }

        public CustomerModel(int _ID, string _FirstName, string _LastName, DateTime _DateOfBirthdate)
        {
            ID = _ID;
            FirstName = _FirstName;
            LastName = _LastName;
            DateOfBirthdate = _DateOfBirthdate;
        }
        public override string ToString()
        {
            return $"{ID} {FirstName} {LastName} {DateOfBirthdate}";
        }
    }
}
