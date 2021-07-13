using Nav.Services.CustomFieldAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nav.Services.CustomFieldAPI.Repository
{
    public  interface ICustomRepository
    {
        public  Task<IEnumerable<Product>> GetProductsAsync();
    }
}
