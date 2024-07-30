using BiharStateHousingBoard.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json;

using System.Security.Cryptography;
using System;
using System.Data.SqlClient;
using System.Runtime.Intrinsics.X86;
using Microsoft.AspNetCore.Authorization;
using NuGet.Protocol.Core.Types;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace BiharStateHousingBoard.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View("InsertHomePage");
        }
        public IActionResult Dashboard()
        {
            return View("Dashboard");
        }
        public IActionResult InsertHomePage()
        {
            if (HttpContext.Session.GetString("Role") == "_Admin")
            {
                //HttpContext.Session.SetString("Role", "");
                var mdl = new List<DynamicMasterPageModel>();
                var mstrpgMdl = new DynamicMasterPageModel();
                try
                {
                    using (var context = new DemoEntityContext())
                    {
                        var value = context.MasterPageItems.ToList();
                        int cnt = value.Count();
                        int loop = 1;
                        foreach (var masterpgitm in value)
                        {
                            var masterpgMdl = new DynamicMasterPageModel();
                            masterpgMdl.Name = masterpgitm.Name;
                            masterpgMdl.Description = masterpgitm.Description;
                            masterpgMdl.IsActive = masterpgitm.IsActive;
                            masterpgMdl.logo = masterpgitm.logo;
                            TempData["logo"] = masterpgitm.logo;
                            masterpgMdl.DepartmentInEnglish = masterpgitm.DepartmentInEnglish;
                            masterpgMdl.DepartmentInHindi = masterpgitm.DepartmentInHindi;
                            masterpgMdl.DepartmentInEnglishFontSize = masterpgitm.DepartmentInEnglishFontSize;
                            masterpgMdl.DepartmentInHindiFontSize = masterpgitm.DepartmentInHindiFontSize;
                            masterpgMdl.DepartmentInHindiLineHeight = masterpgitm.DepartmentInHindiLineHeight;
                            masterpgMdl.headerBkGrndClrHashCode = masterpgitm.headerBkGrndClrHashCode;
                            masterpgMdl.DepartmentDividerLineImage = masterpgitm.DepartmentDividerLineImage;
                            TempData["DepartmentDividerLineImage"] = masterpgitm.DepartmentDividerLineImage != "" ? masterpgitm.DepartmentDividerLineImage : null;
                            masterpgMdl.HeaderIcon1Path = masterpgitm.HeaderIcon1Path;
                            TempData["HeaderIcon1Path"] = masterpgitm.HeaderIcon1Path;
                            masterpgMdl.HeaderIcon2Path = masterpgitm.HeaderIcon2Path;
                            TempData["HeaderIcon2Path"] = masterpgitm.HeaderIcon2Path;

                            masterpgMdl.HeaderIcon3Path = masterpgitm.HeaderIcon3Path;
                            TempData["HeaderIcon3Path"] = masterpgitm.HeaderIcon3Path;

                            masterpgMdl.HeaderIcon4Path = masterpgitm.HeaderIcon4Path;
                            TempData["HeaderIcon4Path"] = masterpgitm.HeaderIcon4Path;

                            masterpgMdl.HeaderIcon5Path = masterpgitm.HeaderIcon5Path;
                            TempData["HeaderIcon5Path"] = masterpgitm.HeaderIcon5Path;

                            masterpgMdl.HeaderIcon6Path = masterpgitm.HeaderIcon6Path;
                            TempData["HeaderIcon6Path"] = masterpgitm.HeaderIcon6Path;

                            masterpgMdl.HeaderIcon7Path = masterpgitm.HeaderIcon7Path;
                            TempData["HeaderIcon7Path"] = masterpgitm.HeaderIcon7Path;

                            masterpgMdl.HeaderIconHeight = masterpgitm.HeaderIconHeight;
                            masterpgMdl.HeaderIconWidth = masterpgitm.HeaderIconWidth;
                            masterpgMdl.MinistryNmInEnglish = masterpgitm.MinistryNmInEnglish;
                            masterpgMdl.MinistryNmInHindi = masterpgitm.MinistryNmInHindi;
                            masterpgMdl.MinistryNmInEnglishFontSize = masterpgitm.MinistryNmInEnglishFontSize;
                            masterpgMdl.MinistryNmInHindiFontSize = masterpgitm.MinistryNmInHindiFontSize;
                            masterpgMdl.MinistryNmInHindiLineHeight = masterpgitm.MinistryNmInHindiLineHeight;
                            masterpgMdl.MinistryUrl = masterpgitm.MinistryUrl;
                            if (loop == cnt)
                            {
                                mdl.Add(masterpgMdl);
                                mstrpgMdl = masterpgMdl;
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
                return View("InsertHomePage", mstrpgMdl);
            }
            else
            {
                return RedirectToAction("Admin", "Account");
            }
        }
        [HttpPost]
        public ActionResult InsertHomePage(DynamicMasterPageModel mp, IFormFile Image1, IFormFile dvdrImage, IFormFile dvdrImageMinistry, IFormFile HdrImage1, IFormFile HdrImage2, IFormFile HdrImage3, IFormFile HdrImage4, IFormFile HdrImage5, IFormFile HdrImage6, IFormFile HdrImage7)
        {
            //if (HttpContext.Session.GetString("Role") == "_Admin")
            //{
            var model = new List<DynamicMasterPageModel>();
            var masterpgModel = new DynamicMasterPageModel();
            masterpgModel.Name = mp.Name;
            masterpgModel.headerBkGrndClrHashCode = mp.headerBkGrndClrHashCode;
            masterpgModel.Description = mp.Description;
            masterpgModel.IsActive = mp.IsActive;
            masterpgModel.DepartmentInEnglish = mp.DepartmentInEnglish;
            masterpgModel.DepartmentInHindi = mp.DepartmentInHindi;
            masterpgModel.DepartmentInEnglishFontSize = mp.DepartmentInEnglishFontSize;
            masterpgModel.DepartmentInHindiFontSize = mp.DepartmentInHindiFontSize;
            masterpgModel.DepartmentInHindiLineHeight = mp.DepartmentInHindiLineHeight;
            masterpgModel.HeaderIconHeight = mp.HeaderIconHeight;
            masterpgModel.HeaderIconWidth = mp.HeaderIconWidth;
            masterpgModel.MinistryNmInEnglish = mp.MinistryNmInEnglish;
            masterpgModel.MinistryNmInHindi = mp.MinistryNmInHindi;
            masterpgModel.MinistryNmInEnglishFontSize = mp.MinistryNmInEnglishFontSize;
            masterpgModel.MinistryNmInHindiFontSize = mp.MinistryNmInHindiFontSize;
            masterpgModel.MinistryNmInHindiLineHeight = mp.MinistryNmInHindiLineHeight;
            masterpgModel.MinistryUrl = mp.MinistryUrl;

            //if (Image1.FileName != null)
            //{
            //    mp.logo = ProcessUploadedFile(Image1);
            //}
            try
            {
                if (Image1.FileName != null)
                {
                    masterpgModel.logo = ProcessUploadedFileForHomeIndexPg(Image1);
                }
            }
            catch
            {
                if (masterpgModel.logo != "")
                {
                    masterpgModel.logo = TempData["logo"].ToString() == null ? "" : TempData["logo"].ToString();
                }
                else
                {
                    masterpgModel.logo = string.Empty;
                }
            }
            finally { }
            //masterpgModel.logo = mp.logo;
            //if (dvdrImage.FileName != null)
            //{
            //    mp.DepartmentDividerLineImage = ProcessUploadedFile(dvdrImage);
            //}
            try
            {
                //if (dvdrImage.FileName != null)
                if (dvdrImage.FileName != null)
                {
                    masterpgModel.DepartmentDividerLineImage = ProcessUploadedFileForHomeIndexPg(dvdrImage);
                }
            }
            catch
            {
                if (masterpgModel.DepartmentDividerLineImage != "")
                {
                    masterpgModel.DepartmentDividerLineImage = TempData["DepartmentDividerLineImage"].ToString() == null ? "" : TempData["DepartmentDividerLineImage"].ToString();
                }
                else
                {
                    masterpgModel.DepartmentDividerLineImage = string.Empty;
                }
            }
            finally { }
            try
            {
                //if (dvdrImage.FileName != null)
                if (dvdrImageMinistry.FileName != null)
                {
                    masterpgModel.MinistryDividerLineImage = ProcessUploadedFileForHomeIndexPg(dvdrImageMinistry);
                }
            }
            catch
            {
                if (masterpgModel.MinistryDividerLineImage != "")
                {
                    masterpgModel.MinistryDividerLineImage = TempData["MinistryDividerLineImage"].ToString() == null ? "" : TempData["MinistryDividerLineImage"].ToString();
                }
                else
                {
                    masterpgModel.MinistryDividerLineImage = string.Empty;
                }
            }
            finally { }
            masterpgModel.HeaderIcon1Path = "";
            masterpgModel.HeaderIcon2Path = "";
            masterpgModel.HeaderIcon3Path = "";
            masterpgModel.HeaderIcon4Path = "";
            masterpgModel.HeaderIcon5Path = "";
            masterpgModel.HeaderIcon6Path = "";
            masterpgModel.HeaderIcon7Path = "";
            //masterpgModel.DepartmentDividerLineImage = mp.DepartmentDividerLineImage;

            //if (HdrImage1.FileName != null)
            //{
            //    mp.HeaderIcon1Path = ProcessUploadedFile(HdrImage1);
            //}
            //try
            //{
            //    //if (dvdrImage.FileName != null)
            //    if (HdrImage1.FileName != null)
            //    {
            //        masterpgModel.HeaderIcon1Path = ProcessUploadedFileForHomeIndexPg(HdrImage1);
            //    }
            //}
            //catch
            //{
            //    if (masterpgModel.HeaderIcon1Path != "")
            //    {
            //        masterpgModel.HeaderIcon1Path = TempData["HeaderIcon1Path"].ToString() == null ? "" : TempData["HeaderIcon1Path"].ToString();
            //    }
            //    else
            //    {
            //        masterpgModel.HeaderIcon1Path = string.Empty;
            //    }
            //}
            //finally { }
            ////masterpgModel.HeaderIcon1Path = mp.HeaderIcon1Path;
            ////if (HdrImage2.FileName != null)
            ////{
            ////    mp.HeaderIcon2Path = ProcessUploadedFile(HdrImage2);
            ////}
            //try
            //{
            //    //if (dvdrImage.FileName != null)
            //    if (HdrImage2.FileName != null)
            //    {
            //        masterpgModel.HeaderIcon2Path = ProcessUploadedFileForHomeIndexPg(HdrImage2);
            //    }
            //}
            //catch
            //{
            //    if (masterpgModel.HeaderIcon2Path != "")
            //    {
            //        masterpgModel.HeaderIcon2Path = TempData["HeaderIcon2Path"].ToString() == null ? "" : TempData["HeaderIcon2Path"].ToString();
            //    }
            //    else
            //    {
            //        masterpgModel.HeaderIcon2Path = string.Empty;
            //    }
            //}
            //finally { }
            ////masterpgModel.HeaderIcon2Path = mp.HeaderIcon2Path;
            ////if (HdrImage3.FileName != null)
            ////{
            ////    mp.HeaderIcon3Path = ProcessUploadedFile(HdrImage3);
            ////}
            //try
            //{
            //    //if (dvdrImage.FileName != null)
            //    if (HdrImage3.FileName != null)
            //    {
            //        masterpgModel.HeaderIcon3Path = ProcessUploadedFileForHomeIndexPg(HdrImage3);
            //    }
            //}
            //catch
            //{
            //    if (masterpgModel.HeaderIcon3Path != "")
            //    {
            //        masterpgModel.HeaderIcon3Path = TempData["HeaderIcon3Path"].ToString() == null ? "" : TempData["HeaderIcon3Path"].ToString();
            //    }
            //    else
            //    {
            //        masterpgModel.HeaderIcon3Path = string.Empty;
            //    }
            //}
            //finally { }
            ////masterpgModel.HeaderIcon3Path = mp.HeaderIcon3Path;
            ////if (HdrImage4.FileName != null)
            ////{
            ////    mp.HeaderIcon4Path = ProcessUploadedFile(HdrImage4);
            ////}
            //try
            //{
            //    //if (dvdrImage.FileName != null)
            //    if (HdrImage4.FileName != null)
            //    {
            //        masterpgModel.HeaderIcon4Path = ProcessUploadedFileForHomeIndexPg(HdrImage4);
            //    }
            //}
            //catch
            //{
            //    if (masterpgModel.HeaderIcon4Path != "")
            //    {
            //        masterpgModel.HeaderIcon4Path = TempData["HeaderIcon4Path"].ToString() == null ? "" : TempData["HeaderIcon4Path"].ToString();
            //    }
            //    else
            //    {
            //        masterpgModel.HeaderIcon4Path = string.Empty;
            //    }
            //}
            //finally { }
            ////masterpgModel.HeaderIcon4Path = mp.HeaderIcon4Path;
            ////if (HdrImage5.FileName != null)
            ////{
            ////    mp.HeaderIcon5Path = ProcessUploadedFile(HdrImage5);
            ////}
            //try
            //{
            //    //if (dvdrImage.FileName != null)
            //    if (HdrImage5.FileName != null)
            //    {
            //        masterpgModel.HeaderIcon5Path = ProcessUploadedFileForHomeIndexPg(HdrImage5);
            //    }
            //}
            //catch
            //{
            //    if (masterpgModel.HeaderIcon5Path != "")
            //    {
            //        masterpgModel.HeaderIcon5Path = TempData["HeaderIcon5Path"].ToString() == null ? "" : TempData["HeaderIcon5Path"].ToString();
            //    }
            //    else
            //    {
            //        masterpgModel.HeaderIcon5Path = string.Empty;
            //    }
            //}
            //finally { }
            ////masterpgModel.HeaderIcon5Path = mp.HeaderIcon5Path;
            ////if (HdrImage6.FileName != null)
            ////{
            ////    mp.HeaderIcon6Path = ProcessUploadedFile(HdrImage6);
            ////}
            //try
            //{
            //    //if (dvdrImage.FileName != null)
            //    if (HdrImage6.FileName != null)
            //    {
            //        masterpgModel.HeaderIcon6Path = ProcessUploadedFileForHomeIndexPg(HdrImage6);
            //    }
            //}
            //catch
            //{
            //    if (masterpgModel.HeaderIcon6Path != "")
            //    {
            //        masterpgModel.HeaderIcon6Path = TempData["HeaderIcon6Path"].ToString() == null ? "" : TempData["HeaderIcon6Path"].ToString();
            //    }
            //    else
            //    {
            //        masterpgModel.HeaderIcon6Path = string.Empty;
            //    }
            //}
            //finally { }
            ////masterpgModel.HeaderIcon6Path = mp.HeaderIcon6Path;
            ////if (HdrImage7.FileName != null)
            ////{
            ////    mp.HeaderIcon7Path = ProcessUploadedFile(HdrImage7);
            ////}
            //try
            //{
            //    //if (dvdrImage.FileName != null)
            //    if (HdrImage7.FileName != null)
            //    {
            //        masterpgModel.HeaderIcon7Path = ProcessUploadedFileForHomeIndexPg(HdrImage7);
            //    }
            //}
            //catch
            //{
            //    if (masterpgModel.HeaderIcon7Path != "")
            //    {
            //        masterpgModel.HeaderIcon7Path = TempData["HeaderIcon7Path"].ToString() == null ? "" : TempData["HeaderIcon7Path"].ToString();
            //    }
            //    else
            //    {
            //        masterpgModel.HeaderIcon7Path = string.Empty;
            //    }
            //}
            //finally { }
            //masterpgModel.HeaderIcon7Path = mp.HeaderIcon7Path;

            model.Add(masterpgModel);
            using (var context = new DemoEntityContext())
            {
                context.MasterPageItems.Update(masterpgModel);
                context.SaveChanges();
            }
            var mdl = new List<DynamicMasterPageModel>();
            try
            {
                using (var context = new DemoEntityContext())
                {
                    var value = context.MasterPageItems.ToList();
                    int cnt = value.Count();
                    int loop = 1;
                    foreach (var masterpgitm in value)
                    {
                        var masterpgMdl = new DynamicMasterPageModel();
                        masterpgMdl.Name = masterpgitm.Name;
                        masterpgMdl.Description = masterpgitm.Description;
                        masterpgMdl.IsActive = masterpgitm.IsActive;
                        masterpgMdl.logo = masterpgitm.logo;
                        masterpgMdl.DepartmentInEnglish = masterpgitm.DepartmentInEnglish;
                        masterpgMdl.DepartmentInHindi = masterpgitm.DepartmentInHindi;
                        masterpgMdl.DepartmentInEnglishFontSize = masterpgitm.DepartmentInEnglishFontSize;
                        masterpgMdl.DepartmentInHindiFontSize = masterpgitm.DepartmentInHindiFontSize;
                        masterpgMdl.DepartmentInHindiLineHeight = masterpgitm.DepartmentInHindiLineHeight;
                        masterpgMdl.headerBkGrndClrHashCode = masterpgitm.headerBkGrndClrHashCode;
                        masterpgMdl.DepartmentDividerLineImage = masterpgitm.DepartmentDividerLineImage;
                        masterpgMdl.HeaderIcon1Path = masterpgitm.HeaderIcon1Path;
                        masterpgMdl.HeaderIcon2Path = masterpgitm.HeaderIcon2Path;
                        masterpgMdl.HeaderIcon3Path = masterpgitm.HeaderIcon3Path;
                        masterpgMdl.HeaderIcon4Path = masterpgitm.HeaderIcon4Path;
                        masterpgMdl.HeaderIcon5Path = masterpgitm.HeaderIcon5Path;
                        masterpgMdl.HeaderIcon6Path = masterpgitm.HeaderIcon6Path;
                        masterpgMdl.HeaderIcon7Path = masterpgitm.HeaderIcon7Path;
                        masterpgMdl.HeaderIconHeight = masterpgitm.HeaderIconHeight;
                        masterpgMdl.HeaderIconWidth = masterpgitm.HeaderIconWidth;
                        masterpgMdl.MinistryNmInEnglish = masterpgitm.MinistryNmInEnglish;
                        masterpgMdl.MinistryNmInHindi = masterpgitm.MinistryNmInHindi;
                        masterpgMdl.MinistryNmInEnglishFontSize = masterpgitm.MinistryNmInEnglishFontSize;
                        masterpgMdl.MinistryNmInHindiFontSize = masterpgitm.MinistryNmInHindiFontSize;
                        masterpgMdl.MinistryNmInHindiLineHeight = masterpgitm.MinistryNmInHindiLineHeight;
                        masterpgMdl.MinistryUrl = masterpgitm.MinistryUrl;
                        if (loop == cnt)
                        {
                            mdl.Add(masterpgMdl);
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
            return RedirectToAction("Index", "Home", mdl);
            //}
            //else
            //{
            //    return RedirectToAction("Admin", "Account");
            //}
        }
        public IActionResult AddEditFooterMap()
        {
            if (HttpContext.Session.GetString("Role") == "_Admin")
            {
                //HttpContext.Session.SetString("Role", "");
                var Ftrmaplnk = new List<FooterMapModel>();
                var ftrmaplnkMdl = new FooterMapModel();
                using (var context = new DemoEntityContext())
                {
                    var value = context.FooterMaps.ToList();
                    int cnt = value.Count();
                    int loop = 1;
                    foreach (var ftrmnuitm in value)
                    {
                        var ftrmaplnkModel = new FooterMapModel();
                        ftrmaplnkModel.Id = ftrmnuitm.Id;
                        ftrmaplnkModel.maplink = ftrmnuitm.maplink;

                        if (loop == cnt)
                        {
                            Ftrmaplnk.Add(ftrmaplnkModel);
                            ftrmaplnkMdl = ftrmaplnkModel;
                        }
                        else
                        {
                            loop = loop + 1;
                        }
                    }
                }
                return View("AddEditFooterMap", ftrmaplnkMdl);
            }
            else
            {
                return RedirectToAction("Admin", "Account");
            }
        }
        [HttpPost]
        public IActionResult AddEditFooterMap(FooterMapModel ftrmp)
        {
            var ftrmodel = new List<FooterMapModel>();
            var ftrmapModel = new FooterMapModel();
            ftrmapModel.maplink = ftrmp.maplink;

            ftrmodel.Add(ftrmapModel);
            using (var context = new DemoEntityContext())
            {
                context.FooterMaps.Update(ftrmapModel);
                context.SaveChanges();
            }
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
            var MasterPgViewModel = new MasterPgViewModel();
            List<DynamicMasterPageModel>? MsterPgeItems = new List<DynamicMasterPageModel>();
            //string domain = Request.Url.Host;
            //MsterPgeItems = model;
            var MsterPgeMnus = new List<MenuModel>();

            using (var context = new DemoEntityContext())
            {
                var value = context.Menus.ToList();
                int cnt = value.Count();
                int loop = 1;
                foreach (var mnuitm in value)
                {
                    var mnuModel = new MenuModel();
                    mnuModel.Id = mnuitm.Id;
                    mnuModel.ParentMenuId = mnuitm.ParentMenuId;
                    mnuModel.Title = mnuitm.Title;
                    mnuModel.Controller = mnuitm.Controller;
                    mnuModel.Action = mnuitm.Action;
                    mnuModel.DateCreated = mnuitm.DateCreated;
                    if (loop == cnt)
                    {
                        MsterPgeMnus.Add(mnuModel);
                    }
                    else
                    {
                        loop = loop + 1;
                    }
                }
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
                int loop = 1;
                foreach (var ftrmnuitm in value)
                {
                    var ftrmaplnkModel = new FooterMapModel();
                    ftrmaplnkModel.Id = ftrmnuitm.Id;
                    ftrmaplnkModel.maplink = ftrmnuitm.maplink;
                    if (loop == cnt)
                    {
                        Ftrmaplnk.Add(ftrmaplnkModel);
                    }
                    else
                    {
                        loop = loop + 1;
                    }
                }
            }

            MasterPgViewModel.mstrpg = MsterPgeItems.ToList();
            MasterPgViewModel.mnus = MsterPgeMnus.ToList();
            MasterPgViewModel.ftrhotlinks = FtrHotLinksMnus.ToList();
            MasterPgViewModel.ftrmaplink = Ftrmaplnk.ToList();

            //return View(MasterPgViewModel);
            return RedirectToAction("Index", "Home", MasterPgViewModel);
        }
        public IActionResult AddEditHomeBanner()
        {
            if (HttpContext.Session.GetString("Role") == "_Admin")
            {
                //HttpContext.Session.SetString("Role", "");
                var BannerImageMdl = new List<HomeBannerModel>();
                var bannrImg = new HomeBannerModel();
                using (var context = new DemoEntityContext())
                {
                    var value = context.HomeBanner.ToList();
                    int cnt = value.Count();
                    int loop = 1;
                    foreach (var ftrmnuitm in value)
                    {
                        var hmbnnrimgModel = new HomeBannerModel();
                        bannrImg.Id = ftrmnuitm.Id;
                        bannrImg.homebannerImage = ftrmnuitm.homebannerImage;
                        TempData["homebannerImage"] = ftrmnuitm.homebannerImage;
                        if (loop == cnt)
                        {
                            BannerImageMdl.Add(bannrImg);
                        }
                        else
                        {
                            loop = loop + 1;
                        }
                    }
                }
                return View("AddEditHomeBanner", bannrImg);
            }
            else
            {
                return RedirectToAction("Admin", "Account");
            }
        }
        [HttpPost]
        public IActionResult AddEditHomeBanner(IFormFile HomeBannerImage)
        {
            var hmbnrmodel = new List<HomeBannerModel>();
            var homembnrModel = new HomeBannerModel();
            try
            {
                if (HomeBannerImage.FileName != null)
                {
                    homembnrModel.homebannerImage = ProcessUploadedFileForHomeIndexPg(HomeBannerImage);
                }
            }
            catch
            {
                if (homembnrModel.homebannerImage != "")
                {
                    homembnrModel.homebannerImage = TempData["homebannerImage"].ToString() == null ? "" : TempData["homebannerImage"].ToString();
                }
                else
                {
                    homembnrModel.homebannerImage = string.Empty;
                }
            }
            finally { }
            hmbnrmodel.Add(homembnrModel);
            using (var context = new DemoEntityContext())
            {
                context.HomeBanner.Update(homembnrModel);
                context.SaveChanges();
            }
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
            var MasterPgViewModel = new MasterPgViewModel();
            List<DynamicMasterPageModel>? MsterPgeItems = new List<DynamicMasterPageModel>();
            //string domain = Request.Url.Host;
            //MsterPgeItems = model;
            var MsterPgeMnus = new List<MenuModel>();

            using (var context = new DemoEntityContext())
            {
                var value = context.Menus.ToList();
                int cnt = value.Count();
                int loop = 1;
                foreach (var mnuitm in value)
                {
                    var mnuModel = new MenuModel();
                    mnuModel.Id = mnuitm.Id;
                    mnuModel.ParentMenuId = mnuitm.ParentMenuId;
                    mnuModel.Title = mnuitm.Title;
                    mnuModel.Controller = mnuitm.Controller;
                    mnuModel.Action = mnuitm.Action;
                    mnuModel.DateCreated = mnuitm.DateCreated;
                    if (loop == cnt)
                    {
                        MsterPgeMnus.Add(mnuModel);
                    }
                    else
                    {
                        loop = loop + 1;
                    }
                }
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
                int loop = 1;
                foreach (var ftrmnuitm in value)
                {
                    var ftrmaplnkModel = new FooterMapModel();
                    ftrmaplnkModel.Id = ftrmnuitm.Id;
                    ftrmaplnkModel.maplink = ftrmnuitm.maplink;
                    if (loop == cnt)
                    {
                        Ftrmaplnk.Add(ftrmaplnkModel);
                    }
                    else
                    {
                        loop = loop + 1;
                    }
                }
            }

            MasterPgViewModel.mstrpg = MsterPgeItems.ToList();
            MasterPgViewModel.mnus = MsterPgeMnus.ToList();
            MasterPgViewModel.ftrhotlinks = FtrHotLinksMnus.ToList();
            MasterPgViewModel.ftrmaplink = Ftrmaplnk.ToList();

            //return View(MasterPgViewModel);
            return RedirectToAction("Index", "Home", MasterPgViewModel);
        }
        public IActionResult PressRelease()
        {
            if (HttpContext.Session.GetString("Role") == "_Admin")
            {
                //HttpContext.Session.SetString("Role", "");
                var PrssRelViewModel = new PressReleaseViewModel();
                int chkcntforAddOrEdit = 0;
                var PrsRelMdl = new List<PressReleaseModel>();
                var prsRel = new PressReleaseModel();
                using (var context = new DemoEntityContext())
                {
                    var value = context.PressReleases.ToList();
                    int cnt = value.Count();
                    chkcntforAddOrEdit = cnt;
                    int loop = 1;
                    foreach (var prssrelitm in value)
                    {
                        var prsrelModel = new PressReleaseModel();
                        prsrelModel.Id = prssrelitm.Id;
                        prsrelModel.Heading = prssrelitm.Heading;
                        prsrelModel.Details = prssrelitm.Details;
                        prsrelModel.Active = prssrelitm.Active;
                        prsrelModel.ReleaseDate = prssrelitm.ReleaseDate;
                        prsrelModel.DisplayOrder = prssrelitm.DisplayOrder;
                        PrsRelMdl.Add(prsrelModel);
                        PrssRelViewModel.prsrels = PrsRelMdl;
                    }
                }
                if (chkcntforAddOrEdit > 0)
                {
                    return View("AddEditPressRelease", PrssRelViewModel);
                }
                else
                {
                    return View("AddPressRelease", prsRel);
                }
            }
            else
            {
                return RedirectToAction("Admin", "Account");
            }
        }
        [HttpPost]
        public IActionResult AddEditPressRelease(string data)
        {
            IList<ClontrolProperties> lst = JsonConvert.DeserializeObject<List<ClontrolProperties>>(data);
            int cnt = lst.Count;
            int recno = 1;
            int chkbxvalcnt = 1;
            var FtrHotLnksViewModel = new PressReleaseViewModel();
            var PresRel = new List<PressReleaseModel>();
            var context = new DemoEntityContext();
            context.PressReleases.Truncate();
            using (var cntext = new DemoEntityContext())
            {
                var prsrelModel = new PressReleaseModel();

                int loopcnt = 1;
                foreach (var presrelitm in lst)
                {
                    int remainder = 0;

                    if (loopcnt < cnt)
                    {
                        if (recno % 6 == 0)
                        {
                            recno = 1;
                        }
                        prsrelModel.Id = 0;
                        remainder = loopcnt % 1;
                        if (remainder == 0)
                        {
                            if (presrelitm.name.Contains("Heading"))
                            {
                                prsrelModel.Heading = presrelitm.value;
                            }
                        }
                        if (presrelitm.name.Contains("Details"))
                        {
                            prsrelModel.Details = lst[loopcnt - 1].value.ToString();
                        }
                        //remainder = loopcnt % 2;
                        //if (loopcnt == cnt - (recno + 3))
                        //{
                        //    if (presrelitm.name.Contains("Details"))
                        //    {
                        //        prsrelModel.Details = presrelitm.value;
                        //    }
                        //}
                        if (presrelitm.name.Contains("ReleaseDate"))
                        {
                            prsrelModel.ReleaseDate = DateTime.Parse(lst[loopcnt - 1].value.ToString());
                            //DateTime.Parse(presrelitm.value);
                        }
                        //if (loopcnt == cnt - (recno + 2))
                        //{
                        //    if (presrelitm.name.Contains("ReleaseDate"))
                        //    {
                        //        prsrelModel.ReleaseDate = DateTime.Parse(presrelitm.value);
                        //    }
                        //}
                        if (presrelitm.name.Contains("DisplayOrder"))
                        {
                            prsrelModel.DisplayOrder = int.Parse(lst[loopcnt - 1].value.ToString());
                        }
                        //if (loopcnt == cnt - (recno + 1))
                        //{
                        //    if (presrelitm.name.Contains("DisplayOrder"))
                        //    {
                        //        prsrelModel.DisplayOrder = int.Parse(presrelitm.value.ToString());
                        //    }
                        //}
                        if (loopcnt % 5 == 0)
                        {
                            int lpcnt = 0;

                            foreach (var presrelchbxitm in lst)
                            {
                                lpcnt++;

                                //if (lpcnt >= (cnt - (cnt / 6 - 1) + (chkbxvalcnt - 1)))
                                //{
                                if (lpcnt > cnt - (cnt / 6))
                                {
                                    string cntns = string.Empty;
                                    cntns = "Active[" + (chkbxvalcnt) + "]";
                                    //if (chkbxvalcnt == 1)
                                    //{
                                    //    cntns = "Active";
                                    //}
                                    //else
                                    //{
                                    //    cntns = "Active[" + (chkbxvalcnt) + "]";
                                    //}
                                    if (presrelchbxitm.name.Contains(cntns))
                                    {
                                        prsrelModel.Active = bool.Parse(presrelchbxitm.value);
                                        break;
                                    }
                                }
                            }
                            chkbxvalcnt++;
                            prsrelModel.DateCreated = System.DateTime.Now.ToShortDateString();
                            if (loopcnt <= cnt - (cnt / 6))
                            {
                                PresRel.Add(prsrelModel);
                                cntext.PressReleases.Update(prsrelModel);
                                cntext.SaveChanges();
                            }
                            prsrelModel = new PressReleaseModel();
                            recno++;
                        }
                        loopcnt++;
                    }
                }

                var FtrHotLinksMnus = new List<FooterHotLinksModel>();

                using (var contxt = new DemoEntityContext())
                {
                    var value = contxt.FooterHotLinkss.ToList();
                    int cntt = value.Count();
                    int loop = 1;
                    foreach (var ftrmnuitm in value)
                    {
                        var ftrmnulnkModel = new FooterHotLinksModel();
                        ftrmnulnkModel.Id = ftrmnuitm.Id;
                        ftrmnulnkModel.ParentMenuId = ftrmnuitm.ParentMenuId;
                        ftrmnulnkModel.Title = ftrmnuitm.Title;
                        ftrmnulnkModel.Controller = ftrmnuitm.Controller;
                        ftrmnulnkModel.Action = ftrmnuitm.Action;
                        ftrmnulnkModel.DateCreated = ftrmnuitm.DateCreated;
                        if (loop == cntt)
                        {
                            FtrHotLinksMnus.Add(ftrmnulnkModel);
                        }
                        else
                        {
                            loop = loop + 1;
                        }
                    }
                }
                var Ftrmaplnk = new List<FooterMapModel>();
            }
            return View("AddEditPressRelease", FtrHotLnksViewModel);

        }
        [HttpPost]
        public IActionResult AddPressRelease(PressReleaseModel prmdl, DateTime? reldt)
        {
            var prsrelmdl = new List<PressReleaseModel>();
            var prsrelModel = new PressReleaseModel();
            prsrelModel.Heading = prmdl.Heading;
            prsrelModel.Details = prmdl.Details;
            prsrelModel.Active = prmdl.Active;
            prsrelModel.DisplayOrder = prmdl.DisplayOrder;
            prsrelModel.ReleaseDate = reldt;
            prsrelModel.DateCreated = System.DateTime.Now.ToString(); ;
            prsrelmdl.Add(prsrelModel);
            using (var context = new DemoEntityContext())
            {
                context.PressReleases.Update(prsrelModel);
                context.SaveChanges();
            }
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
            var MasterPgViewModel = new MasterPgViewModel();
            List<DynamicMasterPageModel>? MsterPgeItems = new List<DynamicMasterPageModel>();
            //string domain = Request.Url.Host;
            //MsterPgeItems = model;
            var MsterPgeMnus = new List<MenuModel>();

            using (var context = new DemoEntityContext())
            {
                var value = context.Menus.ToList();
                int cnt = value.Count();
                int loop = 1;
                foreach (var mnuitm in value)
                {
                    var mnuModel = new MenuModel();
                    mnuModel.Id = mnuitm.Id;
                    mnuModel.ParentMenuId = mnuitm.ParentMenuId;
                    mnuModel.Title = mnuitm.Title;
                    mnuModel.Controller = mnuitm.Controller;
                    mnuModel.Action = mnuitm.Action;
                    mnuModel.DateCreated = mnuitm.DateCreated;
                    if (loop == cnt)
                    {
                        MsterPgeMnus.Add(mnuModel);
                    }
                    else
                    {
                        loop = loop + 1;
                    }
                }
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
                int loop = 1;
                foreach (var ftrmnuitm in value)
                {
                    var ftrmaplnkModel = new FooterMapModel();
                    ftrmaplnkModel.Id = ftrmnuitm.Id;
                    ftrmaplnkModel.maplink = ftrmnuitm.maplink;
                    if (loop == cnt)
                    {
                        Ftrmaplnk.Add(ftrmaplnkModel);
                    }
                    else
                    {
                        loop = loop + 1;
                    }
                }
            }

            prsrelmdl = new List<PressReleaseModel>();

            using (var context = new DemoEntityContext())
            {
                var value = context.PressReleases.ToList();
                //int cnt = value.Count();
                //int loop = 1;
                foreach (var prsrelitm in value)
                {
                    var prssrelModel = new PressReleaseModel();
                    prssrelModel.Id = prsrelitm.Id;
                    prssrelModel.Heading = prsrelitm.Heading;
                    prssrelModel.Details = prsrelitm.Details;
                    prssrelModel.ReleaseDate = prsrelitm.ReleaseDate;
                    prsrelmdl.Add(prssrelModel);
                    //if (loop == cnt)
                    //{
                    //    prsrelmdl.Add(prssrelModel);
                    //}
                    //else
                    //{
                    //    loop = loop + 1;
                    //}
                }
            }
            MasterPgViewModel.mstrpg = MsterPgeItems.ToList();
            MasterPgViewModel.mnus = MsterPgeMnus.ToList();
            MasterPgViewModel.ftrhotlinks = FtrHotLinksMnus.ToList();
            MasterPgViewModel.ftrmaplink = Ftrmaplnk.ToList();
            MasterPgViewModel.prssrel = prsrelmdl.ToList();

            //return View(MasterPgViewModel);
            return RedirectToAction("Index", "Home", MasterPgViewModel);
        }

        public IActionResult AddEditFooterHotLinks()
        {
            if (HttpContext.Session.GetString("Role") == "_Admin")
            {
                //HttpContext.Session.SetString("Role", "");
                var FtrHotLnksViewModel = new FooterHotLinksViewModel();
                var Ftrhotlnk = new List<FooterHotLinksModel>();
                var ftrhotlnkMdl = new FooterHotLinksModel();
                using (var context = new DemoEntityContext())
                {
                    var value = context.FooterHotLinkss.ToList();
                    int cnt = value.Count();
                    int loop = 1;
                    foreach (var ftrhotlinkitm in value)
                    {
                        var ftrhotlnkModel = new FooterHotLinksModel();
                        ftrhotlnkModel.Id = ftrhotlinkitm.Id;
                        ftrhotlnkModel.DisplayOrder = ftrhotlinkitm.DisplayOrder;
                        ftrhotlnkModel.Action = ftrhotlinkitm.Action;
                        ftrhotlnkModel.Controller = ftrhotlinkitm.Controller;
                        ftrhotlnkModel.Title = ftrhotlinkitm.Title;
                        ftrhotlnkModel.ParentMenuId = ftrhotlinkitm.ParentMenuId;
                        ftrhotlnkModel.DateCreated = ftrhotlinkitm.DateCreated;
                        Ftrhotlnk.Add(ftrhotlnkModel);
                        FtrHotLnksViewModel.ftrhotlinks = Ftrhotlnk;

                        //if (loop == cnt)
                        //{
                        //    Ftrhotlnk.Add(ftrhotlnkModel);
                        //    ftrhotlnkMdl = ftrhotlnkModel;
                        //}
                        //else
                        //{
                        //    loop = loop + 1;
                        //}
                    }
                }
                return View("AddEditFooterHotLinks", FtrHotLnksViewModel);
            }
            else
            {
                return RedirectToAction("Admin", "Account");
            }
        }
        [HttpPost]
        public IActionResult AddEditFooterHotLinks(string data)
        {
            IList<ClontrolProperties> lst = JsonConvert.DeserializeObject<List<ClontrolProperties>>(data);
            //ClontrolProperties lst = JsonConvert.DeserializeObject<ClontrolProperties>(data);
            int cnt = lst.Count;
            int recno = 1;
            //IList<ClontrolProperties> ctm = new JavaScriptSerializer().Deserialize<IList<ClontrolProperties>>(data);
            //dynamic _json = JsonConvert.DeserializeObject<List<ClontrolProperties>>(data);
            var FtrHotLnksViewModel = new FooterHotLinksViewModel();
            var Ftrhotlnk = new List<FooterHotLinksModel>();
            var ftrhotlnkMdl = new FooterHotLinksModel();
            var context = new DemoEntityContext();
            context.FooterHotLinkss.Truncate();
            using (var cntext = new DemoEntityContext())
            {
                //var value = context.FooterHotLinkss.ToList();
                //var value = lst;

                var ftrhotlnkModel = new FooterHotLinksModel();

                int loopcnt = 1;
                foreach (var ftrhotlinkitm in lst)
                {
                    int remainder = 0;

                    if (loopcnt <= cnt)
                    {
                        if (recno % 4 == 0)
                        {
                            recno = 1;
                        }
                        ftrhotlnkModel.Id = 0;
                        remainder = loopcnt % 1;
                        if (remainder == 0)
                        {
                            if (ftrhotlinkitm.name.Contains("Title"))
                            {
                                ftrhotlnkModel.Title = ftrhotlinkitm.value;
                            }
                        }
                        remainder = loopcnt % 2;
                        if (remainder == 0)
                        {
                            if (ftrhotlinkitm.name.Contains("Action"))
                            {
                                ftrhotlnkModel.Action = ftrhotlinkitm.value;
                            }
                        }
                        remainder = loopcnt % 3;
                        if (remainder == (recno - 1))
                        {
                            if (ftrhotlinkitm.name.Contains("Controller"))
                            {
                                ftrhotlnkModel.Controller = ftrhotlinkitm.value;
                            }
                        }
                        remainder = loopcnt % 4;
                        if (loopcnt % 4 == 0)
                        {
                            if (ftrhotlinkitm.name.Contains("DisplayOrder"))
                            {
                                ftrhotlnkModel.DisplayOrder = int.Parse(ftrhotlinkitm.value.ToString());
                            }
                            ftrhotlnkModel.DateCreated = System.DateTime.Now.ToShortDateString();
                            ftrhotlnkModel.ParentMenuId = 0;

                            Ftrhotlnk.Add(ftrhotlnkModel);

                            cntext.FooterHotLinkss.Update(ftrhotlnkModel);
                            cntext.SaveChanges();
                            ftrhotlnkModel = new FooterHotLinksModel();
                            recno++;
                        }
                        loopcnt++;
                    }
                }

                var FtrHotLinksMnus = new List<FooterHotLinksModel>();

                using (var contxt = new DemoEntityContext())
                {
                    var value = contxt.FooterHotLinkss.ToList();
                    int cntt = value.Count();
                    int loop = 1;
                    foreach (var ftrmnuitm in value)
                    {
                        var ftrmnulnkModel = new FooterHotLinksModel();
                        ftrmnulnkModel.Id = ftrmnuitm.Id;
                        ftrmnulnkModel.ParentMenuId = ftrmnuitm.ParentMenuId;
                        ftrmnulnkModel.Title = ftrmnuitm.Title;
                        ftrmnulnkModel.Controller = ftrmnuitm.Controller;
                        ftrmnulnkModel.Action = ftrmnuitm.Action;
                        ftrmnulnkModel.DateCreated = ftrmnuitm.DateCreated;
                        if (loop == cntt)
                        {
                            FtrHotLinksMnus.Add(ftrmnulnkModel);
                        }
                        else
                        {
                            loop = loop + 1;
                        }
                    }
                }
                var Ftrmaplnk = new List<FooterMapModel>();
            }
            return View("AddEditFooterHotLinks", FtrHotLnksViewModel);
        }
        public IActionResult AddEditFooterContactUs()
        {
            if (HttpContext.Session.GetString("Role") == "_Admin")
            {
                //HttpContext.Session.SetString("Role", "");
                var Ftrcontactus = new List<FooterContactUsModel>();
                var ftrcnttusModel = new FooterContactUsModel();
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
                            ftrcnttusModel = ftrcntactusModel;
                        }
                        else
                        {
                            loopftrcontactus = loopftrcontactus + 1;
                        }
                    }
                }
                return View("AddEditFooterContactUs", ftrcnttusModel);
            }
            else
            {
                return RedirectToAction("Admin", "Account");
            }
        }
        [HttpPost]
        public IActionResult AddEditFooterContactUs(FooterContactUsModel ftrcontactus)
        {
            var ftrcntactusModel = new List<FooterContactUsModel>();
            var ftrcontactusModel = new FooterContactUsModel();
            ftrcontactusModel.addressline1 = ftrcontactus.addressline1;
            ftrcontactusModel.addressline2 = ftrcontactus.addressline2;
            ftrcontactusModel.addressline3 = ftrcontactus.addressline3;
            ftrcontactusModel.addressline4 = ftrcontactus.addressline4;
            ftrcontactusModel.Pincode = ftrcontactus.Pincode;
            ftrcontactusModel.mobile1 = ftrcontactus.mobile1;
            ftrcontactusModel.mobile2 = ftrcontactus.mobile2;
            ftrcontactusModel.emailaddress = ftrcontactus.emailaddress;

            ftrcntactusModel.Add(ftrcontactusModel);
            using (var context = new DemoEntityContext())
            {
                context.FooterContactUss.Update(ftrcontactusModel);
                context.SaveChanges();
            }
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
            var MasterPgViewModel = new MasterPgViewModel();
            List<DynamicMasterPageModel>? MsterPgeItems = new List<DynamicMasterPageModel>();
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
            }
            var FtrHotLinksMnus = new List<FooterHotLinksModel>();

            using (var context = new DemoEntityContext())
            {
                var value = context.FooterHotLinkss.ToList();
                int cnt = value.Count();
                int loop = 1;
                foreach (var ftrmnuitm in value)
                {
                    var ftrmnulnkModel = new FooterHotLinksModel();
                    ftrmnulnkModel.Id = ftrmnuitm.Id;
                    ftrmnulnkModel.ParentMenuId = ftrmnuitm.ParentMenuId;
                    ftrmnulnkModel.Title = ftrmnuitm.Title;
                    ftrmnulnkModel.Controller = ftrmnuitm.Controller;
                    ftrmnulnkModel.Action = ftrmnuitm.Action;
                    ftrmnulnkModel.DateCreated = ftrmnuitm.DateCreated;
                    if (loop == cnt)
                    {
                        FtrHotLinksMnus.Add(ftrmnulnkModel);
                    }
                    else
                    {
                        loop = loop + 1;
                    }
                }
            }
            var Ftrmaplnk = new List<FooterMapModel>();

            using (var context = new DemoEntityContext())
            {
                var value = context.FooterMaps.ToList();
                int cnt = value.Count();
                int loop = 1;
                foreach (var ftrmnuitm in value)
                {
                    var ftrmaplnkModel = new FooterMapModel();
                    ftrmaplnkModel.Id = ftrmnuitm.Id;
                    ftrmaplnkModel.maplink = ftrmnuitm.maplink;
                    if (loop == cnt)
                    {
                        Ftrmaplnk.Add(ftrmaplnkModel);
                    }
                    else
                    {
                        loop = loop + 1;
                    }
                }
            }
            var Ftrcontactus = new List<FooterContactUsModel>();

            using (var context = new DemoEntityContext())
            {
                var value = context.FooterContactUss.ToList();
                int cnt = value.Count();
                int loop = 1;
                foreach (var ftrcontactusitm in value)
                {
                    var ftrcntctusModel = new FooterContactUsModel();
                    ftrcntctusModel.Id = ftrcontactusitm.Id;
                    ftrcntctusModel.addressline1 = ftrcontactusitm.addressline1;
                    ftrcntctusModel.addressline2 = ftrcontactusitm.addressline2;
                    ftrcntctusModel.addressline3 = ftrcontactusitm.addressline3;
                    ftrcntctusModel.addressline4 = ftrcontactusitm.addressline4;
                    ftrcntctusModel.Pincode = ftrcontactusitm.Pincode;
                    ftrcntctusModel.mobile1 = ftrcontactusitm.mobile1;
                    ftrcntctusModel.mobile2 = ftrcontactusitm.mobile2;
                    ftrcntctusModel.emailaddress = ftrcontactusitm.emailaddress;
                    if (loop == cnt)
                    {
                        Ftrcontactus.Add(ftrcntctusModel);
                    }
                    else
                    {
                        loop = loop + 1;
                    }
                }
            }
            MasterPgViewModel.mstrpg = MsterPgeItems.ToList();
            MasterPgViewModel.mnus = MsterPgeMnus.ToList();
            MasterPgViewModel.ftrhotlinks = FtrHotLinksMnus.ToList();
            MasterPgViewModel.ftrmaplink = Ftrmaplnk.ToList();
            MasterPgViewModel.ftrcntactus = Ftrcontactus.ToList();
            return RedirectToAction("Index", "Home", MasterPgViewModel);
        }
        public IActionResult AddEditHomeIndexPage()
        {
            if (HttpContext.Session.GetString("Role") == "_Admin")
            {
                //HttpContext.Session.SetString("Role", "");
                var hmIndxPgModel = new List<HomeIndexPageModel>();
                var hmindexmdl = new HomeIndexPageModel();
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
                        TempData["hmInxTitleImage"] = hmindxpgitm.hmInxTitleImage;
                        hmindexmodel.hmInxTitleDescription = hmindxpgitm.hmInxTitleDescription;
                        hmindexmodel.hmInxTitleImageWidth = hmindxpgitm.hmInxTitleImageWidth;
                        hmindexmodel.hmInxTitleImageHeight = hmindxpgitm.hmInxTitleImageHeight;

                        hmindexmodel.hmInxPrimeMinisterImage = hmindxpgitm.hmInxPrimeMinisterImage;
                        TempData["hmInxPrimeMinisterImage"] = hmindxpgitm.hmInxPrimeMinisterImage;
                        hmindexmodel.hmInxPrimeMinisterName = hmindxpgitm.hmInxPrimeMinisterName;
                        hmindexmodel.hmInxPrimeMinisterDesignation = hmindxpgitm.hmInxPrimeMinisterDesignation;
                        hmindexmodel.hmInxPrimeMinisterPlace = hmindxpgitm.hmInxPrimeMinisterPlace;
                        hmindexmodel.hmInxPrimeMinisterPortfolioUrl = hmindxpgitm.hmInxPrimeMinisterPortfolioUrl;

                        hmindexmodel.hmInxChiefMinisterImage = hmindxpgitm.hmInxChiefMinisterImage;
                        TempData["hmInxChiefMinisterImage"] = hmindxpgitm.hmInxChiefMinisterImage;
                        hmindexmodel.hmInxChiefMinisterName = hmindxpgitm.hmInxChiefMinisterName;
                        hmindexmodel.hmInxChiefMinisterDesignation = hmindxpgitm.hmInxChiefMinisterDesignation;
                        hmindexmodel.hmInxChiefMinisterPlace = hmindxpgitm.hmInxChiefMinisterPlace;

                        hmindexmodel.hmInxMinisterOfficer1Image = hmindxpgitm.hmInxMinisterOfficer1Image;
                        TempData["hmInxMinisterOfficer1Image"] = hmindxpgitm.hmInxMinisterOfficer1Image;
                        hmindexmodel.hmInxMinisterOfficer1Name = hmindxpgitm.hmInxMinisterOfficer1Name;
                        hmindexmodel.hmInxMinisterOfficer1Designation = hmindxpgitm.hmInxMinisterOfficer1Designation;
                        hmindexmodel.hmInxMinisterOfficer1Place = hmindxpgitm.hmInxMinisterOfficer1Place;
                        hmindexmodel.hmInxMinisterOfficer2Image = hmindxpgitm.hmInxMinisterOfficer2Image;
                        TempData["hmInxMinisterOfficer2Image"] = hmindxpgitm.hmInxMinisterOfficer2Image;
                        hmindexmodel.hmInxMinisterOfficer2Name = hmindxpgitm.hmInxMinisterOfficer2Name;
                        hmindexmodel.hmInxMinisterOfficer2Designation = hmindxpgitm.hmInxMinisterOfficer2Designation;
                        hmindexmodel.hmInxMinisterOfficer2Place = hmindxpgitm.hmInxMinisterOfficer2Place;
                        hmindexmodel.hmInxMinisterOfficer3Image = hmindxpgitm.hmInxMinisterOfficer3Image;
                        TempData["hmInxMinisterOfficer3Image"] = hmindxpgitm.hmInxMinisterOfficer3Image;
                        hmindexmodel.hmInxMinisterOfficer3Name = hmindxpgitm.hmInxMinisterOfficer3Name;
                        hmindexmodel.hmInxMinisterOfficer3Designation = hmindxpgitm.hmInxMinisterOfficer3Designation;
                        hmindexmodel.hmInxMinisterOfficer3Place = hmindxpgitm.hmInxMinisterOfficer3Place;
                        hmindexmodel.hmInxMinisterOfficer4Image = hmindxpgitm.hmInxMinisterOfficer4Image;
                        TempData["hmInxMinisterOfficer4Image"] = hmindxpgitm.hmInxMinisterOfficer4Image;
                        hmindexmodel.hmInxMinisterOfficer4Name = hmindxpgitm.hmInxMinisterOfficer4Name;
                        hmindexmodel.hmInxMinisterOfficer4Designation = hmindxpgitm.hmInxMinisterOfficer4Designation;
                        hmindexmodel.hmInxMinisterOfficer4Place = hmindxpgitm.hmInxMinisterOfficer4Place;
                        hmindexmodel.hmInxMinisterOfficer5Image = hmindxpgitm.hmInxMinisterOfficer5Image;
                        TempData["hmInxMinisterOfficer5Image"] = hmindxpgitm.hmInxMinisterOfficer5Image;
                        hmindexmodel.hmInxMinisterOfficer5Name = hmindxpgitm.hmInxMinisterOfficer5Name;
                        hmindexmodel.hmInxMinisterOfficer5Designation = hmindxpgitm.hmInxMinisterOfficer5Designation;
                        hmindexmodel.hmInxMinisterOfficer5Place = hmindxpgitm.hmInxMinisterOfficer5Place;
                        hmindexmodel.hmInxMinisterOfficer6Image = hmindxpgitm.hmInxMinisterOfficer6Image;
                        TempData["hmInxMinisterOfficer6Image"] = hmindxpgitm.hmInxMinisterOfficer6Image;
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
                        hmindexmdl = hmindexmodel;
                    }
                }
                return View("AddEditHomeIndexPage", hmindexmdl);
            }
            else
            {
                return RedirectToAction("Admin", "Account");
            }
        }
        [HttpPost]
        public IActionResult AddEditHomeIndexPage(HomeIndexPageModel hmindxpg, IFormFile TitleImage, IFormFile PMImage, IFormFile CMImage, IFormFile Image1, IFormFile Image2, IFormFile Image3, IFormFile Image4, IFormFile Image5, IFormFile Image6)
        {
            //if (ModelState.IsValid)
            //{
            var hmIndxPgModel = new List<HomeIndexPageModel>();
            var hmIndexPgmodel = new HomeIndexPageModel();
            hmIndexPgmodel.pgTitle = hmindxpg.pgTitle;
            //hmIndexPgmodel.hmInxTitleImage = hmindxpg.hmInxTitleImage;
            try
            {
                if (TitleImage.FileName != null)
                {
                    hmIndexPgmodel.hmInxTitleImage = ProcessUploadedFileForHomeIndexPg(TitleImage);
                }
            }
            catch
            {
                if (hmIndexPgmodel.hmInxTitleImage != "")
                {
                    hmIndexPgmodel.hmInxTitleImage = TempData["hmInxTitleImage"].ToString() == null ? "" : TempData["hmInxTitleImage"].ToString();
                }
                else
                {
                    hmIndexPgmodel.hmInxTitleImage = string.Empty;
                }
            }
            finally { }
            //hmIndexPgmodel.hmInxTitleImage = hmindxpg.hmInxTitleImage;
            hmIndexPgmodel.hmInxTitleDescription = hmindxpg.hmInxTitleDescription;
            hmIndexPgmodel.hmInxTitleReadMoreUrl = hmindxpg.hmInxTitleReadMoreUrl;
            hmIndexPgmodel.hmInxTitleImageWidth = hmindxpg.hmInxTitleImageWidth;
            hmIndexPgmodel.hmInxTitleImageHeight = hmindxpg.hmInxTitleImageHeight;
            try
            {
                if (PMImage.FileName != null)
                {
                    hmIndexPgmodel.hmInxPrimeMinisterImage = ProcessUploadedFileForHomeIndexPg(PMImage);
                }
            }
            catch
            {
                if (hmIndexPgmodel.hmInxPrimeMinisterImage != "")
                {
                    hmIndexPgmodel.hmInxPrimeMinisterImage = TempData["hmInxPrimeMinisterImage"].ToString() == null ? "" : TempData["hmInxPrimeMinisterImage"].ToString();
                }
                else
                {
                    hmIndexPgmodel.hmInxPrimeMinisterImage = string.Empty;
                }
            }
            finally { }
            hmIndexPgmodel.hmInxPrimeMinisterName = hmindxpg.hmInxPrimeMinisterName;
            hmIndexPgmodel.hmInxPrimeMinisterDesignation = hmindxpg.hmInxPrimeMinisterDesignation;
            hmIndexPgmodel.hmInxPrimeMinisterPlace = hmindxpg.hmInxPrimeMinisterPlace;
            hmIndexPgmodel.hmInxPrimeMinisterPortfolioUrl = hmindxpg.hmInxPrimeMinisterPortfolioUrl;

            try
            {
                if (CMImage.FileName != null)
                {
                    hmIndexPgmodel.hmInxChiefMinisterImage = ProcessUploadedFileForHomeIndexPg(CMImage);
                }
            }
            catch
            {
                if (hmIndexPgmodel.hmInxChiefMinisterImage != "")
                {
                    hmIndexPgmodel.hmInxChiefMinisterImage = TempData["hmInxChiefMinisterImage"].ToString() == null ? "" : TempData["hmInxChiefMinisterImage"].ToString();
                }
                else
                {
                    hmIndexPgmodel.hmInxChiefMinisterImage = string.Empty;
                }
            }
            finally { }
            hmIndexPgmodel.hmInxChiefMinisterName = hmindxpg.hmInxChiefMinisterName;
            hmIndexPgmodel.hmInxChiefMinisterDesignation = hmindxpg.hmInxChiefMinisterDesignation;
            hmIndexPgmodel.hmInxChiefMinisterPlace = hmindxpg.hmInxChiefMinisterPlace;

            try
            {
                if (Image1.FileName != null)
                {
                    hmIndexPgmodel.hmInxMinisterOfficer1Image = ProcessUploadedFileForHomeIndexPg(Image1);
                }
            }
            catch
            {
                if (hmIndexPgmodel.hmInxMinisterOfficer1Image != "")
                {
                    hmIndexPgmodel.hmInxMinisterOfficer1Image = TempData["hmInxMinisterOfficer1Image"].ToString() == null ? "" : TempData["hmInxMinisterOfficer1Image"].ToString();
                }
                else
                {
                    hmIndexPgmodel.hmInxMinisterOfficer1Image = string.Empty;
                }
            }
            finally { }
            //if (Image1.FileName != null)
            //{
            //    hmindxpg.hmInxMinisterOfficer1Image = ProcessUploadedFileForHomeIndexPg(Image1);
            //}
            //hmIndexPgmodel.hmInxMinisterOfficer1Image = hmindxpg.hmInxMinisterOfficer1Image;
            hmIndexPgmodel.hmInxMinisterOfficer1Name = hmindxpg.hmInxMinisterOfficer1Name;
            hmIndexPgmodel.hmInxMinisterOfficer1Designation = hmindxpg.hmInxMinisterOfficer1Designation;
            hmIndexPgmodel.hmInxMinisterOfficer1Place = hmindxpg.hmInxMinisterOfficer1Place;
            //if (Image2.FileName != null)
            //{
            //    hmindxpg.hmInxMinisterOfficer2Image = ProcessUploadedFileForHomeIndexPg(Image2);
            //}
            try
            {
                if (Image2.FileName != null)
                {
                    hmIndexPgmodel.hmInxMinisterOfficer2Image = ProcessUploadedFileForHomeIndexPg(Image2);
                }
            }
            catch
            {
                if (hmIndexPgmodel.hmInxMinisterOfficer2Image != "")
                {
                    hmIndexPgmodel.hmInxMinisterOfficer2Image = TempData["hmInxMinisterOfficer2Image"].ToString() == null ? "" : TempData["hmInxMinisterOfficer2Image"].ToString();
                }
                else
                {
                    hmIndexPgmodel.hmInxMinisterOfficer1Image = string.Empty;
                }
            }
            finally { }
            //hmIndexPgmodel.hmInxMinisterOfficer2Image = hmindxpg.hmInxMinisterOfficer2Image;
            hmIndexPgmodel.hmInxMinisterOfficer2Name = hmindxpg.hmInxMinisterOfficer2Name;
            hmIndexPgmodel.hmInxMinisterOfficer2Designation = hmindxpg.hmInxMinisterOfficer2Designation;
            hmIndexPgmodel.hmInxMinisterOfficer2Place = hmindxpg.hmInxMinisterOfficer2Place;
            //if (Image3.FileName != null)
            //{
            //    hmindxpg.hmInxMinisterOfficer3Image = ProcessUploadedFileForHomeIndexPg(Image3);
            //}
            try
            {
                if (Image3.FileName != null)
                {
                    hmIndexPgmodel.hmInxMinisterOfficer3Image = ProcessUploadedFileForHomeIndexPg(Image3);
                }
            }
            catch
            {
                if (hmIndexPgmodel.hmInxMinisterOfficer3Image != "")
                {
                    hmIndexPgmodel.hmInxMinisterOfficer3Image = TempData["hmInxMinisterOfficer3Image"].ToString() == null ? "" : TempData["hmInxMinisterOfficer3Image"].ToString();
                }
                else
                {
                    hmIndexPgmodel.hmInxMinisterOfficer3Image = string.Empty;
                }
            }
            finally { }
            //hmIndexPgmodel.hmInxMinisterOfficer3Image = hmindxpg.hmInxMinisterOfficer3Image;
            hmIndexPgmodel.hmInxMinisterOfficer3Name = hmindxpg.hmInxMinisterOfficer3Name;
            hmIndexPgmodel.hmInxMinisterOfficer3Designation = hmindxpg.hmInxMinisterOfficer3Designation;
            hmIndexPgmodel.hmInxMinisterOfficer3Place = hmindxpg.hmInxMinisterOfficer3Place;
            //if (Image4.FileName != null)
            //{
            //    hmindxpg.hmInxMinisterOfficer4Image = ProcessUploadedFileForHomeIndexPg(Image4);
            //}
            try
            {
                if (Image4.FileName != null)
                {
                    hmIndexPgmodel.hmInxMinisterOfficer4Image = ProcessUploadedFileForHomeIndexPg(Image4);
                }
            }
            catch
            {
                if (hmIndexPgmodel.hmInxMinisterOfficer4Image != "")
                {
                    hmIndexPgmodel.hmInxMinisterOfficer4Image = TempData["hmInxMinisterOfficer4Image"].ToString() == null ? "" : TempData["hmInxMinisterOfficer4Image"].ToString();
                }
                else
                {
                    hmIndexPgmodel.hmInxMinisterOfficer4Image = string.Empty;
                }
            }
            finally { }
            //hmIndexPgmodel.hmInxMinisterOfficer4Image = hmindxpg.hmInxMinisterOfficer4Image;
            hmIndexPgmodel.hmInxMinisterOfficer4Name = hmindxpg.hmInxMinisterOfficer4Name;
            hmIndexPgmodel.hmInxMinisterOfficer4Designation = hmindxpg.hmInxMinisterOfficer4Designation;
            hmIndexPgmodel.hmInxMinisterOfficer4Place = hmindxpg.hmInxMinisterOfficer4Place;
            //if (Image5.FileName != null)
            //{
            //    hmindxpg.hmInxMinisterOfficer5Image = ProcessUploadedFileForHomeIndexPg(Image5);
            //}
            try
            {
                if (Image5.FileName != null)
                {
                    hmIndexPgmodel.hmInxMinisterOfficer5Image = ProcessUploadedFileForHomeIndexPg(Image5);
                }
            }
            catch
            {
                if (hmIndexPgmodel.hmInxMinisterOfficer5Image != "")
                {
                    hmIndexPgmodel.hmInxMinisterOfficer5Image = TempData["hmInxMinisterOfficer5Image"].ToString() == null ? "" : TempData["hmInxMinisterOfficer5Image"].ToString();
                }
                else
                {
                    hmIndexPgmodel.hmInxMinisterOfficer5Image = string.Empty;
                }
            }
            finally { }
            //hmIndexPgmodel.hmInxMinisterOfficer5Image = hmindxpg.hmInxMinisterOfficer5Image; hmIndexPgmodel.hmInxMinisterOfficer5Name = hmindxpg.hmInxMinisterOfficer5Name;
            hmIndexPgmodel.hmInxMinisterOfficer5Name = hmindxpg.hmInxMinisterOfficer5Name;
            hmIndexPgmodel.hmInxMinisterOfficer5Designation = hmindxpg.hmInxMinisterOfficer5Designation;
            hmIndexPgmodel.hmInxMinisterOfficer5Place = hmindxpg.hmInxMinisterOfficer5Place;
            //if (Image6.FileName != null)
            //{
            //    hmindxpg.hmInxMinisterOfficer6Image = ProcessUploadedFileForHomeIndexPg(Image6);
            //}
            try
            {
                if (Image6.FileName != null)
                {
                    hmIndexPgmodel.hmInxMinisterOfficer6Image = ProcessUploadedFileForHomeIndexPg(Image6);
                }
            }
            catch
            {
                if (hmIndexPgmodel.hmInxMinisterOfficer6Image != "")
                {
                    try
                    {
                        hmIndexPgmodel.hmInxMinisterOfficer6Image = TempData["hmInxMinisterOfficer6Image"].ToString() == null ? "" : TempData["hmInxMinisterOfficer6Image"].ToString();
                    }
                    catch { hmIndexPgmodel.hmInxMinisterOfficer6Image = ""; }
                    finally { }
                }
                else
                {
                    hmIndexPgmodel.hmInxMinisterOfficer6Image = string.Empty;
                }
            }
            finally { }
            //hmIndexPgmodel.hmInxMinisterOfficer6Image = hmindxpg.hmInxMinisterOfficer6Image; hmIndexPgmodel.hmInxMinisterOfficer6Name = hmindxpg.hmInxMinisterOfficer6Name;
            hmIndexPgmodel.hmInxMinisterOfficer6Name = hmindxpg.hmInxMinisterOfficer6Name;
            hmIndexPgmodel.hmInxMinisterOfficer6Designation = hmindxpg.hmInxMinisterOfficer6Designation;
            hmIndexPgmodel.hmInxMinisterOfficer6Place = hmindxpg.hmInxMinisterOfficer6Place;
            hmIndexPgmodel.hmInxMinisterOfficerImageWidth = hmindxpg.hmInxMinisterOfficerImageWidth;
            hmIndexPgmodel.hmInxMinisterOfficerImageHeight = hmindxpg.hmInxMinisterOfficerImageHeight;
            hmIndxPgModel.Add(hmIndexPgmodel);
            using (var context = new DemoEntityContext())
            {
                context.HomeIndexPages.Update(hmIndexPgmodel);
                context.SaveChanges();
            }
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
            var MasterPgViewModel = new MasterPgViewModel();
            List<DynamicMasterPageModel>? MsterPgeItems = new List<DynamicMasterPageModel>();
            //string domain = Request.Url.Host;
            //MsterPgeItems = model;
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
                foreach (var ftrmnuitm in value)
                {
                    var ftrmaplnkModel = new FooterMapModel();
                    ftrmaplnkModel.Id = ftrmnuitm.Id;
                    ftrmaplnkModel.maplink = ftrmnuitm.maplink;
                    Ftrmaplnk.Add(ftrmaplnkModel);
                }
            }
            var Ftrcontactus = new List<FooterContactUsModel>();

            using (var context = new DemoEntityContext())
            {
                var value = context.FooterContactUss.ToList();
                foreach (var ftrcontactusitm in value)
                {
                    var ftrcntctusModel = new FooterContactUsModel();
                    ftrcntctusModel.Id = ftrcontactusitm.Id;
                    ftrcntctusModel.addressline1 = ftrcontactusitm.addressline1;
                    ftrcntctusModel.addressline2 = ftrcontactusitm.addressline2;
                    ftrcntctusModel.addressline3 = ftrcontactusitm.addressline3;
                    ftrcntctusModel.addressline4 = ftrcontactusitm.addressline4;
                    ftrcntctusModel.Pincode = ftrcontactusitm.Pincode;
                    ftrcntctusModel.mobile1 = ftrcontactusitm.mobile1;
                    ftrcntctusModel.mobile2 = ftrcontactusitm.mobile2;
                    ftrcntctusModel.emailaddress = ftrcontactusitm.emailaddress;

                    Ftrcontactus.Add(ftrcntctusModel);
                }
            }
            hmIndxPgModel = new List<HomeIndexPageModel>();

            using (var context = new DemoEntityContext())
            {
                var value = context.HomeIndexPages.ToList();
                foreach (var hmindxpgitm in value)
                {
                    var hmindexmodel = new HomeIndexPageModel();
                    hmindexmodel.Id = hmindxpgitm.Id;
                    hmindexmodel.pgTitle = hmindxpgitm.pgTitle;
                    hmindexmodel.hmInxTitleImage = hmindxpgitm.hmInxTitleImage;
                    hmindexmodel.hmInxTitleDescription = hmindxpgitm.hmInxTitleDescription;
                    hmindexmodel.hmInxTitleImageWidth = hmindxpgitm.hmInxTitleImageWidth;
                    hmindexmodel.hmInxTitleImageHeight = hmindxpgitm.hmInxTitleImageHeight;
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
                    hmIndxPgModel.Add(hmindexmodel);
                }
            }
            MasterPgViewModel.mstrpg = MsterPgeItems.ToList();
            MasterPgViewModel.mnus = MsterPgeMnus.ToList();
            MasterPgViewModel.ftrhotlinks = FtrHotLinksMnus.ToList();
            MasterPgViewModel.ftrmaplink = Ftrmaplnk.ToList();
            MasterPgViewModel.ftrcntactus = Ftrcontactus.ToList();
            MasterPgViewModel.hmindxpg = hmIndxPgModel.ToList();
            return RedirectToAction("Index", "Home", MasterPgViewModel);
        }
        public IActionResult ManagePhotoAlbums()
        {
            if (HttpContext.Session.GetString("Role") == "_Admin")
            {
                AlbumModelService objAlbumMaster = new AlbumModelService();
                ViewBag.total = objAlbumMaster.GetAlbums().ToList().Count;
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
                return View(PhtoGaleyViewModel);
            }
            else
            {
                return RedirectToAction("Admin", "Account");
            }
        }
        [HttpPost]
        public IActionResult ManagePhotoAlbums(IFormFile PhotoAlbumImage)
        {
            var photoAlbmodel = new List<AlbumMaster>();
            var phtoAlbModel = new AlbumMaster();
            try
            {
                if (PhotoAlbumImage.FileName != null)
                {
                    phtoAlbModel.ImagePath = ProcessUploadedPhotoToPhotoAbbum(PhotoAlbumImage);
                }
            }
            catch
            {
                if (phtoAlbModel.ImagePath != "")
                {
                    phtoAlbModel.ImagePath = TempData["photoImage"].ToString() == null ? "" : TempData["homebannerImage"].ToString();
                }
                else
                {
                    phtoAlbModel.ImagePath = string.Empty;
                }
            }
            finally { }
            photoAlbmodel.Add(phtoAlbModel);
            using (var context = new DemoEntityContext())
            {
                context.PhotoAlbumMaster.Update(phtoAlbModel);
                context.SaveChanges();
            }
            //return View(MasterPgViewModel);
            return RedirectToAction("ManagePhotoAlbums", "Admin");
            //return RedirectToAction("Index", "Home");
        }
        public string ProcessUploadedPhotoToPhotoAbbum(IFormFile file)
        {
            string filename = file.FileName;
            string path = "";
            try
            {
                if (file.Length > 0)
                {
                    path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Uploads\\PhotoAlbum"));
                    var filestream = new FileStream(Path.Combine(path, filename), FileMode.Create);
                    file.CopyToAsync(filestream);
                }
            }
            catch (Exception)
            {
                //throw;
            }
            return filename;
        }
        public string ProcessUploadedFileForHomeIndexPg(IFormFile file)
        {
            string filename = file.FileName;
            string path = "";
            try
            {
                if (file.Length > 0)
                {
                    path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Uploads\\HomeIndexImages"));
                    var filestream = new FileStream(Path.Combine(path, filename), FileMode.Create);
                    file.CopyToAsync(filestream);
                }
            }
            catch (Exception)
            {
                //throw;
            }
            return filename;
        }
        public IActionResult Allotment()
        {
            if (HttpContext.Session.GetString("Role") == "_Admin")
            {
                //HttpContext.Session.SetString("Role", "");
                var AllotmentViewModel = new AllotmentViewModel();
                var ProptyMdl = new List<PropertyMaster>();
                var propty = new PropertyMaster();
                using (var context = new DemoEntityContext())
                {
                    var value = context.PropertyMaster.ToList();
                    int cnt = value.Count();
                    foreach (var proptyitm in value)
                    {
                        var prptyModel = new PropertyMaster();
                        prptyModel.PropertyId = proptyitm.PropertyId;
                        prptyModel.PropertyCategory = proptyitm.PropertyCategory;
                        prptyModel.Property = proptyitm.Property;
                        ProptyMdl.Add(prptyModel);
                        AllotmentViewModel.propertylstmdl = ProptyMdl;
                    }
                }
                var ApplyctMdl = new List<ApplicantMaster>();
                var applycts = new ApplicantMaster();
                using (var context = new DemoEntityContext())
                {
                    var value = context.ApplicantMaster.ToList();
                    int cnt = value.Count();
                    foreach (var applyctitm in value)
                    {
                        var applyctModel = new ApplicantMaster();
                        applyctModel.RegistrationNo = applyctitm.RegistrationNo;
                        applyctModel.ApplicantCategory = applyctitm.ApplicantCategory;
                        applyctModel.ApplicantName = applyctitm.ApplicantName;
                        ApplyctMdl.Add(applyctModel);
                        AllotmentViewModel.applicantlstmdl = ApplyctMdl;
                    }
                }
                return View("Allotment", AllotmentViewModel);
            }
            else
            {
                return RedirectToAction("Admin", "Account");
            }
        }
        [HttpPost]
        public IActionResult Allotment(string i)
        {
            var AllotmentViewModel = new AllotmentViewModel();
            var ApplyctMdl = new List<ApplicantMaster>();
            var applycts = new ApplicantMaster();
            using (var context = new DemoEntityContext())
            {
                var value = context.ApplicantMaster.ToList();
                int cnt = value.Count();
                ViewBag.applicantcnt = cnt;
                foreach (var applyctitm in value)
                {
                    var applyctModel = new ApplicantMaster();
                    applyctModel.RegistrationNo = applyctitm.RegistrationNo;
                    applyctModel.ApplicantCategory = applyctitm.ApplicantCategory;
                    applyctModel.ApplicantName = applyctitm.ApplicantName;
                    ApplyctMdl.Add(applyctModel);
                    AllotmentViewModel.applicantlstmdl = ApplyctMdl;
                }
            }
            var ProptyMdl = new List<PropertyMaster>();
            var propty = new PropertyMaster();
            using (var context = new DemoEntityContext())
            {
                var value = context.PropertyMaster.ToList();
                int cnt = value.Count();
                foreach (var proptyitm in value)
                {
                    var prptyModel = new PropertyMaster();
                    prptyModel.PropertyId = proptyitm.PropertyId;
                    prptyModel.PropertyCategory = proptyitm.PropertyCategory;
                    prptyModel.Property = proptyitm.Property;
                    ProptyMdl.Add(prptyModel);
                }
                if (AllotmentViewModel.applicantlstmdl.Count > cnt)
                {
                    for (int a = 0; a < AllotmentViewModel.applicantlstmdl.Count - cnt; a++)
                    {
                        var blnkprptyModel = new PropertyMaster();
                        blnkprptyModel.PropertyId = cnt + a + 1;
                        blnkprptyModel.PropertyCategory = "MIG";
                        blnkprptyModel.Property = string.Concat("Blnk/", (a + 1).ToString());
                        ProptyMdl.Add(blnkprptyModel);
                    }
                    AllotmentViewModel.propertylstmdl = ProptyMdl;
                }
                else
                {
                    AllotmentViewModel.propertylstmdl = ProptyMdl;
                }
            }
            return View("ApplicantPropertyList", AllotmentViewModel);
        }
        [HttpPost]
        public IActionResult ApplicantPropertyList(string i)
        {
            var AllotmentViewModel = new AllotmentViewModel();
            var ApplyctMdl = new List<ApplicantMaster>();
            var applycts = new ApplicantMaster();

            var AllotmentMdl = new List<AllotmentMaster>();
            using (var rmvcontext = new DemoEntityContext())
            {
                var valtormv = rmvcontext.AllotmentMaster.ToList();
                foreach (var alltmtitm in valtormv)
                {
                    var alltmtModel = new AllotmentMaster();
                    alltmtModel.AllotmentId = alltmtitm.AllotmentId;
                    alltmtModel.Property = alltmtitm.Property;
                    alltmtModel.RegistrationNo = alltmtitm.RegistrationNo;
                    alltmtModel.ApplicantName = alltmtitm.ApplicantName;
                    AllotmentMdl.Add(alltmtModel);
                }
            }
            if (AllotmentMdl.Count < 50)
            {

                using (var context = new DemoEntityContext())
                {
                    var value = context.ApplicantMaster.ToList();
                    int cnt = value.Count();
                    ViewBag.applicantcnt = cnt;
                    foreach (var applyctitm in value)
                    {
                        var applyctModel = new ApplicantMaster();
                        applyctModel.RegistrationNo = applyctitm.RegistrationNo;
                        applyctModel.ApplicantCategory = applyctitm.ApplicantCategory;
                        applyctModel.ApplicantName = applyctitm.ApplicantName;
                        ApplyctMdl.Add(applyctModel);
                        AllotmentViewModel.applicantlstmdl = ApplyctMdl;
                    }
                }
                var ProptyMdl = new List<PropertyMaster>();
                var propty = new PropertyMaster();
                using (var context = new DemoEntityContext())
                {
                    var value = context.PropertyMaster.ToList();
                    int cnt = value.Count();
                    foreach (var proptyitm in value)
                    {
                        var prptyModel = new PropertyMaster();
                        prptyModel.PropertyId = proptyitm.PropertyId;
                        prptyModel.PropertyCategory = proptyitm.PropertyCategory;
                        prptyModel.Property = proptyitm.Property;
                        ProptyMdl.Add(prptyModel);
                    }
                    if (AllotmentViewModel.applicantlstmdl.Count > cnt)
                    {
                        for (int a = 0; a < AllotmentViewModel.applicantlstmdl.Count - cnt; a++)
                        {
                            var blnkprptyModel = new PropertyMaster();
                            blnkprptyModel.PropertyId = cnt + a + 1;
                            blnkprptyModel.PropertyCategory = "MIG";
                            blnkprptyModel.Property = string.Concat("Blnk/", (a + 1).ToString());
                            ProptyMdl.Add(blnkprptyModel);
                        }
                        AllotmentViewModel.propertylstmdl = ProptyMdl;
                    }
                    else
                    {
                        AllotmentViewModel.propertylstmdl = ProptyMdl;
                    }
                }
                var OriginalProptyMdl = new List<PropertyMaster>();
                OriginalProptyMdl = ProptyMdl;
                var OriginalApplyctMdl = new List<ApplicantMaster>();
                OriginalApplyctMdl = ApplyctMdl;

                using (var rmvcontext = new DemoEntityContext())
                {
                    var valtormv = rmvcontext.AllotmentMaster.ToList();
                    foreach (var alltmtitm in valtormv)
                    {
                        var alltmtModel = new AllotmentMaster();
                        alltmtModel.AllotmentId = alltmtitm.AllotmentId;
                        alltmtModel.Property = alltmtitm.Property;
                        alltmtModel.RegistrationNo = alltmtitm.RegistrationNo;
                    }
                }
                AllotmentMdl = new List<AllotmentMaster>();
                var allotment = new AllotmentMaster();
                string appctnm = string.Empty;
                string propertyassigned = string.Empty;
                int appctregno = 0;
                ApplyctMdl = new List<ApplicantMaster>();
                applycts = new ApplicantMaster();
                var dontAddAppct = false;
                var dontAddPrpty = false;
                var dontAddBlnkPrpty = false;
                using (var context = new DemoEntityContext())
                {
                    var l1 = context.ApplicantMaster.ToList();
                    var value = l1.Except(ApplyctMdl).ToList();
                    int cnt = value.Count();
                    ViewBag.applicantcnt = cnt;
                    Random rnd = new Random();
                    int maxrange = 50;
                    int rndnum = rnd.Next(maxrange + 1);
                    foreach (var applyctitm in value)
                    {
                        var applyctModel = new ApplicantMaster();
                        applyctModel.RegistrationNo = applyctitm.RegistrationNo;
                        if (applyctModel.RegistrationNo != rndnum)
                        {
                            applyctModel.ApplicantCategory = applyctitm.ApplicantCategory;
                            applyctModel.ApplicantName = applyctitm.ApplicantName;
                        }
                        else
                        {
                            using (var rmvcontext = new DemoEntityContext())
                            {
                                var valtormv = rmvcontext.AllotmentMaster.ToList();
                                if (valtormv.Count > 0)
                                {
                                    foreach (var alltmtitm in valtormv)
                                    {
                                        var alltmtModel = new AllotmentMaster();
                                        alltmtModel.AllotmentId = alltmtitm.AllotmentId;
                                        alltmtModel.Property = alltmtitm.Property;
                                        alltmtModel.RegistrationNo = alltmtitm.RegistrationNo;
                                        appctnm = applyctitm.ApplicantName == null ? "" : applyctitm.ApplicantName;
                                        appctregno = applyctitm.RegistrationNo;
                                        if (appctregno == alltmtModel.RegistrationNo)
                                        {
                                            appctnm = "";
                                            appctregno = 0;
                                            dontAddAppct = true;
                                        }
                                        else
                                        {
                                            appctnm = applyctitm.ApplicantName == null ? "" : applyctitm.ApplicantName;
                                            appctregno = applyctitm.RegistrationNo;
                                        }
                                    }
                                }
                                else
                                {
                                    appctnm = string.Concat("NAME", rndnum.ToString());
                                    appctregno = rndnum;
                                }
                            }
                        }
                        if (dontAddAppct == false)
                        {
                            ApplyctMdl.Add(applyctModel);
                            AllotmentViewModel.applicantlstmdl = ApplyctMdl;
                        }
                    }
                }
                propty = new PropertyMaster();
                Random rndprop = new Random();
                int maxrangeprop = 50;
                int rndnumprop = rndprop.Next(maxrangeprop + 1);
                int loopcnt = 0;
                using (var context = new DemoEntityContext())
                {
                    var value = context.PropertyMaster.ToList();
                    int cnt = value.Count();
                    foreach (var proptyitm in value)
                    {
                        var prptyModel = new PropertyMaster();
                        prptyModel.PropertyId = proptyitm.PropertyId;
                        prptyModel.PropertyCategory = proptyitm.PropertyCategory;
                        prptyModel.Property = proptyitm.Property;
                        loopcnt++;
                        if (rndnumprop <= cnt && loopcnt == rndnumprop)
                        {
                            dontAddPrpty = false;
                            using (var rmvcontext = new DemoEntityContext())
                            {
                                var valtormv = rmvcontext.AllotmentMaster.ToList();
                                if (valtormv.Count > 0)
                                {
                                    foreach (var alltmtitm in valtormv)
                                    {
                                        var alltmtModel = new AllotmentMaster();
                                        alltmtModel.AllotmentId = alltmtitm.AllotmentId;
                                        alltmtModel.Property = alltmtitm.Property;
                                        alltmtModel.RegistrationNo = alltmtitm.RegistrationNo;
                                        if (prptyModel.Property == alltmtModel.Property)
                                        {
                                            dontAddPrpty = true;
                                        }
                                        else
                                        {
                                            propertyassigned = prptyModel.Property == null ? "" : prptyModel.Property;
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    if (rndnumprop > cnt)
                                    {
                                        propertyassigned = string.Concat("Blnk", "1");
                                        //prptyModel.Property == null ? "" : prptyModel.Property;
                                        break;
                                    }
                                    else
                                    {
                                        //string proptyy = ((OriginalProptyMdl.First(x => x.PropertyId == rndnumprop).Property)==null)?"": (OriginalProptyMdl.First(x => x.PropertyId == rndnumprop).Property);
                                        //propertyassigned = proptyy;
                                        propertyassigned = OriginalProptyMdl.First(x => x.PropertyId == rndnumprop).Property;
                                        //(OriginalProptyMdl.First(x => x.PropertyId == rndnumprop).Property)==null?"": (OriginalProptyMdl.First(x => x.PropertyId == rndnumprop).Property);
                                    }
                                }
                                if (dontAddPrpty == false)
                                {
                                    propertyassigned = prptyModel.Property == null ? "" : prptyModel.Property;
                                    break;
                                }
                            }
                        }
                    }
                    if (rndnumprop > cnt)
                    {
                        for (int a = 0; a < AllotmentViewModel.applicantlstmdl.Count - cnt; a++)
                        {
                            var blnkprptyModel = new PropertyMaster();
                            blnkprptyModel.PropertyId = rndnumprop;
                            blnkprptyModel.PropertyCategory = "MIG";
                            //blnkprptyModel.Property = string.Concat("Blnk/", (rndnumprop-36).ToString());
                            blnkprptyModel.Property = string.Concat("Blnk/", (a + 1).ToString());
                            dontAddBlnkPrpty = false;
                            using (var rmvcontext = new DemoEntityContext())
                            {
                                var valtormv = rmvcontext.AllotmentMaster.ToList();
                                foreach (var alltmtitm in valtormv)
                                {
                                    var alltmtModel = new AllotmentMaster();
                                    alltmtModel.AllotmentId = alltmtitm.AllotmentId;
                                    alltmtModel.Property = alltmtitm.Property;
                                    alltmtModel.RegistrationNo = alltmtitm.RegistrationNo;
                                    if (blnkprptyModel.Property == alltmtModel.Property)
                                    {
                                        dontAddBlnkPrpty = true;
                                    }
                                }
                            }
                            if (dontAddBlnkPrpty == false)
                            {
                                propertyassigned = blnkprptyModel.Property;
                                break;
                            }
                        }
                    }
                }
                var RndmzProptyMdl = new List<PropertyMaster>();

                var allotmentModel = new AllotmentMaster();
                using (var context = new DemoEntityContext())
                {
                    var value = context.PropertyMaster.ToList();
                    using (var rmvcontext = new DemoEntityContext())
                    {
                        var valtormv = rmvcontext.AllotmentMaster.ToList();
                        foreach (var alltmtitm in valtormv)
                        {
                            var alltmtModel = new AllotmentMaster();
                            alltmtModel.AllotmentId = alltmtitm.AllotmentId;
                            alltmtModel.Property = alltmtitm.Property;
                            alltmtModel.RegistrationNo = alltmtitm.RegistrationNo;
                            if (allotmentModel.RegistrationNo == alltmtModel.RegistrationNo)
                            {
                                allotmentModel.RegistrationNo = 0;
                                allotmentModel.Property = "";
                            }
                            if (allotmentModel.Property == alltmtModel.Property)
                            {
                                allotmentModel.Property = "";
                                allotmentModel.RegistrationNo = 0;
                            }
                        }
                    }
                    AllotmentMdl = new List<AllotmentMaster>();
                    using (var rmvcontext = new DemoEntityContext())
                    {
                        var valtormv = rmvcontext.AllotmentMaster.ToList();
                        foreach (var alltmtitm in valtormv)
                        {
                            var alltmtModel = new AllotmentMaster();
                            alltmtModel.AllotmentId = alltmtitm.AllotmentId;
                            alltmtModel.Property = alltmtitm.Property;
                            alltmtModel.RegistrationNo = alltmtitm.RegistrationNo;
                            alltmtModel.ApplicantName = alltmtitm.ApplicantName;
                            AllotmentMdl.Add(alltmtModel);
                        }
                        allotmentModel.Property = propertyassigned;
                        allotmentModel.ApplicantName = appctnm;
                        allotmentModel.RegistrationNo = appctregno;
                        if (!dontAddAppct && !dontAddPrpty && !dontAddBlnkPrpty)
                        {
                            AllotmentMdl.Add(allotmentModel);
                        }
                    }
                    if (allotmentModel.RegistrationNo != 0 && allotmentModel.Property != "" && dontAddAppct == false && dontAddPrpty == false)
                    {
                        allotmentModel.Property = propertyassigned;
                        allotmentModel.ApplicantName = appctnm;
                        allotmentModel.RegistrationNo = appctregno;
                        using (var svcontext = new DemoEntityContext())
                        {
                            svcontext.AllotmentMaster.Update(allotmentModel);
                            svcontext.SaveChanges();
                        }
                        using (var rmvcontext = new DemoEntityContext())
                        {
                            var valtormv = rmvcontext.AllotmentMaster.ToList();
                            foreach (var alltmtitm in valtormv)
                            {
                                var alltmtModel = new AllotmentMaster();
                                alltmtModel.AllotmentId = alltmtitm.AllotmentId;
                                alltmtModel.Property = alltmtitm.Property;
                                alltmtModel.RegistrationNo = alltmtitm.RegistrationNo;
                                alltmtModel.ApplicantName = alltmtitm.ApplicantName;
                                try
                                {
                                    OriginalApplyctMdl.Remove(OriginalApplyctMdl.First(x => x.RegistrationNo == alltmtModel.RegistrationNo));
                                }
                                catch
                                {

                                }
                                finally { }
                                try
                                {
                                    OriginalProptyMdl.Remove(OriginalProptyMdl.First(x => x.Property == alltmtModel.Property));
                                }
                                catch
                                {

                                }
                                finally { }
                            }
                        }
                        AllotmentViewModel.allotmentlstmdl = AllotmentMdl;
                        AllotmentViewModel.propertylstmdl = OriginalProptyMdl;
                        AllotmentViewModel.applicantlstmdl = OriginalApplyctMdl;
                        return View("RandomizedApplicantPropertyList", AllotmentViewModel);
                    }
                    else
                    {
                        return RedirectToAction("ApplicantPropertyListRepeat");
                    }
                }
            }
            else
            {
                AllotmentViewModel.allotmentlstmdl = AllotmentMdl;
                AllotmentViewModel.propertylstmdl = new List<PropertyMaster>();
                AllotmentViewModel.applicantlstmdl = new List<ApplicantMaster>();
                return View("RandomizedApplicantPropertyList", AllotmentViewModel);
            }
        }
        public ActionResult ApplicantPropertyListRepeat()
        {
            var AllotmentViewModel = new AllotmentViewModel();
            var ApplyctMdl = new List<ApplicantMaster>();
            var applycts = new ApplicantMaster();
            using (var context = new DemoEntityContext())
            {
                var value = context.ApplicantMaster.ToList();
                int cnt = value.Count();
                ViewBag.applicantcnt = cnt;
                foreach (var applyctitm in value)
                {
                    var applyctModel = new ApplicantMaster();
                    applyctModel.RegistrationNo = applyctitm.RegistrationNo;
                    applyctModel.ApplicantCategory = applyctitm.ApplicantCategory;
                    applyctModel.ApplicantName = applyctitm.ApplicantName;
                    ApplyctMdl.Add(applyctModel);
                    AllotmentViewModel.applicantlstmdl = ApplyctMdl;
                }
            }
            var ProptyMdl = new List<PropertyMaster>();
            var propty = new PropertyMaster();
            using (var context = new DemoEntityContext())
            {
                var value = context.PropertyMaster.ToList();
                int cnt = value.Count();
                foreach (var proptyitm in value)
                {
                    var prptyModel = new PropertyMaster();
                    prptyModel.PropertyId = proptyitm.PropertyId;
                    prptyModel.PropertyCategory = proptyitm.PropertyCategory;
                    prptyModel.Property = proptyitm.Property;
                    ProptyMdl.Add(prptyModel);
                }
                if (AllotmentViewModel.applicantlstmdl.Count > cnt)
                {
                    for (int a = 0; a < AllotmentViewModel.applicantlstmdl.Count - cnt; a++)
                    {
                        var blnkprptyModel = new PropertyMaster();
                        blnkprptyModel.PropertyId = cnt + a + 1;
                        blnkprptyModel.PropertyCategory = "MIG";
                        blnkprptyModel.Property = string.Concat("Blnk/", (a + 1).ToString());
                        ProptyMdl.Add(blnkprptyModel);
                    }
                    AllotmentViewModel.propertylstmdl = ProptyMdl;
                }
                else
                {
                    AllotmentViewModel.propertylstmdl = ProptyMdl;
                }
            }
            var OriginalProptyMdl = new List<PropertyMaster>();
            var TempProptyMdl = new List<PropertyMaster>();
            OriginalProptyMdl = ProptyMdl;
            TempProptyMdl = ProptyMdl;
            var OriginalApplyctMdl = new List<ApplicantMaster>();
            var TempApplyctMdl = new List<ApplicantMaster>();
            OriginalApplyctMdl = ApplyctMdl;
            TempApplyctMdl = ApplyctMdl;
            using (var rmvcontext = new DemoEntityContext())
            {
                var valtormv = rmvcontext.AllotmentMaster.ToList();
                foreach (var alltmtitm in valtormv)
                {
                    var alltmtModel = new AllotmentMaster();
                    alltmtModel.AllotmentId = alltmtitm.AllotmentId;
                    alltmtModel.Property = alltmtitm.Property;
                    alltmtModel.RegistrationNo = alltmtitm.RegistrationNo;
                }
            }
            var AllotmentMdl = new List<AllotmentMaster>();
            var allotment = new AllotmentMaster();
            string appctnm = string.Empty;
            string propertyassigned = string.Empty;
            int appctregno = 0;
            ApplyctMdl = new List<ApplicantMaster>();
            applycts = new ApplicantMaster();
            var dontAddAppct = false;
            var dontAddPrpty = false;
            var dontAddBlnkPrpty = false;
            using (var context = new DemoEntityContext())
            {
                var l1 = context.ApplicantMaster.ToList();
                var value = l1.Except(ApplyctMdl).ToList();
                int cnt = value.Count();
                ViewBag.applicantcnt = cnt;
                Random rnd = new Random();
                int maxrange = 50;
                int rndnum = rnd.Next(maxrange + 1);
                foreach (var applyctitm in value)
                {
                    var applyctModel = new ApplicantMaster();
                    applyctModel.RegistrationNo = applyctitm.RegistrationNo;
                    if (applyctModel.RegistrationNo != rndnum)
                    {
                        applyctModel.ApplicantCategory = applyctitm.ApplicantCategory;
                        applyctModel.ApplicantName = applyctitm.ApplicantName;
                    }
                    else
                    {
                        using (var rmvcontext = new DemoEntityContext())
                        {
                            var valtormv = rmvcontext.AllotmentMaster.ToList();
                            foreach (var alltmtitm in valtormv)
                            {
                                var alltmtModel = new AllotmentMaster();
                                alltmtModel.AllotmentId = alltmtitm.AllotmentId;
                                alltmtModel.Property = alltmtitm.Property;
                                alltmtModel.RegistrationNo = alltmtitm.RegistrationNo;
                                appctnm = string.Concat("NAME", rndnum.ToString());
                                appctregno = rndnum;
                                if (appctregno == alltmtModel.RegistrationNo)
                                {
                                    appctnm = "";
                                    appctregno = 0;
                                    dontAddAppct = true;
                                }
                                else
                                {
                                    appctnm = string.Concat("NAME", rndnum.ToString());
                                    appctregno = rndnum;
                                }
                            }
                        }
                    }
                    if (dontAddAppct == false)
                    {
                        ApplyctMdl.Add(applyctModel);
                        AllotmentViewModel.applicantlstmdl = ApplyctMdl;
                    }
                }
            }
            propty = new PropertyMaster();
            Random rndprop = new Random();
            int maxrangeprop = 50;
            int rndnumprop = rndprop.Next(maxrangeprop + 1);
            if (rndnumprop == 0)
            {
                rndnumprop = rndprop.Next(maxrangeprop + 1);
            }
            int loopcnt = 0;
            using (var context = new DemoEntityContext())
            {
                var value = context.PropertyMaster.ToList();
                int cnt = value.Count();
                foreach (var proptyitm in value)
                {
                    var prptyModel = new PropertyMaster();
                    prptyModel.PropertyId = proptyitm.PropertyId;
                    prptyModel.PropertyCategory = proptyitm.PropertyCategory;
                    prptyModel.Property = proptyitm.Property;
                    loopcnt++;
                    if (rndnumprop <= cnt && loopcnt == rndnumprop)
                    {
                        dontAddPrpty = false;
                        using (var rmvcontext = new DemoEntityContext())
                        {
                            var valtormv = rmvcontext.AllotmentMaster.ToList();
                            foreach (var alltmtitm in valtormv)
                            {
                                var alltmtModel = new AllotmentMaster();
                                alltmtModel.AllotmentId = alltmtitm.AllotmentId;
                                alltmtModel.Property = alltmtitm.Property;
                                alltmtModel.RegistrationNo = alltmtitm.RegistrationNo;
                                if (prptyModel.Property == alltmtModel.Property)
                                {
                                    dontAddPrpty = true;
                                }
                                else
                                {
                                    propertyassigned = prptyModel.Property == null ? "" : prptyModel.Property;
                                    //break;
                                }
                            }
                            if (dontAddPrpty == false)
                            {
                                propertyassigned = prptyModel.Property == null ? "" : prptyModel.Property;
                                break;
                            }
                        }
                    }
                }
                if (rndnumprop > cnt)
                {
                    for (int a = 0; a < AllotmentViewModel.applicantlstmdl.Count - cnt; a++)
                    {
                        var blnkprptyModel = new PropertyMaster();
                        blnkprptyModel.PropertyId = rndnumprop;
                        blnkprptyModel.PropertyCategory = "MIG";

                        blnkprptyModel.Property = string.Concat("Blnk/", (rndnumprop - 14).ToString());
                        dontAddBlnkPrpty = false;
                        using (var rmvcontext = new DemoEntityContext())
                        {
                            var valtormv = rmvcontext.AllotmentMaster.ToList();
                            foreach (var alltmtitm in valtormv)
                            {
                                var alltmtModel = new AllotmentMaster();
                                alltmtModel.AllotmentId = alltmtitm.AllotmentId;
                                alltmtModel.Property = alltmtitm.Property;
                                alltmtModel.RegistrationNo = alltmtitm.RegistrationNo;
                                if (blnkprptyModel.Property == alltmtModel.Property)
                                {
                                    dontAddBlnkPrpty = true;
                                }
                            }
                        }
                        if (dontAddBlnkPrpty == false)
                        {
                            propertyassigned = blnkprptyModel.Property;
                            break;
                        }
                    }
                }
            }
            var RndmzProptyMdl = new List<PropertyMaster>();

            var allotmentModel = new AllotmentMaster();
            using (var context = new DemoEntityContext())
            {
                var value = context.PropertyMaster.ToList();
                using (var rmvcontext = new DemoEntityContext())
                {
                    var valtormv = rmvcontext.AllotmentMaster.ToList();
                    foreach (var alltmtitm in valtormv)
                    {
                        var alltmtModel = new AllotmentMaster();
                        alltmtModel.AllotmentId = alltmtitm.AllotmentId;
                        alltmtModel.Property = alltmtitm.Property;
                        alltmtModel.RegistrationNo = alltmtitm.RegistrationNo;
                        if (allotmentModel.RegistrationNo == alltmtModel.RegistrationNo)
                        {
                            allotmentModel.RegistrationNo = 0;
                            allotmentModel.Property = "";
                        }
                        if (allotmentModel.Property == alltmtModel.Property)
                        {
                            allotmentModel.Property = "";
                            allotmentModel.RegistrationNo = 0;
                        }
                    }
                }
                AllotmentMdl = new List<AllotmentMaster>();
                using (var rmvcontext = new DemoEntityContext())
                {
                    var valtormv = rmvcontext.AllotmentMaster.ToList();
                    foreach (var alltmtitm in valtormv)
                    {
                        var alltmtModel = new AllotmentMaster();
                        alltmtModel.AllotmentId = alltmtitm.AllotmentId;
                        alltmtModel.Property = alltmtitm.Property;
                        alltmtModel.RegistrationNo = alltmtitm.RegistrationNo;
                        alltmtModel.ApplicantName = alltmtitm.ApplicantName;
                        AllotmentMdl.Add(alltmtModel);
                        try
                        {
                            TempApplyctMdl.Remove(TempApplyctMdl.First(x => x.RegistrationNo == alltmtModel.RegistrationNo));
                        }
                        catch
                        {
                        }
                        finally { }
                        try
                        {
                            TempProptyMdl.Remove(TempProptyMdl.First(x => x.Property == alltmtModel.Property));
                        }
                        catch
                        {

                        }
                        finally { }
                    }
                    if (AllotmentMdl.Count >= 1 && TempApplyctMdl.Count>0)
                    {
                        allotmentModel.RegistrationNo = TempApplyctMdl[0].RegistrationNo;

                        allotmentModel.ApplicantName = TempApplyctMdl[0].ApplicantName;

                        propertyassigned = TempProptyMdl[0].Property==null?"": TempProptyMdl[0].Property;
                        if (propertyassigned!="")
                        {
                            dontAddAppct = false;
                        }
                        if ((allotmentModel.Property != "" && allotmentModel.Property != null) && (allotmentModel.ApplicantName != "" && allotmentModel.ApplicantName != null) && allotmentModel.RegistrationNo != 0)
                        {
                            AllotmentMdl.Add(allotmentModel);
                        }
                        using (var rmvlstcontext = new DemoEntityContext())
                        {
                            var lstvaltormv = rmvlstcontext.AllotmentMaster.ToList();
                            foreach (var alltmtitm in lstvaltormv)
                            {
                                var alltmtModel = new AllotmentMaster();
                                alltmtModel.AllotmentId = alltmtitm.AllotmentId;
                                alltmtModel.Property = alltmtitm.Property;
                                alltmtModel.RegistrationNo = alltmtitm.RegistrationNo;
                                appctnm = allotmentModel.ApplicantName == null ? "" : allotmentModel.ApplicantName;
                                appctregno = allotmentModel.RegistrationNo;
                                if (appctregno == alltmtModel.RegistrationNo)
                                {
                                    appctnm = "";
                                    appctregno = 0;
                                    dontAddAppct = true;
                                }
                                else
                                if (propertyassigned == alltmtModel.Property)
                                {
                                    propertyassigned = "";
                                    dontAddPrpty = true;
                                }
                                else
                                {
                                    appctnm = allotmentModel.ApplicantName == null ? "" : allotmentModel.ApplicantName;
                                    appctregno = allotmentModel.RegistrationNo;                                    
                                }
                            }
                        }
                    }
                    else
                    {
                        allotmentModel.Property = propertyassigned;
                        allotmentModel.ApplicantName = appctnm;
                        allotmentModel.RegistrationNo = appctregno;
                        if (!dontAddAppct && !dontAddPrpty && !dontAddBlnkPrpty)
                        {
                            AllotmentMdl.Add(allotmentModel);
                        }
                    }
                }
                if (allotmentModel.RegistrationNo != 0 && allotmentModel.Property != "" && dontAddAppct == false && dontAddPrpty == false)
                {
                    allotmentModel.Property = propertyassigned;
                    allotmentModel.ApplicantName = appctnm;
                    allotmentModel.RegistrationNo = appctregno;
                    using (var svcontext = new DemoEntityContext())
                    {
                        svcontext.AllotmentMaster.Update(allotmentModel);
                        svcontext.SaveChanges();
                    }
                    using (var rmvcontext = new DemoEntityContext())
                    {
                        var valtormv = rmvcontext.AllotmentMaster.ToList();
                        foreach (var alltmtitm in valtormv)
                        {
                            var alltmtModel = new AllotmentMaster();
                            alltmtModel.AllotmentId = alltmtitm.AllotmentId;
                            alltmtModel.Property = alltmtitm.Property;
                            alltmtModel.RegistrationNo = alltmtitm.RegistrationNo;
                            alltmtModel.ApplicantName = alltmtitm.ApplicantName;
                            try
                            {
                                OriginalApplyctMdl.Remove(OriginalApplyctMdl.First(x => x.RegistrationNo == alltmtModel.RegistrationNo));
                            }
                            catch
                            {

                            }
                            finally { }
                            try
                            {
                                OriginalProptyMdl.Remove(OriginalProptyMdl.First(x => x.Property == alltmtModel.Property));
                            }
                            catch
                            {

                            }
                            finally { }
                        }
                    }
                    AllotmentViewModel.allotmentlstmdl = AllotmentMdl;
                    AllotmentViewModel.propertylstmdl = OriginalProptyMdl;
                    AllotmentViewModel.applicantlstmdl = OriginalApplyctMdl;
                    ViewBag.AllotmentViewModel = AllotmentViewModel;
                    return View("RandomizedApplicantPropertyList", AllotmentViewModel);
                }
                else
                {
                    using (var rmvcontext = new DemoEntityContext())
                    {
                        var valtormv = rmvcontext.AllotmentMaster.ToList();
                        foreach (var alltmtitm in valtormv)
                        {
                            var alltmtModel = new AllotmentMaster();
                            alltmtModel.AllotmentId = alltmtitm.AllotmentId;
                            alltmtModel.Property = alltmtitm.Property;
                            alltmtModel.RegistrationNo = alltmtitm.RegistrationNo;
                            alltmtModel.ApplicantName = alltmtitm.ApplicantName;
                            try
                            {
                                OriginalApplyctMdl.Remove(OriginalApplyctMdl.First(x => x.RegistrationNo == alltmtModel.RegistrationNo));
                            }
                            catch
                            {
                            }
                            finally { }
                            try
                            {
                                OriginalProptyMdl.Remove(OriginalProptyMdl.First(x => x.Property == alltmtModel.Property));
                            }
                            catch
                            {
                            }
                            finally { }
                        }
                    }
                    AllotmentViewModel.allotmentlstmdl = AllotmentMdl;
                    AllotmentViewModel.propertylstmdl = OriginalProptyMdl;
                    AllotmentViewModel.applicantlstmdl = OriginalApplyctMdl;
                    ViewBag.lastAllotmentViewModel = AllotmentViewModel;
                    return RedirectToAction("ApplicantPropertyListRepeat");
                }
            }
        }
    }
}


