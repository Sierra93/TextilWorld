using System;
using System.Collections.Generic;
using System.Text;
using TextilWorld.Models;
using TextilWorld.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace TextilWorld.Services {
    /// <summary>
    /// Сервис получает из БЖ изображения выбранной категории товаров.
    /// </summary>
    /// <returns>Список товаров выбранной категории.</returns>
    public class GetImageConcreteCategory {
        public static List<CategoryDetails> GetImagesConcrete(string id) { 
            List<CategoryDetails> categoriesDetails = new List<CategoryDetails>();
            using (var con = new SqlConnection(Connection.GetConnectionString())) {
                con.Open();
                using (var com = new SqlCommand("SELECT Id, Name, ImagePath, IdGroup, Details FROM CategoryesDetails WHERE IdGroup =" + id, con)) {
                    using (var reader = com.ExecuteReader()) {
                        if (reader.HasRows) {
                            while (reader.Read()) {
                                categoriesDetails.Add(new CategoryDetails {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Name = reader["Name"].ToString(), 
                                    ImagePath = reader["ImagePath"].ToString(),
                                    IdGroup = Convert.ToInt32(reader["IdGroup"]),
                                    Details = reader["Details"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            return categoriesDetails;
        }
    }
}
