using AutoMapper;
using BusinessLogicLayer.ViewModels;
using DataAccessLayer.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EmployeeDTO, EmployeeEntity>();
            CreateMap<EmployeeEntity, EmployeeDTO>();
        }
    }
}
