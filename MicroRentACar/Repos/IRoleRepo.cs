using MicroRentACar.Models;

namespace MicroRentACar.Repos
{
    public interface IRoleRepo
    {

        Task<IEnumerable<Role>> GetRoles();
        Task<Role> GetRoleByID(int RoleID);
        Task AddRole(Role Role);
        Task DeleteRole(int RoleID);
        Task UpdateRole(Role Role);

    }
}
