using AutoMapper;
using SecurityUser.Core.DTOs;
using SecurityUser.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecurityUser.Infrastructure.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        { 
            CreateMap<UserDTO, User>();
            CreateMap <User,UserDTO>();
            CreateMap<User, UserLoginDTO>().ReverseMap();


            CreateMap<Role, RoleDTO>().ReverseMap();
            CreateMap<Permission, PermissionDTO>();
          


        }
    }
}
