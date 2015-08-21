namespace Service.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;

    using global::Models;

    using Microsoft.AspNet.Identity;

    public class PurchaseController : BaseController
    {
        [HttpPut]
        [Route("api/books/buy/{id}")]
        [Authorize]
        public IHttpActionResult CreatePurchase(int id)
        {
            var userId = this.User.Identity.GetUserId();

            var book = this.Data.Books.Read().FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                return this.NotFound();
            }

            if (book.Copies == 0)
            {
                return this.BadRequest("There are no copies left.");
            }

            var purchase = new Purchase
                               {
                                   UserId = userId, 
                                   Book = book, 
                                   Price = book.Price, 
                                   DateOfPurchase = DateTime.Now, 
                                   IsRecalled = false
                               };

            this.Data.Purchases.Create(purchase);
            book.Copies--;
            this.Data.SaveChanges();

            return this.Ok("Your purchase number is: " + purchase.Id);
        }

        [HttpPut]
        [Route("api/books/recall/{id}")]
        [Authorize]
        public IHttpActionResult GetRacallBook(int id)
        {
            var purchase = this.Data.Purchases.Read().FirstOrDefault(p => p.Id == id);

            if (purchase == null)
            {
                return this.NotFound();
            }

            if (purchase.DateOfPurchase.AddDays(30) > DateTime.Now)
            {
                return this.BadRequest("Return fail because more than 30 days have passed since the purchase.");
            }

            purchase.Book.Copies++;
            purchase.IsRecalled = true;
            this.Data.SaveChanges();

            return this.Ok();
        }

        [HttpGet]
        [Route("api/users/{username}/purchase")]
        public IHttpActionResult GetPurchasesByUsername(string username)
        {
            var purchasesView = this.Data.Purchases.Read()
                .Where(u => u.User.UserName == username)
                .OrderBy(p => p.DateOfPurchase)
                .Select(p => new
                                 {
                                     Username = username, 
                                     Purchase = new
                                                    {
                                                        BookTitle = p.Book.Title, 
                                                        PurchasePrice = p.Book.Price, 
                                                        DateOfPurchase = p.DateOfPurchase, 
                                                        IsRacalled = p.IsRecalled
                                                    }
                                 });

            return this.Ok(purchasesView);
        }
    }
}