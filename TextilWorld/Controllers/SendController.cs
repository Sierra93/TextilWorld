using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TextilWorld.Models;
using TextilWorld.Services;
using TextilWorld.Data;
using MimeKit;
using System.Net.Mail;

namespace TextilWorld.Controllers {
    /// <summary>
    /// Контроллер для отправлений сообщений.
    /// </summary>
    public class SendController : Controller {
        ApplicationDbContext db;
        public SendController(ApplicationDbContext _context) {
            db = _context;
        }

        /// <summary>
        /// Метод отправляет сообщение на почту.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> SendEmailMessage(Message message) { 
            await SendMessageService.SendMessage(message);
            return View("SuccessOrder");
        }
    }
}