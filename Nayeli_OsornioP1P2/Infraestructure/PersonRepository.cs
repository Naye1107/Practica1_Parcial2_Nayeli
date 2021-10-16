using System.CodeDom.Compiler;
using System.ComponentModel;
using System.IO.Pipes;
using System.Collections;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.IO;
using QueryApi.Domain;
using System.Threading.Tasks;

namespace QueryApi.Repositories
{
    public class PersonRepository
    {
        List<Person> _persons;

        public PersonRepository()
        {
            var fileName = "dummy.data.queries.json";
            if(File.Exists(fileName))
            {
                var json = File.ReadAllText(fileName);
                _persons = JsonSerializer.Deserialize<IEnumerable<Person>>(json).ToList();
            }
        }

        // retornar todos los valores
        public IEnumerable<Person> GetAll()
        {
            var query = _persons.Select(person => person);
            return query;
        }

        // retornar campos especificos COMIENZA LA CODIFICACION
        public IEnumerable<Object> GetField()
        {
            var query = _persons.Select(person => new {
                NombreCompleto = $"{person.FirstName}{person.LastName}",
                AnioNacimiento = DateTime.Now.AddYears(person.Age * -1).Year,
                CorreoElectronico = person.Email
            });
            return query;
        }
        
        // retornar elementos que sean iguales
        public IEnumerable<Person> GetByGender(char gender)
        {
            //var gender = 'M';
            var query = _persons.Where(person => person.Gender == gender);
            return query;
        }
        
        public IEnumerable<Person> GetByMaxAge()
        {
            var age = 30;
            var query = _persons.Where(person => person.Age <= age);
            return query;
        }

        // Retornar elementos que sean diferentes
        public IEnumerable<Person> GetDiferencesJob(string job)
        {
            //var job = "Civil Engineer";
            var query = _persons.Where(person => person.Job != job);
            return query;
        }

        public IEnumerable<string> GetJobs()
        {
            var query = _persons.Select(person => person.Job).Distinct();
            return query;
        }

        
        // retornar valores que contengan LISTO
        public IEnumerable<Person> GetContainPartName(string partName)
        {
            //var partName = "ar";
            var query = _persons.Where(person => person.FirstName.Contains(partName));
            return query;
        }
        
        public IEnumerable<Person> GetByAges(int age1, int age2, int age3)
        {

            var ages = new List<int>{age1, age2, age3};
            var query = _persons.Where(person => ages.Contains(person.Age));
            return query;
        }

        // retornar valores entre un rango LISTO
        public IEnumerable<Person> GetByRangeAge(int minAge, int maxAge)
        {
            //var minAge = 30;
            //var maxAge = 40;
            var query = _persons.Where(person => person.Age >= minAge && person.Age <= maxAge);
            return query;
        }
        
        // retornar elementos ordenados LISTO
        public IEnumerable<Person> GetPersonsOrder(int edad)
        {
            //var job = "Payment Adjustment Coordinator";
            var query = _persons.Where(person => person.Age > edad)
                        .OrderBy(person => person.Age);
            return query;
        }

        public IEnumerable<Person> GetPersonsOrderDesc(char gender, int age1, int age2)
        {

            var query = _persons.Where(person => person.Gender == gender && person.Age >= age1 && person.Age <= age2)
                        .OrderByDescending(person => person.FirstName);
            return query;
        }
        
        // retorno cantidad de elementos
        public int CounPeople(char gender)
        {
            //var age = 37;
            var query = _persons.Count(person => person.Gender == gender);
            return query;
        }
        
        // Evalua si un elemento existe
        public bool ExistPerson()
        {
            //Maurise
            var lastName = "de Mullett";
            //Origen, método, iterador 
            var query = _persons.Exists(p => p.LastName == lastName);
            return query;
        }

        public bool AnyPersonExist()
        {
            var lastName = "";
            var query = _persons.Any(p => p.LastName == lastName);
            return query;
        }

        // retornar solo un elemento
        public Person GetOneElementPerson()
        {
            var generador = new Random(DateTime.Now.Millisecond);
            var id = generador.Next(1000);

            var query = _persons.FirstOrDefault(person => person.Id == id);
            return query;
        }
        
        // retornar solamente unos elementos
        public IEnumerable<Person> TakePersons()
        {
            var job = "Software Consultant";
            var take = 3;
            var query = _persons.Where(person => person.Job == job).Take(take);
            return query;
        }
        
        public IEnumerable<Person> TakeLastPersons()
        {
            var job = "Physical Therapy Assistant";
            var takeLast = 3;
            var query = _persons.Where(person => person.Job == job).TakeLast(takeLast);
            return query;

        }
        // retornar elementos saltando posición
        public IEnumerable<Person> SkipPerson()
        {
            var job = "Software Consultant";
            var skip = 3;
            var query = _persons.Where(person => person.Job == job).Skip(skip);
            return query;
        }

        public IEnumerable<Person> SkipTakePerson()
        {
            var job = "Software Consultant";
            var skip = 3;
            var take = 5;
            var query = _persons.Where(person => person.Job == job).Skip(skip).Take(take);
            return query;
        }
        
        public Person OnePerson(string job, int age)
        {
            var query = _persons.FirstOrDefault(person => person.Job == job && person.Age == age);
            return query;
        }
    }
}