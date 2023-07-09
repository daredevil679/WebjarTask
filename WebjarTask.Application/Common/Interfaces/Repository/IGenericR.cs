using ErrorOr;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace WebjarTask.Application.Common.Interfaces.Repository
{
    public interface IGenericR<T> where T : class
    {
        Task<ErrorOr<bool>> Exist(Expression<Func<T, bool>>? Predicate, bool IgnoreQuerryFilter = false);
        Task<ErrorOr<T2>> FindFirstOrDefaultAsync<T2>(
            Expression<Func<T, bool>>? Predicate
            , Func<IQueryable<T>, IIncludableQueryable<T, object>>? Include
            , bool NoTracking, bool IgnoreQuerryFilter = false);
        Task<ErrorOr<List<T2>>> GetAllWithCondition<T2>(
            Expression<Func<T, bool>>? Predicate,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? Include,
            bool NoTracking,
            Expression<Func<T2, object>>? OrderField = null,
            bool Descending = false,
            bool IgnoreQuerryFilter = false);
        Task<ErrorOr<T>> Insert(T Obj, Func<IQueryable<T>, IIncludableQueryable<T, object>>? Include = null, bool IdentityInsert = false);
        Task<ErrorOr<bool>> Update(T Obj);
        Task<ErrorOr<bool>> UpdateRange(List<T> ObjList);
        Task<ErrorOr<bool>> DeletePermanent(T Entity);
        Task<ErrorOr<bool>> RemoveWithCondition(Expression<Func<T, bool>>? Predicate, bool IgnoreQuerryFilter = false);
        Task<ErrorOr<bool>> AddRange(List<T> Records);

    }
}
