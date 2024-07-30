using System.ComponentModel.DataAnnotations;

namespace BiharStateHousingBoard.Models
{
    public class PressReleaseModel
    {
        [Key]
        public int Id { get; set; }
        public string? Heading { get; set; }
        public string? Details { get; set; }
        public int? DisplayOrder { get; set; }
        public bool Active { get; set; }
        [DataType(DataType.Date, ErrorMessage = "Date only")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> ReleaseDate { get; set; }
        public string? DateCreated { get; set; }
    }
}
