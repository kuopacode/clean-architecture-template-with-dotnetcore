using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.Api.Applications.Commands;
using Product.Api.Applications.Dtos;
using Product.Api.Applications.Queries;
using Product.Api.Applications.ViewModels;
using Swashbuckle.AspNetCore.Annotations;

namespace Product.Api.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IMediator mediator, ILogger<ProductController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost, Route("/backend/product/add")]
        [SwaggerOperation(Summary = "新增商品", Tags = new[] { "新增/編輯商品" })]
        [ProducesResponseType(typeof(bool), 200)]
        public async Task<IActionResult> Add([FromBody] AddProductCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(result);
        }

        [HttpGet, Route("/backend/product/get")]
        [SwaggerOperation(Summary = "新增商品", Tags = new[] { "新增/編輯商品" })]
        [ProducesResponseType(typeof(GetProductVo), 200)]
        public async Task<IActionResult> Get([FromQuery] GetProductQuery query, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }
    }
}
