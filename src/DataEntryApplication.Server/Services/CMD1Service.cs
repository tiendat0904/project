using System.Collections.Generic;
using System.Threading.Tasks;
using DataEntryApplication.Server.Data;
using DataEntryApplication.Server.Data.Entities;
using DataEntryApplication.Server.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataEntryApplication.Server.Services
{
    public class CMD1Service : BaseService, ICmd1Service
    {
        public CMD1Service(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IList<CMD1>> GetValuesOfCMD1()
        {
            var query = DbContext.CMD1;
            var values = await query.ToListAsync();
            return values;
        }

        public async Task Save(IList<CMD1> values)
        {
            DbContext.UpdateRange(values);
            await DbContext.SaveChangesAsync();
        }
    }
}
