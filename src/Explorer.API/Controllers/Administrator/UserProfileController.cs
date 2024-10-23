﻿using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Explorer.API.Controllers.Administrator
{
    [Authorize(Policy = "administratorPolicy")]
    [Route("api/administrator/profile")]
    public class UserProfileController : BaseApiController
    {
        private readonly IUserProfileService _userProfileService;

        public UserProfileController(IUserProfileService userProfileService)
        {
            _userProfileService = userProfileService;
        }

        [HttpGet]
        public ActionResult<UserProfileDto> Get()
        {
            var userId = User.FindFirst("id")?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }
            var result = _userProfileService.Get(Int32.Parse(userId));
            return CreateResponse(result);
        }

        [HttpGet("{userId:long}")]
        public ActionResult<UserProfileDto> GetById(int userId)
        {
            var result = _userProfileService.Get(userId);
            return CreateResponse(result);
        }

        [HttpPut]
        public ActionResult<UserProfileDto> Update([FromBody] UserProfileDto profile)
        {
            var result = _userProfileService.Update(profile);
            return CreateResponse(result);
        }

    }
}
