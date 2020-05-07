using System.Threading.Tasks;
using AutoLotDAL_Core2.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace AutoLotMVC_Core2.ViewComponents
{
    public class InventoryViewComponent : ViewComponent
    {
        private readonly IInventoryRepo repo;

        public InventoryViewComponent(IInventoryRepo repo)
        {
            this.repo = repo;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var cars = this.repo.GetAll(x => x.Make, true);
            if (cars != null)
            {
                return View("InventoryPartialView", cars);
            }
            return new ContentViewComponentResult("Unable to locate records.");
        }
    }
}