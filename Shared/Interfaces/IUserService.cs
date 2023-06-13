using AgroStore.Shared;

namespace AgroStore.Shared.Interfaces
{
    public interface IUserService
    {
        User GetUserById(int userId);
        Task<User> GetUserByEmail(string Email);
        Task<User> AddUser(User user);
        void UpdateUser(User user);
        Task DeleteUser(int userId);
        Task<List<User>>GetAll();
    }
}
