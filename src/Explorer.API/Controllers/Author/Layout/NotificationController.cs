﻿using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Dtos.TourProblemDtos;
using Explorer.Tours.API.Public.Execution;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Author.Layout
{
    public class NotificationController : BaseApiController
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet("getUnread")]
        public ActionResult GetUnreadNotifications([FromQuery] int authorId)
        {
            var result = _notificationService.GetUnreadNotificationsByReciever(authorId);
            return CreateResponse(result);
        }

        [HttpPut("setSeen")]
        public ActionResult<TourPreferencesDto> Update([FromBody] NotificationDto notification)
        {
            notification.IsRead = true;
            var result = _notificationService.Update(notification);
            return CreateResponse(result);
        }
    }
}
