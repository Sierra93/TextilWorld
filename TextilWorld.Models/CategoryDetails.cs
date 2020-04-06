using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TextilWorld.Models {
    /// <summary>
    /// Модель описывает детальную информацию о товаре категории.
    /// </summary>
    public class CategoryDetails {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }   // Название товара.
        public string ImagePath { get; set; }   // Путь к изображению.
        public int IdGroup { get; set; }    // Номер группы.
        public string Details { get; set; } // Детальное описание товара.
        public List<MultepleContextTable> MultepleContextTables { get; set; }
        public CategoryDetails() { 
            MultepleContextTables = new List<MultepleContextTable>();
        }
    }
}
