using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Layer.ExecResult
{
    public class OperationResult
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; } = null!;
        public object Data { get; set; } = default!;
    }
}
