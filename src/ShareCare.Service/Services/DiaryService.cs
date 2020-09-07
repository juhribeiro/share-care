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
    public class DiaryService : IDiaryService
    {
        private readonly IBaseRepository<Diary, DiaryModel> diaryRepository;
        private readonly IMapper mapper;

        public DiaryService(
            IBaseRepository<Diary, DiaryModel> diaryRepository,
            IMapper mapper)
        {
            this.diaryRepository = diaryRepository;
            this.mapper = mapper;
        }

        public async Task<ModelStateDictionary> CreateAsync(DiaryModel model)
        {
            ModelStateDictionary keyValuePairs = new ModelStateDictionary();
            var diary = mapper.Map<Diary>(model);
            //todo valid
            await diaryRepository.AddAsync(diary);

            return keyValuePairs;
        }
    }
}
