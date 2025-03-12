using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pharmecy.Application;
using Pharmecy.Application.Commands;
using Pharmecy.Application.Dtos;
using Pharmecy.Application.Shared;

namespace PharmecyV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private readonly IMediator _mediator;

        // Constructor Injection
        public MedicineController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("ADD")]
        public async Task<IActionResult> Add([FromBody] CreateMedicineDto medicine)
        {
            if (medicine == null)
            {
                return BadRequest("Invalid medicine data.");
            }

            // ایجاد دستور برای ایجاد دارو
            var command = new CreateMedicineCommand<OperationResult>(medicine);

            // ارسال دستور به MediatR
            var result = await _mediator.Send(command);

            // بررسی نتیجه و ارسال پاسخ مناسب
            if ((int) result.Status == (int)Status.Success)
            {
                return Ok(result.Message); // موفقیت‌آمیز
            }
            return BadRequest(result.Message); // شکست در ایجاد دارو
            
        }
    }
}