using StudentManagementWebForms.Data;
using StudentManagementWebForms.Logic.Model;
using StudentManagementWebForms.Logic.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentManagementWebForms.UI
{
    public partial class EditStudent : System.Web.UI.Page
    {
        StudentServices Service = new StudentServices();
        DepartmentDataBase Ddb = new DepartmentDataBase();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int RollNumber = Convert.ToInt32(Request.QueryString["RollNumber"]);
                Ddb.LoadDepartment(ddlDepartment);
                LoadStudent(RollNumber);
            }

        }

        private void LoadStudent(int RollNumber)
        {
            Students student =Service.EditStudentDetail(RollNumber);
            if(student != null)
            {
                inputRollNumber.Text = student.RollNumber.ToString();
                inputName.Text = student.Name;
                inputEmail.Text = student.Email;
                ddlDepartment.SelectedValue = student.DepartmentID.ToString();
                rblGender.Text = student.Gender;
                inputAddress.Text = student.Address;
                inputAge.Text = student.Age.ToString();
                inputPhone.Text = student.Phone.ToString();
                inputDateOfBirth.Text = student.DateOfBirth.ToString("yyyy-MM-dd");
                inputAddmissionDate.Text = student.AddmissionDate.ToString("yyyy-MM-dd");
            }
        }
        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            Students student = new Students
            {
                RollNumber = Convert.ToInt32(inputRollNumber.Text),
                Name = inputName.Text,
                Email = inputEmail.Text,
                DepartmentID = Convert.ToInt32(ddlDepartment.Text),
                Address = inputAddress.Text,
                Gender = rblGenderList.Text,
                Age = Convert.ToInt32(inputAge.Text),
                DateOfBirth = Convert.ToDateTime(inputDateOfBirth.Text),
                Phone = inputPhone.Text
            };

            bool success = Service.UpdateStudentDetail(student);
            if (success)
            {
                string script = "alert('Student Updated Successfully'); window.location='DisplayPage.aspx';";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);

            }
            else
            {
                string script = "alert('Error: Could not able to Update student Information');";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
            }
        }

        protected void CancelBtn_Click(object sender, EventArgs e)
        {
            string script = "window.location='DisplayPage.aspx';";
            ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
        }
    }
}