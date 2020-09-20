using BusinessLogicLayer.ViewModels;
using DataAccessLayer.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Mapping
{
    public class EmployeeMapping
    {
		public EmployeeDTO toDTO(EmployeeEntity entity)
		{
			EmployeeDTO dto = new EmployeeDTO();
			dto.Id = entity.Id;
			dto.Email = entity.Email;
			dto.Password = entity.Password;
			dto.FullName = entity.FullName;
			dto.PhoneNumber = entity.PhoneNumber;
			dto.IdRole = entity.IdRole;
			dto.DateCreated = entity.DateCreated;
			return dto;
		}

		public List<EmployeeDTO> toDTOs(IEnumerable<EmployeeEntity> entitys)
		{
			List<EmployeeDTO> dtos = new List<EmployeeDTO>();
			foreach (var entity in entitys)
			{
				dtos.Add(this.toDTO(entity));
			}
			return dtos;
		}
	}
}
