using H5ServersideMonday.Components.Context;
using H5ServersideMonday.Components.Models;
using Microsoft.EntityFrameworkCore;

namespace H5ServersideMonday.Components.Repositories
{
    public class CprRepository
    {
        private readonly MyContext _context;

        public CprRepository(MyContext context)
        {
            _context = context;
        }

        public async Task<CprEntry> GetUserId(string user)
        {
            try
            {
                var foundUser = await _context.Cpr.FirstOrDefaultAsync(usr => usr.User == user);
                return foundUser;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> ValidCpr(int userId, string cpr)
        {
            try
            {
                var foundUser = await _context.Cpr.FirstOrDefaultAsync(user => user.Id == userId && user.Cpr == cpr);
                if (!string.IsNullOrEmpty(foundUser?.Cpr))
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                throw;
            }
        }

        public async Task<CprEntry> CreateCpr(CprEntry newCpr)
        {
            await _context.Cpr.AddAsync(newCpr);
            await _context.SaveChangesAsync();
            return newCpr;
        }
        
    }
}
