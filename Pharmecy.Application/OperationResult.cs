using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pharmecy.Application.Shared;

namespace Pharmecy.Application
{
    public class OperationResult
    {
        public string Message { get; set; }
        public Status Status { get; set; }

        public static OperationResult Success(string message)
        {
            return new OperationResult { Status = Status.Success, Message = message };
        }

        public static OperationResult Error(string message)
        {
            return new OperationResult { Status = Status.Error, Message = message };
        }

        public static OperationResult NotFound(string message)
        {
            return new OperationResult { Status = Status.NotFound, Message = message };
        }
    }
}

