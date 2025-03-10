using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Domain.Entities;
using Pharmacy.Domain.Enums;
using Pharmecy.Application;
using Pharmecy.Application.Commands;
using Pharmecy.Application.Dtos;
using Pharmecy.Infrastructure.Data.DbContext;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Pharmecy.Application.Handlers
{
    public class CreateMedicineHandler : IRequestHandler<CreateMedicineCommand, OperationResult>
    {
        private readonly ProgramDbContext _context;
        private readonly IMapper _mapper;

        public CreateMedicineHandler(IMapper mapper , ProgramDbContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OperationResult> Handle(CreateMedicineCommand request, CancellationToken cancellationToken)
        {
            var data = request.CreateMedicineDto;

            // بررسی برای وجود دارو با همان نام و سازنده
            var existingMedicine = _context.Medicine
                .FirstOrDefault(m => m.Name == data.Name && m.Manufacturer == data.Manufacturer);

            if (existingMedicine != null)
            {
                return OperationResult.Error("Medicine with the same name and manufacturer already exists.");
            }

            // ایجاد داروی جدید
            var medicine = _mapper.Map<Medicine>(data);

            // افزودن دارو به کانتکست
            _context.Medicine.Add(medicine);

            // ذخیره تغییرات به صورت غیر همزمان و استفاده از CancellationToken
            await _context.SaveChangesAsync();

            // موفقیت‌آمیز بودن عملیات
            return OperationResult.Success("Medicine created successfully.");
        }

    }
}
