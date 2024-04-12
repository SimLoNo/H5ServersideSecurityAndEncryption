using H5ServersideMonday.Components.Context;
using H5ServersideMonday.Components.Models;
using Microsoft.EntityFrameworkCore;

namespace H5ServersideMonday.Components.Repositories
{
    
    public class ToDoRepository
    {
        private readonly MyContext _context;
        public ToDoRepository(MyContext context)
        {
            _context = context;
        }

        public async Task<List<ToDoList>> GetList(int userId)
        {
            try
            {
                return await _context.ToDoList.Where(list => list.UserId == userId).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<ToDoList> AddToDO(ToDoList item)
        {
            try
            {
                await _context.ToDoList.AddAsync(item);
                await _context.SaveChangesAsync();
                return item;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
