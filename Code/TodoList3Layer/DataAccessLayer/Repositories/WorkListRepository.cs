using DataAccessLayer.Context;
using DataAccessLayer.Entitys;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace DataAccessLayer.Repositories
{
    public class WorkListRepository : IWorkListRepository
    {
        private TodoListDBContext todoListDBContext = TodoListDBContext.getInstance();

        public WorkList addEmployee(int idWorkList, int idEmployee)
        {
            WorkListEmployee workListEmployee = new WorkListEmployee();
            workListEmployee.IdWorkList = idWorkList;
            workListEmployee.IdEmployee = idEmployee;
            var result = todoListDBContext.WorkListEmployee.Add(workListEmployee);
            todoListDBContext.SaveChanges();
            return todoListDBContext.WorkList.Find(idWorkList);
        }

        public IEnumerable<WorkList> getAllByIdEmployee(int id)
        {
            var result = from wl in todoListDBContext.WorkList
                         join wle in todoListDBContext.WorkListEmployee on wl.Id equals wle.IdWorkList
                         where wle.IdEmployee == id
                         select wl;
            return result;
        }

        public IEnumerable<WorkList> getPublicByIdEmployee(int id)
        {
            var result = from wl in todoListDBContext.WorkList
                         join wle in todoListDBContext.WorkListEmployee on wl.Id equals wle.IdWorkList
                         where wle.IdEmployee == id && wl.IdWorkListStatus == 1
                         select wl;
            return result;
        }

        public bool remove(int id)
        {
            var results = todoListDBContext.WorkList.Find(id);
            todoListDBContext.WorkList.Remove(results);
            todoListDBContext.SaveChanges();
            if (todoListDBContext.WorkList.Find(id) != null)
            {
                return true;
            }
            return false;
        }

        public WorkList save(WorkList workList, int idEmployee)
        {
            if (workList.Id == 0)
            {
                var result = todoListDBContext.WorkList.Add(workList);
                todoListDBContext.SaveChanges();
                int idNewWorkList = todoListDBContext.WorkList.Select(wl => wl.Id).Max();
                WorkListEmployee workListEmployee = new WorkListEmployee();
                workListEmployee.IdEmployee = idNewWorkList;
                workListEmployee.IdWorkList = idNewWorkList;
                todoListDBContext.WorkListEmployee.Add(workListEmployee);
                todoListDBContext.SaveChanges();
                return result.Entity;
            }
            else
            {
                WorkList findResult = todoListDBContext.WorkList.Find(workList.Id);
                findResult.WorkListName = workList.WorkListName;
                findResult.IdWorkListStatus = workList.IdWorkListStatus;
                todoListDBContext.SaveChanges();
                return todoListDBContext.WorkList.Find(workList.Id);
            }
        }
    }
}
