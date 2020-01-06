using EntityFrameworkDemo.DomainModels;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace EntityFrameworkDemo.Repositories.Interfaces
{
    public interface IZoneRepository :  IRepository<Zone>
    {
        IEnumerable<Zone> Delete(IEnumerable<int> ids);
        IEnumerable<Zone> Read(IEnumerable<int> ids);
        IEnumerable<Zone> Read(int? condominiumId = null, short pageNumber = 0, short rowsPerPage = 0, IEnumerable<KeyValuePair<string, SortOrder>> orderBy = null);
    }
}