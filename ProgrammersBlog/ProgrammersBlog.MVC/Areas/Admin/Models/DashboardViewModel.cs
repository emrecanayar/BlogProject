using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entites.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammersBlog.MVC.Areas.Admin.Models
{
    public class DashboardViewModel
    {
        public int CategoriesCount { get; set; }
        public int ArticlesCount { get; set; }
        public int CommentsCount { get; set; }
        public int UsersCount { get; set; }
        public ArticleListDto Articles { get; set; }
    }
}
