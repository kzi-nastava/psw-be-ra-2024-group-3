﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.API.Dtos.TourProblemDtos
{
    public class ProblemDetailsDto
    {  
        public ProblemCategory Category { get;  set; }
        public int ProblemPriority { get;  set; }
        public string Explanation { get;  set; }
        public DateTime Time { get;  set; }  
    }

    public enum ProblemCategory
    {
        Other,
        UnclearInstructions,
        RoadObstacles,
        UnreachablePart
    }
}
