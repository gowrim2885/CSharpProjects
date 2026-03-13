using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.EnterpriseServices;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace ASPWebFormStudentManagementSystem.pages
{
    public partial class EditStudent : System.Web.UI.Page
    {
        string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int RollNumber = Convert.ToInt32(Request.QueryString["RollNumber"]);
                LoadStudent(RollNumber);
            }

        }

        public void LoadStudent(int RollNumber)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("SELECT RollNumber, Name, Email, DepartmentID, Gender, Address, Age, DateOfBirth, Phone, AddmissionDate FROM Students WHERE RollNumber=@Rollnumber", con);
                cmd.Parameters.AddWithValue("@RollNumber", RollNumber);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    inputRollNumber.Text = RollNumber.ToString();
                    inputName.Text = reader["Name"].ToString();
                    inputEmail.Text = reader["Email"].ToString();
                    ddlDepartment.Text = reader["DepartmentID"].ToString();
                    rblGender.Text = reader["Gender"].ToString();
                    inputAddress.Text = reader["Address"].ToString();
                    inputAge.Text = reader["Age"].ToString();
                    inputDateOfBirth.Text = reader["DateOfBirth"].ToString();
                    inputPhone.Text = reader["Phone"].ToString();
                    inputAddmissionDate.Text = reader["AddmissionDate"].ToString();
                }

            }
        }
    }
}