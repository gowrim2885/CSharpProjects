using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.logic.models;



namespace EmployeeManagementSystem.logic.services
{
    public class EmployeeService
    {
        EmployeeData data = new EmployeeData();
        List<EmployeeModel> Employees = new List<EmployeeModel>();
        public void AddNewEmployee(string strName, string strDepartment, string strEmail, decimal dSalary, int nAge, string strLocation)
        {

            data.AddEmployee(new EmployeeModel
            {
                name = strName,
                department = strDepartment,
                email = strEmail,
                salary = (int)dSalary,
                age = nAge,
                location = strLocation
            });

        }

        public List<EmployeeModel> DisplayAllEmployees()
        {
            return data.GetAllEmployees();
        }

        public bool DeleteEmployee(string strName)
        {
            bool IsDelete = false;

            List<EmployeeModel> employees = DisplayAllEmployees();
            var employeeToDelete = employees.Find(emp => emp.name == strName);

            if (employeeToDelete != null)
            {
                employees.Remove(employeeToDelete);
                IsDelete = true;

                data.UpdateNewEmployeeList(employees);
                return IsDelete;
            }
            else
            {
                return IsDelete;
            }
        }

        public bool UpdateEmployeeInformation(string strName, string strDepartment, string strEmail, int nSalary, int nAge, string strLocation)
        {
            bool IsUpdate = false;
            List<EmployeeModel> employees = DisplayAllEmployees();
            var employeeToUpdate = employees.Find(emp => emp.name == strName);
            if (employeeToUpdate != null)
            {
                employeeToUpdate.department = strDepartment;
                employeeToUpdate.email = strEmail;
                employeeToUpdate.salary = nSalary;
                employeeToUpdate.age = nAge;
                employeeToUpdate.location = strLocation;
                IsUpdate = true;
                data.UpdateNewEmployeeList(employees);
                return IsUpdate;
            }
            else
            {
                return IsUpdate;

            }
        }
    }
}