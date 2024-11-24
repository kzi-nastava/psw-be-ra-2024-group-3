using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Payments.Core.Domain.ShoppingCarts;
using FluentResults;
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

        public int RefundPurchasedTour(int tourId, int touristId);

        TourPurchaseToken FindByTourAndTourist(int tourId, int touristId);

    }
}
