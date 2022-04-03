using AutoMapper;
using BLL.Models;
using BLL.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using WebForumMVC.Models.PostModels;
using WebForumMVC.Models.PutModels;
using WebForumMVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace WebForumMVC.Controllers
{
    public class TopicsController : Controller
    {
        private readonly ITopicService topicService;
        private readonly IMapper mapper;

        public TopicsController(ITopicService topicService, IMapper mapper)
        {
            this.topicService = topicService;
            this.mapper = mapper;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(mapper.Map<IEnumerable<TopicViewModel>>(await topicService.Get()));
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(Guid id)
        {
            var topic = await topicService.Get(id);

            if (topic == null)
            {
                return NotFound();
            }

            return View(mapper.Map<TopicViewModel>(topic));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TopicPostModel topic)
        {
            if (ModelState.IsValid)
            {
                topic.Id = Guid.NewGuid();
                await topicService.Create(mapper.Map<TopicModel>(topic));
                return RedirectToAction(nameof(Index));
            }
            return View(topic);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var topic = await topicService.Get(id);
            if (topic == null)
            {
                return NotFound();
            }
            return View(mapper.Map<TopicPutModel>(topic));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Title")] TopicPutModel topic)
        {
            if (id != topic.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                await topicService.Update(mapper.Map<TopicModel>(topic));

                return RedirectToAction(nameof(Index));
            }
            return View(topic);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var topic = await topicService.Get(id);
            if (topic == null)
            {
                return NotFound();
            }

            return View(topic);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var topic = await topicService.Get(id);
            if(topic == null)
            {
                return NotFound();
            }
            await topicService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}