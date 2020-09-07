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
        private readonly IBaseRepository<Scheduler, DetailSchedulerModel> confirmSchedulerrepository;
        private readonly IBaseRepository<Scheduler, DetailSolicitationModel> confirmSolicitationrepository;
        private readonly IBaseRepository<Diary, DiaryModel> diaryRepository;

        public HomeService(
            IBaseRepository<Scheduler, DetailSchedulerModel> confirmSchedulerrepository,
            IBaseRepository<Scheduler, DetailSolicitationModel> confirmSolicitationrepository,
            IBaseRepository<Diary, DiaryModel> diaryRepository)
        {
            this.confirmSchedulerrepository = confirmSchedulerrepository;
            this.confirmSolicitationrepository = confirmSolicitationrepository;
            this.diaryRepository = diaryRepository;
        }

        public async Task<List<DetailSchedulerModel>> GetDetailSchedulerAsync(Guid patientId)
        {
            return await confirmSchedulerrepository.ListByConditionAsync(x => x.DoctorPatient.Patient.Id.Equals(patientId));
        }

        public async Task<List<DetailSolicitationModel>> GetDetailSolicitationAsync(Guid doctorId)
        {
            return await confirmSolicitationrepository.ListByConditionAsync(x => x.DoctorPatient.Doctor.Id.Equals(doctorId));
        }

        public async Task<List<DiaryModel>> GetDiaryAsync(Guid patientId)
        {
            return await diaryRepository.ListByConditionAsync(x => x.Patient.Id.Equals(patientId));
        }
    }
}
