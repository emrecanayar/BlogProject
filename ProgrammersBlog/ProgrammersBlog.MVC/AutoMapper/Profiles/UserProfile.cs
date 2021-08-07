using AutoMapper;
using ProgrammersBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.Entites.Dtos;

namespace ProgrammersBlog.MVC.AutoMapper.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserAddDto, User>();
            CreateMap<User, UserUpdateDto>();
            CreateMap<UserUpdateDto, User>();
        }
    }
}
