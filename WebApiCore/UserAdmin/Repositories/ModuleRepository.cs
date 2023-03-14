using Database;
using Database.models;
using Microsoft.EntityFrameworkCore;

namespace UserAdmin.Repositories
{
    public class ModuleRepository : IModuleRepository
    {

        private readonly AppDbContext appDbContext;
        ModuleRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<List<modulem>> GetListAsync()
        {
            try
            {
                var Records = await appDbContext.Modulem.ToListAsync();
                return Records;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
        }
        public  async Task<modulem?> GetRecordAsync(int id)
        {
            try
            {
                var Record = await appDbContext.Modulem
                    .FirstOrDefaultAsync(f => f.module_id == id);
                 return Record;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
        }
    }
}
