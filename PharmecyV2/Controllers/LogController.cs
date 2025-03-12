using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pharmecy.Application.Services;
using Pharmecy.Domain.Entities;

namespace PharmecyV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly LogService _logService;
        public LogController(LogService logService)
        {
            _logService = logService;
        }
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Log>>> GetAllLogs()
        {
            var logs = await _logService.GetLogsAsync();
            return Ok(logs);
        }
    }
}
