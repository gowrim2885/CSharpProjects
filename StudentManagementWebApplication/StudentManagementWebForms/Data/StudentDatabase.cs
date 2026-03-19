using StudentManagementWebForms.Logic.Model;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace StudentManagementWebForms.Data
{
    public class StudentDatabase
    {
        private readonly string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

        private SqlConnection GetConnection()
        {
            return new SqlConnection(CS);
        }

        private int ExecuteNonQueryMethod(SqlCommand cmd)
        {
            using (SqlConnection con = GetConnection())
            {
                cmd.Connection = con;
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        private DataTable ExecuteDataTable(SqlCommand cmd)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = GetConnection())
            {
                cmd.Connection = con;
                using (SqlDataAdapter adap = new SqlDataAdapter(cmd))
                {
                    adap.Fill(dt);
                }
            }
            return dt;
        }
        public int AddStudent(Students student)
        {
            string InsertQuery = "INSERT INTO Students (RollNumber, Name, Email, DepartmentID, Address, Gender, Age, DateOfBirth, Phone) VALUES (@RollNumber, @Name, @Email, @Department, @Address, @Gender, @Age, @DOB, @Phone)";
            SqlCommand cmd = new SqlCommand(InsertQuery);

            cmd.Parameters.AddWithValue("@RollNumber", student.RollNumber);
            cmd.Parameters.AddWithValue("@Name", student.Name);
            cmd.Parameters.AddWithValue("@Email", student.Email);
            cmd.Parameters.AddWithValue("@Department", student.DepartmentID);
            cmd.Parameters.AddWithValue("@Address", student.Address);
            cmd.Parameters.AddWithValue("@Gender", student.Gender);
            cmd.Parameters.AddWithValue("@Age", student.Age);
            cmd.Parameters.AddWithValue("@DOB", student.DateOfBirth);
            cmd.Parameters.AddWithValue("@Phone", student.Phone);

            return ExecuteNonQueryMethod(cmd);

        }
        public DataTable GetAllStudentDetail()
        {
            SqlCommand cmd = new SqlCommand("DisplayStudentsInfo");

            cmd.CommandType = CommandType.StoredProcedure;

            return ExecuteDataTable(cmd);
        }

        public Students LoadUpdatePageDetail(int RollNumber)
        {
            using (SqlConnection con =GetConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT RollNumber, Name, Email, DepartmentID, Gender, Address, Age, DateOfBirth, Phone, AddmissionDate FROM Students WHERE RollNumber=@Rollnumber", con);
                cmd.Parameters.AddWithValue("@RollNumber", RollNumber);
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Students
                        {
                            RollNumber = RollNumber,
                            Name = reader["Name"].ToString(),
                            Email = reader["Email"].ToString(),
                            DepartmentID = Convert.ToInt32(reader["DepartmentID"]),
                            Address = reader["Address"].ToString(),
                            Gender = reader["Gender"].ToString(),
                            Age = Convert.ToInt32(reader["Age"]),
                            DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]),
                            Phone = reader["Phone"].ToString(),
                            AddmissionDate = Convert.ToDateTime(reader["AddmissionDate"])
                        };

                    }
                }
                
            }
            return null;
        }

        public int UpdateStudents(Students student)
        {
            SqlCommand cmd = new SqlCommand("UpdateStudentInfo");
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@RollNumber", student.RollNumber);
            cmd.Parameters.AddWithValue("@Name", student.Name);
            cmd.Parameters.AddWithValue("@Email", student.Email);
            cmd.Parameters.AddWithValue("@DepartmentID", student.DepartmentID);
            cmd.Parameters.AddWithValue("@Address", student.Address);
            cmd.Parameters.AddWithValue("@Gender", student.Gender);
            cmd.Parameters.AddWithValue("@Age", student.Age);
            cmd.Parameters.AddWithValue("@DateOfBirth", student.DateOfBirth);
            cmd.Parameters.AddWithValue("@Phone", student.Phone);

            return ExecuteNonQueryMethod(cmd);
        
        }

        public int DeleteStudentData(int RollNumber)
        {
            SqlCommand cmd = new SqlCommand("DeleteStudentInfo");
            
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@RollNumber", RollNumber);

            return ExecuteNonQueryMethod(cmd);
        }
        public DataTable SearchStudentData(string search_data)
        {
            SqlCommand cmd = new SqlCommand("SearchStudent");

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@SearchTerm", search_data);

            return ExecuteDataTable(cmd);
        }

        public DataTable SortAToZ()
        {
            SqlCommand cmd = new SqlCommand("SortStudentInfo");

            cmd.CommandType = CommandType.StoredProcedure;

            return ExecuteDataTable(cmd);

        }
        public DataTable SortZToA()
        {
            SqlCommand cmd = new SqlCommand("SortStudentInfoZA");

            cmd.CommandType = CommandType.StoredProcedure;

            return ExecuteDataTable(cmd);
        }
    }
}