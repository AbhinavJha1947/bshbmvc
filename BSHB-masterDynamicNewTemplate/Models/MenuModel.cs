﻿using System.ComponentModel.DataAnnotations;
namespace BiharStateHousingBoard.Models
{
    public class MenuModel
    {
        [Key]
        public int Id { get; set; }
        public int? ParentMenuId { get; set; }
        public string? Title { get; set; }
        public string? Controller { get; set; }
        public string? Action { get; set; }
        public string? DateCreated { get; set; }
    }
}
