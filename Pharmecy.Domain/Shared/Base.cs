using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pharmacy.Domain.Enums;

namespace Pharmacy.Domain.Shared
{
    public class Base
    {
        public int Id { get; set; }
        public DateTime CreatedDate{ get; set; } = DateTime.Now;
        public IsDeleteEnum Status { get; set; } = IsDeleteEnum.Unknown; 
    }
}
