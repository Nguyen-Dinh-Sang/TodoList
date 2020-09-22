using DataAccessLayer.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Interfaces
{
    public interface IWorkListRepository
    {
        IEnumerable<WorkList> getAllByIdEmployee(int id);

        IEnumerable<WorkList> getPublicByIdEmployee(int id);

        // sửa tên vs tạo mới
        WorkList save(WorkList employee);

        // thêm người vào danh sách
    }
}
