using JDRC2237A3.Data;
using JDRC2237A3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JDRC2237A3.Controllers
{
    public class PlayListController : Controller
    {
        // GET: PlayList
        private Manager manager = new Manager();
        public ActionResult Index()
        {
            return View(manager.PlaylistGetAll());
        }

        // GET: PlayList/Details/5
        public ActionResult Details(int? id)
        {
            var playlist = manager.PlaylistGetById(id.GetValueOrDefault());

            if (playlist == null)
                return HttpNotFound();
            else
            playlist.Tracks = playlist.Tracks.OrderBy(x => x.Name).ToList();
            return View(playlist);
        }

        // GET: PlayList/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlayList/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PlayList/Edit/5
        public ActionResult Edit(int id)
        {
            var playlist = manager.PlaylistGetById(id);

            if (playlist == null)
            {
                return HttpNotFound();
            }

            var availableTracks = manager.TrackGetAllWithDetail().ToList();
            var selectedTracks = playlist.Tracks.ToList();

            var viewModel = new PlaylistEditTracksFormViewModel
            {
                PlaylistId = playlist.PlaylistId,
                PlaylistName = playlist.Name,
                AllTracks = new SelectList(
                    availableTracks, 
                    "TrackId", 
                    "NameFull",
                    "IsSelected"),
                SelectedTrackIds = selectedTracks.Select(x => x.TrackId),
                CurrentTracks = selectedTracks.Select(x => new TrackBaseViewModel
                {
                    TrackId = x.TrackId,
                    Name = x.Name,
                    Composer = x.Composer,
                    Milliseconds = x.Milliseconds,
                    UnitPrice = x.UnitPrice,
                }),
                TracksCount = selectedTracks.Count
            };

            return View(viewModel);
        }

        // POST: PlayList/Edit/5
        [HttpPost]
        public ActionResult Edit(PlaylistEditTracksViewModel newItem)
        {
            return View();
            //if (!ModelState.IsValid)
            //{
            //    // Our "version 1" approach is to display the "edit form" again
            //    return RedirectToAction("edit", new { id = newItem.PlaylistId });
            //}

            //if (id.GetValueOrDefault() != newItem.PlaylistId)
            //{
            //    // This appears to be data tampering, so redirect the user away
            //    return RedirectToAction("index");
            //}

            //// Attempt to do the update
            //var editedItem = manager.PlaylistEditTracks(newItem);

            //if (editedItem == null)
            //{
            //    // There was a problem updating the object
            //    // Our "version 1" approach is to display the "edit form" again
            //    return RedirectToAction("edit", new { id = newItem.PlaylistId });
            //}
            //else
            //{
            //    // Show the details view, which will have the updated data
            //    return RedirectToAction("details", new { id = newItem.PlaylistId });
            //}
        }


        // GET: PlayList/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PlayList/Delete/5
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
