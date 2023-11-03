using JDRC2237A3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JDRC2237A3.Controllers
{
    public class TrackController : Controller
    {
        // GET: Track
        private Manager manager = new Manager();
        public ActionResult Index()
        {
            return View(manager.TrackGetAllWithDetail());
        }

        // GET: Track/Details/5
        public ActionResult Details(int? id)
        {
            var tracks = manager.TrackGetById(id.GetValueOrDefault());

            if (tracks == null)
                return HttpNotFound();
            else
                return View(tracks);
        }

        // GET: Track/Create

        public ActionResult Create()
        {
            var form = new TrackAddFormViewModel();

            var selected = 156;
            List<AlbumBaseViewModel> albums = manager.AlbumGetAll().ToList();
            form.AlbumList = new SelectList(
                items: albums,
                dataValueField: "AlbumId",
                dataTextField: "Title",
                selectedValue: selected
                );
            List<MediaTypeBaseViewModel> mediaTypes = manager.MediaTypeGetAll().ToList();
            form.MediaTypeList = new SelectList(
                items: mediaTypes,
                dataValueField: "MediaTypeId",
                dataTextField: "Name",
                selectedValue: selected
                );

            return View(form);
        }

        //POST: Track/Create
       [HttpPost]
        public ActionResult Create(TrackAddViewModel newTrack)
        {
            if (!ModelState.IsValid)
            {
                return View(newTrack);
            }
            try
            {
                var addedItem = manager.TrackAdd(newTrack);

                if (addedItem == null)
                {
                    return View(newTrack);
                }
                else
                {
                    return RedirectToAction("Details", new { id = addedItem.TrackId });
                }
            }
            catch
            {
                return View(newTrack);
            }
        }

        // GET: Track/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Track/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Track/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Track/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
