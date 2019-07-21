using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Synonyms.AppLogic;
using Synonyms.AppLogic.MediatR.CreateSynonym;
using Synonyms.AppLogic.MediatR.GetSynonyms;
using Synonyms.Database.Models;

namespace Synonyms.Api.Controllers
{
    [ApiController]
    [Route("api/synonym")]
    public class SynonymsController : ControllerBase
    {
        private readonly IMediator mediator;

        public SynonymsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateSynonymCommand command)
        {
            await this.mediator.Send(command);
            return Ok();
        }
        
        [HttpGet]
        public Task<IReadOnlyList<SynonymsDto>> Get() 
            => this.mediator.Send(new GetSynonymsCommand());
    }
}