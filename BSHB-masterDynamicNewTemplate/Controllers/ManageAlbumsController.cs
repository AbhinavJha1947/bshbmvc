using BiharStateHousingBoard.Models;
using Microsoft.AspNetCore.Mvc;

namespace BiharStateHousingBoard.Controllers
{
    public class ManageAlbumsController : Controller
    {
        public IActionResult Index()
        {
            var model = new List<DynamicMasterPageModel>();
            try
            {
                using (var context = new DemoEntityContext())
                {
                    var value = context.MasterPageItems.ToList();
                    int cnt = value.Count();
                    int loop = 1;
                    foreach (var masterpgitm in value)
                    {
                        var masterpgModel = new DynamicMasterPageModel();
                        masterpgModel.Name = masterpgitm.Name;
                        masterpgModel.Description = masterpgitm.Description;
                        masterpgModel.IsActive = masterpgitm.IsActive;
                        masterpgModel.logo = masterpgitm.logo;
                        masterpgModel.logo = masterpgitm.logo;
                        masterpgModel.DepartmentInEnglish = masterpgitm.DepartmentInEnglish;
                        masterpgModel.DepartmentInHindi = masterpgitm.DepartmentInHindi;
                        masterpgModel.DepartmentInEnglishFontSize = masterpgitm.DepartmentInEnglishFontSize;
                        masterpgModel.DepartmentInHindiFontSize = masterpgitm.DepartmentInHindiFontSize;
                        masterpgModel.DepartmentInHindiLineHeight = masterpgitm.DepartmentInHindiLineHeight;
                        masterpgModel.headerBkGrndClrHashCode = masterpgitm.headerBkGrndClrHashCode;
                        masterpgModel.DepartmentDividerLineImage = masterpgitm.DepartmentDividerLineImage;
                        masterpgModel.HeaderIcon1Path = masterpgitm.HeaderIcon1Path;
                        masterpgModel.HeaderIcon2Path = masterpgitm.HeaderIcon2Path;
                        masterpgModel.HeaderIcon3Path = masterpgitm.HeaderIcon3Path;
                        masterpgModel.HeaderIcon4Path = masterpgitm.HeaderIcon4Path;
                        masterpgModel.HeaderIcon5Path = masterpgitm.HeaderIcon5Path;
                        masterpgModel.HeaderIcon6Path = masterpgitm.HeaderIcon6Path;
                        masterpgModel.HeaderIcon7Path = masterpgitm.HeaderIcon7Path;
                        masterpgModel.HeaderIconHeight = masterpgitm.HeaderIconHeight;
                        masterpgModel.HeaderIconWidth = masterpgitm.HeaderIconWidth;
                        masterpgModel.MinistryDividerLineImage = masterpgitm.MinistryDividerLineImage;
                        TempData["MinistryDividerLineImage"] = masterpgitm.MinistryDividerLineImage;
                        masterpgModel.MinistryNmInEnglish = masterpgitm.MinistryNmInEnglish;
                        masterpgModel.MinistryNmInEnglishFontSize = masterpgitm.MinistryNmInEnglishFontSize;
                        masterpgModel.MinistryNmInHindi = masterpgitm.MinistryNmInHindi;
                        masterpgModel.MinistryNmInHindiFontSize = masterpgitm.MinistryNmInHindiFontSize;
                        masterpgModel.MinistryNmInHindiLineHeight = masterpgitm.MinistryNmInHindiLineHeight;
                        masterpgModel.MinistryUrl = masterpgitm.MinistryUrl;
                        if (loop == cnt)
                        {
                            model.Add(masterpgModel);
                        }
                        else
                        {
                            loop = loop + 1;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            List<DynamicMasterPageModel>? MsterPgeItems = new List<DynamicMasterPageModel>();
            MsterPgeItems = model;
            var MsterPgeMnus = new List<MenuModel>();

            using (var context = new DemoEntityContext())
            {
                var value = context.Menus.ToList();
                foreach (var mnuitm in value)
                {
                    var mnuModel = new MenuModel();
                    mnuModel.Id = mnuitm.Id;
                    mnuModel.ParentMenuId = mnuitm.ParentMenuId;
                    mnuModel.Title = mnuitm.Title;
                    mnuModel.Controller = mnuitm.Controller;
                    mnuModel.Action = mnuitm.Action;
                    mnuModel.DateCreated = mnuitm.DateCreated;
                    MsterPgeMnus.Add(mnuModel);
                }
                TempData["menucnt"] = context.Menus.Select(p => p.ParentMenuId).Distinct().Count();
                //TempData["menucnt"] = context.Menus.DistinctBy(p => p.ParentMenuId).ToList().Count;
                //TempData["menucnt"] = context.Menus.Select(mnuMsterPgeMnus.).ToList().Count;
            }

            var FtrHotLinksMnus = new List<FooterHotLinksModel>();

            using (var context = new DemoEntityContext())
            {
                var value = context.FooterHotLinkss.ToList();
                foreach (var ftrmnuitm in value)
                {

                    var ftrmnulnkModel = new FooterHotLinksModel();
                    ftrmnulnkModel.Id = ftrmnuitm.Id;
                    ftrmnulnkModel.ParentMenuId = ftrmnuitm.ParentMenuId;
                    ftrmnulnkModel.Title = ftrmnuitm.Title;
                    ftrmnulnkModel.Controller = ftrmnuitm.Controller;
                    ftrmnulnkModel.Action = ftrmnuitm.Action;
                    ftrmnulnkModel.DateCreated = ftrmnuitm.DateCreated;
                    FtrHotLinksMnus.Add(ftrmnulnkModel);
                }
            }
            var Ftrmaplnk = new List<FooterMapModel>();

            using (var context = new DemoEntityContext())
            {
                var value = context.FooterMaps.ToList();
                int cnt = value.Count();
                int loopftrmaplnk = 1;
                foreach (var ftrmnuitm in value)
                {
                    var ftrmaplnkModel = new FooterMapModel();
                    ftrmaplnkModel.Id = ftrmnuitm.Id;
                    ftrmaplnkModel.maplink = ftrmnuitm.maplink;
                    if (loopftrmaplnk == cnt)
                    {
                        Ftrmaplnk.Add(ftrmaplnkModel);
                    }
                    else
                    {
                        loopftrmaplnk = loopftrmaplnk + 1;
                    }
                }
            }
            var Ftrcontactus = new List<FooterContactUsModel>();

            using (var context = new DemoEntityContext())
            {
                var value = context.FooterContactUss.ToList();
                int cnt = value.Count();
                int loopftrcontactus = 1;
                foreach (var ftrcontactusitm in value)
                {
                    var ftrcntactusModel = new FooterContactUsModel();
                    ftrcntactusModel.Id = ftrcontactusitm.Id;
                    ftrcntactusModel.addressline1 = ftrcontactusitm.addressline1;
                    ftrcntactusModel.addressline2 = ftrcontactusitm.addressline2;
                    ftrcntactusModel.addressline3 = ftrcontactusitm.addressline3;
                    ftrcntactusModel.addressline4 = ftrcontactusitm.addressline4;
                    ftrcntactusModel.Pincode = ftrcontactusitm.Pincode;
                    ftrcntactusModel.mobile1 = ftrcontactusitm.mobile1;
                    ftrcntactusModel.mobile2 = ftrcontactusitm.mobile2;
                    ftrcntactusModel.emailaddress = ftrcontactusitm.emailaddress;
                    if (loopftrcontactus == cnt)
                    {
                        Ftrcontactus.Add(ftrcntactusModel);
                    }
                    else
                    {
                        loopftrcontactus = loopftrcontactus + 1;
                    }
                }
            }
            var hmIndxPgModel = new List<HomeIndexPageModel>();

            using (var context = new DemoEntityContext())
            {
                var value = context.HomeIndexPages.ToList();
                int cnt = value.Count();
                int loop = 1;
                foreach (var hmindxpgitm in value)
                {
                    var hmindexmodel = new HomeIndexPageModel();
                    hmindexmodel.Id = hmindxpgitm.Id;
                    hmindexmodel.pgTitle = hmindxpgitm.pgTitle;
                    hmindexmodel.hmInxTitleImage = hmindxpgitm.hmInxTitleImage;
                    hmindexmodel.hmInxTitleDescription = hmindxpgitm.hmInxTitleDescription;
                    hmindexmodel.hmInxTitleReadMoreUrl = hmindxpgitm.hmInxTitleReadMoreUrl;
                    hmindexmodel.hmInxTitleImageWidth = hmindxpgitm.hmInxTitleImageWidth;
                    hmindexmodel.hmInxTitleImageHeight = hmindxpgitm.hmInxTitleImageHeight;

                    hmindexmodel.hmInxPrimeMinisterImage = hmindxpgitm.hmInxPrimeMinisterImage;
                    hmindexmodel.hmInxPrimeMinisterName = hmindxpgitm.hmInxPrimeMinisterName;
                    hmindexmodel.hmInxPrimeMinisterDesignation = hmindxpgitm.hmInxPrimeMinisterDesignation;
                    hmindexmodel.hmInxPrimeMinisterPlace = hmindxpgitm.hmInxPrimeMinisterPlace;
                    hmindexmodel.hmInxPrimeMinisterPortfolioUrl = hmindxpgitm.hmInxPrimeMinisterPortfolioUrl;

                    hmindexmodel.hmInxChiefMinisterImage = hmindxpgitm.hmInxChiefMinisterImage;
                    hmindexmodel.hmInxChiefMinisterName = hmindxpgitm.hmInxChiefMinisterName;
                    hmindexmodel.hmInxChiefMinisterDesignation = hmindxpgitm.hmInxChiefMinisterDesignation;
                    hmindexmodel.hmInxChiefMinisterPlace = hmindxpgitm.hmInxChiefMinisterPlace;

                    hmindexmodel.hmInxMinisterOfficer1Image = hmindxpgitm.hmInxMinisterOfficer1Image;
                    hmindexmodel.hmInxMinisterOfficer1Name = hmindxpgitm.hmInxMinisterOfficer1Name;
                    hmindexmodel.hmInxMinisterOfficer1Designation = hmindxpgitm.hmInxMinisterOfficer1Designation;
                    hmindexmodel.hmInxMinisterOfficer1Place = hmindxpgitm.hmInxMinisterOfficer1Place;
                    hmindexmodel.hmInxMinisterOfficer2Image = hmindxpgitm.hmInxMinisterOfficer2Image;
                    hmindexmodel.hmInxMinisterOfficer2Name = hmindxpgitm.hmInxMinisterOfficer2Name;
                    hmindexmodel.hmInxMinisterOfficer2Designation = hmindxpgitm.hmInxMinisterOfficer2Designation;
                    hmindexmodel.hmInxMinisterOfficer2Place = hmindxpgitm.hmInxMinisterOfficer2Place;
                    hmindexmodel.hmInxMinisterOfficer3Image = hmindxpgitm.hmInxMinisterOfficer3Image;
                    hmindexmodel.hmInxMinisterOfficer3Name = hmindxpgitm.hmInxMinisterOfficer3Name;
                    hmindexmodel.hmInxMinisterOfficer3Designation = hmindxpgitm.hmInxMinisterOfficer3Designation;
                    hmindexmodel.hmInxMinisterOfficer3Place = hmindxpgitm.hmInxMinisterOfficer3Place;
                    hmindexmodel.hmInxMinisterOfficer4Image = hmindxpgitm.hmInxMinisterOfficer4Image;
                    hmindexmodel.hmInxMinisterOfficer4Name = hmindxpgitm.hmInxMinisterOfficer4Name;
                    hmindexmodel.hmInxMinisterOfficer4Designation = hmindxpgitm.hmInxMinisterOfficer4Designation;
                    hmindexmodel.hmInxMinisterOfficer4Place = hmindxpgitm.hmInxMinisterOfficer4Place;
                    hmindexmodel.hmInxMinisterOfficer5Image = hmindxpgitm.hmInxMinisterOfficer5Image;
                    hmindexmodel.hmInxMinisterOfficer5Name = hmindxpgitm.hmInxMinisterOfficer5Name;
                    hmindexmodel.hmInxMinisterOfficer5Designation = hmindxpgitm.hmInxMinisterOfficer5Designation;
                    hmindexmodel.hmInxMinisterOfficer5Place = hmindxpgitm.hmInxMinisterOfficer5Place;
                    hmindexmodel.hmInxMinisterOfficer6Image = hmindxpgitm.hmInxMinisterOfficer6Image;
                    hmindexmodel.hmInxMinisterOfficer6Name = hmindxpgitm.hmInxMinisterOfficer6Name;
                    hmindexmodel.hmInxMinisterOfficer6Designation = hmindxpgitm.hmInxMinisterOfficer6Designation;
                    hmindexmodel.hmInxMinisterOfficer6Place = hmindxpgitm.hmInxMinisterOfficer6Place;
                    hmindexmodel.hmInxMinisterOfficerImageWidth = hmindxpgitm.hmInxMinisterOfficerImageWidth;
                    hmindexmodel.hmInxMinisterOfficerImageHeight = hmindxpgitm.hmInxMinisterOfficerImageHeight;
                    if (loop == cnt)
                    {
                        hmIndxPgModel.Add(hmindexmodel);
                    }
                    else
                    {
                        loop = loop + 1;
                    }
                }
            }
            var HmBannerImage = new List<HomeBannerModel>();

            using (var context = new DemoEntityContext())
            {
                var value = context.HomeBanner.ToList();
                foreach (var hmbnnritm in value)
                {

                    var hmBnnrModel = new HomeBannerModel();
                    hmBnnrModel.Id = hmbnnritm.Id;
                    hmBnnrModel.homebannerImage = hmbnnritm.homebannerImage;
                    HmBannerImage.Add(hmBnnrModel);
                }
            }

            var PrsRels = new List<PressReleaseModel>();
            using (var context = new DemoEntityContext())
            {
                var value = context.PressReleases.ToList();
                foreach (var prsrelitm in value)
                {
                    var prsrelModel = new PressReleaseModel();
                    prsrelModel.Id = prsrelitm.Id;
                    prsrelModel.Heading = prsrelitm.Heading;
                    prsrelModel.Details = prsrelitm.Details;
                    prsrelModel.ReleaseDate = prsrelitm.ReleaseDate;
                    prsrelModel.DisplayOrder = prsrelitm.DisplayOrder;
                    prsrelModel.Active = prsrelitm.Active;
                    prsrelModel.DateCreated = prsrelitm.DateCreated;
                    PrsRels.Add(prsrelModel);
                }
            }            
            var PhoAlbm = new List<AlbumMaster>();
            using (var context = new DemoEntityContext())
            {
                var value = context.PhotoAlbumMaster.ToList();
                foreach (var phtoalbmitm in value)
                {
                    var phtAlbumModel = new AlbumMaster();
                    phtAlbumModel.ImageId = phtoalbmitm.ImageId;
                    phtAlbumModel.ImagePath = phtoalbmitm.ImagePath;

                    PhoAlbm.Add(phtAlbumModel);
                }
            }
            var PhtoGaleyViewModel = new PhotoGalleryViewModel();
            PhtoGaleyViewModel.photoalnmlstmdl = PhoAlbm.ToList();

            var MasterPgViewModel = new MasterPgViewModel();

            MasterPgViewModel.mstrpg = MsterPgeItems.ToList();
            MasterPgViewModel.mnus = MsterPgeMnus.ToList();
            MasterPgViewModel.ftrhotlinks = FtrHotLinksMnus.ToList();
            MasterPgViewModel.ftrmaplink = Ftrmaplnk.ToList();
            MasterPgViewModel.ftrcntactus = Ftrcontactus.ToList();
            MasterPgViewModel.hmindxpg = hmIndxPgModel.ToList();
            MasterPgViewModel.hmbnnr = HmBannerImage.ToList();
            MasterPgViewModel.prssrel = PrsRels.ToList();
            MasterPgViewModel.photoalnmlstmdl = PhoAlbm.ToList();
            return View(MasterPgViewModel);
            //return View();
        }
    }
}
