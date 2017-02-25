namespace DistanceCalculatorRESTService.Controllers
{
    using System;
    using System.Web.Http;

    using DistanceCalculatorRESTService.Models.BindingModels;

    public class PointsController : ApiController
    {
        [Route("api/points/distance")]
        public IHttpActionResult Get([FromUri] BindingVectorModel vector)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest("Invalid vector points.");
            }

            double distance = Math.Sqrt(Math.Pow(vector.StartX - vector.EndX, 2) + Math.Pow(vector.StartY - vector.EndY, 2));
            return this.Ok(distance);
        }
    }
}