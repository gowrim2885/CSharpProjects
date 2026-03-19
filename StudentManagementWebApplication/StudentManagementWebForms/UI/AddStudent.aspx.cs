using System;
using System.Configuration;
using StudentManagementWebForms.Logic.Model;
using StudentManagementWebForms.Logic.Service;

using System.Web.UI.WebControls;

namespace StudentManagementWebForms.UI
{
    public partial class AddStudent : System.Web.UI.Page
    {

        StudentServices Service = new StudentServices(); 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Service.LoadDepartment(ddlDepartment);
            }
        }

        protected void AddStudBtn_Click(object sender, EventArgs e)
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

            bool success = Service.AddStudents(student);
            if (success)
            {
                string script = "alert('Student Added Successfully'); window.location='DisplayPage.aspx';";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);

            }
            else
            {
                string script = "alert('Error: Could not add student');";
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