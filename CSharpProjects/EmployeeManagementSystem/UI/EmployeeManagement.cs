using EmployeeManagementSystem.logic.services;

namespace EmployeeManagementSystem.UI
{
    internal class EmployeeManagement
    {
        EmployeeService service = new EmployeeService();
        public void Start()
        {
            while (true)
            {
                Console.WriteLine("\n **************************************************\n");
                Console.WriteLine("Select Which operation you want to Perform");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. Display All Employees");
                Console.WriteLine("3. Delete Employee");
                Console.WriteLine("4.Update Employee");
                Console.WriteLine("4. Exit");
                Console.WriteLine("\n **************************************************\n");


                Console.Write("\n\nEnter Your Choice  :   ");
                //try { 
                    int n = Convert.ToInt32(Console.ReadLine());
                


                switch (n)
                {
                    case 1:
                        AddEmployee();
                        Console.WriteLine("***Employee Added Successfully*** \n ");
                        break;
                    case 2:
                        Console.WriteLine("\n\n Display All Employees\n\n");
                        DisplayAllEmployees();
                        break;
                    case 3:
                        DeleteEmployee();
                        break;
                    case 4:
                        UpdateEmployee();
                        break;
                    case 5:
                        Console.WriteLine("Exiting the Program");
                        return;
                    default:
                        Console.WriteLine("Select a Valid Option");
                        break;

                }
                //}
                //catch (Exception e)
                //{
                //    Console.WriteLine("Enter Valid Input" + e);
                //}
            }
        }

        public void AddEmployee()
        {
            Console.Write("Enter Employee Name  ");
            string? strName = Console.ReadLine();

            Console.Write("Enter employee Department   ");
            string? strDepartment = Console.ReadLine();


            Console.Write("Enter Employee Email  ");
            string? strEmail = Console.ReadLine();

            Console.Write("Enter Employee Salary  ");
            int nSalary = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Employee Age  ");
            int nAge = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Employee Location  ");
            string? strLocation = Console.ReadLine();

            service.AddNewEmployee(strName, strDepartment, strEmail, nSalary, nAge, strLocation);

            Console.WriteLine("\n\n" + $"Employee Name: {strName}, Department: {strDepartment}, Email ID: {strEmail}, " +
                $"Employee Salary: {nSalary},Employee Age: {nAge}, Employee Location: {strLocation}\n");

        }

        public void DisplayAllEmployees()
        {
            var employees = service.DisplayAllEmployees();
            foreach (var emp in employees)
            {
                Console.WriteLine($"Employee Name: {emp.name},\nEmployee Department: {emp.department}, \nMail Id:{emp.email}, \nEmployee Age: {emp.age}, " +
                        $"\nEmployee Salary: {emp.salary},  \nEmployee Location: {emp.location}\n\n");
            }

        }

        public void DeleteEmployee()
        {
            Console.Write("Enter Employee Name to Delete:  ");
            string? strName = Console.ReadLine();
             
            bool status = service.DeleteEmployee(strName);

            if (status)
            {
                Console.WriteLine($"Employee {strName} deleted successfully.");
            }
            else
            {
                Console.WriteLine($"Employee {strName} not found.");
            }
        }

        public void UpdateEmployee()
        {
            bool status = false;
            Console.Write("Enter Employee Name to Update:  ");
            string? strName = Console.ReadLine();

            Console.Write("Enter new Department: ");
            string? strDepartment = Console.ReadLine();
            Console.Write("Enter new Email: ");
            string? strEmail = Console.ReadLine();
            Console.Write("Enter new Salary: ");
            int nSalary = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter new Age: ");
            int nAge = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter new Location: ");
            string? strLocation = Console.ReadLine();

            service.UpdateEmployeeInformation(strName, strDepartment, strEmail, nSalary, nAge, strLocation);


            if (status)
            {
                Console.WriteLine($"Employee {strName} Updated successfully.");
            }
            else
            {
                Console.WriteLine($"Employee {strName} not found.");
            }

        }
    }

}

