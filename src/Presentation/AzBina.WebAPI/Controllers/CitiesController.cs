using AzBina.Application.Abstracts.Services;
using AzBina.Application.DTOs.CategoryDtos;
using AzBina.Application.DTOs.CityDtos;
using AzBina.Application.Shared;
using AzBina.Persistance.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AzBina.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
       
            public CitiesController(ICityService cityService)
            {
                _cityService = cityService;
            }

            private ICityService _cityService { get; }


            // GET: api/<CitiesController>
            [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CitiesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CitiesController>
        [HttpPost]
        [ProducesResponseType(typeof(BaseResponse<CityUpdateDto>), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(BaseResponse<string>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(BaseResponse<string>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Post([FromBody] CityCreateDto dto)
        {
            var result = await _cityService.AddAsync(dto);
            return StatusCode((int)result.StatusCode, result);
        }
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CitiesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] CityUpdateDto dto)
        {
            var result = await _cityService.UpdateAsync(dto);
            return StatusCode((int)result.StatusCode, result);
        }


        // DELETE api/<CitiesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        [HttpGet("search")]
        public async Task<IActionResult> Search(string query)
        {
            var result = await _cityService.GetByNameSearchAsync(query);
            return Ok(result);
        }
    }
}
