using System.Threading.Tasks;
using GolemioApi;
using GolemioApi.PublicTransport;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

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

        public async Task<IActionResult> Expected(string? id)
        {
            // 1. get all expected stop times in +/- 2 hours (?)
            // 2. group by route
            // 3. for each route: find the nearest vehicle
            var vehiclePositions = await PublicTransportOperations.GetVehiclePositions(golemioConfiguration, 10, 0, true, null, id);

            return View((object) JsonConvert.SerializeObject(vehiclePositions));
        }
    }
}