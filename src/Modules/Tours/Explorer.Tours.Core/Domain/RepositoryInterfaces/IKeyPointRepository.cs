﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.Domain.RepositoryInterfaces
{
    public interface IKeyPointRepository
    {
        public KeyPoint GetByIdAsync(int keyPointId);
        KeyPoint GetByStoryId(int storyId);
        KeyPoint Update(KeyPoint entity);
    }
}
