using AutoMapper;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entites.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgrammersBlog.Business.AutoMapper.Profiles
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<ArticleAddDto, Article>().ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<ArticleUpdateDto, Article>().ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<Article, ArticleUpdateDto>();
        }
    }
}
