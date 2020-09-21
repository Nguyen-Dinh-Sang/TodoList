using DataAccessLayer.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Interfaces
{
    public interface IEmployeeRepository
    {
        IEnumerable<EmployeeEntity> getAll();

        EmployeeEntity login(string email, string password);

        bool checkEmailExists(string email);

        EmployeeEntity getById(int id);

        EmployeeEntity save(EmployeeEntity employee);
    }
}
