using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nasr.API.Application.Services;
using Nasr.API.Core.Person;

namespace Nasr.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : BaseController
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IPersonService _personService;

        public PersonController(ILogger<PersonController> logger,
                                IPersonService personService)
        {
            _personService = personService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<Person>>> GetAsync()
        {
            try
            {
                return Collection(await _personService.GetAllAsync());
            }
            catch(Exception ex)
            {
                return ErrorResponse(ex);
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetByIdAsync(int id)
        {
            try
            {
                return Single(await _personService.GetByIdAsync(id));
            }
            catch(Exception ex)
            {
                return ErrorResponse(ex);
            }
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<Person>> GetByNameAsync(string name)
        {
            try
            {
                return Single(await _personService.GetByNameAsync(name));
            }
            catch(Exception ex)
            {
                return ErrorResponse(ex);
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody]PersonCreateModel person)
        {
            try
            {
                await _personService.AddAsync(person);
                return Ok();
            }
            catch(Exception ex)
            {
                return ErrorResponse(ex);
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody]Person person)
        {
            try
            {
                await _personService.UpdateAsync(person);
                return Ok();
            }
            catch(Exception ex)
            {
                return ErrorResponse(ex);
            }
        }

        [HttpDelete("{id}/{rowVer}")]
        public async Task<ActionResult> DeleteAsync([FromRoute]int id,[FromRoute] byte[] rowVer)
        {
            try
            {
                await _personService.DeleteAsync(id, rowVer);
                return Ok();
            }
            catch(Exception ex)
            {
                return ErrorResponse(ex);
            }
        }
    }
}
