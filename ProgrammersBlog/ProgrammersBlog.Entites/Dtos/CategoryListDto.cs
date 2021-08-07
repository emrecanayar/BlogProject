using ProgrammersBlog.Core.Entities.Abstract;
using ProgrammersBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgrammersBlog.Entites.Dtos
{
    public class CategoryListDto : DtoGetBase
    {
        public IList<Category> Categories { get; set; }
    }
}
