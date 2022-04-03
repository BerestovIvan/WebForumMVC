using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.DbContext;
using DAL.Entity;
using BLL.Models;
using WebForumMVC.Models.PutModels;
using BLL.ServiceInterfaces;
using AutoMapper;

namespace WebForumMVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(UserPutModel userPutModel)
        {
            userPutModel.Id = Request.Headers["UserId"];
            await userService.ChangePassword(mapper.Map<UserModel>(userPutModel));
            return RedirectToAction("Index", "User");
        }

        // GET: User/Details/5
        //public async Task<IActionResult> Details(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var article = await _context.Articles
        //        .Include(a => a.Creator)
        //        .Include(a => a.Topic)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (article == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(article);
        //}

        //// GET: User/Create
        //public IActionResult Create()
        //{
        //    ViewData["CreatorId"] = new SelectList(_context.Users, "Id", "Id");
        //    ViewData["TopicId"] = new SelectList(_context.Topics, "Id", "Title");
        //    return View();
        //}

        //// POST: User/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Title,Text,CreatorId,TopicId")] Article article)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        article.Id = Guid.NewGuid();
        //        _context.Add(article);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["CreatorId"] = new SelectList(_context.Users, "Id", "Id", article.CreatorId);
        //    ViewData["TopicId"] = new SelectList(_context.Topics, "Id", "Title", article.TopicId);
        //    return View(article);
        //}

        //// GET: User/Edit/5
        //public async Task<IActionResult> Edit(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var article = await _context.Articles.FindAsync(id);
        //    if (article == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["CreatorId"] = new SelectList(_context.Users, "Id", "Id", article.CreatorId);
        //    ViewData["TopicId"] = new SelectList(_context.Topics, "Id", "Title", article.TopicId);
        //    return View(article);
        //}

        //// POST: User/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(Guid id, [Bind("Id,Title,Text,CreatorId,TopicId")] Article article)
        //{
        //    if (id != article.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(article);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ArticleExists(article.Id))
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
        //    ViewData["CreatorId"] = new SelectList(_context.Users, "Id", "Id", article.CreatorId);
        //    ViewData["TopicId"] = new SelectList(_context.Topics, "Id", "Title", article.TopicId);
        //    return View(article);
        //}

        //// GET: User/Delete/5
        //public async Task<IActionResult> Delete(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var article = await _context.Articles
        //        .Include(a => a.Creator)
        //        .Include(a => a.Topic)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (article == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(article);
        //}

        //// POST: User/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(Guid id)
        //{
        //    var article = await _context.Articles.FindAsync(id);
        //    _context.Articles.Remove(article);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool ArticleExists(Guid id)
        //{
        //    return _context.Articles.Any(e => e.Id == id);
        //}
    }
}
