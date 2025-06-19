using AzBina.Application.Abstracts.Services;
using AzBina.Application.DTOs.CategoryDtos;
using AzBina.Application.DTOs.DistrictDtos;
using AzBina.Application.Shared;
using AzBina.Persistance.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AzBina.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController : ControllerBase
    {
        public DistrictController(IDistrictService districtService)
        {
            _districtService = districtService;
        }

        private IDistrictService _districtService { get; }
        // GET: api/<DistrictController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<DistrictController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DistrictController>
        [HttpPost]
        [ProducesResponseType(typeof(BaseResponse<CategoryUpdateDto>), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(BaseResponse<string>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(BaseResponse<string>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Post([FromBody] DistrictCreateDto dto)
        {
            var result = await _districtService.AddAsync(dto);
            return StatusCode((int)result.StatusCode, result);
        }

        // PUT api/<DistrictController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] DistrictUpdateDto dto)
        {
            var result = await _districtService.UpdateAsync(dto);
            return StatusCode((int)result.StatusCode, result);
        }

        // DELETE api/<DistrictController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        [HttpGet("search")]
        [ProducesResponseType(typeof(BaseResponse<List<CategoryGetDto>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseResponse<string>), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(BaseResponse<string>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetByNameSearchAsync(string search)
        {
            var category = await _districtService.GetByNameSearchAsync(search);
            return StatusCode((int)category.StatusCode, category);
        }
    }
}
