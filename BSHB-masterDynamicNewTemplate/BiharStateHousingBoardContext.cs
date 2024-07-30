using BiharStateHousingBoard.Models;
using Microsoft.EntityFrameworkCore;

namespace BiharStateHousingBoard
{
    public class BiharStateHousingBoardContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=VINIT\\SQLEXPRESS;Database=BSHB_DBFinal;Trusted_Connection=True;User Id=sa;Password=abc1234;");
        }
        public DbSet<HomeBannerModel> HomeBanner { get; set; }
        public DbSet<DynamicMasterPageModel> MasterPageItems { get; set; }
        public DbSet<MenuModel> Menus { get; set; }
        public DbSet<FooterHotLinksModel> FooterHotLinkss { get; set; }
        public DbSet<FooterMapModel> FooterMaps { get; set; }
        public DbSet<FooterContactUsModel> FooterContactUss { get; set; }
        public DbSet<HomeIndexPageModel> HomeIndexPages { get; set; }
        public DbSet<LoginViewModel> Login { get; set; }
        public DbSet<Roles> Roless { get; set; }

    }
}
