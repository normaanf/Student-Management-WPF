using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    internal class Student
    {
        public String StudentId { get; set; }
        public String FullName { get; set; }
        public String Email { get; set; }
        public String PhoneNumber { get; set; }
        public DateTime Date { get; set; }
        public Student(string studentId, string fullName, string email, string phoneNumber, DateTime date)
        {
            StudentId = studentId;
            FullName = fullName;
            Email = email;
            PhoneNumber = phoneNumber;
            Date = date;
        }
    }
}
