using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolScedual
{
    public class Student
    {
        private string fullName;
        private string adress;
        private long phoneNumber;

        public string FullName { get; set; }
        public long PhoneNumber 
        {
            get 
            { 
                return phoneNumber; 
            }
            set
            {
                if(CheckPhoneNumber(value))
                {
                    phoneNumber = value;
                }
            }
        }
        public string Adress { get; set; }

        public bool CheckPhoneNumber(long phoneNumber)
        {
            string pHst = phoneNumber.ToString();
            if (pHst.Length < 11 || pHst.Length > 11)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void ShowInfoAboutStudent()
        {
            Console.WriteLine($"Full name: {FullName}");
            Console.WriteLine($"Phone number: {PhoneNumber}");
            Console.WriteLine($"Adress:{Adress}");
        }

        public Student(string fullName, string adress, string phoneNumber)
        {
            long phone;
            bool flag = Int64.TryParse(phoneNumber, out phone);
            if(flag )
            {
                FullName = fullName;
                Adress = adress;
                PhoneNumber = phone;
            }
            else
            {
                Console.WriteLine("Incorrect phone number");
            }
        }
    }
}
