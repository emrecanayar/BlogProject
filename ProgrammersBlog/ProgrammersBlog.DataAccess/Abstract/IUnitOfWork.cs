using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.DataAccess.Abstract
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        //Repositorylerin interfacelerini burada bir isim belirleyerek çağırıyoruz.

        IArticleRepository Articles { get; }
        ICategoryRepository Categories { get; }
        ICommentRepository Comments { get; }
       
        Task<int> SaveAsync();
    }
}
