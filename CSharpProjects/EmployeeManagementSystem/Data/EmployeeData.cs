using EmployeeManagementSystem.logic.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Data
{
    public class EmployeeData
    {

        DataStorage storage = new DataStorage();

        List<EmployeeModel> Employees = new List<EmployeeModel>();
        public void AddEmployee(EmployeeModel emp)
        {
            Employees.Add(emp);

            storage.SaveToFile(Employees);
        }
        public List<EmployeeModel> GetAllEmployees()
        {

            return storage.ReadFromFile();
        }

        public void UpdateNewEmployeeList(List<EmployeeModel> Employees)
        {
            storage.SaveToFile(Employees);
        }

    }
}
