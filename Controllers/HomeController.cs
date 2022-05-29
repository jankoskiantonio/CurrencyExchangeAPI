using CurrencyExchangeAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CurrencyExchangeAPI.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        private readonly StaticFileService _staticFileService;

        public HomeController(StaticFileService staticFileService)
        {
            _staticFileService = staticFileService;
        }
        [Route("/")]
        public async Task Index()
        {
            HttpContext.Response.StatusCode = 200;
            HttpContext.Response.ContentType = "text/html";
            await using var file = await _staticFileService.GetFile("index.html");
            await file.CopyToAsync(HttpContext.Response.Body);
            await HttpContext.Response.Body.FlushAsync();
        }
    }
}
