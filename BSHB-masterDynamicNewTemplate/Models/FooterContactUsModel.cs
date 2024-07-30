using System.ComponentModel.DataAnnotations;

namespace BiharStateHousingBoard.Models
{
    public class FooterContactUsModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? addressline1 { get; set; }
        [Required]
        public string? addressline2 { get; set; }
        [Required]
        public string? addressline3 { get; set; }
        [Required]
        public string? addressline4 { get; set; }
        [Required]
        public string? Pincode { get; set; }
        [Required]
        public string? mobile1 { get; set; }
        [Required]
        public string? mobile2 { get; set; }
        [Required]
        public string? emailaddress { get; set; }
    }
}
