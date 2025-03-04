using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.DTO
{
    class ResponseModel<T>
    {
        public string Message { get; set; } = "";
        public bool Success { get; set; } = true;
        public T Data { get; set; } = default(T);
    }
}
