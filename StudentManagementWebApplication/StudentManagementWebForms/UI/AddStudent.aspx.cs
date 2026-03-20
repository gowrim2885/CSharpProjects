using System;
using StudentManagementWebForms.Logic.Model;
using StudentManagementWebForms.Logic.Service;

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
                inputAddmissionDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
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
                Phone = inputPhone.Text,
                AddmissionDate = Convert.ToDateTime(inputAddmissionDate.Text)
            };

            string result = Service.AddStudents(student);
            ClientScript.RegisterStartupScript(this.GetType(), "alert", result, true);

        }

        protected void CancelBtn_Click(object sender, EventArgs e)
        {
            string script = "window.location='DisplayPage.aspx';";
            ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
        }

    }
}