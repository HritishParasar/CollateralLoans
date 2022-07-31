using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationService.Models
{
    public class Result
    {
        public int Status { get; set; }

        public string Token { get; set; }
    }
}
