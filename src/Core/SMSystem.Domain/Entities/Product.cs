﻿using SMSystem.Domain.Entities.Common;

namespace SMSystem.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Inventory> Inventories { get; set; }
    }
}
