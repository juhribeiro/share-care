using ShareCare.Model.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShareCare.Model.Interfaces
{
    public interface IMedicalGuideService
    {
        Task<List<SimpleDoctorModel>> GetListAsync();
    }
}
