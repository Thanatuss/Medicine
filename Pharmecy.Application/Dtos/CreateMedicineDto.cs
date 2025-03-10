using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmecy.Application.Dtos
{
    public class CreateMedicineDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Manufacturer { get; set; }
        public string Dosage { get; set; }
        public decimal Price { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int Stock { get; set; }
    }
}
