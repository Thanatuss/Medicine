using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pharmecy.Domain.Entities;

namespace Pharmecy.Domain.Interfaces
{
    public interface ILogRepository
    {
        Task SaveLogAsync(Log log);
        Task<IEnumerable<Log>> GetLogsAsync();
    }
}
