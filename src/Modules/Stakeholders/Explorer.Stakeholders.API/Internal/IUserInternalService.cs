﻿using Explorer.Stakeholders.API.Dtos;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.API.Internal
{
    public interface IUserInternalService
    {
        Result<bool> Exists(string username);
        Result<UserDto> GetActiveByName(string username);
        Result<UserDto> Create(UserDto userDto);
        Result<UserDto> Update(UserDto userDto);
        Result<long> GetPersonId(long userId);
        Result<UserDto> GetUserById(long userId);
        Result<PersonDto> GetPersonByUserId(long userId);
        Result<LocationDto> SetUserLocation(long userId, float longitude, float latitude);
        Result<LocationDto> GetUserLocation(long userId);
        Result<string> GetUsernameById(long userId);
        Result<List<UserDto>> GetAll();
        Result<List<UserDto>> GetAllTourists();
        Result<UserDto> UpdateXPs(int userId, int xp);
        Result<int> GetLevelById(int userId);
        Result<UserDto> UpdateAchievements(UserDto userDto);
    }
}
