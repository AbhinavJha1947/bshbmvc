using System.ComponentModel.DataAnnotations;

namespace BiharStateHousingBoard.Models
{
    public class FooterMapModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? maplink { get; set; }

    }
}
