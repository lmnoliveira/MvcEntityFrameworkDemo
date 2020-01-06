using EntityFrameworkDemo.DomainModels;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Data.SqlClient;
using EntityFrameworkDemo.Repositories.Interfaces;
using Common.Extensions;


namespace EntityFrameworkDemo.Repositories
{
    public class ZoneRepository : RepositoryBase<Zone>, IZoneRepository
    {
        public DbSet<Zone> Zones { get; set; }

        public ZoneRepository() : base()    
        {
        }

        public ZoneRepository(string nameOrConnectionString) //: base(nameOrConnectionString)
        {
        }

        public IEnumerable<Zone> Read(IEnumerable<int> ids)
        {
            return Zones.Where(c => ids.Contains(c.Id)).ToList();
        }

        public IEnumerable<Zone> Read(int? condominiumId, short pageNumber = 0, short rowsPerPage = 0, IEnumerable<KeyValuePair<string, SortOrder>> orderBy = null)
        {
            IQueryable<Zone> query = GetReadQuery(Zones, condominiumId, pageNumber, rowsPerPage, orderBy);
            return query.ToList();
        }

        public static IQueryable<Zone> GetReadQuery(IQueryable<Zone> query, int? condominiumId, short pageNumber, short rowsPerPage, IEnumerable<KeyValuePair<string, SortOrder>> orderBy)
        {
            if (query == null) query = Enumerable.Empty<Zone>().AsQueryable();
            //if (condominiumId.HasValue) query = query.Where(z => z.Condominium.Id == condominiumId);
            if (orderBy != null && orderBy.Count() > 0) foreach (var o in orderBy) query = query.OrderBy(o.Key, o.Value == SortOrder.Ascending);
            query = query.Skip(pageNumber).Take(rowsPerPage);
            return query;
        }

        public IEnumerable<Zone> Delete(IEnumerable<int> ids)
        {
            var deletedZones = Zones.RemoveRange(Read(ids));
            SaveChanges();
            return deletedZones;
        }
    }
}