using MicroRentACar.Models;

namespace MicroRentACar.Repos
{
    public interface IUserRepo
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUserByID(int UserID);
        Task AddUser(User User);
        Task DeleteUser(int UserID);
        Task UpdateUser(User User);
        Task<bool> VerificationUser(string Email, string Password);

        Task<IEnumerable<User>> GetUsersByPage(int pageNumber);
        Task<int> GetUsersCount();


    }
}
