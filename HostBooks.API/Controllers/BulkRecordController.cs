using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HostBooks.Data.Models;
using HostBooks.Repos.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HostBooks.API.Controllers
{
    public class BulkRecordController : ControllerBase
    {
        private readonly IBulkRecords _bulkRecordService;

        public BulkRecordController(IBulkRecords bulkRecord)
        {
            this._bulkRecordService = bulkRecord;
        }

        [HttpGet]
        [Route("GetBulkRecord")]
        public ActionResult<IEnumerable<Bulkrecord>> GetAllUserBySP(int fisrt, int last)
        {
            var result = _bulkRecordService.GetRecordsByPagination(fisrt,last);
            return Ok(result);
        }
    }
}