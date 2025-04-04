using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos.TourProblemDtos;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.API.Public.Execution
{
    public interface ITourProblemService
    {
        Result<TourProblemDto> GetById(int id);
        Result<PagedResult<TourProblemDto>> GetByToursIds(List<int> ids);
        Result<PagedResult<TourProblemDto>> GetByTouristId(int id);
        Result<TourProblemDto> Create(TourProblemDto tourProblemDto);
        Result<TourProblemDto> Update(TourProblemDto tourProblemDto);
        Result<PagedResult<TourProblemDto>> GetAll();
        Result<TourProblemDto> AddComment(int problemId, ProblemCommentDto comment);
        Result<TourProblemDto> SetDeadline(int problemId, DateTime deadline, int receiverId);
        Result<TourProblemDto> ChangeStatus(int problemId, ProblemStatus status);
        Result<TourProblemDto> SetProblemClosed(TourProblemDto tourProblemDto);
    }
}
