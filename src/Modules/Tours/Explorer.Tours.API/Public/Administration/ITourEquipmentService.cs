﻿using Explorer.Tours.API.Dtos;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.API.Public.Administration
{
    public interface ITourEquipmentService
    {
        Result<List<TourEquipmentDto>> GetByTourId(int id);
        Result Delete(int id);
        Result<TourEquipmentDto> Create(TourEquipmentDto tourEquipment);
    }
}
