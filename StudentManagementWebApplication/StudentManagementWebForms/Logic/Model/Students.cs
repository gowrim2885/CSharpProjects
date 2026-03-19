using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManagementWebForms.Logic.Model
{
    public class Students
    {

        public int RollNumber { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int DepartmentID { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public DateTime AddmissionDate { get; set; }
    }
}