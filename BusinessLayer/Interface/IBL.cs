using ModelLayer.DTO;
using RepositoryLayer.EmEntity;
using System.Collections.Generic;

namespace BusinessLayer.Interface
{
    public interface IBL
    {
        UserEntity RegisterEm(Register register);
        List<UserEntity> GetEmployeesSortedBySalary();
        List<UserEntity> GetEmployeesByDepartment(string department);
        UserEntity GetEmployeeById(int id);
        UserEntity UpdateEmployee(int id, Register updatedDetails);
    }
}
