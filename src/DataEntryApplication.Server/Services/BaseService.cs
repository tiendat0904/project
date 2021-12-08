using DataEntryApplication.Server.Data;

namespace DataEntryApplication.Server.Services
{
    public class BaseService
    {
        protected ApplicationDbContext DbContext;
        protected BaseService(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }
    }
}
