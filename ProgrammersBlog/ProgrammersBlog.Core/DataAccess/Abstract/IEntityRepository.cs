using ProgrammersBlog.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Core.DataAccess.Abstract
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetAsyncV2(IList<Expression<Func<T, bool>>> predicates, IList<Expression<Func<T, object>>> includeProperties);

        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties);
        Task<IList<T>> GetAllAsyncV2(IList<Expression<Func<T, bool>>> predicates, IList<Expression<Func<T, object>>> includeProperties);

        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<IList<T>> SearchAsync(IList<Expression<Func<T, bool>>> predicates, params Expression<Func<T, object>>[] includeProperties);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate); //Veritabanına kaydetmek istediğimiz nesneleri daha önceden varmı sorgulamak için oluşturulmuştur.

        Task<int> CountAsync(Expression<Func<T, bool>> predicate = null); //Bir nesneden toplam kaç tane var onları elde etmek için oluşturulmuştur.


    }
}
