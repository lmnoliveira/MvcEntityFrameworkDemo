using DomainModelsDemo;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Data.SqlClient;
using EntityFrameworkDemo.Repositories.Interfaces;
using Common.Extensions;


namespace EntityFrameworkDemo.Repositories
{
    public class CondominiumRepository : RepositoryBase<Condominium>, ICondominiumRepository
    {
        //public DbSet<Condominium> Condominiums { get; set; }

        public IEnumerable<Condominium> Read(IEnumerable<int> ids)
        {
            return Set<Condominium>().Where(c => ids.Contains(c.Id)).ToList();
        }

        public IEnumerable<Condominium> Read(long subsidiaryId, string codeName = null, short pageNumber = 0, short rowsPerPage = 0, IEnumerable<KeyValuePair<string, SortOrder>> orderBy = null)
        {
            IQueryable<Condominium> query = GetReadQuery(Set<Condominium>(), subsidiaryId, codeName, pageNumber, rowsPerPage, orderBy);
            return query.ToList();
        }

        public static IQueryable<Condominium> GetReadQuery(IQueryable<Condominium> query, long subsidiaryId, string codeName, short pageNumber, short rowsPerPage, IEnumerable<KeyValuePair<string, SortOrder>> orderBy)
        {
            if (query == null) query = Enumerable.Empty<Condominium>().AsQueryable();
            query = query.Where(c => c.SubsidiaryId == subsidiaryId);
            if (!string.IsNullOrWhiteSpace(codeName)) query = query.Where(c => c.Code.Contains(codeName) || c.Name.Contains(codeName));
            if (orderBy != null && orderBy.Count() > 0) foreach (var o in orderBy) query = query.OrderBy(o.Key, o.Value == SortOrder.Ascending);
            query = query.Skip(pageNumber).Take(rowsPerPage);
            return query;
        }

        public IEnumerable<Condominium> Delete(IEnumerable<int> ids)
        {
            var deletedCondominiums = Set<Condominium>().RemoveRange(Read(ids));
            SaveChanges();
            return deletedCondominiums;
        }
    }
}