﻿using SportsHall.Data.Models;
using SportsHall.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHall.Services.Data.Interfaces
{
    public interface ITrainingService
    {
        Task<IEnumerable<TrainingsViewModel>> GetAllAsync();
        Task<Training> GetByIdIncludeAsync(int id);
        Task<List<Training>> GetAllTrainingsAsync();
        Task<TrainingCreateViewModel> GetCreateTrainingViewModel();
        Task<Training> CreateAsync(TrainingCreateViewModel model);
    }
}