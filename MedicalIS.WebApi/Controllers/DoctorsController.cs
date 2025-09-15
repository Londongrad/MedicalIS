using MediatR;
using MedicalIS.Application.Commands.Doctors.ChangeDoctorSpecialty;
using MedicalIS.Application.Commands.Doctors.CreateDoctor;
using MedicalIS.Application.Commands.Doctors.DeleteDoctor;
using MedicalIS.Application.Commands.Doctors.UpdateDoctorPhone;
using MedicalIS.Application.DTOs.Doctor;
using MedicalIS.Application.Queries.Doctors.GetAllDoctors;
using MedicalIS.Application.Queries.Doctors.GetDoctorById;
using MedicalIS.Application.Queries.Doctors.GetDoctorsBySpecialty;
using Microsoft.AspNetCore.Mvc;

namespace MedicalIS.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorsController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<DoctorDTO>>> GetAll(CancellationToken cancellationToken)
        {
            var doctors = await _mediator.Send(new GetAllDoctorsQuery(), cancellationToken);
            return Ok(doctors);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<DoctorDTO>> GetById(Guid id, CancellationToken cancellationToken)
        {
            var doctor = await _mediator.Send(new GetDoctorByIdQuery(id), cancellationToken);
            if (doctor == null) return NotFound();
            return Ok(doctor);
        }

        [HttpGet("specialty/{specialty}")]
        public async Task<ActionResult<IReadOnlyList<DoctorDTO>>> GetBySpecialty(string specialty, CancellationToken cancellationToken)
        {
            var doctors = await _mediator.Send(new GetDoctorsBySpecialtyQuery(specialty), cancellationToken);
            return Ok(doctors);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateDoctorCommand command, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(command, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpPut("{id:guid}/phone")]
        public async Task<IActionResult> UpdatePhone(Guid id, [FromBody] string newPhone, CancellationToken cancellationToken)
        {
            await _mediator.Send(new UpdateDoctorPhoneCommand(id, newPhone), cancellationToken);
            return NoContent();
        }

        [HttpPut("{id:guid}/specialty")]
        public async Task<IActionResult> ChangeSpecialty(Guid id, [FromBody] string newSpecialty, CancellationToken cancellationToken)
        {
            await _mediator.Send(new ChangeDoctorSpecialtyCommand(id, newSpecialty), cancellationToken);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteDoctorCommand(id), cancellationToken);
            return NoContent();
        }
    }
}
