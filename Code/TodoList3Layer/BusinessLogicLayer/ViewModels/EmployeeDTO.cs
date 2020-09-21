using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLogicLayer.ViewModels
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public Role IdRole { get; set; }
        public DateTime? DateCreated { get; set; }

        public enum Role
        {
            NhanVien = 2,
            GiamDoc = 1
        }
    }
}
