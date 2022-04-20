using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Truck.Application.Interfaces;
using Truck.CrossCuting.Enum;

namespace Truck.Web.UI.Controllers
{
    public class TruckController : Controller
    {
        private readonly ITruckService _truckService;
        private readonly int pageSize = 10;

        public TruckController(ITruckService truckService)
        {
            _truckService = truckService;
        }

        #region Index and Search

        [HttpGet]
        public IActionResult Index()
        {

            ViewBag.StatusRecord = TempData["StatusRecord"];
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Get(int? pageNumber = 1)
        {
            var list = await _truckService.Get();

            ViewBag.totalPages = Math.Ceiling((decimal)list.Count() / pageSize);
            ViewBag.page = pageNumber ?? 1;
            ViewBag.countRowns = list.Count();
            int skip = pageSize * (pageNumber.Value - 1);

            list = list.Skip(skip).Take(pageSize);

            return PartialView("_List", list);
        }

        #endregion

        #region Create

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await DdlModelsAsync();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Domain.Models.Truck obj)
        {
            if (ModelState.IsValid)
            {
                var (status, description) = await _truckService.Create(obj);
                if (status == Return.added)
                {
                    TempData["StatusRecord"] = Return.added;
                    return RedirectToAction("Index");
                }
                else
                {
                    await DdlModelsAsync();

                    ViewBag.error = description;
                    return View(obj);
                }                
            }
            return View();
        }

        #endregion

        #region Edit

        public async Task<IActionResult> Edit(int id)
        {
            var obj = await _truckService.Get(id);
            if (obj == null)
            {
                return NotFound();
            }

            await DdlModelsAsync();

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Domain.Models.Truck obj)
        {

            if (ModelState.IsValid)
            {
                var (status, description) = await _truckService.Update(obj);

                if (status == Return.changed)
                {
                    TempData["StatusRecord"] = Return.changed;
                    return RedirectToAction("Index");
                }
                else
                {
                    await DdlModelsAsync();

                    ViewBag.error = description;
                    return View(obj);
                }
            }
            return View();
        }

        #endregion

        #region Delete

        public async Task<IActionResult> Delete(int id)
        {
            var obj = await _truckService.Get(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int id)
        {

            var (status, description) = await _truckService.Remove(id);

            if (status == Return.deleted)
            {
                TempData["StatusRecord"] = Return.deleted;
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.error = description;
                return View();
            }
        }

        #endregion

        #region Outers

        public async Task DdlModelsAsync()
        {
            IModelTruckService modelServ = (IModelTruckService)HttpContext.RequestServices.GetService(typeof(IModelTruckService));
            var list = (await modelServ.Get()).ToList();

            var itemList = new SelectList(list, "IdModel", "Model");
            ViewBag.itemList = itemList;
        }

        #endregion
    }
}
