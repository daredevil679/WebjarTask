using ErrorOr;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore.Query;
using WebjarTask.Domain.Errors;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;
using WebjarTask.Application.Common.Interfaces.Repository;

namespace WebjarTask.Infrastructure.Persistence.Repository
{
    public sealed class GenericR<T> : IGenericR<T> where T : class
    {
        private WebjarProductDbContext _db;
        private readonly IMapper _mapper;
        private DbSet<T> table;
        public GenericR(WebjarProductDbContext db, IMapper imapper)
        {
            _db = db;
            _mapper = imapper;
            table = _db.Set<T>();
        }

        public async Task<ErrorOr<bool>> Exist(Expression<Func<T, bool>>? Predicate, bool IgnoreQuerryFilter = false)
        {
            try
            {
                IQueryable<T> query = table;
                if (Predicate != null)
                {
                    query = query.Where(Predicate);
                }
                query = IgnoreQuerryFilter ? query.IgnoreQueryFilters() : query;
                var res = await query.AnyAsync();
                var x = res;
                return res;
            }
            catch (Exception ex)
            {
                return VErrors.CRUD.Read;
            }

        }
        public async Task<ErrorOr<T2>> FindFirstOrDefaultAsync<T2>(
            Expression<Func<T, bool>>? Predicate
            , Func<IQueryable<T>, IIncludableQueryable<T, object>>? Include
            , bool NoTracking, bool IgnoreQuerryFilter = false)
        {

            try
            {
                IQueryable<T> query = table;
                if (NoTracking)
                {
                    query = query.AsNoTracking();
                }
                if (Include != null)
                {
                    query = Include(query);
                }
                if (Predicate != null)
                {
                    query = query.Where(Predicate);
                }
                query = IgnoreQuerryFilter ? query.IgnoreQueryFilters() : query;
                var resp = await query.ProjectToType<T2>(_mapper.Config).FirstOrDefaultAsync();
                return resp;
            }
            catch (Exception ex)
            {
                return VErrors.CRUD.Read;
            }

        }
        public async Task<ErrorOr<List<T2>>> GetAllWithCondition<T2>(
            Expression<Func<T, bool>>? Predicate,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? Include,
            bool NoTracking,
            Expression<Func<T2, object>>? OrderField = null,
            bool Descending = false,
            bool IgnoreQuerryFilter = false)
        {

            try
            {
                IQueryable<T> query = table;
                if (NoTracking)
                {
                    query = query.AsNoTracking();
                }
                if (Include != null)
                {
                    query = Include(query);
                }
                if (Predicate != null)
                {
                    query = query.Where(Predicate);
                }
                query = IgnoreQuerryFilter ? query.IgnoreQueryFilters() : query;
                var resp = await query.ProjectToType<T2>(_mapper.Config).ToListAsync();
                if (OrderField != null)
                {
                    resp = Descending ? resp.AsQueryable().OrderByDescending(OrderField).ToList() : resp.AsQueryable().OrderBy(OrderField).ToList();
                }
                return resp;
            }
            catch (Exception ex)
            {
                return VErrors.CRUD.Read;
            }

        }
        public async Task<ErrorOr<T>> Insert(T Obj, Func<IQueryable<T>, IIncludableQueryable<T, object>>? Include=null, bool IdentityInsert = false)
        {
            await using var transaction = await _db.Database.BeginTransactionAsync();
            try
            {
                if (IdentityInsert == true)
                {
                    var tableName = typeof(T).Name.Replace("PM", "");
                    string queryOn = $"SET IDENTITY_INSERT dbo.{tableName} ON";
                    await _db.Database.ExecuteSqlRawAsync(queryOn);
                    await table.AddAsync(Obj);
                    await _db.SaveChangesAsync();
                    string queryOff = $"SET IDENTITY_INSERT dbo.{tableName} OFF";
                    await _db.Database.ExecuteSqlRawAsync(queryOff);
                    await transaction.CommitAsync();
                    return Obj;
                }
                if (Include != null)
                {
                    Include(table);
                }
                await table.AddAsync(Obj);
                await _db.SaveChangesAsync();
                await transaction.CommitAsync();
                return Obj;
            }
            catch (Exception ex)
            {
                await transaction.DisposeAsync();
                return VErrors.CRUD.Create;
            }
        }
        public async Task<ErrorOr<bool>> Update(T Obj)
        {
            try
            {
                table.Update(Obj);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return VErrors.CRUD.Update;
            }
        }
        public async Task<ErrorOr<bool>> UpdateRange(List<T> ObjList)
        {
            try
            {
                table.UpdateRange(ObjList);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return VErrors.CRUD.Update;
            }
        }
        public async Task<ErrorOr<bool>> DeletePermanent(T Entity)
        {
            try
            {
                table.Remove(Entity);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return VErrors.CRUD.Delete;
            }
        }
        public async Task<ErrorOr<bool>> RemoveWithCondition(Expression<Func<T, bool>>? Predicate, bool IgnoreQuerryFilter = false)
        {
            try
            {
                IQueryable<T> query = table;
                if (Predicate != null)
                {
                    query = query.Where(Predicate);
                }
                if (IgnoreQuerryFilter == true)
                {
                    query = query.IgnoreQueryFilters();
                }
                table.RemoveRange(query);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return VErrors.CRUD.Delete;
            }
        }
        public async Task<ErrorOr<bool>> AddRange(List<T> Records)
        {
            try
            {
                IQueryable<T> query = table;
                table.AddRange(Records);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return VErrors.CRUD.Create;
            }
        }
    }
}
