using SMSystem.Domain.Entities.Common;

namespace SMSystem.Domain.Entities
{
    public class Localization : BaseEntity
    {
        public string ResourceKey { get; set; }
        public string CultureCode { get; set; }
        public string ResourceValue { get; set; }
    }
}