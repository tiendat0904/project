using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DataEntryApplication.Server.Data.Entities;
using DataEntryApplication.Server.Services.Interfaces;
using DataEntryApplication.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataEntryApplication.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CMD1Controller : ControllerBase
    {
        private readonly ICmd1Service _cmd1Service;
        private readonly IMapper _mapper;

        public CMD1Controller(ICmd1Service cmd1Service, IMapper mapper)
        {
            _cmd1Service = cmd1Service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var values = await _cmd1Service.GetValuesOfCMD1();
            var valuesModel = _mapper.Map<IList<CMD1Model>>(values);
            return Ok(valuesModel);
        }

        [HttpPost("{mode:int}")]
        public async Task<IActionResult> Post([FromBody] IList<CMD1Model> values, int mode)
        {
            try
            {
                var valuesModel = _mapper.Map<IList<CMD1>>(values);
                await _cmd1Service.Save(valuesModel);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
