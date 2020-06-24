// Palak Depani, 000787449
// Date - 15 November 2019
// I, Palak depani, student no 000787449, cerify that all code submitted is my own work;that i have not copied from any other source .
//I also certify that i have not allowed my work to be copied by other
// purpose - in this lab i will update my lab 1 from program .net programming using properties
// generics , collection and lambda expression.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4A
{

    /// <summary>
    /// this will have get and set method of employee data
    /// </summary>
    class Employee
    {
        
        // some varibale to get employee data
        public string Name { get; set; }
        public int Number { get; set; }
        public decimal Rate { get; set; }
        public double WorkHours { get; set; }
        public decimal grossPay { get; private set; }
        
        public Employee()
        {

        }
        /// <summary>
        /// get and set values of different data
        /// </summary>
        /// <param name="name"></param>
        /// <param name="number"></param>
        /// <param name="rate"></param>
        /// <param name="hours"></param>
        public Employee(string name, int number, decimal rate, double workhours)
        {
            Name = name;
            Number = number;
            Rate = rate;
            WorkHours = workhours;
            grossPay = GetGross();
        }


        /// <summary>
        /// this is overridde to string method for output 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0,-20} {1:D4} {2,6:C} {4:#0.00} {3,8:C}", Name, Number, Rate, WorkHours, GetGross());
        }

        internal static object OrderBy(Func<object, object> p)
        {
            throw new NotImplementedException();
        }
        

        /// <summary>
        /// this will calculate gross pay of employees 
        /// </summary>
        /// <returns></returns>
        public decimal GetGross()
        {
            // pay for less than 40 hours
            if (WorkHours < 40)
            {
                grossPay = Rate * (decimal)WorkHours;
            }

            // calculate pay for over time
            else
            {
                double overTimeHours = WorkHours - 40;
                grossPay = (40 * Rate) + ((decimal)overTimeHours * (Rate * (decimal)1.5));
            }

            // return grosspay
            return grossPay;
        }

    }
}
