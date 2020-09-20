using DataAccessLayer.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Interfaces
{
    public interface IEmployeeRepository
    {
        IEnumerable<EmployeeEntity> getAll();
    }
}
