using HostBooks.Data.Models;
using HostBooks.Repos.Interfaces;
using HostBooks.Repos.UnitOfWorkInterface;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace HostBooks.Repos.Services
{
    public class BulkRecordService : IBulkRecords
    {
        private readonly UnitOfWork _unitOfWork;

        public BulkRecordService(IUnitOfWork _uow)
        {
            this._unitOfWork = _uow as UnitOfWork;
        }
        public IEnumerable<Bulkrecord> GetRecordsByPagination(int index, int end)
        {
            
            return _unitOfWork.Repository<Bulkrecord>().ExecuteWithStoreProcedure("exec usp_getBulkRecord @start, @end",
                                                        new SqlParameter("start", SqlDbType.Int) { Value = index },
                                                        new SqlParameter("end", SqlDbType.Int) { Value = end });
        }
    }
}
