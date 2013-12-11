using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdventurousContacts.Models;
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

        // GET: /AdventurousContacts/

        public ActionResult Index()
        {
            return View("Index", _repository.GetLastContacts());
        }

        // GET: /AdventurousContacts/

        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: /AdventurousContacts/

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Exclude="ContactID")]Contact contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _repository.Add(contact);
                    _repository.Save();

                    return View("Success");
                }
                catch(Exception e)
                {
                    string error = "Ett fel inträffade vid skapandet av kontakt Meddelande: " + e.Message;
                    ModelState.AddModelError(String.Empty, error);
                }
            }
            return View("Create");
        }

        // GET: /AdventurousContacts/

        public ActionResult Delete(int id = 0)
        {
            var contact = _repository.GetContactById(id);

            return View("Delete", contact);
        }

        // POST: /AdventurousContacts/

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteFinished(Contact contact)
        {
            try
            {
                _repository.DeleteContact(contact.ContactID);
                _repository.Save();

                return View("Success");
            }
            catch (Exception e)
            {
                string error = "Ett fel inträffade vid borttagningen av kontakt! Meddelande: " + e.Message;
                ModelState.AddModelError(String.Empty, error);
            }
            return View("Delete", contact.ContactID);
        }

        // GET: /AdventurousContacts/

        public ActionResult Edit(int id = 0)
        {
            var contact = _repository.GetContactById(id);

            return View("Edit", contact);
        }

        // POST: /AdventurousContacts/

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _repository.Update(contact);
                    _repository.Save();

                    return View("Success");
                }
                catch (Exception e)
                {
                    string error = "Ett fel inträffade vid uppdateringen! Meddelande: " + e.Message;
                    ModelState.AddModelError(String.Empty, error);
                }
            }
            return View("Edit", contact.ContactID);
        }
    }
}
