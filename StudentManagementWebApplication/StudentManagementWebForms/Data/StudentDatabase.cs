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

        private int ExecuteNonQueryMethod(SqlCommand cmd, SqlCommand AuditCommand)
        {
            using (SqlConnection con = GetConnection())
            {
                con.Open();
                using(SqlTransaction transaction = con.BeginTransaction())
                {
                    try
                    {
                        cmd.Connection = con;
                        cmd.Transaction = transaction;
                        cmd.CommandType = CommandType.StoredProcedure;

                        AuditCommand.Connection = con;
                        AuditCommand.Transaction = transaction;
                        AuditCommand.CommandType = CommandType.StoredProcedure;

                        int changes = (int)cmd.ExecuteNonQuery();
                        AuditCommand.ExecuteNonQuery();

                        transaction.Commit();
                        return changes;
                    }
                    catch
                    {
                        transaction.Rollback();
                        return -1;
                    }
                }

            }
        }

      

        private DataTable ExecuteDataTable(SqlCommand cmd)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = GetConnection())
            {
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataAdapter adap = new SqlDataAdapter(cmd))
                {
                    adap.Fill(dt);
                }
            }
            return dt;
        }
        public int AddStudent(Students student)
        {
            SqlCommand cmd = new SqlCommand("AddStudentInfo");

            cmd.Parameters.AddWithValue("@RollNumber", student.RollNumber);
            cmd.Parameters.AddWithValue("@Name", student.Name);
            cmd.Parameters.AddWithValue("@Email", student.Email);
            cmd.Parameters.AddWithValue("@Department", student.DepartmentID);
            cmd.Parameters.AddWithValue("@Address", student.Address);
            cmd.Parameters.AddWithValue("@Gender", student.Gender);
            cmd.Parameters.AddWithValue("@Age", student.Age);
            cmd.Parameters.AddWithValue("@DOB", student.DateOfBirth);
            cmd.Parameters.AddWithValue("@Phone", student.Phone);
            cmd.Parameters.AddWithValue("@AddmissionDate", student.AddmissionDate);

            SqlCommand Auditcommand = new SqlCommand("AddStudentAuditData");
            Auditcommand.Parameters.AddWithValue("@RollNumber", student.RollNumber);
            Auditcommand.Parameters.AddWithValue("@Action", "Insert");
            Auditcommand.Parameters.AddWithValue("@VersionNumber",1);
            Auditcommand.Parameters.AddWithValue("@Name", student.Name);
            Auditcommand.Parameters.AddWithValue("@Email", student.Email);
            Auditcommand.Parameters.AddWithValue("@Department", student.DepartmentID);
            Auditcommand.Parameters.AddWithValue("@Address", student.Address);
            Auditcommand.Parameters.AddWithValue("@Gender", student.Gender);
            Auditcommand.Parameters.AddWithValue("@Age", student.Age);
            Auditcommand.Parameters.AddWithValue("@DOB", student.DateOfBirth);
            Auditcommand.Parameters.AddWithValue("@Phone", student.Phone);
            Auditcommand.Parameters.AddWithValue("@AddmissionDate", student.AddmissionDate);
            Auditcommand.Parameters.AddWithValue("@Action", "Insert");
            Auditcommand.Parameters.AddWithValue("@VersionNumber",(student.VersionNumber + 1));

            return ExecuteNonQueryMethod(cmd, Auditcommand);

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
            cmd.Parameters.AddWithValue("@AddmissionDate", student.AddmissionDate);


            SqlCommand Auditcmd = new SqlCommand("UpdateStudentAuditData");
            ExecuteAuditTableNonQuery(Auditcmd);

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