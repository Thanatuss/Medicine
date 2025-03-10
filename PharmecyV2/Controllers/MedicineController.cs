using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pharmecy.Application.Commands;
using Pharmecy.Application.Dtos;

namespace PharmecyV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        public IMediator _mediator;

        public MedicineController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("ADD")]
        public IActionResult Add(CreateMedicineDto medicine)
        {
            var command = new CreateMedicineCommand(new CreateMedicineDto()
            {
                Manufacturer = medicine.Manufacturer,
                Price = medicine.Price,
                Stock = medicine.Stock,
                Description = medicine.Description,
                Dosage = medicine.Dosage,
                ExpiryDate = medicine.ExpiryDate,
                Name = medicine.Name
            });
            var result = _mediator.Send(command);
            return Ok(result.Result.Message);
        }
    }
}
