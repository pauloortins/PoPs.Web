using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PoPs.Service;
using PoPs.Web.Models;
using PoPs.Domain;

namespace PoPs.Web.Controllers
{
    public class PopController : Controller
    {
        IPopService popService = null;
        ITagService tagService = null;

        public PopController(IPopService popServ, ITagService tagServ)
        {
            this.popService = popServ;
            this.tagService = tagServ;
        }

        public ActionResult Create()
        {
            Dictionary<int, string> tagsListItem = this.tagService.GetAll().ToList().ToDictionary(x => x.Id, x => x.Name);

            PopViewModel viewModel = new PopViewModel()
            {
                TagsListItem = tagsListItem
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(PopViewModel viewModel)
        {
            return View(viewModel);
        }
    }
}
