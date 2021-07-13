using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Nav.Services.DBConfigAPI.Model
{
    public class Product
    {
        public String EntityName { get; set; } = "Product";
        public IEnumerable<Fields> Fields { get; set; }
    }
}
