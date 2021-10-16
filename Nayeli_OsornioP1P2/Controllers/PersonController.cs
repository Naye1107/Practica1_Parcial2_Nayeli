using System.Collections;
using Microsoft.AspNetCore.Mvc;
using QueryApi.Repositories;
using QueryApi.Domain;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public IActionResult GetAll()
        {
            var repository = new PersonRepository();
            var persons = repository.GetAll();
            return Ok(persons);
        } 

        [HttpGet]
        [Route("Filed")]
        public IActionResult GetField()
        {
            var repository = new PersonRepository();
            var persons = repository.GetField();
            return Ok(persons);
        } 

        [HttpGet]
        [Route("PedirGenero")]
        public IActionResult GetByGender(char gender)
        {
            var repository = new PersonRepository();
            var persons = repository.GetByGender(gender);
            return Ok(persons);
        } 

        [HttpGet]
        [Route("PedirRangosEdad")]
        public IActionResult GetByRangeAge(int minAge, int maxAge)
        {
            var repository = new PersonRepository();
            var persons = repository.GetByRangeAge(minAge, maxAge);
            return Ok(persons);
        } 

        [HttpGet]
        [Route("PedirTodosTrabajos")]
        public IActionResult GetJobs()
        {
            var repository = new PersonRepository();
            var persons = repository.GetJobs();
            return Ok(persons);
        } 

        [HttpGet]
        [Route("PedirParteNombre")]
        public IActionResult GetContainPartName(string lastName)
        {
            var repository = new PersonRepository();
            var persons = repository.GetDiferencesJob(lastName);
            return Ok(persons);
        } 

        [HttpGet]
        [Route("GetByAgess")]
        public IActionResult GetByAges(int age1, int age2, int age3)
        {
            var repository = new PersonRepository();
            var persons = repository.GetByAges(age1, age2, age3);
            return Ok(persons);
        } 

        [HttpGet]
        [Route("PedirEnOrden")]
        public IActionResult GetPersonsOrder(int age)
        {
            var repository = new PersonRepository();
            var persons = repository.GetPersonsOrder(age);
            return Ok(persons);
        } 

        [HttpGet]
        [Route("OrdenarDesc")]
        public IActionResult GetPersonsOrderDesc(char gender, int age1, int age2)
        {
            var repository = new PersonRepository();
            var persons = repository.GetPersonsOrderDesc(gender, age1, age2);
            return Ok(persons);
        } 

        [HttpGet]
        [Route("ContarPersonasXGenero")]
        public IActionResult CounPeople(char gender)
        {
            var repository = new PersonRepository();
            var persons = repository.CounPeople(gender);
            return Ok(persons);
        } 

        [HttpGet]
        [Route("PersonaExistente")]
        public IActionResult AnyPersonExist()
        {
            var repository = new PersonRepository();
            var persons = repository.AnyPersonExist();
            return Ok(persons);
        } 

        [HttpGet]
        [Route("GetOnePerson")]
        public IActionResult OnePerson(string job, int age)
        {
            var repository = new PersonRepository();
            var persons = repository.OnePerson(job, age);
            return Ok(persons);
        } 

        [HttpGet]
        [Route("TakePerson")]
        public IActionResult TakePersons()
        {
            var repository = new PersonRepository();
            var persons = repository.TakePersons();
            return Ok(persons);
        } 

        [HttpGet]
        [Route("SkipPerson")]
        public IActionResult SkipPerson()
        {
            var repository = new PersonRepository();
            var persons = repository.SkipPerson();
            return Ok(persons);
        } 

        [HttpGet]
        [Route("SkipTakePerson")]
        public IActionResult SkipTakePerson()
        {
            var repository = new PersonRepository();
            var persons = repository.SkipTakePerson();
            return Ok(persons);
        } 
    }
}