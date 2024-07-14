
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliManager.Models
{
    public class ResultStatus
    {

        public bool Status { get; set; }
        public string Message { get; set; }        
        public dynamic Data { get; set; }

        public ResultStatus()
        {
            Status = true;
            Message = "";            
            Data = null;
        }
    }
}
