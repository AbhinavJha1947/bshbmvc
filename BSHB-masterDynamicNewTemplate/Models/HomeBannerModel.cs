using System.ComponentModel.DataAnnotations;

namespace BiharStateHousingBoard.Models
{
    public class HomeBannerModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? homebannerImage { get; set; }
    }
}
