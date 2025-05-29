using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzBina.Domain.Entities
{
     
        public class User
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string PhoneNumber { get; set; }
            public string Email { get; set; }
            public bool IsAgent { get; set; }
            public DateTime CreatedAt { get; set; }

            public ICollection<Ad> Ads { get; set; }
            public ICollection<Favorite> Favorites { get; set; }
        }

    }

