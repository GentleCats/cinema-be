using cinema_be.Entities;
using cinema_be.Interfaces;
using cinema_be.Models.DTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using cinema_be.Validators;

namespace cinema_be.Services
{
    public class HallService : IHallService
    {
        private readonly IRepository<Hall> _hallRepo;
        private readonly IMapper _mapper;

        public HallService(IRepository<Hall> hallRepo, IMapper mapper)
        {
            _hallRepo = hallRepo;
            _mapper = mapper;
        }

        public void Create(CreateHallDto createHallDto)
        {
            var validator = new CreateHallDtoValidator();
            var validationResult = validator.Validate(createHallDto);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage)));
            }
            try
            {
                var hall = _mapper.Map<Hall>(createHallDto);
                _hallRepo.Insert(hall);
                _hallRepo.Save();
                Console.WriteLine("Hall added successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while adding hall: {ex.Message}");
            }
        }

        public IEnumerable<Hall> GetHalls()
        {
            return _hallRepo.Get();
        }

        public Hall? GetHallById(int id)
        {
            var hall = _hallRepo.Get(filter: h => h.Id == id).FirstOrDefault();
            return hall;
        }

        public void Delete(int id)
        {
            var hall = GetHallById(id);
            if (hall == null) return;

            _hallRepo.Delete(hall);
            _hallRepo.Save();
        }
    }
}
