using BusinessLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.DTO;
using RepositoryLayer.EmEntity;
using System.Collections.Generic;

namespace EmRegister.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeRegisterController : ControllerBase
    {
        private readonly IBL _bl;

        public EmployeeRegisterController(IBL bl)
        {
            _bl = bl;
        }

        [HttpPost("Register")]
        public IActionResult RegisterEm(Register register)
        {
            var user = _bl.RegisterEm(register);
            return Ok(user);
        }

        [HttpGet("Sort")]
        public IActionResult GetEmployeesSortedBySalary()
        {
            var employees = _bl.GetEmployeesSortedBySalary();
            return employees.Count == 0 ? NotFound("No employees found.") : Ok(employees);
        }

        [HttpGet("Department/{department}")]
        public IActionResult GetEmployeesByDepartment(string department)
        {
            var employees = _bl.GetEmployeesByDepartment(department);
            return employees.Count == 0 ? NotFound($"No employeess found in {department} department.") : Ok(employees);
        }

        [HttpPut("UpdateEmployee/{id}")]
        public IActionResult UpdateEmployee(int id, Register updatedDetails)
        {
            var updatedEmployee = _bl.UpdateEmployee(id, updatedDetails);
            return updatedEmployee == null
                ? NotFound($"Employee with ID {id} not found.")
                : Ok(updatedEmployee);
        }
    }
}
