﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bootcamp.Domain.Products;

namespace Bootcamp.Domain.Categories
{
    public class Category : BaseEntity<int>
    {
        public string Name { get; set; } = default!;
        public virtual IEnumerable<Product>? Products { get; set; }
    }
}
