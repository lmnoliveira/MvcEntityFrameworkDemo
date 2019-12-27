using EntityFrameworkDemo01.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace EntityFrameworkDemo01.Repositories
{
    public class CondominiumRepository : Repository<CondominiumModel>
    {
        public IEnumerable<CondominiumModel> Read(IEnumerable<int> ids)
        {
            return Set<CondominiumModel>().Where(c => ids.Contains(c.Id)).ToList();
        }

        public IEnumerable<CondominiumModel> Read(long subsidiaryId,
                                                  string code_name = null, 
                                                  short pageNumber = 0, 
                                                  short rowsPerPage = 0)
        {
            DbSet<CondominiumModel> query = Set<CondominiumModel>();
            query.Where(c => c.SubsidiaryId == subsidiaryId);
            if (!string.IsNullOrWhiteSpace(code_name)) query.Where(c => c.Code.Contains(code_name) || c.Name.Contains(code_name));
            query.Skip(pageNumber).Take(rowsPerPage);
            return query.ToList();
        }

        public IEnumerable<CondominiumModel> Delete(IEnumerable<int> ids)
        {
            return  Set<CondominiumModel>().RemoveRange(Read(ids));
        }
    }
}