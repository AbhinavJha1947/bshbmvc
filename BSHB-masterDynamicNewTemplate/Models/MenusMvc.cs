using System;
using System.Collections.Generic;

namespace BiharStateHousingBoard.Models
{
    public partial class MenusMvc
    {
        public int MenuId { get; set; }
        public int? ParentMenuId { get; set; }
        public string? Title { get; set; }
        public string? Controller { get; set; }
        public string? Action { get; set; }
    }
}
