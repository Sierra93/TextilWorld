using System;
using System.Collections.Generic;
using System.Text;
using TextilWorld.Models;

namespace TextilWorld.Models {
    /// <summary>
    /// Класс описывает связи между таблицами.
    /// </summary>
    public class MultepleContextTable {
        public int UserId { get; set; } 
        public User User { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int CategoryDetailsId { get; set; }
        public CategoryDetails CategoryesDetails { get; set; }
    }
}
