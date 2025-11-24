
using System;
using System.Collections.Generic;

namespace LINQTut07.Shared
{
    public class Employee
    {
        public string EmployeeNo { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
        public decimal Salary { get; set; }

        public List<string> Skills { get; set; } = new List<string>();


        public override string ToString()
        {

            return
                    $"" +
                    $"{EmployeeNo,-13}\t" +
                    $"{Name,-20}\t" +
                    $"{Email,-32}\t" +
                    $"{String.Format("{0:C0}", Salary)}  " +
                    $"[ {string.Join(", ", Skills)} ]";

        }


        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Employee e = (Employee)obj;
                return (this.Email.Equals(e.Email));
            }
        }

        public override int GetHashCode()
        {
            return Email.GetHashCode() + 13 * 7;
        }
    }
}
