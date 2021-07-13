using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Nav.Services.DefaultFieldsAPI.Model
{
    public class Product
    {
        [Key]      
        public int FieldId { get; set; }

        public string field { get; set; }
        public bool IsRquired { get; set; }
        public int Maxlength { get; set; }
        public String Source { get; set; }
    }
}
