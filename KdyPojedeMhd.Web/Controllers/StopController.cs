using System;
using System.Threading.Tasks;
using GolemioApi;
using GolemioApi.PublicTransport;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NodaTime;

namespace KdyPojedeMhd.Web.Controllers
{
    public class StopController : Controller
    {
        private readonly ILogger<StopController> logger;
        private readonly GolemioConfiguration golemioConfiguration;

        public StopController(ILogger<StopController> logger, GolemioConfiguration golemioConfiguration)
        {
            this.logger = logger;
            this.golemioConfiguration = golemioConfiguration;
        }

        public IActionResult Index()
        {
            return new NotFoundResult();
        }

        public IActionResult ChoosePoint()
        {
            throw new NotImplementedException();
        }

        public async Task<IActionResult> Expected(string? id)
        {
            if (String.IsNullOrWhiteSpace(id))
            {
                return RedirectToActionPermanent("ChoosePoint");
            }

            // 1. get all expected stop times in +/- 2 hours (?)
            var now = DateTime.Now;
            var stopTimes = await PublicTransportOperations.GetStopTimes(golemioConfiguration, id, LocalDate.FromDateTime(now), new LocalTime(Math.Max(0, now.Hour - 2), 0), new LocalTime(Math.Min(23, now.Hour + 2), 59, 59), 50, 0, false);
            
            // 2. group by route

            // 3. for each route: find the nearest vehicle
            var vehiclePositions = await PublicTransportOperations.GetVehiclePositions(golemioConfiguration, 10, 0, true, null, id);

            return View((object) JsonConvert.SerializeObject(vehiclePositions));
        }
    }
}