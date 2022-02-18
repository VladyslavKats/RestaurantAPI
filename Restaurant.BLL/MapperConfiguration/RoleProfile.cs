using AutoMapper;
using Restaurant.BLL.DTOs;
using Restaurant.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.BLL.MapperConfiguration
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            this.CreateMap<Role, RoleDTO>();
            this.CreateMap<RoleDTO, Role>();
        }
    }
}
