using System.ComponentModel.DataAnnotations;
namespace BiharStateHousingBoard.Models
{
    public class AlbumMaster
    {
        [Key]
        public int ImageId { get; set; }
        public string? ImagePath { get; set; }
        //public byte[] Image { get; set; }
    }
}
