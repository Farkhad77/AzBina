using AzBina.Application.Abstracts.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AzBina.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TownshipsController : ControllerBase
{
    private ITownshipService _townshipService { get; }
    public TownshipsController(ITownshipService townshipService)
    {
        _townshipService = townshipService;
    }



    // GET: api/<TownshipsController>
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };
    }

    // GET api/<TownshipsController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<TownshipsController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<TownshipsController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<TownshipsController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
