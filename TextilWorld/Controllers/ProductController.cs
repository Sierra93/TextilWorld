using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TextilWorld.Models;
using TextilWorld.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

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
            var data = FetchImageFromDB();
            return View(data);
        }

        /// <summary>
        /// Метод получает список категорий товаров.
        /// </summary>
        /// <returns>Список категорий.</returns>
        private List<Category> FetchImageFromDB() {
            List<Category> categories = new List<Category>();
            using (var con = new SqlConnection(Connection.GetConnectionString())) {
                con.Open();
                using (var com = new SqlCommand("SELECT Id, Title, ImagePath, IdGroup FROM Categoryes", con)) {
                    using (var reader = com.ExecuteReader()) {
                        if (reader.HasRows) {
                            while (reader.Read()) {
                                categories.Add(new Category {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Title = reader["Title"].ToString(),
                                    ImagePath = reader["ImagePath"].ToString(),
                                    IdGroup = Convert.ToInt32(reader["IdGroup"])
                                });
                            }
                        }
                    }
                }
            }
            return categories;
        }
    }
}