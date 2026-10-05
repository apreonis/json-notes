using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public interface INoteRepository
    {
        Task<List<Note>> GetAllAsync();
        Task<Note> AddAsync(Note value);
        Task DeleteAsync(Guid ID);
        Task SaveAsync();
     
    }
}
