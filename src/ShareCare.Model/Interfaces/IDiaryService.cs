using Microsoft.AspNetCore.Mvc.ModelBinding;
using ShareCare.Model.Models;
using System;
using System.Threading.Tasks;

namespace ShareCare.Model.Interfaces
{
    public interface IDiaryService
    {
        Task<ModelStateDictionary> CreateAsync(DiaryModel model);
    }
}
