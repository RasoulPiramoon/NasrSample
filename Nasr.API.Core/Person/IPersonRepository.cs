using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nasr.API.Core.Person
{
    public interface IPersonRepository
    {
        Task<List<Person>> GetAllAsync();
        Task<Person> GetByIdAsync(int id);
        Task<Person> GetByNameAsync(string name);
        Task AddAsync(PersonCreateModel person);
        Task UpdateAsync(Person person);
        Task DeleteAsync(int id, byte[] rowVer);
    }
}