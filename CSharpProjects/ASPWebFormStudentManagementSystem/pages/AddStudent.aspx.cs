using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ASPWebFormStudentManagementSystem.pages
{
    public partial class AddStudent : System.Web.UI.Page
    {
        string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDepartment();
            }
        }

        protected void LoadDepartment()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("Select DepartmentID, DepartmentName from DEPARTMENT", con);
                    con.Open();
                   
                    ddlDepartment.DataValueField = "DepartmentID";
                    ddlDepartment.DataTextField = "DepartmentName";
                    SqlDataReader reader = cmd.ExecuteReader();
                    ddlDepartment.DataSource = reader;
                    ddlDepartment.DataBind();
                    con.Close();
                    ddlDepartment.Items.Insert(0, "Select Department");
                }
            }
            catch(Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
        }
        //protected void maleRadioBtn_CheckedChanged(object sender, EventArgs e)
        //{
        //    rblGender.Text = "Male radio button was clicked";

        //}
        //protected void femaleRadioBtn_CheckedChanged(object sender, EventArgs e)
        //{
        //    rblGender.Text = "Female radio button was clicked";
        //}
        protected void AddStudBtn_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(CS))
                {
                    string InsertQuery = "INSERT INTO Students (RollNumber, Name, Email, DepartmentID, Address, Gender, Age, DateOfBirth, Phone) VALUES (@RollNumber, @Name, @Email, @Department, @Address, @Gender, @Age, @DOB, @Phone)";

                    SqlCommand cmd = new SqlCommand(InsertQuery, con);
                    cmd.Parameters.AddWithValue("@RollNumber", inputRollNumber.Text);
                    cmd.Parameters.AddWithValue("@Name", inputName.Text);
                    cmd.Parameters.AddWithValue("@Email", inputEmail.Text);
                    cmd.Parameters.AddWithValue("@Department", Convert.ToInt32(ddlDepartment.Text));
                    cmd.Parameters.AddWithValue("@Address", inputAddress.Text);
                    cmd.Parameters.AddWithValue("@Gender", rblGender.Text);
                    cmd.Parameters.AddWithValue("@Age", Convert.ToInt32(inputAge.Text));
                    cmd.Parameters.AddWithValue("@DOB", Convert.ToDateTime(inputDateOfBirth.Text));
                     cmd.Parameters.AddWithValue("@Phone", inputPhone.Text);

                     con.Open();
                    int changes = (int) cmd.ExecuteNonQuery();

                    if (changes > 0)
                    {
                        string script = "alert('Student Added Successfully'); window.location='DisplayPage.aspx';";
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Error: " + message + "');", true);
            }
        }

        protected void CancelBtn_Click(object sender, EventArgs e)
        {

        }

    }
}