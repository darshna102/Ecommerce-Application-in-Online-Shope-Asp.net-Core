using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Data;
using OnlineShop.Models;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]

    public class ProductTypesController : Controller
    {
        private ApplicationDbContext _db;

        public ProductTypesController(ApplicationDbContext db)
        {
            _db= db;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            //var data=_db.ProductTypes.ToList());
            return View(_db.ProductTypes.ToList());
        }

        //Create a get action method
        public ActionResult Create()
        {
            return View();
        }
        //Create a post action method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Create(ProductTypes productTypes)
        {
            if (ModelState.IsValid)
            {
                _db.ProductTypes.Add(productTypes);
                await _db.SaveChangesAsync();
                TempData["save"] = "Product Type has been saved";
                return RedirectToAction(actionName:nameof(Index));

            }
            return View(productTypes);
        }

        //Edit a get action method
        public ActionResult Edit(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }
            var productType = _db.ProductTypes.Find(id);
            if(productType==null)
            {
                return NotFound();
            }
            return View(productType);
        }
        //Create a post action method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductTypes productTypes)
        {
            if (ModelState.IsValid)
            {
                _db.Update(productTypes);
                await _db.SaveChangesAsync();
                TempData["edit"] = "Product Type has been Updated";
                return RedirectToAction(actionName: nameof(Index));

            }
            return View(productTypes);
        }

        //Details a get action method
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var productType = _db.ProductTypes.Find(id);
            if (productType == null)
            {
                return NotFound();
            }
            return View(productType);
        }
        //Details a post action method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Details (ProductTypes productTypes)
        {
             
                return RedirectToAction(nameof(Index));

            
        }

        //Delete a get action method
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var productType = _db.ProductTypes.Find(id);
            if (productType == null)
            {
                return NotFound();
            }
            return View(productType);
        }
        //Delete a post action method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id,ProductTypes productTypes)
        {
            if(id==null)
            {
                return NotFound();
            }
            if(id!=productTypes.Id)
            {
                return NotFound();
            }
            var productType= _db.ProductTypes.Find(id);
            if(productType==null)
            {
                return NotFound();

            }
            if (ModelState.IsValid)
            {
                _db.Remove(productType);
                await _db.SaveChangesAsync();
                TempData["delete"] = "Product Type has been Deleted";
                return RedirectToAction(actionName: nameof(Index));

            }
            return View(productTypes);
        }
    }
}
