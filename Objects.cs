using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalLib.Objects
{
    public class QueryResult
    {
        public bool Success { get; set; } = true;
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
        public object Data { get; set; }
    }
}
