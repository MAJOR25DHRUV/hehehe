using ModelLayer.DTO;
using RepositoryLayer.EmEntity;
using RepositoryLayer.Interface;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace RepositoryLayer.Service
{
    public class RL : IRL
    {
        private readonly string _filePath = "employee.json";

        public UserEntity RegisterEm(Register register)
        {
            var employees = GetEmployees();

            var newEmployee = new UserEntity
            {
                EmployeeId = employees.Any() ? employees.Max(e => e.EmployeeId) + 1 : 1,
                Name = register.Name,
                Department = register.Department,
                Salary = register.Salary
            };

            employees.Add(newEmployee);
            File.WriteAllText(_filePath, JsonSerializer.Serialize(employees));

            return newEmployee;
        }

        public List<UserEntity> GetEmployees()
        {
            if (!File.Exists(_filePath))
            {
                return new List<UserEntity>();
            }

            var jsonData = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<UserEntity>>(jsonData) ?? new List<UserEntity>();
        }

        public UserEntity UpdateEmployee(int id, Register updatedDetails)
        {
            var employees = GetEmployees();
            var employee = employees.FirstOrDefault(e => e.EmployeeId == id);

            if (employee == null)
            {
                return null;
            }


            employee.Name = updatedDetails.Name;
            employee.Department = updatedDetails.Department;
            employee.Salary = updatedDetails.Salary;

            
            File.WriteAllText(_filePath, JsonSerializer.Serialize(employees));

            return employee;
        }
    }
}
