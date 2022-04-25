using MicroRentACar.Data;
using MicroRentACar.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroRentACar.Repos
{
    public class RoleRepo : IRoleRepo
    {

        private readonly MicroDBContext _context;

        public RoleRepo(MicroDBContext context)
        {
            _context = context;
        }

        public async Task UpdateRole(Role Role)
        {
            _context.Entry(Role).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task AddRole(Role Role)
        {
            _context.Add(Role);
            await _context.SaveChangesAsync();
        }

        public async Task<Role> GetRoleByID(int RoleID)
        {
            return await _context.Roles.FindAsync(RoleID);
        }

        public async Task<IEnumerable<Role>> GetRoles()
        {
            try
            {
                IEnumerable<Role> roles = await _context.Roles.ToListAsync();
                return roles;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteRole(int RoleID)
        {
            Role selectedRole=await _context.Roles.FindAsync(RoleID);
            _context.Roles.Remove(selectedRole);
            await _context.SaveChangesAsync();
        }
    }
}
