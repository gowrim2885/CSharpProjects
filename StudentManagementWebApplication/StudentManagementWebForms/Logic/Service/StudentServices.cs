using StudentManagementWebForms.Data;
using StudentManagementWebForms.Logic.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace StudentManagementWebForms.Logic.Service
{
    public class StudentServices
    {
        StudentDatabase Sdb = new StudentDatabase();
        DepartmentDataBase Ddb = new DepartmentDataBase();
        public bool AddStudents(Students student)
        {
            int changes = Sdb.AddStudent(student);

            return changes > 0;
        }

        public void LoadDepartment(DropDownList ddlDepartment)
        {
            Ddb.LoadDepartment(ddlDepartment);
        }
        public DataTable GetAllStudentDetails()
        {
             return Sdb.GetAllStudentDetail();
        }
        public Students EditStudentDetail(int RollNumber)
        {
            return Sdb.LoadUpdatePageDetail(RollNumber);
        }

        public bool UpdateStudentDetail(Students student) {

            int changes = Sdb.UpdateStudents(student);

            return changes > 0;

        }
        public int DeleteStudent(int RollNumber)
        {
            int n = Sdb.DeleteStudentData(RollNumber);
            return n;
        }
        public DataTable SearchData(string Search_data)
        {
            if (string.IsNullOrEmpty(Search_data))
            {
                //GetAllStudentDetails();
                return null;
            }
            else
            {
                return Sdb.SearchStudentData(Search_data);
            }
        }
        public DataTable SortDataAssendingOrder()
        {
            return Sdb.SortAToZ();
        }
        public DataTable SortDataDessendingOrder()
        {
            return Sdb.SortZToA();
        }
    }
}