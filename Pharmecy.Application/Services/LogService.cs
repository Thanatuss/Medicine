using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pharmecy.Domain.Entities;
using Pharmecy.Domain.Interfaces;

namespace Pharmecy.Application.Services
{
    public class LogService
    {
        private readonly ILogRepository _logRepository;
        public LogService(ILogRepository logRepository)
        {
            _logRepository = logRepository; 
        }
        public async Task SaveLogAsync(string message , string level)
        {
            var log = new Log(message, level);
            await _logRepository.SaveLogAsync(log);
        }
        public async Task<IEnumerable<Log>> GetLogsAsync()
        {
            return await _logRepository.GetLogsAsync();
        }
    }
}
