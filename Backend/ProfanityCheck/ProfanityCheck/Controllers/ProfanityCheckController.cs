using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProfanityCheck.ApplicationServices.Interfaces;

namespace ProfanityCheck.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfanityCheckController : ControllerBase
    {
        private readonly IProfanityService profanityService;

        public ProfanityCheckController(IProfanityService profanityService)
        {
            this.profanityService = profanityService;
        }

        [HttpPost]
        [Route("check")]
        public async Task<bool> CheckFileAsync()
        {
            using var reader = new StreamReader(Request.Body, Encoding.UTF8);
            string fileContent = await reader.ReadToEndAsync();
            bool result = profanityService.IsFileAllowed(fileContent.ToUpper());

            return result;
        }

        [HttpGet]
        public string Test()
        {
            return "This is an WebApi for profanity check";
        }
    }
}