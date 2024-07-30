using Microsoft.EntityFrameworkCore;

namespace BiharStateHousingBoard.Models
{
    public class DemoEntityContext : DbContext
    {
        public DemoEntityContext(DbContextOptions<DemoEntityContext> options) : base(options)
        {
        }

        public DbSet<HomeBannerModel> HomeBanner { get; set; }
        public DbSet<DynamicMasterPageModel> MasterPageItems { get; set; }
        public DbSet<MenuModel> Menus { get; set; }
        public DbSet<FooterHotLinksModel> FooterHotLinkss { get; set; }
        public DbSet<PressReleaseModel> PressReleases { get; set; }
        public DbSet<FooterMapModel> FooterMaps { get; set; }
        public DbSet<FooterContactUsModel> FooterContactUss { get; set; }
        public DbSet<HomeIndexPageModel> HomeIndexPages { get; set; }
        public DbSet<LoginViewModel> Login { get; set; }
        public DbSet<Roles> Roless { get; set; }
        public DbSet<AlbumMaster> PhotoAlbumMaster { get; set; }
        public DbSet<PropertyMaster> PropertyMaster { get; set; }
        public DbSet<ApplicantMaster> ApplicantMaster { get; set; }
        public DbSet<AllotmentMaster> AllotmentMaster { get; set; }
    }
}
