using MicroRentACar.Data;
using MicroRentACar.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroRentACar.Repos
{
    public class UserRepo : IUserRepo
    {
        private readonly MicroDBContext _context;

        public UserRepo(MicroDBContext context)
        {
            _context = context;
        }




        public async Task UpdateUser(User User)
        {
            _context.Entry(User).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task AddUser(User User)
        {
            _context.Add(User);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUserByID(int UserID)
        {
            return await _context.Users.FindAsync(UserID);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            try
            {
                IEnumerable<User> users = await _context.Users.ToListAsync();
                return users;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteUser(int UserID)
        {
            User SelectedUser = await _context.Users.FindAsync(UserID);
            _context.Users.Remove(SelectedUser);
            await _context.SaveChangesAsync();
        }


        public async Task<bool> VerificationUser(string email, string password)
        {
            return await _context.Users.AnyAsync(o =>

            (o.Email == email)
            &&
            (o.Password == password || password==null)
            );

        }

        public async Task<IEnumerable<User>> GetUsersByPage(int pageNumber)
        {
            return await _context.Users.Skip((pageNumber - 1) * 10).Take(10).ToListAsync();
        }

        public async Task<int> GetUsersCount()
        {
            return await _context.Users.CountAsync();
        }
    }
}
