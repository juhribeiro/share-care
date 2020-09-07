using AutoMapper;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ShareCare.Model.DbModels;
using ShareCare.Model.Interfaces;
using ShareCare.Model.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShareCare.Service.Services
{
    public class HomeService : IHomeService
    {
        private readonly IBaseRepository<Scheduler, SchedulerModel> schedulerrepository;
        private readonly IBaseRepository<DoctorPatient, DoctorPatientModel> doctorPatientRepository;
        private readonly IBaseRepository<Scheduler, DetailSchedulerModel> confirmSchedulerrepository;
        private readonly IBaseRepository<Scheduler, DetailSolicitationModel> confirmSolicitationrepository;
        private readonly IMapper mapper;

        public HomeService(
            IBaseRepository<Scheduler, SchedulerModel> schedulerrepository,
            IBaseRepository<DoctorPatient, DoctorPatientModel> doctorPatientRepository,
            IBaseRepository<Scheduler, DetailSchedulerModel> confirmSchedulerrepository,
            IBaseRepository<Scheduler, DetailSolicitationModel> confirmSolicitationrepository,

            IMapper mapper)
        {
            this.schedulerrepository = schedulerrepository;
            this.doctorPatientRepository = doctorPatientRepository;
            this.confirmSchedulerrepository = confirmSchedulerrepository;
            this.confirmSolicitationrepository = confirmSolicitationrepository;
            this.mapper = mapper;
        }

        public async Task<List<DetailSchedulerModel>> GetDetailSchedulerAsync(Guid doctorId)
        {
            return await confirmSchedulerrepository.ListByConditionAsync(x => x.DoctorPatient.Doctor.Id.Equals(doctorId));
        }

        public async Task<List<DetailSolicitationModel>> GetDetailSolicitationAsync(Guid doctorId)
        {
            return await confirmSolicitationrepository.ListByConditionAsync(x => x.DoctorPatient.Doctor.Id.Equals(doctorId));
        }
    }
}
