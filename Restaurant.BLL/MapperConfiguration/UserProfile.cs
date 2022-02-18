using AutoMapper;
using Restaurant.BLL.DTOs;
using Restaurant.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.BLL.MapperConfiguration
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            this.CreateMap<User, UserDTO>();
            this.CreateMap<UserDTO, User>();
        }
    }
}
