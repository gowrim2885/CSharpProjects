using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StudentManagementSystem.Logic.Models;
using StudentManagementSystem.Data;

namespace StudentManagementSystem.Logic.service
{
    internal class StudentService
    {
        StudentData data = new StudentData();
        public void AddNewStudent(int nId, string strName, int nAge, string strEmail, string strDepartment)
        {
            data.AddStudent(new StudentModel
            {
                StudentId = nId,
                StudentName = strName,
                Age = nAge,
                Email = strEmail,
                Department = strDepartment

            }
            );
        }
    }
}
