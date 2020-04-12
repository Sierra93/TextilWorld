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
using WhatsAppApi;

namespace TextilWorld.Controllers {
    public class SendController : Controller {
        ApplicationDbContext db;
        public SendController(ApplicationDbContext _context) {
            db = _context;
        }

        /// <summary>
        /// Метод отправляет сообщение на WhatsApp.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> SendMessageToWhatsApp(Message message) {
            await SendMessage.SendMessageToWhatsApp(message);
            return View("SuccessOrder");
        }
    }
}