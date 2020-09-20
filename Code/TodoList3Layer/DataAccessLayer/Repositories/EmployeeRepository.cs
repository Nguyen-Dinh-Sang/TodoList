using DataAccessLayer.Context;
using DataAccessLayer.Entitys;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private  TodoListDBContext todoListDBContext = TodoListDBContext.getInstance();
        public IEnumerable<EmployeeEntity> getAll()
        {
            return todoListDBContext.Employee;
        }
    }
}
