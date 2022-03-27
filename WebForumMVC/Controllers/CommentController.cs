using AutoMapper;
using BLL.Models;
using BLL.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebForumMVC.Models.PostModels;
using WebForumMVC.Models.PutModels;
using WebForumMVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService commentService;
        private readonly IMapper mapper;

        public CommentController(ICommentService commentService, IMapper mapper)
        {
            this.commentService = commentService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommentViewModel>>> Get()
        {
            var commentViewModel = await commentService.Get();
            return Ok(mapper.Map<IEnumerable<CommentViewModel>>(commentViewModel));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<CommentViewModel>>> Get(Guid id)
        {
            var commentViewModel = await commentService.Get(id);
            return Ok(mapper.Map<CommentViewModel>(commentViewModel));
        }

        [HttpPost("Create")]
        public async Task<ActionResult<CommentPostModel>> Create([FromBody] CommentPostModel commentPostModel)
        {
            var comment = mapper.Map<CommentModel>(commentPostModel);
            comment = await commentService.Create(comment);
            commentPostModel = mapper.Map<CommentPostModel>(comment);
            return Created("~/api/comment/" + commentPostModel.Id, commentPostModel);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await commentService.Delete(id);
            return Ok();
        }

        [HttpPut("Update")]
        public async Task<ActionResult<CommentPutModel>> Update([FromBody] CommentPutModel commentPutModel)
        {
            var comment = mapper.Map<CommentModel>(commentPutModel);
            comment = await commentService.Update(comment);
            commentPutModel = mapper.Map<CommentPutModel>(comment);
            return Ok(commentPutModel);

        }
    }
}
