using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace ASPWebFormStudentManagementSystem.pages
{
    public partial class DisplayPage : System.Web.UI.Page
    {
        string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString; 
        protected void Page_Load(object sender, EventArgs e)
        {
            DisplayStudentDetails();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            DisplayStudentDetails();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int RollNumber = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            string name = ((TextBox)GridView1.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
            string email = ((TextBox)GridView1.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
            string department = ((TextBox)GridView1.Rows[e.RowIndex].Cells[3].Controls[0]).Text;

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("UPDATE Students SET Name=@Name, Email=@Email, DepartmentID=@Dept WHERE RollNumber=@RollNumber", con);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Dept", department);
                cmd.Parameters.AddWithValue("@RollNumber", RollNumber);
                con.Open();
                cmd.ExecuteNonQuery();
            }

            GridView1.EditIndex = -1;
            DisplayStudentDetails();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            DisplayStudentDetails();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int RollNumber = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Students WHERE StudentID=@RollNumber", con);
                cmd.Parameters.AddWithValue("@RollNumber", RollNumber);
                con.Open();
                cmd.ExecuteNonQuery();
            }

            DisplayStudentDetails();
        }

        protected void DisplayStudentDetails()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(CS))
                {
                    using (SqlDataAdapter adap = new SqlDataAdapter("DisplayStudentsInfo", con))
                    {
                        DataSet ds = new DataSet();

                        adap.Fill(ds, "StudentsList");

                        GridView1.DataSource = ds.Tables["StudentsList"];
                        GridView1.DataBind();
                        
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Error: " + message + "');", true);
            }
        }
    }
}