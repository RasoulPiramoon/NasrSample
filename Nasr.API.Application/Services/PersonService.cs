using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Nasr.API.Core.Person;
using Newtonsoft.Json;

namespace Nasr.API.Application.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<Person> GetByIdAsync(int id)
            => await _personRepository.GetByIdAsync(id);

        public async Task<Person> GetByNameAsync(string name)
            => await _personRepository.GetByNameAsync(name);

        public async Task<List<Person>> GetAllAsync()
            => await _personRepository.GetAllAsync();           
        
        public async Task AddAsync(PersonCreateModel person)
        {
            if (person.BirthDay == null || person.BirthDay > DateTime.Today)
            {
                throw new Exception("تاریخ تولد اجباری است و نمی تواند تاریخ آینده باشد");
            }
            
            if (string.IsNullOrWhiteSpace(person.Name))
            {
                throw new Exception("نام اجباری است");
            }

            if (string.IsNullOrWhiteSpace(person.Config))
            {
                throw new Exception("دسترسی اجباری است");
            }
            else
            {
                var permissions = JsonConvert.DeserializeObject<Permissions>(person.Config);
                if(permissions == null)
                    throw new Exception("دسترسی معتبر نیست");
            }
            await _personRepository.AddAsync(person);
        }
        
        public async Task UpdateAsync(Person person)
        {
            if (person.BirthDay == null || person.BirthDay > DateTime.Today)
            {
                throw new Exception("تاریخ تولد اجباری است و نمی تواند تاریخ آینده باشد");
            }
            if (string.IsNullOrWhiteSpace(person.Name))
            {
                throw new Exception("نام اجباری است");
            }
            if (string.IsNullOrWhiteSpace(person.Config))
            {
                throw new Exception("دسترسی اجباری است");
            }
            else
            {
                var permissions = JsonConvert.DeserializeObject<Permissions>(person.Config);
                if(permissions == null)
                    throw new Exception("دسترسی معتبر نیست");
            }

            await _personRepository.UpdateAsync(person);
        }
        
        public async Task DeleteAsync(int id, byte[] rowVer)
            => await _personRepository.DeleteAsync(id, rowVer);
    }
}