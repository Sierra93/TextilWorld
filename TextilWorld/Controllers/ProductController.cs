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
        /// Метод добавляет товар в корзину.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult AddProductToShop(int id) {
            CategoryDetails addShop = new CategoryDetails();
            // Если нажали перейти в корзину, то никакого id не имеем, а просто происходит переход в корзину.
            if (id == 0) {
                var data = db.CategoryesDetails.Where(p => p.isShop == "1").ToList();
                return View(data);
            }

            // Добавляет товар в корзину.
            var changeProduct = db.CategoryesDetails.Where(p => p.Id == id).ToList();
            changeProduct[0].isShop = "1";
            addShop.isShop = changeProduct[0].isShop;
            db.SaveChanges();
            return View(changeProduct);
        }

        /// <summary>
        /// Метод выводит конкретный товар на страницу описания.
        /// </summary>
        /// <returns>Конкретный товар.</returns>
        public IActionResult DisplayConcreateProduct(int id) {
            var concreteProduct = db.CategoryesDetails.Where(p => p.Id == id).ToList();
            return View(concreteProduct);
        }

        /// <summary>
        /// Метод ищет товар, который ввели в поле поиска.
        /// </summary>
        /// <returns>Список найденных товаров.</returns>
        public IActionResult SearchIn(string search) {
            var collectionSearch = db.CategoryesDetails.Where(p => p.Details.Contains(search)).ToList();
            return View(collectionSearch);
        }
    }
}