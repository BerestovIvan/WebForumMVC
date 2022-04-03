using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BLL.ServiceInterfaces;
using AutoMapper;
using WebForumMVC.Models.ViewModels;
using WebForumMVC.Models.PostModels;
using BLL.Models;

namespace WebForumMVC.Controllers
{
    public class CommentsController : Controller
    {
        private readonly ICommentService commentService;
        private readonly IMapper mapper;

        public CommentsController(ICommentService commentService, IMapper mapper)
        {
            this.commentService = commentService;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var comments = await commentService.Get();
            return View(mapper.Map<CommentViewModel>(comments));
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var comment = await commentService.Get(id);

            if (comment == null)
            {
                return NotFound();
            }

            return View(mapper.Map<CommentViewModel>(comment));
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Text,ArticleId")] CommentPostModel comment)
        {
            comment.ApplicationUserId = HttpContext.Request.Headers["UserId"];
            if (ModelState.IsValid)
            {
                await commentService.Create(mapper.Map<CommentModel>(comment));
                return RedirectToAction("Details", "Articles", new ArticleViewModel {Id = comment.ArticleId });
            }
            return Redirect("~/Shared/Error");
        }

        //// GET: Comments/Edit/5
        //public async Task<IActionResult> Edit(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var comment = await _context.Comments.FindAsync(id);
        //    if (comment == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id", comment.ApplicationUserId);
        //    ViewData["ArticleId"] = new SelectList(_context.Articles, "Id", "CreatorId", comment.ArticleId);
        //    return View(comment);
        //}

        //// POST: Comments/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(Guid id, [Bind("Id,Text,ApplicationUserId,ArticleId")] Comment comment)
        //{
        //    if (id != comment.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(comment);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!CommentExists(comment.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id", comment.ApplicationUserId);
        //    ViewData["ArticleId"] = new SelectList(_context.Articles, "Id", "CreatorId", comment.ArticleId);
        //    return View(comment);
        //}

        //// GET: Comments/Delete/5
        //public async Task<IActionResult> Delete(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var comment = await _context.Comments
        //        .Include(c => c.ApplicationUser)
        //        .Include(c => c.Article)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (comment == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(comment);
        //}

        //// POST: Comments/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(Guid id)
        //{
        //    var comment = await _context.Comments.FindAsync(id);
        //    _context.Comments.Remove(comment);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool CommentExists(Guid id)
        //{
        //    return _context.Comments.Any(e => e.Id == id);
        //}
    }
}
