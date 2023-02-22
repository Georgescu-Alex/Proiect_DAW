using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProiectDAW.ContextModels;
using ProiectDAW.Models;

namespace ProiectDAW.Controllers
{
    public class ArticlesController : Controller
    {
        ArticlesContext _articlesContext { get; set; }

        public ArticlesController(ArticlesContext articlesContext)
        {
            _articlesContext = articlesContext;
        }

        public IActionResult Index()
        {
            var articles = _articlesContext.Article.Include(articles=> articles.Category).ToArray();
            return View("Articles", articles);
        }
        public IActionResult ShowViewArticle(int Id)
        {
            ViewBag.category = _articlesContext.Category.Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.Name
            }).ToList();
            var article = _articlesContext.Article.Include(article => article.Category).FirstOrDefault(x => x.Id == Id);
            return View("ViewArticle", article);
        }

        public IActionResult ViewArticle()
        {
            return View();
        }

        public IActionResult ShowAddArticle()
        {
            ViewBag.category = _articlesContext.Category.Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.Name
            }).ToList();
            return View("AddArticle");
        }

        [HttpPost]
        public IActionResult AddArticle(Article article)
        {
            _articlesContext.Add(article);
            _articlesContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult ShowEditArticle(int Id)
        {
            ViewBag.category = _articlesContext.Category.Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.Name
            }).ToList();
            var article = _articlesContext.Article.Include(article => article.Category).FirstOrDefault(x => x.Id == Id);
            return View("EditArticle", article);
        }

        public IActionResult EditArticle(Article article)
        {
            _articlesContext.Update(article);
            _articlesContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteArticle(int Id)
        {
            var article = _articlesContext.Article.Include(article=>article.Category).FirstOrDefault(a => a.Id == Id);
            _articlesContext.Remove(article);
            _articlesContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Search(string title)
        {
            var articles = _articlesContext.Article.Include(articles => articles.Category).Where(x => x.Title.Contains(title)).ToArray();
            return View("Articles", articles);
        }
    }
}
