using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmecy.Domain.Entities
{
    public class Log
    {
        public string Id { get; set; }  
        public string Message { get; set; }
        public string Level { get; set; } 
        public DateTime Timestamp { get; set; }
    
        public Log(string message , string level)
            {
                Id = Guid.NewGuid().ToString();
                Message = message;
                Level = level;
                Timestamp = DateTime.UtcNow;
            }
    }
}
