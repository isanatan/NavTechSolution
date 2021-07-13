using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nav.Services.DBConfigAPI
{
    public class SD
    {
        public static string  DefaultFieldAPIBase { get; set; }
        public static string  CustomFieldAPIBase { get; set; }

        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }
    }
}
