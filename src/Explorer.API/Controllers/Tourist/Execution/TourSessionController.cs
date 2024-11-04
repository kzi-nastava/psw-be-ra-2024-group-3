﻿using Explorer.Stakeholders.Core.Domain.Users;
using Explorer.Tours.API.Dtos.TourSessionDtos;
using Explorer.Tours.API.Public.Administration;
using Explorer.Tours.API.Public.Execution;
using Explorer.Tours.Core.Domain.TourSessions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Tourist.Execution
{
    [Authorize(Policy = "touristPolicy")]
    [Route("api/administration/tourSession")]
    public class TourSessionController:BaseApiController
    {

        private readonly ITourSessionService _tourSessionService;

        public TourSessionController(ITourSessionService tourSessionService)
        {
            _tourSessionService = tourSessionService;
        }



       


        [HttpPost("start")]
        public ActionResult<bool> StartTour([FromQuery] int tourId, [FromQuery] double latitude, [FromQuery] double longitude)
        {

            var initialLocation = new LocationDto(latitude, longitude);


            var result = _tourSessionService.StartTour(tourId, initialLocation);


            if (result.IsSuccess)
            {
                return Ok(true);
            }


            return BadRequest(false);
        }



        [HttpPost("complete/{id}")]
        public ActionResult<bool> CompleteTour(int id)
        {
            var result = _tourSessionService.CompleteTour(id);

            if (result.IsSuccess)
            {
                return Ok(true);
            }

            return NotFound(false);
        }


        [HttpPost("abandon/{id}")]
        public ActionResult<bool> AbandonTour(int id)
        {
            var result = _tourSessionService.AbandonTour(id);

            if (result.IsSuccess)
            {
                return Ok(true);
            }

            return NotFound(false);
        }



        [HttpPost("update-location")]
        public ActionResult UpdateLocation([FromQuery] int tourId, [FromQuery] double latitude, [FromQuery] double longitude)
        {
            var location = new LocationDto(latitude,longitude);
            _tourSessionService.UpdateLocation(tourId, location);

            return Ok();
        }

        [HttpPost("update-session")]
        public ActionResult UpdateSession([FromQuery] int tourId, [FromQuery] double latitude, [FromQuery] double longitude)
        {
            var locationDto = new LocationDto(latitude, longitude);
            _tourSessionService.UpdateSession(tourId, locationDto);

            return Ok("Sesija uspešno ažurirana.");
        }

    }


}

