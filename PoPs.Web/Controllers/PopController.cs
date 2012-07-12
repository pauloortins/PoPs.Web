using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PoPs.Service;
using PoPs.Web.Models;

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
            PopViewModel viewModel = new PopViewModel()
            {
                Tags = this.tagService.GetAll()
            };

            return View(viewModel);
        }
    }
}
