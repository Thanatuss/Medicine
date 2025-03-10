using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Pharmacy.Domain.Entities;
using Pharmecy.Application.Dtos;

namespace Pharmecy.Application.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateMedicineDto, Medicine>();

        }
    }
}
