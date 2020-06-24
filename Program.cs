// Palak Depani, 000787449
// Date - 15 November 2019
// I, Palak depani, student no 000787449, cerify that all code submitted is my own work;that i have not copied from any other source .
//I also certify that i have not allowed my work to be copied by other
// purpose - in this lab i will update my lab 1 from program .net programming using properties
// generics , collection and lambda expression.



using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace lab4A
{
    
    /// <summary>
    /// in this program we are going to sort given emmployee data according to user input
    /// </summary>
    class Program
    {
        
        /// <summary>
        /// this is main method of program where we write the code to sort given employee data
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // defining some varibles
            int data; 
            bool selection = true;

            // use of list instead of array for employee data
            var employee = new List<Employee>(); 

            // variable to store user input
            string userInput;
            
            // read emplyee
            Read(employee);


            while (selection)
            {
                // call method which display user instructions
                userInput = userOptions();

                if(Int32.TryParse(userInput, out data))
                {
                    switch (data)
                    {

                        case 1:
                            {
                                // this option sort data by employee name
                                employee = employee.OrderBy(x => x.Name).ToList();
                                break;
                            }
                        case 2:
                            {
                                //this option sort data by employee number
                                employee = employee.OrderBy(x => x.Number).ToList();
                                break;
                            }
                        case 3:
                            {
                                //this option sort data in descending hourate by employee rate
                                employee = employee.OrderByDescending(x => x.Rate).ToList();
                                break;
                            }
                        
                        case 4:
                            {
                                //this option sort data in descending hourrate for employee work hours
                                employee = employee.OrderByDescending(x => x.WorkHours).ToList();
                                break;
                            }

                        case 5:
                            {

                                // this option sort data in descending order for employee gross amount
                                employee = employee.OrderByDescending(x => x.GetGross()).ToList();
                                break;
                            }
                        case 6:
                            {
                                // this will exit the loop and close app
                                selection = false;
                                break;
                            }
                        default:
                            {
                                // just show invalid selection message if appropriate option is not selected
                                Console.WriteLine("INVALID SELECTION");
                                break;
                            }
                    }


                    if(data >= 0 && data <= 5)
                    {
                        // this display emplyee data if appropriate option is selected ( either from 1 to 5)
                        employeeData(employee);
                    }
                }

                else
                {
                    // give message to enter appropriate choice again
                    Console.WriteLine("INVALID CHOICE - SELECT AGAIN");
                }
                
            }
        }


        /// <summary>
        /// this method displays the employee data
        /// </summary>
        /// <param name="employeeData"></param>
        private static void employeeData(List<Employee> employeeData)
        {
            Console.Clear();

            Console.WriteLine("Employee Name      Number      Rate      Hours     Gross Pay");
            
            // foreach loop to get data
            foreach(var employee in employeeData)
            {
                // display the declared employee List
                Console.WriteLine($"{employee}");
                Console.WriteLine();
            }

        }


        /// <summary>
        /// this will read employees data
        /// </summary>
        /// <param name="list"></param>
        private static void Read(List<Employee> list)
        {
            string userChoice;
            try
            {
                
                // filestream to read file and data from it
                FileStream file = new FileStream(path: "employee.txt", mode: FileMode.Open, access: FileAccess.Read);
                StreamReader details = new StreamReader(file);
                while((userChoice = details.ReadLine()) != null)
                {
                    
                    // splits the sring by , 
                    string[] temp = userChoice.Split(',');
                    
                    // this add data to list file
                    list.Add(new Employee(temp[0], int.Parse(temp[1]), decimal.Parse(temp[2]), double.Parse(temp[3])));
                }
                details.Close();
            }

            // error message if data not found in system
            catch (IOException ex)
            {
                
                Console.WriteLine("FILE NOT FOUND {0}", ex.Message);
                
            }
            
        }

        /// <summary>
        /// this will display all the option for user selection
        /// </summary>
        /// <returns>user selection</returns>
        
        private static string userOptions()
        {
            
            // display all the available option to user for input 
            Console.WriteLine("Choose a valid Option");                  
            Console.WriteLine("1. SORT BY EMPLOYEE NAME (ASCENDING)");
            Console.WriteLine("2. SORT BY EMPLOYEE NUMBER (ASCENDING)");
            Console.WriteLine("3. SORT BY EMPLOYEE RATE (DESCENDING)");
            Console.WriteLine("4. SORT BY EMPLOYEE HOURS (DESCENDING)");
            Console.WriteLine("5. SORT BY EMPLOYEE GROSS PAY (DESCENDING)");
            Console.WriteLine("6. EXIT\n");

            Console.Write("Enter your choice: ");
            // read user input choice
            return Console.ReadLine();
        }
    }
}
