using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Marketplace.Api
{
    [Route("/ad")]
    public class ClassifiedAdsCommandsApi : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Post(Contracts.ClassiefiedAds.V1.Create request)
        {
            return Ok();
        }
    }
}
