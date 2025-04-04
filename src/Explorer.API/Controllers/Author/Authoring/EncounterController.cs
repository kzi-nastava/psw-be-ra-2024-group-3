﻿using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Encounters.API.Dtos.EncounterDtos;
using Explorer.Encounters.API.Public;
using Explorer.Stakeholders.Infrastructure.Authentication;
using Explorer.Tours.API.Public.Authoring;
using Explorer.Tours.Core.UseCases.Authoring;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Author.Authoring
{
    [Authorize(Policy = "authorPolicy")]
    [Route("api/author/encounter")]
    public class EncounterController : BaseApiController
    {
        private readonly IEncounterService _encounterService;
        private readonly IKeyPointService _keyPointService;
        
        public EncounterController(IEncounterService encounterService, IKeyPointService keyPointService)
        {
            _encounterService = encounterService;
            _keyPointService = keyPointService;
        }

        [HttpGet]
        public ActionResult<PagedResult<EncounterDto>> GetAll()
        {
            var result = _encounterService.GetPaged(0, 0);
            return CreateResponse(result);
        }

        [HttpPost]
        public ActionResult<EncounterDto> Create([FromBody] EncounterDto encounter)
        {
            int userId = User.PersonId();
            encounter.UserId = userId;
            if (encounter.Type != EncounterType.Location)
            {
                encounter.Coordinates.Latitude = _keyPointService.Get(encounter.KeyPointId).Value.Latitude;
                encounter.Coordinates.Longitude = _keyPointService.Get(encounter.KeyPointId).Value.Longitude;
            }
            encounter.Status = EncounterStatus.Active;

            var result = _encounterService.Create(encounter);
            return CreateResponse(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _encounterService.Delete(id);
            if (result.IsFailed)
            {
                return NotFound(result.Errors.First().Message);
            }

            return CreateResponse(result);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] EncounterDto encounterDto)
        {
            if (encounterDto == null || encounterDto.Id != id)
            {
                return BadRequest("Invalid data.");
            }

            var result = _encounterService.Update(encounterDto);

            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }

            if (result.Errors.Any(e => e.Message.Contains("not found")))
            {
                return NotFound("Encounter not found.");
            }

            return BadRequest("Invalid input data.");
        }
    }
}
