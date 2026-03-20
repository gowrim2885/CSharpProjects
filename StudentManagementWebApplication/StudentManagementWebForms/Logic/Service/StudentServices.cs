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
        public string AddStudents(Students student)
        {
            int result = Sdb.AddStudent(student);

            if (result == 1)
            {
                string script = "alert('Student Added Successfully'); window.location='DisplayPage.aspx';";
                return script;
            }
            else if (result == 2627) 
            {
                string script = "alert('Error: Roll Number already exists.');";
                return script;
            }
            else if (result == 547) 
            {
                string script = "alert('Error: Invalid Department ID.');";
                return script;
            }
            else
            {
                string script = "alert('Error: Could not add student.');";
                return script;
            }
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

        public string UpdateStudentDetail(Students student) {

            int result = Sdb.UpdateStudents(student);

            if (result == 1)
            {
                string script = "alert('Student updated successfully'); window.location='DisplayPage.aspx';";
                return script;
            }
            else if (result == 2627)
            {
                string script = "alert('Error: Roll Number already exists.');";
                return script;

            }
            else if (result == 547) 
            {
                string script = "alert('Error: Invalid Department ID.');";
                return script;

            }
            else
            {
                string script = "alert('Error: Could not update student.');";
                return script;

            }

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