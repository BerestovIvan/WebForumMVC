using System;
using AutoMapper;
using BLL.Models;
using BLL.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebForumMVC.Models.PostModels;
using WebForumMVC.Models.PutModels;
using WebForumMVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using WebForumMVC.Models.QueryParam;

namespace WebForumMVC.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly ITopicService topicService;
        private readonly IArticleService articleService;
        private readonly IMapper mapper;
        public ArticlesController(IArticleService articleService, ITopicService topicService, IMapper mapper)
        {
            this.articleService = articleService;
            this.topicService = topicService;
            this.mapper = mapper;
        }
         
        public async Task<IActionResult> Index(QueryParamsViewModel paramsViewModel)
        {
            var articleModels = await articleService.Get(mapper.Map<QueryParamsModel>(paramsViewModel));
            var articleViewModels = mapper.Map<IEnumerable<ArticleViewModel>>(articleModels);
            return View(articleViewModels);
        }
        
        public async Task<IActionResult> Details(Guid id)
        {
            var article = await articleService.Get(id);

            return View(mapper.Map<ArticleViewModel>(article));
        }

        [Authorize]
        public async Task<IActionResult> Create()
        {
            var topicModels = await topicService.Get();
            var topics = mapper.Map<IEnumerable<TopicViewModel>>(topicModels);

            ViewData["TopicId"] = new SelectList(topics, "Id", "Title", topics);
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Title,Text,CreatorId, TopicId")] ArticlePostModel articlePostModel)
        {
            articlePostModel.CreatorId = HttpContext.Request.Headers["UserId"];
            if (ModelState.IsValid)
            {
                var articleModel = await articleService.Create(mapper.Map<ArticleModel>(articlePostModel));
                articlePostModel = mapper.Map<ArticlePostModel>(articleModel);
                return RedirectToAction(nameof(Index));
            }
            var topics = mapper.Map<IEnumerable<TopicViewModel>>(await topicService.Get());
            ViewData["TopicId"] = new SelectList(topics, "Id", "Title", articlePostModel.TopicId);
            return View(articlePostModel);
        }

        [Authorize]
        public async Task<IActionResult> Edit(Guid id)
        {
            var article = await articleService.Get(id);
            if (article == null)
            {
                return NotFound();
            }
            var topics = mapper.Map<IEnumerable<TopicViewModel>>(await topicService.Get());
            ViewData["TopicId"] = new SelectList(topics, "Id", "Title", article.TopicId);
            return View(mapper.Map<ArticlePutModel>(article));
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Title,Text,TopicId")] ArticlePutModel article)
        {
            if (ModelState.IsValid)
            {
                article.CreatorId = HttpContext.Request.Headers["UserId"];
                await articleService.Update(mapper.Map<ArticleModel>(article));
                return RedirectToAction(nameof(Index));
            }
            var topics = mapper.Map<IEnumerable<TopicViewModel>>(await topicService.Get());
            ViewData["TopicId"] = new SelectList(topics, "Id", "Title", article.TopicId);
            return View(article);
        }

        [Authorize]
        public async Task<IActionResult> Delete(Guid id)
        {
            var article = await articleService.Get(id);
            if (article == null)
            {
                return NotFound();
            }

            return View(mapper.Map<ArticleViewModel>(article));
        }

        [Authorize]
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await articleService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}