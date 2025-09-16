#region [ Usings ]

using MediatR;
using MedicalIS.Application.DTOs;
using MedicalIS.Application.Queries.Diseases.GetAllDiseases;
using MedicalIS.Application.Queries.Diseases.GetDiseaseById;
using Microsoft.AspNetCore.Mvc;

#endregion [ Usings ]

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
    }
}
