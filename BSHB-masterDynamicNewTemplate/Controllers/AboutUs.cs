using BiharStateHousingBoard.Models;
using Microsoft.AspNetCore.Mvc;

namespace BiharStateHousingBoard.Controllers
{
    public class AboutUs : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult GetMenuData()
        {
            BSHBContext entities = new BSHBContext();
            var result = (from m in entities.MenusMvcs
                          select new MenusMvc
                          {
                              MenuId = m.MenuId,
                              ParentMenuId = m.ParentMenuId,
                              Title = m.Title,
                              Action = m.Action,
                              Controller = m.Controller
                          }).ToList();
            return View("Menu", result);
        }
        public ActionResult MDMessage()
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
            var MsterPgeMnus = new List<MenuModel>();
            List<DynamicMasterPageModel>? MsterPgeItems = new List<DynamicMasterPageModel>();
            //string domain = Request.Url.Host;
            MsterPgeItems = model;
            MenuEntities entities = new MenuEntities();
            var result = (from m in entities.Menus
                          select new MenuModel
                          {
                              Id = m.Id,
                              ParentMenuId = m.ParentMenuId,
                              Title = m.Title,
                              Action = m.Action,
                              Controller = m.Controller
                          }).ToList();


            MasterPgViewModel.mstrpg = MsterPgeItems.ToList();
            MasterPgViewModel.mnus = result;

            //return View(MasterPgViewModel);
            return View("MDMessage", MasterPgViewModel);
        }
        public ActionResult ListofChairman()
        {
            return View();
        }

    }
}
