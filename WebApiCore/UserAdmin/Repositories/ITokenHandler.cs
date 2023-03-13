
using Database.models;


namespace UserAdmin.Repositories
{
    public interface ITokenHandler
    {
        Task<string> CreateTokenAsync(userm user);
    }
}
