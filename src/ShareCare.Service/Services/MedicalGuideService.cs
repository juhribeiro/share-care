using ShareCare.Model.DbModels;
using ShareCare.Model.Interfaces;
using ShareCare.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShareCare.Service.Services
{
    public class MedicalGuideService : IMedicalGuideService
    {
        private readonly IBaseRepository<Doctor, SimpleDoctorModel> doctorRepository;

        public MedicalGuideService(IBaseRepository<Doctor, SimpleDoctorModel> doctorRepository)
        {
            this.doctorRepository = doctorRepository;
        }


        public async Task<List<SimpleDoctorModel>> GetListAsync()
        {
            var doctors = await doctorRepository.ToListAsync();
            doctors.ForEach(x => x.Password = string.Empty);
            return doctors;
        }
    }
}
