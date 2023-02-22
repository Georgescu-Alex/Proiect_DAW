using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProiectDAW.ContextModels;

namespace ProiectDAW.Controllers
{
    public class CategoryController : Controller
    {
        ArticlesContext _articlesContext { get; set; }

        public CategoryController(ArticlesContext articlesContext)
        {
            _articlesContext = articlesContext;
        }
        public IActionResult Arta()
        {
            var articles = _articlesContext.Article.Include(articles => articles.Category).ToArray();
            return View("ViewArta", articles);
        }
        public IActionResult Fizica()
        {
            var articles = _articlesContext.Article.Include(articles => articles.Category).ToArray();
            return View("ViewFizica", articles);
        }
        public IActionResult Geografie()
        {
            var articles = _articlesContext.Article.Include(articles => articles.Category).ToArray();
            return View("ViewGeografie", articles);
        }
        public IActionResult Istorie()
        {
            var articles = _articlesContext.Article.Include(articles => articles.Category).ToArray();
            return View("ViewIstorie", articles);
        }
        public IActionResult Matematica()
        {
            var articles = _articlesContext.Article.Include(articles => articles.Category).ToArray();
            return View("ViewMatematica", articles);
        }
        public IActionResult Programare()
        {
            var articles = _articlesContext.Article.Include(articles => articles.Category).ToArray();
            return View("ViewProgramare", articles);
        }
    }
}
