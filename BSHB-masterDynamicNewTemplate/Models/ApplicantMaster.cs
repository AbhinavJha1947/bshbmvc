using System.ComponentModel.DataAnnotations;
namespace BiharStateHousingBoard.Models
{
    public class ApplicantMaster
    {
        [Key]
        public int RegistrationNo { get; set; }
        public string? ApplicantCategory { get; set; }
        public string? ApplicantName { get; set; }
    }
}
