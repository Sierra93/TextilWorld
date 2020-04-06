﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TextilWorld.Models;

namespace TextilWorld.Core {
    /// <summary>
    /// Абстрактный класс описывающий категории продуктов.
    /// </summary>
    public abstract class CategoryProductBase {
        public int Id { get; protected set; }
        public string Title { get; protected set; } // Заголовок категории товара.
        public int CategoryNumber { get; protected set; }   // Номер категории товара.
        public string ImagePath { get; protected set; } // Путь к изображению.

        /// <summary>
        /// Метод выводит список категорий товаров.
        /// </summary>
        /// <param name="idCategory"></param>
        /// <returns>Список категорий товаров.</returns>
        public abstract Task<string> DisplayCategories(int idCategory);
    }
}
