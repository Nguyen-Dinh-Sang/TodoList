using DataAccessLayer.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Interfaces
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> getAll();

        Employee login(string email, string password);

        bool checkEmailExists(string email);

        Employee getById(int id);

        Employee save(Employee employee);

        IEnumerable<Employee> getByIdWorkList(int id);
    }
}
