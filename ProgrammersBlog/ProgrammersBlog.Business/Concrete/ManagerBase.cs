using AutoMapper;
using ProgrammersBlog.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Business.Concrete
{
    public class ManagerBase
    {
        protected IUnitOfWork UnitOfWork { get; }
        protected IMapper Mapper { get; }

        public ManagerBase(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }
    }
}
