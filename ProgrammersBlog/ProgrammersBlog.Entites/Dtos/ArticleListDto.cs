using ProgrammersBlog.Core.Entities.Abstract;
using ProgrammersBlog.Core.Utilities.Results.ComplexTypes;
using ProgrammersBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgrammersBlog.Entites.Dtos
{
    public class ArticleListDto : DtoGetBase
    {
        public IList<Article> Articles { get; set; }

        public int? CategoryId { get; set; }



    }


}
