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
    public partial class DisplayPage : System.Web.UI.Page
    {
        StudentServices Service = new StudentServices();
        protected void Page_Load(object sender, EventArgs e)
        {
            DisplayStudentDetails();
        }

        private void DisplayStudentDetails()
        {
            GridView1.DataSource = Service.GetAllStudentDetails();
            GridView1.DataBind();
        }

        protected void Getdata_Click(object sender, EventArgs e)
        {
            string search_data = "%" + searchBox.Text + "%";

            DataTable dt = Service.SearchData(search_data);

            if(dt != null && dt.Rows.Count >0)
            {
                GridView1.DataSource = Service.SearchData(search_data);
                GridView1.DataBind();
            }
            else
            {
                string script = "alert('Student Not Found');";
                ClientScript.RegisterStartupScript(GetType(), "script", script, true);
            }
        }

     

        protected void SortAZStudentData_Click(object sender, EventArgs e)
        {
            GridView1.DataSource = Service.SortDataAssendingOrder();
            GridView1.DataBind();
        }
        protected void SortZAStudentData_Click(object sender, EventArgs e)
        {
            GridView1.DataSource = Service.SortDataDessendingOrder();
            GridView1.DataBind();
        }

        protected void Delete_StudentInfo_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;

            GridViewRow row = (GridViewRow)btn.NamingContainer;

            int RowIndex = row.RowIndex;

            int RollNumber = Convert.ToInt32(GridView1.DataKeys[RowIndex].Value);

            int changes = Service.DeleteStudent(RollNumber);

            if (changes > 0)
            {
                Response.Write("Student " + RollNumber + " Deleted Successfully. ");
            }
            else
            {
                Response.Write("Student " + RollNumber + " Not Deleted. The data are not available on your database," +
                    "Check Again.");
            }

            //DisplayStudentDetails();
        }
    }
}