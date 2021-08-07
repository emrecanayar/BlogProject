using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProgrammersBlog.Entites.Dtos;
using ProgrammersBlog.Entities.Concrete;

namespace ProgrammersBlog.MVC.Models
{
    public class ArticleDetailRightSideBarViewModel
    {
        public string Header { get; set; }
        public ArticleListDto ArticleListDto { get; set; }
        public User User { get; set; }
    }
}
