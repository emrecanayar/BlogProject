using ProgrammersBlog.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace ProgrammersBlog.Entities.Concrete
{
    public class Article : EntityBase, IEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Thumbnail { get; set; }
        public DateTime Date { get; set; }
        public int ViewCount { get; set; } = 0;
        public int CommentCount { get; set; } = 0;
        public string SeoAuthor { get; set; }
        public string SeoDescription { get; set; }
        public string SeoTags { get; set; }
        public int CategoryId { get; set; } //Bu makalenin kategorisi
        public Category Category { get; set; } //Kategori ile ilgili verilere ulaşmak için navigation property.
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<Comment> Comments { get; set; } //Bir makalenin birden fazla yorumu olabilir.
    }
}