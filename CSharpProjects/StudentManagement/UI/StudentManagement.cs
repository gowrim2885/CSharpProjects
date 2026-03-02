using StudentManagementSystem.Logic.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.UI
{
    internal class StudentManagement
    {
        StudentService service = new StudentService();
        public void Start()
        {

            while(true)
            {
                Console.WriteLine(" *** WELCOME TO STUDENT MANAGEMENT SYSTEM ***");

                Console.WriteLine("Enter Which Operation are to be performed");
                Console.WriteLine("1. Add Students");
                Console.WriteLine("2. Display Students");

                int n = Convert.ToInt32(Console.Read());

                switch (n)
                {
                    case 1:
                        AddStudent();
                        break;
                }

            }

        }

        public void AddStudent()
        {
            Console.Write("Enter Student ID :");
            int nId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Student Name :");
            string? strName = Console.ReadLine();
            Console.Write("Enter Student Age :");
            int nAge = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Student Email :");
            string? strEmail = Console.ReadLine();
            Console.WriteLine("Enter Student Department :");
            string? strDepartment = Console.ReadLine();

            service.AddNewStudent(nId, strName, nAge, strEmail, strDepartment);

        }

    }
}
