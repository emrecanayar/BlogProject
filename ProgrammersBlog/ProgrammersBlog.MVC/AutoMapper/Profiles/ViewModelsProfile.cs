using AutoMapper;
using ProgrammersBlog.Entites.Dtos;
using ProgrammersBlog.MVC.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProgrammersBlog.Entities.Concrete;

namespace ProgrammersBlog.MVC.AutoMapper.Profiles
{
    public class ViewModelsProfile : Profile
    {
        public ViewModelsProfile()
        {
            CreateMap<ArticleAddViewModel, ArticleAddDto>();
            CreateMap<ArticleUpdateDto, ArticleUpdateViewModel>().ReverseMap();
            CreateMap<ArticleRightSideBarWidgetOptions, ArticleRightSideBarWidgetOptionsViewModel>();

        }
    }
}
