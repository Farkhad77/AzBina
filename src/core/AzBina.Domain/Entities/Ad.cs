using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzBina.Domain.Entities
{
    
        public class Ad : BaseEntity
        {
        public int Room_Count { get; set; }
        public bool for_sale { get; set; }
        public decimal Price { get; set; }
        public decimal Field { get; set; }
        public decimal House_Field { get; set; }
        public int Floor { get; set; }
        public string Note { get; set; }
        public bool Deed { get; set; }
        public string Map { get; set; }
        public string Address { get; set; }
        public bool is_activited { get; set; }
        public bool is_approved { get; set; }
        public int Building_Floor { get; set; }
        public bool is_repaired { get; set; }
        public int Building_Type { get; set; }

        public Category Category { get; set; }
        public Guid CategoryId { get; set; }

        public City City { get; set; }
        public Guid CityId { get; set; }

        public Township Town { get; set; }
        public Guid TownId { get; set; }

        public District District { get; set; }
        public Guid DistrictId { get; set; }

        public Type Type { get; set; }
        public Guid TypeId { get; set; }

        public ICollection<Favorite> Favorites { get; set; }
        public ICollection<Image> Images { get; set; }
    }

    }

