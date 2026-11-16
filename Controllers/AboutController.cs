using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;
using MyPortfolioUdemy.DAL.Entities;

namespace MyPortfolioUdemy.Controllers
{
    public class AboutController : Controller
    {
        MyPortfolioContext context = new MyPortfolioContext();

        [HttpGet]
        public IActionResult Index()
        {
            var value = context.Abouts.FirstOrDefault() ?? new About();
            return View(value);
        }

        [HttpPost]
        public IActionResult Index(About about)
        {
            if (about.AboutId == 0)
                context.Abouts.Add(about);
            else
                context.Abouts.Update(about);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}