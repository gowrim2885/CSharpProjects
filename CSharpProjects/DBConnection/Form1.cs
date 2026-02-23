using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace DBConnection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            string connctionString = "Data Source=.;Initial Catalog=EmployeeDatabase;User ID=sa;Password=Gowri@2212;";
            try
            {
                using (SqlConnection connection = new SqlConnection(connctionString))
                {
                    string query = "SELECT * FROM Employee";
                    using (SqlDataAdapter da = new SqlDataAdapter(query, connection))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();   
        }



    }
}