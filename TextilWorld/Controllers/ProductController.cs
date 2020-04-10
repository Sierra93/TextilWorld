using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TextilWorld.Models;
using TextilWorld.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using TextilWorld.Services;

namespace TextilWorld.Controllers {
    /// <summary>
    /// Контроллер описывает действия с товарами.
    /// </summary>
    public class ProductController : Controller {
        ApplicationDbContext db;        
        public ProductController(ApplicationDbContext _context) {
            db = _context;
        }

        /// <summary>
        /// Метод отображает стартовую страницу.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Start() {
            // Получает категории товаров.
            var OData = GetImageCategoriesService.FetchImageFromDB();
            return View(OData);
        }        

        /// <summary>
        /// Метод получает товары выбранной категории.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetImageConcreteCategory(string id) {
            var oData = GetImageConcreteCategoryService.GetImagesConcrete(id); 
            return View(oData);
        }

        /// <summary>
        /// Метод добавляет товар в корзину и переходит в корзину.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult AddProductToShop(int id) {
            if (id == 0) {
                var data = db.CategoryesDetails.Where(p => p.isShop == "1");
                return View(data);
            }
            var changeProduct = db.CategoryesDetails.FirstOrDefault(l => l.Id == id);
            changeProduct.isShop = "1";
            db.SaveChangesAsync();
            return View(changeProduct);
        }
    }
}