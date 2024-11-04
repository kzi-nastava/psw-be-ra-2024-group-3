﻿using AutoMapper;
using Explorer.BuildingBlocks.Core.Domain;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Dtos.TourLifecycleDtos;
using Explorer.Tours.API.Public.Authoring;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using Explorer.Tours.Core.Domain.Tours;
using FluentResults;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.UseCases.Authoring
{
    public class TourService : CrudService<TourDto, Tour>, ITourService

    {

        private readonly ITourRepository _tourRepository;
        private readonly ICrudRepository<KeyPoint> _keyPointRepository;
        private readonly IMapper _mapper;
        public TourService(ICrudRepository<Tour> repository, IMapper mapper, ITourRepository tourRepository, ICrudRepository<KeyPoint> keyPointRepository) : base(repository, mapper) {          
            _mapper = mapper;
            _tourRepository = tourRepository;
            _keyPointRepository = keyPointRepository;
        }

        public Result<KeyPointDto> AddKeyPointToTourAsync(int tourId, KeyPointDto keyPointDto)
        {
            try
            {
                
                var tour = GetTourByIdAsync(tourId);

                if (tour == null)
                {
                    return Result.Fail<KeyPointDto>("Tour not found.");
                }
                Console.WriteLine($"Tour found: {tour.Id}, KeyPoints Count: {tour.KeyPoints.Count}");

                var keyPoint = _mapper.Map<KeyPoint>(keyPointDto);


                tour.KeyPoints.Add(keyPoint);

                _keyPointRepository.Create(keyPoint);
               


                var tourDto = _mapper.Map<TourDto>(tour);
                Update(tourDto);
                
                
                return Result.Ok(_mapper.Map<KeyPointDto>(keyPoint));
            }
            catch (Exception ex)
            {
                var innerExceptionMessage = ex.InnerException?.Message ?? "No inner exception.";
                return Result.Fail<KeyPointDto>("An error occurred while adding the key point: " + ex.Message);
            }
        }

        private Tour GetTourByIdAsync(int tourId)
        {
            return _tourRepository.GetByIdAsync(tourId);
        }
        public Result<List<TourDto>> GetByAuthorId(int page, int pageSize, int id)
        {
            var tours = GetPaged(page, pageSize);
            var authorTours = tours.Value.Results.FindAll(x => x.AuthorId == id);
            return authorTours;
        }

        public Result<bool> Publish(TourDto tourDto)
        {
            try
            {
                var tour = _mapper.Map<Tour>(tourDto);
                tour.Publish();
                var updatedTourDto = _mapper.Map<TourDto>(tour);
                Update(updatedTourDto);

                return Result.Ok(true);
            }
            catch (Exception ex)
            {
                return Result.Fail("An error occurred while publishing the tour: " + ex.Message);
            }
        }

        public Result<bool> Archive(TourDto tourDto)
        {
            throw new NotImplementedException();
        }

        public Result<List<TourDto>> GetAllToursWithKeyPoints()
        {
           
            var tours = _tourRepository.GetAllToursWithKeyPoints(); 

            if (tours == null || !tours.Any())
            {
                return Result.Fail<List<TourDto>>("No tours found.");
            }

            var tourDtos = tours.Select(t => _mapper.Map<TourDto>(t)).ToList();

            return Result.Ok(tourDtos);
        }
        public TourDto GetKeyPointsByTourId(int tourId)
         {

            var tour = _tourRepository.GetKeyPointsForTour(tourId);
            var tourDto = _mapper.Map<TourDto>(tour);
            //return Result.Ok(tourDto);
            return tourDto;
         }

        public Result<bool> UpdateTransportInfo(int tourId, TransportInfoDto transportInfoDto)
        {
            
            var tour = GetKeyPointsByTourId(tourId);

            if (tour == null)
            {
                return Result.Fail<bool>("Tour not found");
            }


            tour.TransportInfo.Distance = transportInfoDto.Distance;
            tour.TransportInfo.Time = transportInfoDto.Time;

            
            var updatedTourDto = _mapper.Map<TourDto>(tour);
            Update(updatedTourDto);

            return Result.Ok(true);
        }


    }
}
