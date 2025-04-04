﻿using Explorer.BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Explorer.Payments.Core.Domain.Shopping
{
    public enum BundleStatus
    {
        Draft,
        Published,
        Archived
    }

    public class Bundle : Entity
    {
        public int AuthorId { get; private set; }
        public List<int> TourIds { get; private set; }
        public double Price { get; private set; }
        public BundleStatus Status { get; private set; }
        public string Title { get; private set; }

        public Bundle() { }


        public Bundle(int authorId, List<int> tourIds, double price, string title)
        {
            AuthorId = authorId;
            Price = price;
            Status = BundleStatus.Draft;
            TourIds = tourIds;
            if (string.IsNullOrWhiteSpace(title)) throw new ArgumentException("Invalid bundle title.");
            Title = title;
        }

    }
}
