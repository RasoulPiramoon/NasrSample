using System.Collections.Generic;
using System.Threading.Tasks;
using Nasr.API.Core.Person;

namespace Nasr.API.Application.Services
{
    public interface IPersonService
    {
        Task<List<Person>> GetAllAsync();
        Task<Person> GetByIdAsync(int id);
        Task<Person> GetByNameAsync(string name);
        Task AddAsync(PersonCreateModel person);
        Task UpdateAsync(Person person);
        Task DeleteAsync(int id, byte[] rowVer);
    }
}