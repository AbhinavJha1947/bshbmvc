using System.ComponentModel.DataAnnotations;
namespace BiharStateHousingBoard.Models
{
    public class PropertyMaster
    {
        [Key]
        public int PropertyId { get; set; }
        public string? PropertyCategory { get; set; }
        public string? Property { get; set; }
    }
}
