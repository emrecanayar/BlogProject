using ProgrammersBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammersBlog.MVC.Models
{
    public class RightSideBarViewModel
    {
        public IList<Category> Categories { get; set; }
        public IList<Article> Articles { get; set; }

    }
}
