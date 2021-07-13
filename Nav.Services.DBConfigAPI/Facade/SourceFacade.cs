using Nav.Services.DBConfigAPI.IServices;
using Nav.Services.DBConfigAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Nav.Services.DBConfigAPI.Facade
{
    public class SourceFacade
    {
        private IBaseService _baseService;
        public SourceFacade(IBaseService _baseService)
        {
          this._baseService = _baseService;           
        }
        public async Task<IEnumerable<Fields>> getDefaultFieldData()
        {
            return await  _baseService.SendAsync(new ApiRequest
            {
                ApiType = SD.ApiType.GET,               
                Url = SD.DefaultFieldAPIBase + "api/DefaultFields"
            });
        }
        public async Task<IEnumerable<Fields>> getCustomFieldData()
        {
            return await _baseService.SendAsync(new ApiRequest
            {
                ApiType = SD.ApiType.GET,
                Url = SD.CustomFieldAPIBase + "api/CustomFields"
            });
        }
    }
}
