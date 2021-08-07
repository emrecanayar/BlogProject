using ProgrammersBlog.Core.Entities.Abstract;
using ProgrammersBlog.Core.Utilities.Results.ComplexTypes;
using ProgrammersBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgrammersBlog.Entites.Dtos
{
    public class ArticleDto : DtoGetBase
    {
        public Article Article { get; set; }

    }
}
