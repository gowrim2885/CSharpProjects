using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace StudentManagementWebForms.Data
{
    public class DepartmentDataBase
    {
        string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        public void LoadDepartment(DropDownList ddlDepartment)
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
            catch (Exception ex)
            {
                throw new Exception("Error loading Department: " + ex.Message);
            }
        }
    }
}