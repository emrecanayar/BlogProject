using ProgrammersBlog.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgrammersBlog.Entities.Concrete
{
    public class Comment : EntityBase, IEntity
    {
        public string Text { get; set; }
        public int ArticleId { get; set; } //Bu yorum hangi makaleye eklenmiş.
        public Article Article { get; set; } //Article(Makale) özelliklerine veya bilgilerine ulaşmak için.
    }
}
