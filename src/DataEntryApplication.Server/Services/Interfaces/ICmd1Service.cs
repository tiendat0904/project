using System.Collections.Generic;
using System.Threading.Tasks;
using DataEntryApplication.Server.Data.Entities;

namespace DataEntryApplication.Server.Services.Interfaces
{
    public interface ICmd1Service
    {
        Task<IList<CMD1>> GetValuesOfCMD1();
        Task Save(IList<CMD1> values);
    }
}
