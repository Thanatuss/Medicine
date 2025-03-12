using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using Pharmecy.Domain.Entities;
using Pharmecy.Domain.Interfaces;

namespace Pharmecy.Infrastructure.Repository
{
    public class LogRepository : ILogRepository
    {
        private readonly IMongoCollection<Log> _log;
        public LogRepository(IMongoCollection<Log> log)
        {
            _log = log;
        }
        public async Task<IEnumerable<Log>> GetLogsAsync()
        {
            return await _log.Find(x => true).ToListAsync();
        }

        public async Task SaveLogAsync(Log log)
        {
            await _log.InsertOneAsync(log);
        }
    }
}
