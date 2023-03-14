using Database.models;

namespace UserAdmin.Repositories
{
   public interface IUserRepository
    {
        Task<userm?> AuthenticateAsync(string username, string password);
        Task<userm?> GetUserAsync(int user_id);
    }

}
