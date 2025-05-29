using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzBina.Domain.Entities
{
    public class Ad
    {
        public class Ad
        {
            public int Id { get; set; }
            public int CategoryId { get; set; }
            public int RoomCount { get; set; }
            public bool ForSale { get; set; }
            public decimal Price { get; set; }
            public decimal Field { get; set; }
            public decimal HouseField { get; set; }
            public int Floor { get; set; }
            public int CityId { get; set; }
            public int TownshipId { get; set; }
            public int DistrictId { get; set; }
            public string Note { get; set; }
            public int UserId { get; set; }
            public int TypesId { get; set; }
            public bool Deed { get; set; }
            public string Map { get; set; }
            public string Address { get; set; }
            public bool IsActivated { get; set; }
            public bool IsApproved { get; set; }
            public int BuildingFloor { get; set; }
            public bool IsRepaired { get; set; }
            public int BuildingType { get; set; }

            public User User { get; set; }
            public Category Category { get; set; }
            public Type Type { get; set; }
            public City City { get; set; }
            public District District { get; set; }
            public Township Township { get; set; }

            public ICollection<Image> Images { get; set; }
            public ICollection<Favorite> Favorites { get; set; }
        }

    }
}
