using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace day_7_assign_9
{
    class ValidationException : Exception
    {
        public ValidationException(string message) : base(message) { }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            char choice;
            do
            {
                try
                {
                    //Propmt user to enter name,email,password
                    Console.WriteLine("Enter Your name: ");
                    string name = Console.ReadLine();

                    Console.WriteLine("Enter your Email: ");
                    string email = Console.ReadLine();

                    Console.WriteLine("Enter Your Password: ");
                    string password = Console.ReadLine();

                    //Validate User input
                    ValidateUserInput(name, email, password);

                    
                    Console.WriteLine("******************************");
                    Console.WriteLine("User Registration Successful");
                    Console.WriteLine("******************************");
                    Console.WriteLine($"Name: {name} \nEmail: {email} \nPassword: {password}");

                }
                catch (ValidationException ex)
                {
                    Console.WriteLine("Validation Error: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                finally
                {
                    Console.WriteLine("End of Program");
                    Console.WriteLine($"\nDo you want to conitnue: if yes press 'Y' or press any other key to Exits");
                    choice = char.Parse(Console.ReadLine());
                    Console.ReadLine();
                }
            }
            while (choice == 'y');
        }
        static void ValidateUserInput(string name, string email, string password)
        {
            //check for any missing values in name,email,password
            if(string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email)
                  || string.IsNullOrWhiteSpace(password))
            {
                throw new ValidationException("Please Provide all fields");
            }

            //check name length and password length both
            if (name.Length < 6 && password.Length < 8)
            {
                throw new ValidationException("Password and Name must have valid Charachters");
            }
            //check name length
            if (name.Length<6)
            {
                throw new ValidationException("Name must have atleast 6 Charachter");
            }

            //check password length
            if(password.Length<8)
            {
                throw new ValidationException("Password must have atleast 8 Charachter");
            }

        }
    }
}
