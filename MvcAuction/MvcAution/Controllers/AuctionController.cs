using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcAuction.Models;

namespace MvcAuction.Controllers
{
    //Contorller : ControllerBase, IActionFilter, IAuthenticationFilter, IAuthorizationFilter, 
    //IDisposable, IExceptionFilter, IResultFilter, IAsyncController, IController,
    //IAsyncManagerContainer
    public class AuctionController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            var auctions = default(List<Auction>);
            var db = new AuctionsDataContext();
            auctions = db.Auctions.ToList();
            return View(auctions);
        }
        public ActionResult TempDataDemo()
        {
            TempData["SucessMessage"] = "The action succeed!";

            return RedirectToAction("Index");
        }
        public ActionResult Auction(long id)
        {
            var auction = default(Auction);
            var db = new AuctionsDataContext();
            auction = db.Auctions.Find(id);

            //ViewData["Auction"] = auction;
            return View(auction);
        }
        [HttpGet]
        public ActionResult Create()
        {
            var categoryList = new SelectList(new[] { "Automotive", "Electronics", "Games", "Home" });
            ViewBag.CategoryList = categoryList;
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Exclude = "CurrentPrice")]Models.Auction auction)
        {
            //if (string.IsNullOrWhiteSpace(auction.Title))
            //{
            //    ModelState.AddModelError("Title", "Title cannot be empty");
            //}
            //else if (auction.Title.Length < 5 || auction.Title.Length > 200)
            //{
            //    ModelState.AddModelError("Title", "Title must be 5 to 200 chars");
            //}
            if (ModelState.IsValid)
            {
                // Save to database
                var db = new AuctionsDataContext();
                db.Auctions.Add(auction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return Create();
        }
        [HttpPost]
        public ActionResult Bid(Bid bid)
        {
            var auction = default(Auction);
            var db = new AuctionsDataContext();
            auction = db.Auctions.Find(bid.AuctionId);
            if (auction == null)
            {
                ModelState.AddModelError("AuctionId", "Auction Not found");
            }
            else if (auction.CurrentPrice > bid.Amount)
            {
                ModelState.AddModelError("Amount", "Bid amount must exceed current bid");
            }
            else
            {
                bid.Username = Request.LogonUserIdentity.Name;
                auction.Bids.Add(bid);
                auction.CurrentPrice = bid.Amount;
                db.SaveChanges();
            }

            if (!Request.IsAjaxRequest())
            {
                return RedirectToAction("Auction", new { id = bid.AuctionId });
            }
            //var httpStatus = ModelState.IsValid ? HttpStatusCode.OK : HttpStatusCode.BadRequest;
            //return new HttpStatusCodeResult(httpStatus);
            //return PartialView("_CurrentPrice", auction);
            return Json(new
            {
                CurrentPrice = bid.Amount.ToString("C"),
                BidCount = auction.BidCount
            });
        }
    }
}