using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TextilWorld.Models {
    /// <summary>
    /// Модель описывает категорию товаров.
    /// </summary>
    public class Category {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }   // Заголовок категории.
        public string ImagePath { get; set; }   // Путь к изображению.
        public int IdGroup { get; set; }    // Номер группы.
        public List<MultepleContextTable> MultepleContextTables { get; set; }
        public Category() { 
            MultepleContextTables = new List<MultepleContextTable>();
        }
    }
}
