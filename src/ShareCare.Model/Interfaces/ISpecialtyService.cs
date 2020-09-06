using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShareCare.Model.Interfaces
{
    public interface ISpecialtyService
    {
        Task<IEnumerable<string>> GetSpecialtyAsync();
    }
}
