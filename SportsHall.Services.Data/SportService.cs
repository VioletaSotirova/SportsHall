﻿using Microsoft.EntityFrameworkCore;

using SportsHall.Data.Repository.Interfaces;
using SportsHall.Services.Data.Interfaces;
using SportsHall.Data.Models;
using SportsHall.Services.Mapping;
using SportsHall.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SportsHall.Services.Data
{
    public class SportService : ISportService
    {
        private IRepository<Sport, int> sportRepository;

        public SportService(IRepository<Sport, int> sportRepository)
        {
            this.sportRepository = sportRepository;
        }
        public async Task<IEnumerable<SportsViewModel>> GetAllAsync()
        {
            var sports = await this.sportRepository
                .GetAllAttached()
                .To<SportsViewModel>()
                .ToListAsync();

            return sports;
        }
        public async Task<SportDetailsViewModel> DetailsAsync(int id)
        {
            var sport = await this.sportRepository
                 .GetAllAttached()
                 .Where(s => s.Id == id)
                 .To<SportDetailsViewModel>()
                 .FirstOrDefaultAsync();

            return sport;
        }
        public async Task<SportEditViewModel> EditAsync(int id)
        {
            var sport = await GetByIdAsync(id);

            var model = new SportEditViewModel
            {
                Id = sport.Id,
                Name = sport.Name,
                Description = sport.Description,
                MaxParticipants = sport.MaxParticipants,
                ImageUrl = sport.ImageUrl
            };

            return model;
        }
        public async Task UpdateSportAsync(SportEditViewModel model)
        {
            var sport = await GetByIdAsync(model.Id);
         
            if (sport != null)
            {              
                sport.Name = model.Name;
                sport.Description = model.Description;
                sport.MaxParticipants = model.MaxParticipants;
                sport.ImageUrl = model.ImageUrl;

                await this.sportRepository.UpdateAsync(sport);
            }  
        }
        public async Task DeleteAsync (int id)
        {
            var sport = await sportRepository.GetByIdAsync(id);

            if (sport != null)
            {

                await sportRepository.DeleteAsync(sport);
     
            }
        }
        public async Task<Sport> CreateAsync(SportEditViewModel model)
        {
            var sport = new Sport
            {
                Name = model.Name,
                Description = model.Description,
                MaxParticipants = model.MaxParticipants,
                ImageUrl = model.ImageUrl,               
            };

            await sportRepository.AddAsync(sport);
            return sport;
        }
        public async Task<Sport> GetByIdAsync(int id)
        {
            return await sportRepository.GetByIdAsync(id);
        }
        public async Task<IEnumerable<SelectListItem>> GetSportsAsSelectItemAsync()
        {
            return (await sportRepository.GetAllAsync())
                .Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.Name });
        }
    }
}
