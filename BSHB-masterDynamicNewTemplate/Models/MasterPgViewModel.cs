namespace BiharStateHousingBoard.Models
{
    public class MasterPgViewModel
    {
        public List<BiharStateHousingBoard.Models.MenuModel> mnus { get; set; }
        public List<BiharStateHousingBoard.Models.DynamicMasterPageModel> mstrpg { get; set; }
        public List<BiharStateHousingBoard.Models.FooterHotLinksModel> ftrhotlinks { get; set; }
        public List<BiharStateHousingBoard.Models.FooterMapModel> ftrmaplink { get; set; }
        public List<BiharStateHousingBoard.Models.FooterContactUsModel> ftrcntactus { get; set; }
        public List<BiharStateHousingBoard.Models.HomeIndexPageModel> hmindxpg { get; set; }
        public List<BiharStateHousingBoard.Models.HomeBannerModel> hmbnnr { get; set; }
        public List<BiharStateHousingBoard.Models.PressReleaseModel> prssrel { get; set; }
        public List<BiharStateHousingBoard.Models.AlbumMaster> photoalnmlstmdl { get; set; }
        public BiharStateHousingBoard.Models.AlbumMaster photoalblmstrmdl { get; set; }
    }
}
