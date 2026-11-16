using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;
using MyPortfolioUdemy.DAL.Entities;

namespace MyPortfolioUdemy.Controllers
{
    public class FeatureController : Controller
    {
        MyPortfolioContext context = new MyPortfolioContext();

        [HttpGet]
        public IActionResult Index()
        {
            var value = context.Features.FirstOrDefault() ?? new Feature();
            return View(value);
        }

        [HttpPost]
        public IActionResult Index(Feature feature)
        {
            if (feature.FeatureId == 0)
                context.Features.Add(feature);
            else
                context.Features.Update(feature);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
