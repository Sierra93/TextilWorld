using System;
using System.Collections.Generic;
using System.Text;
using TextilWorld.Models;

namespace TextilWorld.Core {
    /// <summary>
    /// Класс абстрактной фабрики описывающий продукт.
    /// </summary>
    public abstract class ProductBase {
        public int ProductId { get; protected set; }
        public string TitleCategory { get; protected set; } // Заголовок категории товара.
        public int NumberCategory { get; protected set; }   // Номер категории товара.
        public string ImagePath { get; protected set; } // Путь к изображению товара.

        /// <summary>
        /// Метод выводит категории товаров.
        /// </summary>
        /// <returns>Список категорий.</returns>
        public abstract CategoryProductBase DisplayProductCategory(int categoryId);

        public abstract CategoryDetailsBase DisplayConcreteCategoryDetails(int categoryId); 
    }
}
