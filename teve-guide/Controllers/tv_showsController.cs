﻿using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.ServiceModel.Channels;
using System.Web.Mvc;
using teve_guide.Models.db;
using System;
using System.Web;
using teve_guide.Models;
using teve_guide.Security;

namespace teve_guide.Controllers
{
    public class tv_showsController : Controller
    {
    private TeveGuideEntities db = new TeveGuideEntities();

   
    // GET: tv_shows
    public ActionResult Index()
        {
            return View(db.tv_shows.ToList());
        }

        //Get current Tv-table
        public ActionResult CurrentTvTable(string channel)
        {
            var currentChannel = from c in db.tv_shows
                                 where c.Channel.Contains(channel)
                                 select c;

            return View(currentChannel.ToList());
        }

        public ActionResult TomorrowTvTable(string channel)
        {
            var currentChannel = from c in db.tv_shows
                                 orderby c.Starttime
                                 where c.Channel.Contains(channel)
                                 select c;

            return View(currentChannel);
           
        }

        public ActionResult InTwoDaysTvTable(string channel)
        {
            var currentChannel = from c in db.tv_shows
                                 where c.Channel.Contains(channel)
                                 select c;

            return View(currentChannel.ToList());
        }

        public ActionResult InThreeDaysTvTable(string channel)
        {
            var currentChannel = from c in db.tv_shows
                                 where c.Channel.Contains(channel)
                                 select c;

            return View(currentChannel.ToList());
        }

        public ActionResult InFourDaysTvTable(string channel)
        {
            var currentChannel = from c in db.tv_shows
                                 where c.Channel.Contains(channel)
                                 select c;

            return View(currentChannel.ToList());
        }

        public ActionResult InFiveDaysTvTable(string channel)
        {
            var currentChannel = from c in db.tv_shows
                                 where c.Channel.Contains(channel)
                                 select c;

            return View(currentChannel.ToList());
        }

        public ActionResult InSixDaysTvTable(string channel)
        {
            var currentChannel = from c in db.tv_shows
                                 where c.Channel.Contains(channel)
                                 select c;

            return View(currentChannel.ToList());
        }

        // GET: tv_shows/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tv_shows tv_shows = db.tv_shows.Find(id);
            if (tv_shows == null)
            {
                return HttpNotFound();
            }
            return View(tv_shows);
        }


        [Authorize]

        public ActionResult MyPage(string channel)
        {
            ViewBag.Channel = (from c in db.tv_shows select c.Channel).Distinct();

            var model = from c in db.tv_shows
                        orderby c.Channel
                        where c.Channel == channel || channel == null || channel == ""
                        select c;
            return View(model);
        
        }

        public ActionResult MyPageView(FormCollection collection)
        {
            try
            {
                ViewBag.TvChannels = collection["channel"];
            }
            catch 
            {
                ViewBag.Message = "Det blev en catch...";
            }
            return View();
        }

        [HttpPost]
        public ActionResult ShowTvshow(TvShow model)
        {
            return View();
        }

        // GET: tv_shows/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tv_shows/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Starttime,Endtime,Substance,Category,Channel")] tv_shows tv_shows)
        {
            if (ModelState.IsValid)
            {

                db.tv_shows.Add(tv_shows);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tv_shows);
        }

        // GET: tv_shows/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tv_shows tv_shows = db.tv_shows.Find(id);
            if (tv_shows == null)
            {
                return HttpNotFound();
            }
            return View(tv_shows);
        }

        // POST: tv_shows/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Starttime,Endtime,Substance,Category,Channel")] tv_shows tv_shows)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tv_shows).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tv_shows);
        }

        // GET: tv_shows/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tv_shows tv_shows = db.tv_shows.Find(id);
            if (tv_shows == null)
            {
                return HttpNotFound();
            }
            return View(tv_shows);
        }

        // POST: tv_shows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tv_shows tv_shows = db.tv_shows.Find(id);
            db.tv_shows.Remove(tv_shows);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        [AuthorizeRoles("Admin")]

        public ActionResult AdminPage()
        {
            ViewBag.Message = "Endast administratörer.";
            //return View();
            return View(db.tv_shows.ToList());

        }

        [HttpPost]
        public ActionResult SetPuffId(int id)
        {
            ViewBag.Puff1 = id;
            return RedirectToAction("Index");
        }

    }
}
