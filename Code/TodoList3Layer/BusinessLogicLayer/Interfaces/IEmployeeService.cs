using BusinessLogicLayer.ViewModels;
using DataAccessLayer.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDTO> getAll();

        EmployeeDTO login(string email, string password);

        bool checkEmailExists(string email);

        EmployeeDTO getById(int id);

        EmployeeDTO save(EmployeeDTO employee);

        IEnumerable<EmployeeDTO> getByIdWorkList(int id);
    }
}
