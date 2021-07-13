using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Nav.Services.DBConfigAPI.SD;

namespace Nav.Services.DBConfigAPI.Model
{
    public class ApiRequest
    {
   
            public ApiType ApiType { get; set; } = ApiType.GET;
            public string Url { get; set; }
        
    }
}
