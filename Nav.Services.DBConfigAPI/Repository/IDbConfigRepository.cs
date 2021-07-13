using Nav.Services.DBConfigAPI.Model;
using Nav.Services.DBConfigAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nav.Services.DBConfigAPI.Repository
{
    public  interface IDbConfigRepository
    {
        public  Task<IEnumerable<Fields>> GetDBConfigAsync();

        public Task<bool> CreateUpdateDbConfigAsync(Fields fields);
    }
}
