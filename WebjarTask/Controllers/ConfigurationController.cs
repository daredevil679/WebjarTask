using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebjarTask.Application.Product.Commands.AddAdditive;
using WebjarTask.Application.Settings.Commands.ChangeDollarPrice;

namespace WebjarTask.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("[controller]")]
    public class ConfigurationController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;
        public ConfigurationController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [Route("ChangeDollarPrice")]
        [HttpPost]
        public async Task<IActionResult> ChangeDollarPrice([FromForm] ChangeDollarPriceVM request)
        {
            var result = await _mediator.Send(request);
            return result.Match(
            result => Ok(_mapper.Map<bool>(result)),
            errors => Problem(errors));
        }
    }
}
