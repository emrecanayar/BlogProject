using ProgrammersBlog.Entites.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammersBlog.MVC.Models
{
    public class ArticleSearchViewModel
    {
        public ArticleListDto ArticleListDto { get; set; }
        public string Keyword { get; set; }
    }
}
