using Microsoft.AspNetCore.Mvc;
using MRGGameTek.Models.Register;
using System.Text.Json;
using System.Threading.Tasks;

namespace MRGGameTek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterRepository<MrGreen> _mrGreenRepository;
        private readonly IRegisterRepository<RedBet> _redBetRepository;

        public RegisterController(IRegisterRepository<MrGreen> mrGreenRepository, IRegisterRepository<RedBet> redBetRepository)
        {
            _mrGreenRepository = mrGreenRepository;
            _redBetRepository = redBetRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromHeader] string tenantId)
        {
            if (string.IsNullOrEmpty(tenantId))
            {
                ModelState.AddModelError("tenantId", "Please provide your tenant ID in the tenantId header value");
                return BadRequest(ModelState);
            }

            //Can be moved to mediatr cqrs
            if (tenantId == "mrgreen")
            {
                return RegisterMrGreen(await JsonSerializer.DeserializeAsync<MrGreen>(Request.BodyReader.AsStream(true)));
            }
            else if (tenantId == "redbet")
            {
                return RegisterRedBet(await JsonSerializer.DeserializeAsync<RedBet>(Request.BodyReader.AsStream(true)));
            }
            else
            {
                return BadRequest();
            }
        }

        private IActionResult RegisterRedBet(RedBet registrar)
        {
            registrar.Validate(ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _redBetRepository.Register(registrar);
            return Ok();
        }

        private IActionResult RegisterMrGreen(MrGreen registrar)
        {
            registrar.Validate(ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _mrGreenRepository.Register(registrar);
            return Ok();
        }
    }
}
