using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Nasr.API.Core.Person;

namespace Nasr.API.Infrastructure.EFRepositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly NasrDbContext _dbContext;
        public PersonRepository(NasrDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Person>> GetAllAsync()
            => await _dbContext.Person.ToListAsync();

        public async Task<Person> GetByIdAsync(int id)
            => await _dbContext.Person.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<Person> GetByNameAsync(string name)
            => await _dbContext.Person.FirstOrDefaultAsync(x => x.Name == name);

        public async Task AddAsync(PersonCreateModel person)
        {
            var name = new SqlParameter("@Name", person.Name);
            var birthDay = new SqlParameter("@BirthDay", person.BirthDay);
            var config = new SqlParameter("@Config", person.Config);
            await _dbContext.Database.ExecuteSqlRawAsync("CreatePersonProc @Name, @BirthDay, @Config", name, birthDay, config);
        }

        public async Task UpdateAsync(Person person)
        {
            var id = new SqlParameter("@Id", person.Id);
            var name = new SqlParameter("@Name", person.Name);
            var birthDay = new SqlParameter("@BirthDay", person.BirthDay);
            var config = new SqlParameter("@Config", person.Config);
            var rowVer = new SqlParameter("@RowVer", person.RowVer);
            await _dbContext.Database.ExecuteSqlRawAsync("UpdatePersonProc @Id, @Name, @BirthDay, @Config, @RowVer"
                                        , id, name, birthDay, config, rowVer);
        }

        public async Task DeleteAsync(int id, byte[] rowVer)
        {
            var idParam = new SqlParameter("@Id", id);
            var rowVerParam = new SqlParameter("@RowVer", rowVer);
            await _dbContext.Database.ExecuteSqlRawAsync("DeletePersonProc @Id, @RowVer"
                                        , id, rowVer);
        }
    }
}