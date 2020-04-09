using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using TextilWorld.Models;
using TextilWorld.Core;

namespace TextilWorld.Services {
    /// <summary>
    /// Сервис получает категории изображений из БД.
    /// </summary>
    public class GetImageCategories {
        /// <summary>
        /// Метод получает список категорий товаров.
        /// </summary>
        /// <returns>Список категорий.</returns>
        public static List<Category> FetchImageFromDB() {
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
