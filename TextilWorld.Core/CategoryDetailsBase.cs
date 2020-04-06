using System;
using System.Collections.Generic;
using System.Text;
using TextilWorld.Models;

namespace TextilWorld.Core {
    /// <summary>
    /// Абстрактный класс описывающий детальные описания категорий товаров.
    /// </summary>
    public abstract class CategoryDetailsBase {
        public int Id { get; protected set; }
        public string Title { get; protected set; } // Заголовок категории товара.
        public int CategoryNumber { get; protected set; }   // Номер категории товара.
        public string ImagePath { get; protected set; } // Путь к изображению.

        /// <summary>
        /// Метод выводит детальные категории товаров.
        /// </summary>
        /// <param name="idCategory"></param>
        /// <returns>Список определенной категории.</returns>
        public abstract string DisplayConcreteDetailsCategory(int idCategory);  
    }
}
