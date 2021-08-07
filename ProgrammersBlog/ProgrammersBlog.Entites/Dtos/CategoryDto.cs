using ProgrammersBlog.Core.Entities.Abstract;
using ProgrammersBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgrammersBlog.Entites.Dtos
{
    public class CategoryDto : DtoGetBase
    {
        public Category Category { get; set; }
    }
}
