using ModelLayer.DTO;
using RepositoryLayer.EmEntity;
using BusinessLayer.Interface;
using RepositoryLayer.Interface;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer.Service
{
    public class BL : IBL
    {
        private readonly IRL _registerBl;

        public BL(IRL registerBl)
        {
            _registerBl = registerBl;
        }

        public UserEntity RegisterEm(Register register)
        {
            return _registerBl.RegisterEm(register);
        }

        public List<UserEntity> GetEmployeesSortedBySalary()
        {
            var employees = _registerBl.GetEmployees();
            return employees?.OrderBy(e => e.Salary).ToList() ?? new List<UserEntity>();
        }

        public List<UserEntity> GetEmployeesByDepartment(string department)
        {
            var employees = _registerBl.GetEmployees();
            return employees?.Where(e => e.Department == department).ToList() ?? new List<UserEntity>();
        }

        public UserEntity GetEmployeeById(int id)
        {
            var employees = _registerBl.GetEmployees();
            return employees?.FirstOrDefault(e => e.EmployeeId == id);
        }

        public UserEntity UpdateEmployee(int id, Register updatedDetails)
        {
            return _registerBl.UpdateEmployee(id, updatedDetails);
        }
    }
}
