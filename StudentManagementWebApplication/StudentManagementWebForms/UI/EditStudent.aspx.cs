using StudentManagementWebForms.Data;
using StudentManagementWebForms.Logic.Model;
using StudentManagementWebForms.Logic.Service;
using System;
using System.Web;
using System.Web.Optimization;
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
            Students student = Service.EditStudentDetail(RollNumber);
            if(student != null)
            {
                inputRollNumber.Text = student.RollNumber.ToString();
                inputName.Text = student.Name;
                inputEmail.Text = student.Email;
                ddlDepartment.SelectedValue = student.DepartmentID.ToString();
                rblGenderList.Text = student.Gender;
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
                Phone = inputPhone.Text,
                AddmissionDate = Convert.ToDateTime(inputAddmissionDate.Text)

            };

            string result  = Service.UpdateStudentDetail(student);
            ClientScript.RegisterStartupScript(this.GetType(), "alert", result, true);
        }

        protected void CancelBtn_Click(object sender, EventArgs e)
        {
            string script = "window.location='DisplayPage.aspx';";
            ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
        }
    }
}