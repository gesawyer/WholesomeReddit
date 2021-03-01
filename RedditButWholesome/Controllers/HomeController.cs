using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RedditButWholesome.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using static RedditButWholesome.Models.Post;

namespace RedditButWholesome.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private RedditDAL rd = new RedditDAL();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            PostRoot pr = new PostRoot();
            PostData basePath = pr.data.children[0].data;
            string title = basePath.title;
            string image = basePath.thumbnail;
            string url = "reddit.com" + basePath.permalink;

            RedditTrimmedModel rtm = new RedditTrimmedModel();
            rtm.Title = title;
            rtm.ImageUrl = image;
            rtm.LinkUrl = url;
            return View(rtm);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
