using BiharStateHousingBoard.Models;
using Microsoft.EntityFrameworkCore;

namespace BiharStateHousingBoard
{
    public class MenuEntities : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-41D89A4\\SQLEXPRESS;Database=bshb;Trusted_Connection=True;User Id=sa;Password=abcd;");
        }
        public DbSet<MenuModel> Menus { get; set; }

    }
}
