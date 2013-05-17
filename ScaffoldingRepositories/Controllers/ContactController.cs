using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ScaffoldingRepositories.Models;

namespace ScaffoldingRepositories.Controllers
{   
    public class ContactController : Controller
    {
		private readonly IContactRepository contactRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public ContactController() : this(new ContactRepository())
        {
        }

        public ContactController(IContactRepository contactRepository)
        {
			this.contactRepository = contactRepository;
        }

        //
        // GET: /Contact/

        public ViewResult Index()
        {
            return View(contactRepository.All);
        }

        //
        // GET: /Contact/Details/5

        public ViewResult Details(int id)
        {
            return View(contactRepository.Find(id));
        }

        //
        // GET: /Contact/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Contact/Create

        [HttpPost]
        public ActionResult Create(Contact contact)
        {
            if (ModelState.IsValid) {
                contactRepository.InsertOrUpdate(contact);
                contactRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /Contact/Edit/5
 
        public ActionResult Edit(int id)
        {
             return View(contactRepository.Find(id));
        }

        //
        // POST: /Contact/Edit/5

        [HttpPost]
        public ActionResult Edit(Contact contact)
        {
            if (ModelState.IsValid) {
                contactRepository.InsertOrUpdate(contact);
                contactRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /Contact/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(contactRepository.Find(id));
        }

        //
        // POST: /Contact/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            contactRepository.Delete(id);
            contactRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                contactRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

