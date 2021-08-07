using ProgrammersBlog.Core.Entities.Abstract;
using ProgrammersBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entites.Dtos
{
    public class UserListDto : DtoGetBase
    {
        public IList<User> Users { get; set; }

    }
}
