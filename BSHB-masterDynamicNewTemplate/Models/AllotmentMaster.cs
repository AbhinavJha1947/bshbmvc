using System.ComponentModel.DataAnnotations;
namespace BiharStateHousingBoard.Models
{
    public class AllotmentMaster
    {
        [Key]
        public int AllotmentId { get; set; }
        public string? Property { get; set; }
        public int RegistrationNo { get; set; }
        public string? ApplicantName { get; set; }
    }
}
