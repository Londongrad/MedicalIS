using MediatR;
using MedicalIS.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace MedicalIS.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiseasesController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<DiseaseDTO>>> GetAll(CancellationToken cancellationToken)
        {
            var diseases = await _mediator.Send(new GetAllDiseasesQuery(), cancellationToken);
            return Ok(diseases);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<DiseaseDTO>> GetById(Guid id, CancellationToken cancellationToken)
        {
            var disease = await _mediator.Send(new GetDiseaseByIdQuery(id), cancellationToken);
            if (disease == null) return NotFound();
            return Ok(disease);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateDiseaseCommand command, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(command, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteDiseaseCommand(id), cancellationToken);
            return NoContent();
        }
    }
}
