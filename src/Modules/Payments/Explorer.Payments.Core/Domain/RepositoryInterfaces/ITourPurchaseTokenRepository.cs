﻿using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Payments.Core.Domain.ShoppingCarts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Payments.Core.Domain.RepositoryInterfaces
{
    public interface ITourPurchaseTokenRepository: ICrudRepository<TourPurchaseToken>
    {
        public List<int> GetPurchasedTours(int touristId);

    }
}
