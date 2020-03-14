﻿using Code4Ro.CoViz19.Api.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;
using Code4Ro.CoViz19.Models;
using Code4Ro.CoViz19.Api.Swagger;
using Code4Ro.CoViz19.Api.Models;

namespace Code4Ro.CoViz19.Api.Controllers
{
    [ApiController]
    [Route("api/v1/data")]
    [Produces("application/json")]
    [SwaggerTag("Enpoint for provinding latest relevant data")]
    public class DataController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DataController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get latest data provided by Ministry of Health")]
        [SwaggerResponse(200, "Latest data", typeof(ParsedDataModel))]
        [SwaggerResponse(500, "Something went wrong when getting data", typeof(ErrorModel))]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        [SwaggerResponseExample(200, typeof(LatestDataExample))]
        public async Task<IActionResult> GetLatestData()
        {
            var data = await  _mediator.Send(new GetLatestData());
            return new OkObjectResult(data);
        }
    }
}