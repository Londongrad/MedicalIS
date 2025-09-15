#region [ Usings ]

using MediatR;
using MedicalIS.Application.Commands.Doctors.ChangeDoctorSpecialty;
using MedicalIS.Application.Commands.Doctors.CreateDoctor;
using MedicalIS.Application.Commands.Doctors.DeleteDoctor;
using MedicalIS.Application.Commands.Doctors.UpdateDoctorPhone;
using MedicalIS.Application.Commands.Patients.CreatePatient;
using MedicalIS.Application.Commands.Patients.DeletePatient;
using MedicalIS.Application.Commands.Patients.UpdatePatientPhone;
using MedicalIS.Application.DTOs;
using MedicalIS.Application.Queries.Doctors.GetAllDoctors;
using MedicalIS.Application.Queries.Doctors.GetDoctorById;
using MedicalIS.Application.Queries.Doctors.GetDoctorsBySpecialty;
using MedicalIS.Application.Queries.Patients.GetAllPatients;
using MedicalIS.Application.Queries.Patients.GetPatientById;
using Microsoft.AspNetCore.Mvc;

#endregion [ Usings ]

namespace MedicalIS.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientsController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<PatientDTO>>> GetAll(CancellationToken cancellationToken)
        {
            var patients = await _mediator.Send(new GetAllPatientsQuery(), cancellationToken);
            return Ok(patients);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<PatientDTO>> GetById(Guid id, CancellationToken cancellationToken)
        {
            var patient = await _mediator.Send(new GetPatientByIdQuery(id), cancellationToken);
            if (patient == null) return NotFound();
            return Ok(patient);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreatePatientCommand command, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(command, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpPut("{id:guid}/phone")]
        public async Task<IActionResult> UpdatePhone(Guid id, [FromBody] string newPhone, CancellationToken cancellationToken)
        {
            await _mediator.Send(new UpdatePatientPhoneCommand(id, newPhone), cancellationToken);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeletePatientCommand(id), cancellationToken);
            return NoContent();
        }
    }
}
