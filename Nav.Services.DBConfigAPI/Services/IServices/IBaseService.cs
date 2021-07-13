using Nav.Services.DBConfigAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nav.Services.DBConfigAPI.IServices
{

        public interface IBaseService : IDisposable
        {         
         public Task<IEnumerable<Fields>> SendAsync(ApiRequest apiRequest);
        }
    
}
