using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzBina.Domain.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public Guid? CreatedUser { get; set; }
        public DateTime? CreatedAt { get; set; }
        public Guid? UpdatedUser { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
