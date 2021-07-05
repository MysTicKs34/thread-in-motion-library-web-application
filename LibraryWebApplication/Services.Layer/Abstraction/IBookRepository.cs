using Data.Access.Layer.Classes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Layer.Abstraction
{
    public interface IBookRepository : IGenericRepository<Books>
    {
        public Task<IEnumerable<Books>> GetAllWithAuthorAsync();
        public Task<Books> GetByIdWithAuthorAsync(int id);
    }
}
