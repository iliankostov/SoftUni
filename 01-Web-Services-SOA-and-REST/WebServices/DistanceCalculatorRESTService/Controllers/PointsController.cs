namespace DistanceCalculatorRESTService.Controllers
{
    using System;
    using System.Web.Http;

    public class PointsController : ApiController
    {
        public double Get(int startX, int startY, int endX, int endY)
        {
            return Math.Sqrt(Math.Pow(startX - endX, 2) + Math.Pow(startY - endY, 2));
        }
    }
}