using DomainModelsDemo;
using EntityFrameworkDemo.Repositories;
using EntityFrameworkDemo.Repositories.Interfaces;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace MvcEntityFrameworkDemoTest.Mocks
{
    public class CondominiumMockRepository : ICondominiumRepository
    {
        public IList<Condominium> Collection { get; }

        public CondominiumMockRepository()
        {
            Collection = new List<Condominium>();
        }

        public Condominium Create(Condominium c)
        {
            c.Id = Collection.Count() + 1;
            Collection.Add(c);
            return c;
        }

        public IEnumerable<Condominium> Delete(IEnumerable<int> ids)
        {
            List<Condominium> deletedCondominiums = new List<Condominium>();
            (from c in Collection where ids.Contains(c.Id) select c).ToList().ForEach(c => { deletedCondominiums.Add(c); Collection.Remove(c); });
            return deletedCondominiums;
        }

        public IEnumerable<Condominium> Read(IEnumerable<int> ids)
        {
            return from c in Collection where ids.Contains(c.Id) select c;
        }

        public IEnumerable<Condominium> Read(long subsidiaryId, string codeName = null, short pageNumber = 0, short rowsPerPage = 0, IEnumerable<KeyValuePair<string, SortOrder>> orderBy = null)
        {
            IQueryable<Condominium> query = Collection.AsQueryable();
            query = CondominiumRepository.GetReadQuery(query, subsidiaryId, codeName, pageNumber, rowsPerPage, orderBy);
            return query.ToList();
        }

        public void Update(Condominium c)
        {
            Collection.Where(cItem => cItem.Id == c.Id).ToList().ForEach(cItem => Collection[Collection.IndexOf(cItem)] = c);
        }
    }
}