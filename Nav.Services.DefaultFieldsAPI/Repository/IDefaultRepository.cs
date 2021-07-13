using Nav.Services.DefaultFieldsAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nav.Services.DefaultFieldsAPI.Repository
{
    public  interface IDefaultRepository
    {
        public  Task<IEnumerable<Product>> GetProductsAsync();
    }
}
