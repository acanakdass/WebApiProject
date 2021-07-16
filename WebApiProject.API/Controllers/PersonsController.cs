using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiProject.API.ValidationFilters;
using WebApiProject.Core.Dtos;
using WebApiProject.Core.Entities;
using WebApiProject.Core.Services;

namespace WebApiProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IService<Person> _personService;
        private readonly IMapper _mapper;

        public PersonsController(IService<Person> personService, IMapper mapper)
        {
            _personService = personService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var persons = await _personService.GetAllAsync();
            var personsDto = _mapper.Map<IEnumerable<PersonDto>>(persons);
            return Ok(personsDto);
        }

        [ValidationFilter]
        [HttpPost]
        public async Task<IActionResult> Create(PersonDto personDto)
        {
            var personToCreate = _mapper.Map<Person>(personDto);
            var createdPerson = await _personService.AddAsync(personToCreate);
            var person = _mapper.Map<PersonDto>(createdPerson);
            return Created(string.Empty, person);
        }

        [HttpPut]
        public async Task<IActionResult> Update(PersonDto personDto)
        {
            var personToUpdate = _mapper.Map<Person>(personDto);
            var updatedPerson = await _personService.UpdateAsync(personToUpdate);
            return Ok(updatedPerson);
        }
    }
}
