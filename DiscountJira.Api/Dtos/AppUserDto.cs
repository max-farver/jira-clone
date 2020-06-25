using System.ComponentModel.DataAnnotations;

namespace DiscountJira.Api.Dtos
{
    public class AppUserDto
    {
        public int Id { get; set; }
        [Required]
        public string DisplayName { get; set; }
        public string AvatarLocation { get; set; }
    }
}