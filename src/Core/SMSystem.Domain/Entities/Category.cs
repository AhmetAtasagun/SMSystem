using SMSystem.Domain.Entities.Common;

namespace SMSystem.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        public int? ParentId { get; set; }
        public Category Parent { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
