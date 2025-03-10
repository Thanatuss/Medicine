using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pharmacy.Domain.Entities;

namespace Pharmecy.Infrastructure.Data.Configurations
{
    public class MedicineConfiguration : IEntityTypeConfiguration<Medicine>
    {
        public void Configure(EntityTypeBuilder<Medicine> builder)
        {
            builder.HasKey(m => m.Id); // تعیین کلید اصلی

            builder.Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(100); // تعیین محدودیت طول فیلد Name

            builder.Property(m => m.Description)
                .HasMaxLength(500); // توضیحات تا 500 کاراکتر

            builder.Property(m => m.Manufacturer)
                .IsRequired()
                .HasMaxLength(100); // سازنده دارو الزامی و حداکثر 100 کاراکتر

            builder.Property(m => m.Dosage)
                .HasMaxLength(50); // مقدار مصرف حداکثر 50 کاراکتر

            builder.Property(m => m.Price)
                .HasColumnType("decimal(18,2)"); // ذخیره قیمت با دو رقم اعشار

            builder.Property(m => m.ExpiryDate)
                .IsRequired(); // تاریخ انقضا نباید خالی باشد

            builder.Property(m => m.Stock)
                .HasDefaultValue(0); // مقدار پیش‌فرض برای موجودی صفر است}
        }

    }

}
