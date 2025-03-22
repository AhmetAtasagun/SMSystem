using System.ComponentModel.DataAnnotations;

namespace SMSystem.Domain.Models.AuthModels
{

    public class RefreshTokenModel
    {
        [Required]
        public string RefreshToken { get; set; }
    }
}