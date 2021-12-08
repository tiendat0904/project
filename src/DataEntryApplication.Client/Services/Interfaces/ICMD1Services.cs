using System.Collections.Generic;
using System.Threading.Tasks;
using DataEntryApplication.Shared;

namespace DataEntryApplication.Client.Services.Interfaces
{
    public interface ICMD1Services
    {
        Task<IList<CMD1Model>> GetValuesOfCMD1();
        Task<bool> Save(IList<CMD1Model> values, int mode);
    }
}
