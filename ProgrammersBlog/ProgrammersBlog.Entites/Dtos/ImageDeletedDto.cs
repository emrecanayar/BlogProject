using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entites.Dtos
{
    public class ImageDeletedDto
    {
        public string FullName { get; set; }
        public string Extension { get; set; }
        public string FullPath { get; set; }
        public long Size { get; set; }
    }
}
