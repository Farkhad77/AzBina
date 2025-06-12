using AzBina.Application.Abstracts.Repositories;
using AzBina.Application.Abstracts.Services;
using AzBina.Application.DTOs.CategoryDtos;
using AzBina.Application.Shared;
using AzBina.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AzBina.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        private ICategoryService _categoryService { get; }
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CategoriesController>
        [HttpPost]
        [ProducesResponseType(typeof(BaseResponse<string>), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(BaseResponse<string>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(BaseResponse<string>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Post([FromBody] CategoryCreateDto dto)
        {
            
               var result =  await _categoryService.AddAsync(dto);
            return StatusCode((int)result.StatusCode, result);
            
            
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
