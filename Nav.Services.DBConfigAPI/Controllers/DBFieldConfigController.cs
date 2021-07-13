using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nav.Services.DBConfigAPI.Facade;
using Nav.Services.DBConfigAPI.IServices;
using Nav.Services.DBConfigAPI.Model;
using Nav.Services.DBConfigAPI.Repository;
//using Nav.Services.DBConfigAPI.Repository;

namespace Nav.Services.DBConfigAPI.Controllers
{
    [Route("api/dbconfig")]
    [ApiController]
    public class DBConfigController : ControllerBase
    {
        private IDbConfigRepository _dbConfigRepository;
        private IBaseService _baseService;
        private SourceFacade _sourceFacade;
        public DBConfigController(IBaseService baseService, IDbConfigRepository _dbConfigRepository)
        {
            this._baseService = baseService;
            this._dbConfigRepository = _dbConfigRepository;
            _sourceFacade = new SourceFacade(baseService);
        }
        [HttpGet]
        public async Task<Product> getDBConfigFieldsAsync()
        {
            Product productsDetail = new Product();
            IEnumerable<Product> defaultFieldList = new List<Product>();
            try
            {
                var defaultData = await _sourceFacade.getDefaultFieldData();
                var customData = await _sourceFacade.getCustomFieldData();
                var DBData = await _dbConfigRepository.GetDBConfigAsync();
                var SourceData = defaultData.Concat(customData).Concat(DBData);

                productsDetail.Fields = SourceData;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error --> {0} and at function -->{1}",
                    ex.Message.ToString(), ex.Source);
            }
            return productsDetail;
        }
        [HttpPost]
        public async Task<IActionResult> CreateDBConfigFieldsAsync([FromBody] Fields fields)
        {
            try
            {
                var DBData = await _dbConfigRepository.CreateUpdateDbConfigAsync(fields);
                if (DBData)
                {
                   return Ok("Record Added !");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error --> {0} and at function -->{1}",
                    ex.Message.ToString(), ex.Source);
            }
            return BadRequest();
        }

    }
}