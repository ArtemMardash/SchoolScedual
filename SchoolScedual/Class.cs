using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolScedual
{
    public  class Class
    {
        private string classNumber;
        public List<Student> students;

        public string ClassNumber { get; set; }

        public bool CheckClassNumber(string classNumber)
        {
            string[] args = new string[2];
            args = classNumber.Split(" ");
            int number = 0;
            string litteral = args[1];
            if (int.TryParse(args[0], out number) == true && number <= 11 && litteral.Length == 0)
            {
                return true;
            }
            else
            { return false; }
        }

        public void AddStudent()
        {
            Console.WriteLine("Enter student's Full Name");
            string fullName =  Console.ReadLine();
            Console.WriteLine("Enter student's phone number");
            long phoneNumber = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Enter student's adress");
            string adress = Console.ReadLine();
            Student student = new Student(fullName, adress, phoneNumber);
            students.Add(student);
        }

        public void RemoveStudent()
        {
            Console.WriteLine("Enter student's Full Name");
            string fullName = Console.ReadLine();
            int id = -1;
            for(int i = 0; i < students.Count; i++)
            {
                if (students[i].FullName == fullName)
                {
                    id = i;
                }
            }
            if(id != -1)
            {
                students.RemoveAt(id);
                Console.WriteLine("Information about student was delete");
            }
        }

        public void EditStudent()
        {
            string newData = "";
            Console.WriteLine("Enter student's Full Name");
            string fullName = Console.ReadLine();
            foreach (var k in students)
            {
                if(k.FullName == fullName)
                {
                    k.ShowInfoAboutStudent();
                    Console.WriteLine("if you do not want to change data press enter");
                    Console.WriteLine("Enter student's Full name");
                    newData= Console.ReadLine();
                    if(!String.IsNullOrEmpty(newData))
                    {
                        k.FullName= newData;
                    }
                    Console.WriteLine("Enter student's phone number");
                    newData = Console.ReadLine();
                    long phone;
                    if(!String.IsNullOrEmpty(newData) && Int64.TryParse(newData,out phone))
                    {
                        k.PhoneNumber= phone;
                    }
                    Console.WriteLine("Enter student's adreess");
                    newData = Console.ReadLine();
                    if(!string.IsNullOrEmpty(newData))
                    {
                        k.Adress= newData;
                    }
                }
            }
        }

        public void ShowInfoAboutClass()
        {
            foreach(var k in students)
            {
                k.ShowInfoAboutStudent();
            }
        }

        
        public Class(string ClassNumber)
        {
            ClassNumber = classNumber;
            AddStudent();
        }
    }
}
