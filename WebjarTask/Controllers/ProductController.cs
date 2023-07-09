using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebjarTask.Application.Product.Commands.AddAdditive;
using WebjarTask.Application.Product.Commands.AddAdditiveToProduct;
using WebjarTask.Application.Product.Commands.AddFeature;
using WebjarTask.Application.Product.Commands.AddPriceForProduct;
using WebjarTask.Application.Product.Commands.AddProduct;
using WebjarTask.Application.Product.Common;
using WebjarTask.Application.Product.Queries.GetAdditivesByProductId;
using WebjarTask.Application.Product.Queries.GetFeaturesByPriceId;
using WebjarTask.Application.Product.Queries.GetProducts;

namespace WebjarTask.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("[controller]")]
    public class ProductController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;
        public ProductController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [Route("CreateNewAdditive")]
        [HttpPost]
        public async Task<IActionResult> AddAdditive([FromForm] AddAdditiveVM request)
        {
            var result = await _mediator.Send(request);
            return result.Match(
            result => Ok(_mapper.Map<bool>(result)),
            errors => Problem(errors));
        }
        [Route("AddAdditiveToProduct")]
        [HttpPost]
        public async Task<IActionResult> AddProductAdditive([FromForm] AddAdditiveToProductVM request)
        {
            var result = await _mediator.Send(request);
            return result.Match(
            result => Ok(_mapper.Map<bool>(result)),
            errors => Problem(errors));
        }
        [Route("CreateNewProduct")]
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromForm] AddProductVM request)
        {
            var result = await _mediator.Send(request);
            return result.Match(
            result => Ok(_mapper.Map<bool>(result)),
            errors => Problem(errors));
        }
        [Route("CreateNewFeature")]
        [HttpPost]
        public async Task<IActionResult> AddFeature([FromForm] AddFeatureVM request)
        {
            var result = await _mediator.Send(request);
            return result.Match(
            result => Ok(_mapper.Map<bool>(result)),
            errors => Problem(errors));
        }
        [Route("AddPriceToProduct")]
        [HttpPost]
        public async Task<IActionResult> AddPriceToProduct( AddPriceForProductVM request)
        {
            var result = await _mediator.Send(request);
            return result.Match(
            result => Ok(_mapper.Map<bool>(result)),
            errors => Problem(errors));
        }
        [Route("GetProducts")]
        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] GetProductsVM request)
        {
            var result = await _mediator.Send(request);
            return result.Match(
            result => Ok(_mapper.Map<List<Product_vm>>(result)),
            errors => Problem(errors));
        }
        [Route("GetFeaturesByPriceId")]
        [HttpGet]
        public async Task<IActionResult> GetFeaturesByPriceId([FromQuery] GetFeaturesByPriceIdVM request)
        {
            var result = await _mediator.Send(request);
            return result.Match(
            result => Ok(_mapper.Map<List<ProductFeatureVal_vm>>(result)),
            errors => Problem(errors));
        }
        [Route("GetAdditivesByProductId")]
        [HttpGet]
        public async Task<IActionResult> GetAdditivesByProductId([FromQuery] GetAdditivesByProductIdVM request)
        {
            var result = await _mediator.Send(request);
            return result.Match(
            result => Ok(_mapper.Map<List<ProductAdditive_vm>>(result)),
            errors => Problem(errors));
        }
    }
}
