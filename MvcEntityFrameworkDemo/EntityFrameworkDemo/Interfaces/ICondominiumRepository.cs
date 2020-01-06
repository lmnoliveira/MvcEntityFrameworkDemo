using EntityFrameworkDemo.DomainModels;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace EntityFrameworkDemo.Repositories.Interfaces
{
    public interface ICondominiumRepository :  IRepository<Condominium>
    {
        IEnumerable<Condominium> Delete(IEnumerable<int> ids);
        IEnumerable<Condominium> Read(IEnumerable<int> ids);
        IEnumerable<Condominium> Read(long subsidiaryId, string code_name = null, short pageNumber = 0, short rowsPerPage = 0, IEnumerable<KeyValuePair<string, SortOrder>> orderBy = null);
    }
}