using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Pharmecy.Application.Dtos;

namespace Pharmecy.Application.Commands
{
    public class CreateMedicineCommand : IRequest<OperationResult>
    {
        public CreateMedicineDto CreateMedicineDto { get; set; }

        public CreateMedicineCommand(CreateMedicineDto createMedicineDto)
        {
            CreateMedicineDto = createMedicineDto;


        }
    }
}
