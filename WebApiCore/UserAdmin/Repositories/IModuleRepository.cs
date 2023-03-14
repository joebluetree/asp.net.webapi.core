using Database.models;

namespace UserAdmin.Repositories
{
    public interface IModuleRepository
    {
        Task<List<modulem>> GetListAsync();
        Task<modulem?> GetRecordAsync(int id);

    }
}
