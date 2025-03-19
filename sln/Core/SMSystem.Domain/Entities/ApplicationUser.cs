using Microsoft.AspNetCore.Identity;

namespace SMSystem.Domain.Entities
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string FullName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}