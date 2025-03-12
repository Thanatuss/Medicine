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

        private static string GetDefaultMessage(string? message)
        {
            return string.IsNullOrEmpty(message) ? "Message is empty!" : message;
        }
        public static OperationResult Success(string? message)
        {
            return new OperationResult { Status = Status.Success, Message = GetDefaultMessage(message) };
        }

        public static OperationResult Error(string message)
        {
            return new OperationResult { Status = Status.Error, Message = GetDefaultMessage(message) };
        }

        public static OperationResult NotFound(string message)
        {
            return new OperationResult { Status = Status.NotFound, Message = GetDefaultMessage(message) };
        }
    }
}

