using AutoMapper;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ShareCare.Model.DbModels;
using ShareCare.Model.Interfaces;
using ShareCare.Model.Models;
using System;
using System.Threading.Tasks;

namespace ShareCare.Service.Services
{
    public class SchedulerService : ISchedulerService
    {
        private readonly IBaseRepository<Scheduler, SchedulerModel> schedulerrepository;
        private readonly IBaseRepository<DoctorPatient, DoctorPatientModel> doctorPatientRepository;
        private readonly IBaseRepository<Scheduler, ConfirmSchedulerModel> confirmSchedulerrepository;
        private readonly IBaseRepository<Scheduler, ConfirmSolicitationModel> confirmSolicitationrepository;
        private readonly IMapper mapper;

        public SchedulerService(
            IBaseRepository<Scheduler, SchedulerModel> schedulerrepository,
            IBaseRepository<DoctorPatient, DoctorPatientModel> doctorPatientRepository,
            IBaseRepository<Scheduler, ConfirmSchedulerModel> confirmSchedulerrepository,
            IBaseRepository<Scheduler, ConfirmSolicitationModel> confirmSolicitationrepository,

            IMapper mapper)
        {
            this.schedulerrepository = schedulerrepository;
            this.doctorPatientRepository = doctorPatientRepository;
            this.confirmSchedulerrepository = confirmSchedulerrepository;
            this.confirmSolicitationrepository = confirmSolicitationrepository;
            this.mapper = mapper;
        }

        public async Task<Tuple<ModelStateDictionary, Guid>> CreateAsync(SchedulerModel model)
        {
            ModelStateDictionary keyValuePairs = new ModelStateDictionary();
            // todo validar se não é o 2 agendamento no mesmo horario
            var scheduler = mapper.Map<Scheduler>(model);
            var doctorPatient = await doctorPatientRepository.AddAsync(scheduler.DoctorPatient);

            scheduler.MeetAddressLink = "https://meet.google.com/wrc-ztqa-vji";
            scheduler.DoctorPatientId = doctorPatient.Id;
            await schedulerrepository.AddAsync(scheduler);
            //todo pegar do google calendar
            return new Tuple<ModelStateDictionary, Guid>(keyValuePairs, scheduler.Id);
        }

        public async Task<ConfirmSchedulerModel> GetConfirmSchedulerAsync(Guid guid)
        {
            return await confirmSchedulerrepository.GetModelByIdAsync(guid);
        }

        public async Task<ConfirmSolicitationModel> GetConfirmSolicitationAsync(Guid guid)
        {
            return await confirmSolicitationrepository.GetModelByIdAsync(guid);
        }
    }
}
