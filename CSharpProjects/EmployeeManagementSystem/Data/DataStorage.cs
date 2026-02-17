using EmployeeManagementSystem.logic.models;
using System.Text.Json;

namespace EmployeeManagementSystem.Data
{
    public class DataStorage
    {
        string FilePath = "C:\\Gowri\\Repositories\\CSharpProject\\CSharpProjects\\EmployeeManagementSystem\\employee.json";
        public void SaveToFile(List<EmployeeModel> Employees)
        {
            string json = JsonSerializer.Serialize(Employees);
            File.WriteAllText(FilePath, json);
        }


        public List<EmployeeModel> ReadFromFile()
        {
            if (!File.Exists(FilePath))
            {
                return new List<EmployeeModel>();
            }

            string json = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<List<EmployeeModel>>(json);

        }

    }
}
