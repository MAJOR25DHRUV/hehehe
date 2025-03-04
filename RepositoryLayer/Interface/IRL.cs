using ModelLayer.DTO;
using RepositoryLayer.EmEntity;
using System.Collections.Generic;

namespace RepositoryLayer.Interface
{
    public interface IRL
    {
        UserEntity RegisterEm(Register register);
        List<UserEntity> GetEmployees();
        UserEntity UpdateEmployee(int id, Register updatedDetails);
    }
}
