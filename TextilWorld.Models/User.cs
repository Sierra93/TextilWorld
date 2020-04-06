using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TextilWorld.Models;

namespace TextilWorld.Models {
    /// <summary>
    /// Модель описывает пользователя.
    /// </summary>
    public class User {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Не указан логин.")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Не указан пароль.")]
        public string Password { get; set; }
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес.")]
        public string Email { get; set; }
        public List<MultepleContextTable> MultepleContextTables { get; set; }
        public User() {
            MultepleContextTables = new List<MultepleContextTable>();
        }
    }
}
