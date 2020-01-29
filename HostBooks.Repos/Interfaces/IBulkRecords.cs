using HostBooks.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HostBooks.Repos.Interfaces
{
    public interface IBulkRecords
    {
        IEnumerable<Bulkrecord> GetRecordsByPagination(int index, int last);
    }
}
