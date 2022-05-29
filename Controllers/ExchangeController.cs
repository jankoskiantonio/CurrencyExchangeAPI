using CurrencyExchangeAPI.Models;
using CurrencyExchangeAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CurrencyExchangeAPI.Controllers
{
    [Route("exchange")]
    public class ExchangeController : Controller
    {
        private readonly AppDbContext _context;

        public ExchangeController(AppDbContext context)
        {
            _context = context;
        }
        [Route("get")]
        public IActionResult Get()
        {
            return Json(_context.Currencies);
        }
    }
}
