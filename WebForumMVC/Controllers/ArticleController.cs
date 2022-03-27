using AutoMapper;
using BLL.Models;
using BLL.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebForumMVC.Models.PostModels;
using WebForumMVC.Models.PutModels;
using WebForumMVC.Models.ViewModels;

namespace WebForumMVC.Controllers
{
    [Route("[controller]")]
    public class ArticleController : Controller
    {
        private readonly IArticleService articleService;
        private readonly IMapper mapper;

        public ArticleController(IArticleService articleService, IMapper mapper)
        {
            this.articleService = articleService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArticleViewModel>>> Get()
        {
            var articleViewModels = await articleService.Get();
            return Ok(mapper.Map<IEnumerable<ArticleViewModel>>(articleViewModels));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ArticleViewModel>>> Get(Guid id)
        {
            var articleViewModels = await articleService.Get(id);
            return Ok(mapper.Map<ArticleViewModel>(articleViewModels));
        }

        [HttpPost("Create")]
        public async Task<ActionResult<ArticlePostModel>> Create([FromBody] ArticlePostModel articlePostModel)
        {
            var article = mapper.Map<ArticleModel>(articlePostModel);
            article = await articleService.Create(article);
            articlePostModel = mapper.Map<ArticlePostModel>(article);
            return Created("~/api/article/" + articlePostModel.Id, articlePostModel);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await articleService.Delete(id);
            return Ok();
        }

        [HttpPut("Update")]
        public async Task<ActionResult<ArticlePutModel>> Update([FromBody] ArticlePutModel articlePutModel)
        {
            var article = mapper.Map<ArticleModel>(articlePutModel);
            article = await articleService.Update(article);
            articlePutModel = mapper.Map<ArticlePutModel>(article);
            return Ok(articlePutModel);

        }
    }
}
