using BiharStateHousingBoard.Models;
using Microsoft.AspNetCore.Mvc;

namespace BiharStateHousingBoard.Components
{
    public class TopMenuViewComponent : ViewComponent
    {
        private readonly BSHBContext _context;

        public TopMenuViewComponent(BSHBContext context)
        {
            _context = context;

            //_context.AddMenuItems();

            //object value = _context.MenusMvcs();
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = _context.MenuItems.ToList();

            return await Task.FromResult((IViewComponentResult)View("Default", model));
        }
    }
}
