using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProgrammersBlog.Entites.Dtos;

namespace ProgrammersBlog.MVC.Models
{
    public class ArticleDetailViewModel
    {
        public ArticleDto ArticleDto { get; set; }
        public ArticleDetailRightSideBarViewModel ArticleDetailRightSideBarViewModel { get; set; }
    }
}
