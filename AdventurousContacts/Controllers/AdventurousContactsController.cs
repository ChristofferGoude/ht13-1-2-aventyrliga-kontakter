using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdventurousContacts.Models.Datamodels;
using AdventurousContacts.Models.Repository;

namespace AdventurousContacts.Controllers
{
    public class AdventurousContactsController : Controller
    {
        private IRepository _repository;

        public AdventurousContactsController()
            :this(new Repository())
        {
            // Nothing more here
        }

        public AdventurousContactsController(IRepository repository)
        {
            _repository = repository;
        }
        //
        // GET: /AdventurousContacts/

        public ActionResult Index()
        {
            return View("Index");
        }

        //
        // GET: /AdventurousContacts/

        public ActionResult Create()
        {
            return View("Create");
        }

        //
        // GET: /AdventurousContacts/

        public ActionResult Delete()
        {
            return View("Delete");
        }

        //
        // GET: /AdventurousContacts/

        public ActionResult Edit()
        {
            return View("Edit");
        }
    }
}
