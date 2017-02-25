namespace OnlineShop.Service.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using OnlineShop.Data;
    using OnlineShop.Models;
    using OnlineShop.Service.Infrastructure;
    using OnlineShop.Service.Models.BindingModels;
    using OnlineShop.Service.Models.ViewModels;

    public class AdsController : BaseController
    {
        public AdsController()
        {
        }

        public AdsController(IOnlineShopData data, IUserIdProvider userIdProvider)
            : base(data, userIdProvider)
        {
            this.Data = data;
        }

        [HttpGet]
        public IHttpActionResult GetAds()
        {
            var ads = this.Data.Ads.All()
                .Where(a => a.Status == AdStatus.Open)
                .OrderByDescending(a => a.Type.Index)
                .ThenBy(a => a.PostedOn)
                .Select(AdViewModel.Create);

            return this.Ok(ads);
        }

        [HttpPost]
        [Authorize]
        public IHttpActionResult CreateAd(AdBindingModel adBindingModel)
        {
            if (adBindingModel == null)
            {
                return this.BadRequest("Your data is missing");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (!adBindingModel.Categories.Any() || adBindingModel.Categories.Count() > 3)
            {
                return this.BadRequest("Categories count must be between 1 and 3");
            }

            var ad = new Ad();
            ad.OwnerId = this.UserIdProvider.GetUserId();
            ad.Name = adBindingModel.Name;
            ad.Description = adBindingModel.Description;
            ad.Price = adBindingModel.Price;
            ad.PostedOn = DateTime.Now;

            var type = this.Data.AdTypes.All().FirstOrDefault(t => t.Id == adBindingModel.TypeId);
            if (type != null)
            {
                ad.Type = type;
            }

            ad.Categories = new List<Category>();
            foreach (var categoryId in adBindingModel.Categories)
            {
                var category = this.Data.Categories.All().FirstOrDefault(c => c.Id == categoryId);
                if (category != null)
                {
                    ad.Categories.Add(category);
                }
            }

            this.Data.Ads.Add(ad);
            this.Data.SaveChanges();

            var adViewModel = this.Data.Ads.All()
                .Where(a => a.Id == ad.Id)
                .Select(AdViewModel.Create)
                .FirstOrDefault();

            return this.Ok(adViewModel);
        }

        [HttpPut]
        [Route("api/ads/{id}/close")]
        [Authorize]
        public IHttpActionResult CloseAd(int id)
        {
            var ad = this.Data.Ads.All().FirstOrDefault(a => a.Id == id);
            if (ad == null)
            {
                return this.NotFound();
            }

            if (ad.OwnerId != this.UserIdProvider.GetUserId())
            {
                return this.BadRequest("You do not have permission to close ad number " + id);
            }

            ad.Status = AdStatus.Closed;
            ad.ClosedOn = DateTime.Now;

            this.Data.SaveChanges();

            return this.Ok();
        }
    }
}